using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace TaskManager.Desktop
{
    public class Lambda : MarkupExtension
    {
        private static ParseOptions parseOptions = new CSharpParseOptions(kind: SourceCodeKind.Script);

        public string Identifier { get; private set; }

        private List<Assembly> assemblies = new List<Assembly>();
        private List<string> namespaces = new List<string>();

        private MemoryStream scriptAssemblyStream = new MemoryStream();
        private Assembly scriptAssembly;
        private Type scriptType;
        private MethodInfo factory;

        public Lambda(string command)
        {
            // Generate a unique name
            Identifier = "Lambda_" + GetHashCode().ToString("X");

            // Parse the command
            SyntaxTree syntaxTree = SyntaxFactory.ParseSyntaxTree(command, parseOptions);

            // Setup the compiler
            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions
            (
                outputKind: OutputKind.DynamicallyLinkedLibrary,
                mainTypeName: null,
                scriptClassName: Identifier,
                usings: namespaces,
                optimizationLevel: OptimizationLevel.Debug,
                checkOverflow: false,
                allowUnsafe: true,
                platform: Platform.AnyCpu,
                warningLevel: 4,
                xmlReferenceResolver: null,
                sourceReferenceResolver: SourceFileResolver.Default,
                //metadataReferenceResolver: this.Options.ReferenceResolver,
                assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default
            );

            assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic && File.Exists(a.Location)));
            namespaces.AddRange(new [] { "System", "System.IO", "System.Text", "System.Collections.Generic", "System.Linq", "System.Reflection", "System.Threading", "System.Diagnostics" });

            CSharpCompilation compilation = CSharpCompilation.CreateScriptCompilation
            (
                assemblyName: Identifier,
                syntaxTree: syntaxTree,
                references: assemblies.Select(a => MetadataReference.CreateFromFile(a.Location)),
                options: compilationOptions,
                returnType: typeof(object),
                globalsType: typeof(MainWindow)
            );

            EmitResult emitResult = compilation.Emit(scriptAssemblyStream);

            scriptAssembly = Assembly.Load(scriptAssemblyStream.GetBuffer());
            scriptType = scriptAssembly.GetType(Identifier);
            factory = scriptType.GetMethods().ElementAt(1);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                return null;

            IProvideValueTarget service = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            if (service == null)
                return null;

            FrameworkElement frameworkElement = service.TargetObject as FrameworkElement;
            DependencyProperty dependencyProperty = service.TargetProperty as DependencyProperty;

            if (frameworkElement == null || dependencyProperty == null)
                return null;

            /*object dataContext = frameworkElement.DataContext;
            FrameworkElement dataContextElement = frameworkElement as FrameworkElement;

            while (dataContext == null && dataContextElement != null)
            {
                dataContext = dataContextElement.DataContext;
                dataContextElement = dataContextElement.Parent as FrameworkElement;
            }

            if (dataContext == null)
                return null;*/

            object parameter = new object[2] { MainWindow.Instance, null };
            Task<object> task = factory.Invoke(null, new object[1] { parameter }) as Task<object>;

            return task.Result;
        }
    }
}