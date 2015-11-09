using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaskManager.Common;

namespace TaskManager.Desktop
{
    public class DummyTask : Task
    {
        private static Tag osTag = new Tag("OS", TagColor.Cyan);
        private static Tag uiTag = new Tag("UI", TagColor.Red);
        private static Tag cppTag = new Tag("C++", TagColor.Green);

        public DummyTask()
        {
            Name = "My Operating System";
            Description = "A modern operating system build from scratch, with a simple object oriented framework.";

            Date = DateTime.Now;
            Tags.Add(osTag);
            Tags.Add(cppTag);

            // SubTask 1
            Task driverTask = new Task() { Name = "Develop new drivers" };
            driverTask.Tags.Add(cppTag);
            Children.Add(driverTask);

            // SubTask 2
            Task uiTask = new Task() { Name = "Design interface" };
            uiTask.Tags.Add(uiTag);
            Children.Add(uiTask);
        }
    }
}