using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using TaskManager.Common;
using TaskManager.Shared;

namespace TaskManager.Desktop
{
    public static class Program
    {
        public static ObjectDatabase<Task> Database { get; private set; }

        [STAThread]
        public static void Main(params string[] args)
        {
            string address = args[0];
            string username = args[1];
            string password = args[2];

            Database = new TaskBase(address, username, password);
            Database.Load();

            // Connect to local database
            //SQLiteConnection connection = new SQLiteConnection("Data Source=" + args[0]);
            /*MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Database=julien_taskmanager;Uid=julien_taskmanag;Pwd=taskmanager");
            connection.Open();

            // Setup tasks database
            Database = new TaskDatabase(connection);*/

            // Run application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RawMainForm());
        }
    }
}