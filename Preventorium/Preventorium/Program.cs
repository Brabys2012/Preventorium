using System;
using System.Windows.Forms;

namespace Preventorium
{
    static class Program
    {
        static public db_connect data_module;
        static public user_settings user_set;
        static public get_table add_read_module;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            data_module = new db_connect();
            user_set = new user_settings();
            add_read_module = new get_table();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
