using System;
using System.IO;
using System.Windows.Forms;

namespace Preventorium
{

    /// <summary>
    /// Класс, предназначенный для считывания и записи пользовательских настроек.
    /// </summary>
    class user_settings
    {

        /// <summary>
        /// Имя конфигурационного файла с пользовательскими настройками.
        /// </summary>
        private static string _FileName = Application.StartupPath + "\\settings.vrconf";

        /// <summary>
        /// Имя сервера.
        /// </summary>
        public string _server;
        /// <summary>
        /// Имя базы данных.
        /// </summary>
        public string _schema;
        /// <summary>
        /// Признак необходимости Windows аутентификации.
        /// </summary>
        public bool _win_auth;
        /// <summary>
        /// Логин для доступа к базе данных.
        /// </summary>
        public string _login;
        /// <summary>
        /// Пароль для доступа к базе данных.
        /// </summary>
        public string _password;

        /// <summary>
        /// В эту переменную записывается сообщение о отсутствии конфигурационнго файла
        /// </summary>
        public string NOT_FILE;


        /// <summary>
        /// Инициализирует класс пользовательских настроек.
        /// </summary>
        public user_settings()
        {
            // Если файл настроек существует
            if (File.Exists(_FileName))
            {
                // Определяем необходимые переменные
                String param_name = "";
                String param_value = "";
                // Анализируем все строки в файле настроек
                foreach (string _tStr in File.ReadAllLines(_FileName))
                    try
                    {
                        // Если это комментарий или пустая строка, то переходим к другой строке
                        if ((_tStr.Length == 0) | _tStr.Trim().StartsWith("#"))
                            continue;
                        // Определяем имя параметра и его значение
                        param_name = _tStr.Substring(0, _tStr.IndexOf(" ")).Trim();
                        param_value = _tStr.Substring(_tStr.IndexOf(" ")).Trim();
                        // Задаем значения
                        switch (param_name)
                        {
                            case "db_server":
                                this._server = param_value;
                                break;
                            case "db_schema":
                                this._schema = param_value;
                                break;
                            case "db_win_auth":
                                this._win_auth = Boolean.Parse(param_value);
                                break;
                            case "db_user":
                                this._login = param_value;
                                break;
                            case "db_pass":
                                this._password = param_value;
                                break;
                        }
                    }
                    catch (Exception) { }
            }
            // В случае отсутствия конфигурационного файла настроек
            else
            {
                // Загружаем настройки по-умолчанию
                SetDefaultSettings();
                // Сообщаем об этом пользователю
                 NOT_FILE = Convert.ToString(MessageBox.Show("Файл настроек не найден. Необходима первичная настройка программы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                
            }
            this.SetDBSettings(this._server, this._schema, this._win_auth, this._login, this._password);
        }
        /// <summary>
        /// Задает настройки по-умолчанию, в случае отсутствия конфигурационного файла.
        /// </summary>
        public void SetDefaultSettings()
        {
            this._server = "localhost";
            this._schema = "Preventorium";
            this._win_auth = true;
            this._login = "";
            this._password = "";

        }


        /// <summary>
        /// Устанавливает настройки, определенные пользователем.
        /// </summary>
        /// <param name="server">Имя сервера.</param>
        /// <param name="schema">Имя базы данных.</param>
        /// <param name="win_auth">Признак необходимости аутентификации Windows.</param>
        /// <param name="user">Имя пользователя для подключения к базе данных.</param>
        /// <param name="pass">Пароль для подключения к базе данных.</param>
        /// <returns>Признак успешного завершения выполнения операции.</returns>
        public bool SetDBSettings(string server, string schema, bool win_auth, string user, string pass)
        {
            // Формируем строку подключения
            string final_conn_string = "";
            if (!(win_auth))
                final_conn_string += string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, schema, user, pass);
            else
                final_conn_string += string.Format("Integrated Security=true;Initial Catalog={0};Server={1}", schema, server);
            // Если строка не аерная, то выдаем сообщение
            if (!(Program.data_module.set_connection_settings(final_conn_string)))
            {
                MessageBox.Show("Параметры указаны неверно! Введите корректные значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Сохраняем настройки в user_set
            this._server = server;
            this._schema = schema;
            this._win_auth = win_auth;
            this._login = user;
            this._password = pass;
            return true;
        }
        /// <summary>
        /// Осуществляет сохранение пользовательских настроек в конфигурационный файл.
        /// </summary>
        public void SaveSettingsToFile()
        {
            String[] sets = {
                             "db_server " + this._server.ToString(),
                             "db_schema " + this._schema.ToString(),
                             "db_win_auth " + this._win_auth.ToString(),
                             "db_user " + this._login.ToString(),
                             "db_pass " + this._password.ToString()
                            };
            File.WriteAllLines(_FileName, sets);
        }

    }
}
