using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    [Module("Recipe", Prefix)]
    public class RecipeModule : Module
    {
        private const string Prefix = "Recipe.";

        public string Name
        {
            get
            {
                return ReadMetadata<string>(Prefix + nameof(Name));
            }
            set
            {
                WriteMetadata(Prefix + nameof(Name), value);
            }
        }
        public decimal Price
        {
            get
            {
                return ReadMetadata<decimal>(Prefix + nameof(Price));
            }
            set
            {
                WriteMetadata(Prefix + nameof(Price), value);
            }
        }
        public string Quantity
        {
            get
            {
                return ReadMetadata<string>(Prefix + nameof(Quantity));
            }
            set
            {
                WriteMetadata(Prefix + nameof(Quantity), value);
            }
        }

        internal RecipeModule(Task task) : base(task) { }
    }
}