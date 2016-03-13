using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TaskManager.Shared;

namespace TaskManager.Desktop
{
    public static class Program
    {
        public static TaskDatabase Database { get; private set; }

        [STAThread]
        public static void Main(params string[] args)
        {
            args = new string[] { @"..\..\..\Samples\Tasks.db" };

            // Connect to local database
            //SQLiteConnection connection = new SQLiteConnection("Data Source=" + args[0]);
            MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Database=julien_taskmanager;Uid=julien_taskmanag;Pwd=taskmanager");
            connection.Open();

            // Setup tasks database
            Database = new TaskDatabase(connection);

            // Run application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RawMainForm());
        }
    }
}