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
        private static Tag hwTag = new Tag("HW", TagColor.Blue);

        public DummyTask()
        {
            Name = "My Operating System";
            Description = "A modern operating system build from scratch, with a simple object oriented framework.";

            Date = DateTime.Now;
            Tags.Add(osTag);
            Tags.Add(cppTag);

            // Parents
            Task devTask = new Task() { Name = "Development" };
            Parents.Add(devTask);

            // SubTask 1
            Task driverTask = new Task() { Name = "Develop new drivers" };
            driverTask.Tags.Add(cppTag);
            driverTask.Tags.Add(hwTag);
            Children.Add(driverTask);

            // SubTask 1.1
            Task usbTask = new Task() { Name = "USB Driver" };
            usbTask.Tags.Add(cppTag);
            driverTask.Children.Add(usbTask);

            // SubTask 1.2
            Task d3dTask = new Task() { Name = "3D Driver" };
            d3dTask.Tags.Add(cppTag);
            driverTask.Children.Add(d3dTask);

            // SubTask 2
            Task uiTask = new Task() { Name = "Design interface" };
            uiTask.Tags.Add(uiTag);
            Children.Add(uiTask);
        }
    }
}