﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace Preventorium
{
    /// <summary>
    /// Содержит возможные состояния подключения к БД.
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        /// Подключен к БД.
        /// </summary>
        CONNECTED,
        /// <summary>
        /// Отключен от БД.
        /// </summary>
        DISCONNECTED,
        /// <summary>
        /// В процессе подключения к БД.
        /// </summary>
        PROCESS_CONNECTING,
        /// <summary>
        /// Ошибка подключения.
        /// </summary>
        CONNECT_ERROR,
       
    }

    /// <summary>
    /// Класс для работы с БД.
    /// </summary>
    public class db_connect
    {

        /// <summary>
        /// Возвращает результат выполнения последней операции с БД.
        /// </summary>
        public ConnectionStatus ConnStatus { private set; get; }

        
        
        public SqlConnection _conn;
        public string _connection_string;
        public DataSet _ds;
        public SqlDataAdapter _da;
        public SqlCommandBuilder _cb;
        public string _active_table;
        public string _command_text;
        public string text;

        public db_connect()
        {
            this._conn = new SqlConnection();
            this._ds = new System.Data.DataSet();
            this.ConnStatus = ConnectionStatus.DISCONNECTED;

                if (!(this.set_connection_settings("Integrated Security=true;Initial Catalog=1;Server=BABUR-PC")))
                MessageBox.Show("Неверная строка подключения!");
        }

        public bool set_connection_settings(string conn_string)
        {
         
                      
            this._connection_string = conn_string;
            try
            {               
                this._conn.ConnectionString = this._connection_string;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // ------------------------------------------------------------------
        public DataSet get_data_table_breakfast(string table_name, int data)
        {
            string query = "select FIM.ID_food, FIM.day_id, FIM.Serve_time_of_food, F.Name_food "
                           + "from Food_in_menu FIM "
                           + "join Foods F on F.ID_food = FIM.ID_food "
                           + "where FIM.Serve_time_of_food = 'завтрак' and FIM.day_id='" + data+ "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------
        public DataSet get_data_table_dinner(string table_name, int data)
        {
            string query = "select FIM.ID_food, FIM.day_id, FIM.Serve_time_of_food, F.Name_food "
                           + "from Food_in_menu FIM "
                           + "join Foods F on F.ID_food = FIM.ID_food "
                           + "where FIM.Serve_time_of_food = 'обед' and FIM.day_id='" + data + "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------
        public DataSet get_data_table_supper(string table_name,int data)
        {
            string query = "select FIM.ID_food, FIM.day_id, FIM.Serve_time_of_food, F.Name_food "
                           + "from Food_in_menu FIM "
                           + "join Foods F on F.ID_food = FIM.ID_food "
                           + "where FIM.Serve_time_of_food = 'ужин' and FIM.day_id='" + data + "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------
        public DataSet get_data_table_diet_in_food(string table_name)
        {
            string query = "Select F.Name_food, D.NumOfDiet, C.Number_Card, FID.ID_food, FID.ID_Diets, FID.Id_Cards "
                            + "From Food_In_Diets FID "
                            + "join Diets D on D.ID_Diets = FID.ID_Diets "
                            + "join Cards C on C.ID_food = FID.ID_food "
                            + "join Foods F on F.ID_food = FID.ID_food ";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------       


// ------------------------------------------------------------------
        public DataSet get_data_table2(string table_name, int food_id)
        {
            string query = "Select  F.Name_food, I.ingridient_name, IIF.Gross_weight, IIF.Net_weight, IIF.Id_ingridients, F.ID_food "
                            + "From Ingridients_in_food IIF join Ingridients I on "
                            + "IIF.Id_ingridients = I.Id_ingridients "
                            + "join Foods F on  F.ID_food = IIF.ID_food "
                            + "where F.ID_food = '" + food_id + "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------
        public DataSet get_menu(string table_name)
        {
            string query = "select M.ID_menu, M.ID_queue, Q.Number_queue, Q.Number_of_mens, Q.Starting_date, Q.Ending_date "
                         + "from Menu M "
                         + "join Queue Q on Q.ID_queue = M.ID_queue ";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

// ------------------------------------------------------------------  

        public DataSet get_menu_in_day(string table_name, string ID)
        {
            string query = "select * "
                         + "from Menu_in_day"
                         + " where ID_menu ='" + ID + "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }
//------------------------------------------------------
        public DataSet get_data_table(string table_name)
        {
            string query = "";
            query += "select";
            query += " *";
            query += " from ";
            query += table_name;
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// Получаем список блюд и номера карточек
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public DataSet get_food_in_book(string table_name, int book_id)
        {
            string query = "select FIB.Id_Cards, FIB.ID_food, FIB.IDBook, C.Number_Card, F.Name_food, B.Name "
                            + "from FoodInBook FIB "
                            + "join Cards C on C.Id_Cards = FIB.Id_Cards "
                            + "join Foods F on F.ID_Food = C.ID_Food "
                            + "join Book B on B.IDBook = FIB.IDBook "
                            + "where B.IDBook = '" + book_id + "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }


        // ------------------------------------------------------------------
        public DataSet get_data_table_cards(string table_name)
        {
            string query = "Select C.Id_Cards, F.Name_food, C.Cost, C.Method_of_cooking, C.Number_Card, C.ID_food "
                           + "From Cards C "
                           + "join Foods F on F.ID_food = C.ID_food";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------  



        /// <summary>
        /// Подключиться к базе данных.
        /// </summary>
        /// <returns>Результат выполнения операции</returns>
        public ConnectionStatus connect_to_db()
        {
            this.ConnStatus = ConnectionStatus.PROCESS_CONNECTING;
            try
            {
                // Инициализируем Пинг для проверки доступности сервера
                Ping ping = new Ping();
                // Пингуем сервер. Максимальное время ожидания ответа от сервера (500 мсек)
                PingReply pingReply = ping.Send(Program.user_set._server, 500);
                // Если пинг завершился неудачно, то сообщаем об этом пользователю и завершаем метод
                if (pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show("Не удалось проверить доступность сервера баз данных, проверьте корректность настроек подключения, или обратитесь к системному администратору сервера.", "Сервер БД недоступен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Устанавливаем статус и возвращаем результат
                    this.ConnStatus = ConnectionStatus.CONNECT_ERROR;
                    return ConnectionStatus.CONNECT_ERROR;
                }
                // Открываем соединение с БД

                this._conn.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Format("Не удалось подключиться к базе данных по причине {0}.", "\n\nПроверьте настройки подключения или обратитесь к системному администратору.", exc), "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Устанавливаем статус и возвращаем результат
                this.ConnStatus = ConnectionStatus.CONNECT_ERROR;
                return ConnectionStatus.CONNECT_ERROR;
            }
            // Устанавливаем статус и возвращаем результат
            this.ConnStatus = ConnectionStatus.CONNECTED;
            return ConnectionStatus.CONNECTED;
        }

        public string disconnect_db()
        {
            this.ConnStatus = ConnectionStatus.PROCESS_CONNECTING;
            try
            {
                this._conn.Close();
            }
            catch (Exception ex)
            {
                this.ConnStatus = ConnectionStatus.CONNECTED;
                return ex.Data + " " + ex.Message;
            }
            this.ConnStatus = ConnectionStatus.DISCONNECTED;
            return "OK";
        }
    }
}
