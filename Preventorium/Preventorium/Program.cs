using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace Preventorium
{
    static class Program
    {

        /// <summary>
        /// Выполняет действие над окном Windows.
        /// </summary>
        /// <param name="hWnd">Дескриптор окна.</param>
        /// <param name="nCmdShow">Команда, которую необходимо выполнить.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Команды, выполняемые с окном Windows.
        /// </summary>
        private enum WindowState
        {
            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
            /// </summary>
            SW_NORMAL = 1,
            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// Activates the window and displays it as a maximized window.
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
            /// <summary>
            /// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
            /// </summary>
            SW_SHOWNOACTIVATE = 4,
            /// <summary>
            /// Activates the window and displays it in its current size and position.
            /// </summary>
            SW_SHOW = 5,
            /// <summary>
            /// Minimizes the specified window and activates the next top-level window in the Z order.
            /// </summary>
            SW_MINIMIZE = 6,
            /// <summary>
            /// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,
            /// <summary>
            /// Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
            /// </summary>
            SW_SHOWNA = 8,
            /// <summary>
            /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
            /// </summary>
            SW_RESTORE = 9,
            /// <summary>
            /// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
            /// </summary>
            SW_MAX = 10,
            /// <summary>
            /// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
            /// </summary>
            SW_FORCEMINIMIZE = 11,
        }


        /// <summary>
        /// Клиент для работы с БД.
        /// </summary>
        static public db_connect data_module;
        /// <summary>
        /// Пользовательские настройки.
        /// </summary>
        static public user_settings user_set;
        /// <summary>
        /// 
        /// </summary>
        static public get_table add_read_module;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Определяем мьютекс
            bool createdNewMutex;
            Mutex M = new Mutex(true, Process.GetCurrentProcess().ProcessName, out createdNewMutex);
            // Если мьютекс уже определен, то активируем свернутое главное окно приложения
            if (!createdNewMutex)
            {
                // Получаем дескриптор окна
                IntPtr mainWindowHandle = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)[0].MainWindowHandle;
                // Восстанавливаем окно
                ShowWindowAsync(mainWindowHandle, (int)WindowState.SW_SHOWMINIMIZED);
                ShowWindowAsync(mainWindowHandle, (int)WindowState.SW_RESTORE);
                // Закрываем новую копию программы
                Environment.Exit(0);
            }
            // Инициируем пользовательские настройки и клиента БД
            data_module = new db_connect();
            user_set = new user_settings();
            add_read_module = new get_table();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMDI());
            GC.KeepAlive(M);
        }

    }
}
