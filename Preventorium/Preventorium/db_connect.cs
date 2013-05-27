using System;
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
       
        /// <summary>
        /// проверка на правильность строки подключения
        /// </summary>
        public db_connect()
        {
            this._conn = new SqlConnection();
            this._ds = new System.Data.DataSet();
            this.ConnStatus = ConnectionStatus.DISCONNECTED;

                if (!(this.set_connection_settings("Integrated Security=true;Initial Catalog=1;Server=BABUR-PC")))
                MessageBox.Show("Неверная строка подключения!");
        }
        /// <summary>
        /// возвращает признак удачного соедения к БД
        /// </summary>
        /// <param name="conn_string"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Выполняет SQL запрос, который  возвращает записи таблиц в результате этого запроса.
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet SQL_DataSet(string table_name,string query)
        {            
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
        /// возврашает записи о блюдах в меню подаваемые на завтрак на опреденное число
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet get_data_table_breakfast(string table_name, int data)
        {
            return SQL_DataSet(table_name,string.Format("select FIM.ID_food, FIM.day_id, FIM.Serve_time_of_food, F.Name_food, FIM.count_serve from Food_in_menu FIM join Foods F on F.ID_food = FIM.ID_food where FIM.Serve_time_of_food = 'завтрак' and FIM.day_id={0}",data));
        }
        /// <summary>
        /// возврашает записи о блюдах в меню подаваемые на обед на опреденное число
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet get_data_table_dinner(string table_name, int data)
        {
            return SQL_DataSet(table_name, string.Format("select FIM.ID_food, FIM.day_id, FIM.Serve_time_of_food, F.Name_food, FIM.count_serve from Food_in_menu FIM join Foods F on F.ID_food = FIM.ID_food where FIM.Serve_time_of_food = 'обед' and FIM.day_id={0}", data));
         }

       /// <summary>
        /// возврашает записи о блюдах в меню подаваемые на ужин на опреденное число
       /// </summary>
       /// <param name="table_name"></param>
       /// <param name="data"></param>
       /// <returns></returns>
        public DataSet get_data_table_supper(string table_name,int data)
        {
            return SQL_DataSet(table_name, string.Format("select FIM.ID_food, FIM.day_id, FIM.Serve_time_of_food, F.Name_food, FIM.count_serve from Food_in_menu FIM join Foods F on F.ID_food = FIM.ID_food where FIM.Serve_time_of_food = 'ужин' and FIM.day_id={0}", data));
        }

        /// <summary>
        /// возврашает записи о диетах в блюдах 
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public DataSet get_data_table_diet_in_food(string table_name)
        {
            return SQL_DataSet(table_name, string.Format("Select F.Name_food, D.NumOfDiet, C.Number_Card, FID.ID_food, FID.ID_Diets, FID.Id_Cards From Food_In_Diets FID join Diets D on D.ID_Diets = FID.ID_Diets join Cards C on C.ID_food = FID.ID_food join Foods F on F.ID_food = FID.ID_food"));
        }

        /// <summary>
        /// возвращает записи о ингредиентах в блюде
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="food_id"></param>
        /// <returns></returns>
               public DataSet get_data_table2(string table_name, int food_id)
          {
             return SQL_DataSet(table_name, string.Format("Select  F.Name_food, I.ingridient_name, IIF.Gross_weight, IIF.Net_weight, IIF.Id_ingridients, F.ID_food From Ingridients_in_food IIF join Ingridients I on IIF.Id_ingridients = I.Id_ingridients join Foods F on  F.ID_food = IIF.ID_food where F.ID_food ={0}",food_id));
          }

       /// <summary>
     /// возврашает записи о  меню для очереди
       /// </summary>
       /// <param name="table_name"></param>
       /// <returns></returns>
        public DataSet get_menu(string table_name)
        {
            return SQL_DataSet(table_name, string.Format("select M.ID_menu, M.ID_queue, Q.Number_queue, Q.Number_of_mens, Q.Starting_date, Q.Ending_date from Menu M join Queue Q on Q.ID_queue = M.ID_queue"));
        
        }
/// <summary>
 /// возвращает записи о меню  на день
/// </summary>
/// <param name="table_name"></param>
/// <param name="ID"></param>
/// <returns></returns>
        public DataSet get_menu_in_day(string table_name, string ID)
        {
            return SQL_DataSet(table_name, string.Format("select * from Menu_in_day where ID_menu ={0}",ID));       
        }
/// <summary>
/// возвращает логин пользователя не обладающего правами администратора
/// </summary>
/// <param name="table_name"></param>
/// <param name="prof"></param>
/// <returns></returns>
        public DataSet get_data_table_password(string table_name,string prof,string login)
        {            
            return SQL_DataSet(table_name, string.Format("select IDUsers,login, Password from {0}  where role='{1}' and Login='{2}'",table_name,prof,login));  
        }
        /// <summary>
        /// возвращает роль, логин ,пароль и т.д всех пользователей, доступные только пользователю  обладающему правами администратора
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public DataSet get_data_table_password_head_vrach(string table_name)
        {
            return SQL_DataSet(table_name, string.Format("select IDUsers, Post,login,Password,role from {0}", table_name));  
        }
        /// <summary>
        /// возвращает записи таблицы
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public DataSet get_data_table(string table_name)
        {
            return SQL_DataSet(table_name, string.Format("select * from {0}", table_name));          
        }
        
        /// <summary>
        /// Получаем список блюд и номера карточек в справочнике
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public DataSet get_food_in_book(string table_name, int book_id)
        {
            return SQL_DataSet(table_name, string.Format("select FIB.Id_Cards, FIB.ID_food, FIB.IDBook, C.Number_Card, F.Name_food, B.Name from FoodInBook FIB join Cards C on C.Id_Cards = FIB.Id_Cards join Foods F on F.ID_Food = C.ID_Food join Book B on B.IDBook = FIB.IDBook where B.IDBook = {0}",book_id)); 
        }
        /// <summary>
        /// возвращает записи таблицы Cards
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public DataSet get_data_table_cards(string table_name)
        {
            return SQL_DataSet(table_name, string.Format("Select C.Id_Cards, F.Name_food, C.Cost, C.Method_of_cooking, C.Number_Card, C.ID_food From Cards C join Foods F on F.ID_food = C.ID_food"));
        }                        
        
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
                MessageBox.Show(string.Format("Не удалось подключиться к базе данных!!!{0}.", "\n\nПроверьте настройки подключения или обратитесь к системному администратору.", exc), "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Устанавливаем статус и возвращаем результат
                this.ConnStatus = ConnectionStatus.CONNECT_ERROR;
                return ConnectionStatus.CONNECT_ERROR;
            }
            // Устанавливаем статус и возвращаем результат
            this.ConnStatus = ConnectionStatus.CONNECTED;
            return ConnectionStatus.CONNECTED;
        }
        /// <summary>
        /// отключение соеденения от БД
        /// </summary>
        /// <returns></returns>
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
