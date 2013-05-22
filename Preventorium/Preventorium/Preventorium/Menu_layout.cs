using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using word = Microsoft.Office.Interop.Word;

namespace Preventorium
{
    public partial class Menu_layout : Form
    {
        /// <summary>
        /// Содержит id дня
        /// </summary>
        private int AddDayID;
        /// <summary>
        /// Содержит id очереди
        /// </summary>
        private int queue_id;
        /// <summary>
        /// Содержит время падачи блюда:"Завтрак","Обед","Ужин","Весь день"
        /// </summary>
        private string serve;
        /// <summary>
        /// Содержит вес ингедиентов 1-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 2-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves2_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 3-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves3_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 4-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves4_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 5-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves5_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 6-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves6_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 7-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves7_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 8-го блюда на завтрак
        /// </summary>
        public class_ingr_in_food[] _ves8_breakfast;
        /// <summary>
        /// Содержит вес ингедиентов 1-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner;
        /// <summary>
        /// Содержит вес ингедиентов 2-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner2;
        /// <summary>
        /// Содержит вес ингедиентов 3-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner3;
        /// <summary>
        /// Содержит вес ингедиентов 4-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner4;
        /// <summary>
        /// Содержит вес ингедиентов 5-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner5;
        /// <summary>
        /// Содержит вес ингедиентов 6-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner6;
        /// <summary>
        /// Содержит вес ингедиентов 7-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner7;
        /// <summary>
        /// Содержит вес ингедиентов 8-го блюда на обед
        /// </summary>
        public class_ingr_in_food[] _ves_dinner8;
        /// <summary>
        /// Содержит вес ингедиентов 1-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper;
        /// <summary>
        /// Содержит вес ингедиентов 2-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper2;
        /// <summary>
        /// Содержит вес ингедиентов 3-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper3;
        /// <summary>
        /// Содержит вес ингедиентов 4-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper4;
        /// <summary>
        /// Содержит вес ингедиентов 5-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper5;
        /// <summary>
        /// Содержит вес ингедиентов 6-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper6;
        /// <summary>
        /// Содержит вес ингедиентов 7-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper7;
        /// <summary>
        /// Содержит вес ингедиентов 8-го блюда на ужин
        /// </summary>
        public class_ingr_in_food[] _ves_supper8;
        /// <summary>
        /// Содержит общий вес ингредиентов на завтрак
        /// </summary>
        public class_ingr_in_food[] _obshves_breakfast;
        /// <summary>
        /// Содержит общий вес ингредиентов на обед
        /// </summary>
        public class_ingr_in_food[] _obshves_dinner;
        /// <summary>
        /// Содержит общий вес ингредиентов на ужин
        /// </summary>
        public class_ingr_in_food[] _obshves_supper;
        /// <summary>
        /// Содержит общий вес ингредиентов за весь день
        /// </summary>
        public class_ingr_in_food[] _obshves_all_day;
        /// <summary>
        /// Содержит калораж блюда падаемых на завтрак
        /// </summary>
        public class_food[] _obshcal;
        /// <summary>
        /// Содержит калораж блюда падаемых на обед
        /// </summary>
        public class_food[] _obshcal_dinner;
        /// <summary>
        /// Содержит калораж блюда падаемых на ужин
        /// </summary>
        public class_food[] _obshcal_supper;
        /// <summary>
        /// Содержит ФИО кто утверждает меню-раскладку
        /// </summary>
        public class_person _namevrach;
        /// <summary>
        /// Содержит ФИО кто составляет меню-раскладку
        /// </summary>
        public class_person _namevrach2;
        /// <summary>
        /// Это поле список людей работающих  в данной предметной области
        /// </summary>
        public class_person[] _person;
        /// <summary>
        /// Путь к шаблону 
        /// </summary>
        private readonly string File3 = @"\Reports\Меню-раскладка_завтрак_22 ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File4 = @"\Reports\Меню-раскладка_завтрак_47 ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File5 = @"\Reports\Меню-раскладка_обед_22 ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File6 = @"\Reports\Меню-раскладка_обед_47 ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File7 = @"\Reports\Меню-раскладка_ужин_22 ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File8 = @"\Reports\Меню-раскладка_ужин_47 ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File9 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_22_ингр.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File10 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File11 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_обед.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File12 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_ужин.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File13 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак_обед.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File14 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак_ужин.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File15 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_обед_ужин.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File16 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак_обед_ужин.docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File17 = @"\Reports\Menu_layout\Меню-раскладка_ужин_22 ингр(1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File18 = @"\Reports\Menu_layout\Меню-раскладка_ужин_47 ингр(1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File19 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_22_ингр (1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File20 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак (1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File21 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак_обед (1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File22 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак_обед_ужин(1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File23 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_завтрак_ужин(1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File24 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_обед(1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File25 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_обед_ужин(1).docx";
        /// <summary>
        /// Путь к шаблону
        /// </summary>
        private readonly string File26 = @"\Reports\Menu_layout\Меню_раскладка_весь_день_47_ингр_ужин(1).docx";
        /// <summary>
        /// Содержит названия блюд,вес и калораж на завтрак
        /// </summary>
        public class_food[] _food;
        /// <summary>
        /// Содержит названия блюд,вес и калораж на обед
        /// </summary>
        public class_food[] dinner_food;
        /// <summary>
        /// Содержит количество человек на которых составляется меню-раскладка
        /// </summary>
        public class_queue _count_serv;
        /// <summary>
        /// Содержит названия блюд,вес и калораж на ужин
        /// </summary>
        public class_food[] supper_food;
        /// <summary>
        /// Содержит дату создания меню-раскладки
        /// </summary>
        public class_food_in_menu[] _menu_in_day;
        /// <summary>
        /// Содержит наименование ингредиентов  для блюда на завтрак
        /// </summary>
        public class_ingridients[] _ingr_list_breakfast;
        /// <summary>
        /// Содержит наименование ингредиентов  для блюда на обед
        /// </summary>
        public class_ingridients[] _ingr_list_dinner;
        /// <summary>
        /// Содержит наименование ингредиентов  для блюда на ужин
        /// </summary>
        public class_ingridients[] _ingr_list_supper;
        /// <summary>
        /// Содержит наименование ингредиентов на весь день
        /// </summary>
        public class_ingridients[] _ingr_list_all_day;
      
       /// <summary>
       /// Конструктор в который записыввается id дня , id очереди и время подачи блюда: завтрак,обед или ужин
       /// </summary>
       /// <param name="serves"></param>
       /// <param name="day"></param>
       /// <param name="queue"></param>
        public Menu_layout(string serves,int day, int queue)
        {
            serve = serves;
            AddDayID = day;
            queue_id = queue;
            InitializeComponent();
            this.Text = "Расчет меню-раскладки на "+ serves;
            pb.Visible = false;
            label1.Visible = false;
            this.Size = new Size(290,162);
        }

        /// <summary>
        /// Возвращает ФИО утверждающего меню-раскладку
        /// </summary>
        public class_person get_person_name_vrach1()
          {
              class_person person = new class_person();
              string query = "select *  from Users where Post='" + cb_ok.Text + "'";
              string query2 = query;
              try
              {
                  SqlCommand com = Program.data_module._conn.CreateCommand();
                  com.CommandText = query2;                  
                  SqlDataReader rd = com.ExecuteReader();
                  while (rd.Read())
                  {

                      person = new class_person();
                      person.result = "OK";
                      person.surname = rd.GetString(4).ToString();
                      person.name = rd.GetString(5).ToString();
                      person.secondname = rd.GetString(6).ToString();

                  }
                  rd.Close();
                  rd.Dispose();
                  com.Dispose();
              }

              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message + " " + ex.Data);
                  return null;
              }


              return person;
             }
        /// <summary>
        /// Возвращает ФИО составляющего меню-раскладку
        /// </summary>
        public class_person get_person_name_vrach2()
          {
              class_person person = new class_person();
              string query = "select *  from Users where Post='" + cb_diets_vrach.Text + "'";
              string query2 = query;
              try
              {
                  SqlCommand com = Program.data_module._conn.CreateCommand();
                  com.CommandText = query2;                 
                  SqlDataReader rd = com.ExecuteReader();
                  while (rd.Read())
                  {   person = new class_person();
                      person.result = "OK";
                      person.surname = rd.GetString(4).ToString();
                      person.name = rd.GetString(5).ToString();
                      person.secondname = rd.GetString(6).ToString();
                  }
                  rd.Close();
                  rd.Dispose();
                  com.Dispose();
              }

              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message + " " + ex.Data);
                  return null;
              }


              return person;

          }
        /// <summary>
        /// Заполняет комбобокс списком рабочих в профилактории
        /// </summary>
        private void fill_person_list()
        {
            if (this._person != null)
            {
                this.cb_ok.Items.Clear();
                this.cb_diets_vrach.Items.Clear();             
                
            }
            for (int i = 1; i < this._person.Count(); i++)
            {
                if (this._person[i] != null)
                {

                    this.cb_ok.Items.Add(this._person[i].post);
                    this.cb_diets_vrach.Items.Add(this._person[i].post);
                  
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Метод содержит sql запрос,который возвращает имена работающих в профике
        /// </summary>
        /// <returns>имена,фамилии и т.д</returns>
        public class_person[] get_person_list()
        {
            class_person[] person = new class_person[512];
            string query = "select *  from Users ";
             string query2 = query;
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query2;
                int i = 0;
                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    person[i] = new class_person();
                    person[i].result = "OK";                    
                    person[i].post = rd.GetString(7).ToString();
                    person[i].post_id = rd.GetInt32(0).ToString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }

            return person;

        }
        /// <summary>
        /// Событие возникающие при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_layout_Load(object sender, EventArgs e)
        {
            _food = get_food_breakfast(AddDayID);
             dinner_food=get_food_dinner(AddDayID);
             supper_food = get_food_supper(AddDayID);
            _ingr_list_breakfast = get_ingr_list(AddDayID);
            _ingr_list_dinner = get_ingr_list_dinner(AddDayID);
            _ingr_list_supper = get_ingr_list_supper(AddDayID);
            _ingr_list_all_day = get_ingr_all_day(AddDayID);
            _ves_breakfast = get_ves_breakfast();
            _ves2_breakfast = get_ves_breakfast2();
            _ves3_breakfast = get_ves_breakfast3();
            _ves4_breakfast = get_ves_breakfast4();
            _ves5_breakfast = get_ves_breakfast5();
            _ves6_breakfast = get_ves_breakfast6();
            _ves7_breakfast = get_ves_breakfast7();
            _ves8_breakfast = get_ves_breakfast8();
            _ves_dinner = get_ves_dinner();
            _ves_dinner2 = get_ves_dinner2();
            _ves_dinner3 = get_ves_dinner3();
            _ves_dinner4 = get_ves_dinner4();
            _ves_dinner5 = get_ves_dinner5();
            _ves_dinner6 = get_ves_dinner6();
            _ves_dinner7 = get_ves_dinner7();
            _ves_dinner8 = get_ves_dinner8();
            _ves_supper = get_ves_supper();
            _ves_supper2 = get_ves_supper2();
            _ves_supper3 = get_ves_supper3();
            _ves_supper4 = get_ves_supper4();
            _ves_supper5 = get_ves_supper5();
            _ves_supper6 = get_ves_supper6();
            _ves_supper7 = get_ves_supper7();
            _ves_supper8 = get_ves_supper8();
            _obshcal=get_cal_breakfast(AddDayID);
            _obshcal_dinner = get_cal_dinner(AddDayID);
            _obshcal_supper = get_cal_supper(AddDayID);
            _obshves_breakfast = get_sum_breakfast(AddDayID);
            _obshves_dinner = get_sum_dinner(AddDayID);
            _obshves_supper = get_sum_supper(AddDayID);            
            _obshves_all_day = get_sum_all_day(AddDayID);
            _menu_in_day = this.menu_in_day();
            _count_serv = this.get_count_serv(queue_id);
            this._person = this.get_person_list();
            fill_person_list();
        }

        #region
        /// <summary>
        /// Возвращает дату создания меню-раскладки
        /// </summary>
        public class_food_in_menu[] menu_in_day()
        {
            class_food_in_menu[] menu_in_day = new class_food_in_menu[512];

            string query = "select *  from Menu_in_day  where day_id ='" + AddDayID + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    menu_in_day[i] = new class_food_in_menu();
                    menu_in_day[i].result = "OK";
                    menu_in_day[i].serve_time = rd.GetDateTime(1).ToShortDateString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return menu_in_day;


        }
        /// <summary>
        /// Возвращает названия блюд,вес и калораж на завтрак
        /// </summary>
        public class_food[] get_food_breakfast(int date)
        {
            class_food[] food = new class_food[512];

            string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food,F.Full_calories from Food_in_menu FIM" +
                     " join Foods F on F.ID_food = FIM.ID_food " +
                 " where FIM.Serve_time_of_food = 'завтрак'  and day_id='" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;
                 SqlDataReader rd = com.ExecuteReader();
                   while (rd.Read())
                {
                    i = i + 1;
                    food[i] = new class_food();
                    food[i].result = "OK";
                    food[i].food_id = rd.GetInt32(0).ToString();
                    food[i].name = rd.GetString(2);
                         if (rd.IsDBNull(1))
                    { food[i].count_portc = ""; }
                    else
                        food[i].count_portc = rd.GetInt32(1).ToString();

                    if (rd.IsDBNull(2))
                    { food[i].weight = ""; }
                    else
                        food[i].weight = rd.GetDouble(3).ToString();
                    if (rd.IsDBNull(4))
                    { food[i].calories = ""; }
                    else

                    food[i].calories = rd.GetDouble(4).ToString();
                }
                                 
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return food;
        }
        /// <summary>
        /// Возвращает названия блюд,вес и калораж на обед
        /// </summary>
        public class_food[] get_food_dinner(int date)
        {
            class_food[] food = new class_food[512];

            string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food,F.Full_calories from Food_in_menu FIM" +
                     " join Foods F on F.ID_food = FIM.ID_food " +
                 " where FIM.Serve_time_of_food ='обед'" + "  and day_id='" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    food[i] = new class_food();
                    food[i].result = "OK";
                    food[i].food_id = rd.GetInt32(0).ToString();
                    food[i].name = rd.GetString(2);
                    if (rd.IsDBNull(1))
                    { food[i].count_portc = ""; }
                    else
                        food[i].count_portc = rd.GetInt32(1).ToString();

                    if (rd.IsDBNull(2))
                    { food[i].weight = ""; }
                    else
                        food[i].weight = rd.GetDouble(3).ToString();

                    food[i].calories = rd.GetDouble(4).ToString();
                    }
                

                
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return food;
        }
        /// <summary>
        /// Возвращает названия блюд,вес и калораж на ужин
        /// </summary>
        public class_food[] get_food_supper(int date)
        {

            class_food[] food = new class_food[512];

            string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food,F.Full_calories from Food_in_menu FIM" +
                     " join Foods F on F.ID_food = FIM.ID_food " +
                 " where FIM.Serve_time_of_food ='ужин'" + "  and day_id='" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    food[i] = new class_food();
                    food[i].result = "OK";
                    food[i].food_id = rd.GetInt32(0).ToString();
                    food[i].name = rd.GetString(2);
                    if (rd.IsDBNull(1))
                    { food[i].count_portc = ""; }
                    else
                        food[i].count_portc = rd.GetInt32(1).ToString();

                    if (rd.IsDBNull(2))
                    { food[i].weight = ""; }
                    else
                        food[i].weight = rd.GetDouble(3).ToString();
                    food[i].calories = rd.GetDouble(4).ToString();
                }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return food;
        }
        /// <summary>
        /// Возвращает названия ингредиентов блюда на завтрак
        /// </summary>
        public class_ingridients[] get_ingr_list(int date)
        {

            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
             " join Foods F on F.ID_food = FIM.ID_food" +
             " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
             " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
             " where FIM.Serve_time_of_food = 'завтрак' and day_id = '" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    ingr_list[i] = new class_ingridients();
                    ingr_list[i].result = "OK";
                    ingr_list[i].name = rd.GetString(1).ToString();
                    ingr_list[i].ingr_id = rd.GetInt32(0).ToString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }

            return ingr_list;
        }
        /// <summary>
        /// Возвращает названия ингредиентов блюда на обед
        /// </summary>
        public class_ingridients[] get_ingr_list_dinner(int date)
        {

            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
             " join Foods F on F.ID_food = FIM.ID_food" +
             " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
             " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
             " where FIM.Serve_time_of_food ='обед'"+" and day_id = '" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    ingr_list[i] = new class_ingridients();
                    ingr_list[i].result = "OK";
                    ingr_list[i].name = rd.GetString(1).ToString();
                    ingr_list[i].ingr_id = rd.GetInt32(0).ToString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }

            return ingr_list;
        }
        /// <summary>
        /// Возвращает названия ингредиентов блюда на ужин
        /// </summary>
        public class_ingridients[] get_ingr_list_supper(int date)
        {

            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
             " join Foods F on F.ID_food = FIM.ID_food" +
             " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
             " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
             " where FIM.Serve_time_of_food ='ужин'" + " and day_id = '" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    ingr_list[i] = new class_ingridients();
                    ingr_list[i].result = "OK";
                    ingr_list[i].name = rd.GetString(1).ToString();
                    ingr_list[i].ingr_id = rd.GetInt32(0).ToString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }

            return ingr_list;
        }
        /// <summary>
        /// Возвращает названия ингредиентов использующиеся на весь день
        /// </summary>
        public class_ingridients[] get_ingr_all_day(int date)
        {

            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
             " join Foods F on F.ID_food = FIM.ID_food" +
             " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
             " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
             " where day_id = '" + date + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    ingr_list[i] = new class_ingridients();
                    ingr_list[i].result = "OK";
                    ingr_list[i].name = rd.GetString(1).ToString();
                    ingr_list[i].ingr_id = rd.GetInt32(0).ToString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }

            return ingr_list;
        }
        /// <summary>
        /// Возвращает вес 1-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[1] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '"+ AddDayID+"'";


                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'" + "and IIF.ID_food='" + _food[1].food_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    if (rd.IsDBNull(0))
                                    {
                                        food[i].net = "";
                                    }
                                    else
                                    {
                                        food[i].net = rd.GetDouble(0).ToString();
                                    }
                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";
                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }
                        }

                    }

                }

            }

            return food;
        }

        /// <summary>
        /// Возвращает калории для блюда на ужин
        /// </summary>
        public class_food[] get_cal_supper(int day)
        {
            class_food[] foods = new class_food[512];

            string query = "select Sum(Full_calories) From  Foods join Food_in_menu on Foods.ID_food=Food_in_menu.ID_food where Food_in_menu.Serve_time_of_food='ужин' and Food_in_menu.day_id='" + day + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {
                        foods[i].count_cal_food = "";
                    }
                    else
                    {
                        foods[i].count_cal_food = rd.GetDouble(0).ToString();
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return foods;
        }
        /// <summary>
        /// Возвращает общий вес ингредиентов на завтрак
        /// </summary>
        public class_ingr_in_food[] get_sum_breakfast(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];
            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'" + "and Food_in_menu.Serve_time_of_food='завтрак'" + " group by Ingridients_in_food.Id_ingridients";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_ingr_in_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {

                        foods[i].net = "";

                    }
                    else
                    {
                        foods[i].net = rd.GetDouble(0).ToString();

                    }

                }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return foods;
        }
        /// <summary>
        /// Возвращает общий вес ингредиентов на обед
        /// </summary>
        public class_ingr_in_food[] get_sum_dinner(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];

            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'" + "and Food_in_menu.Serve_time_of_food='обед'" + " group by Ingridients_in_food.Id_ingridients";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_ingr_in_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {

                        foods[i].net = "";

                    }
                    else
                    {
                        foods[i].net = rd.GetDouble(0).ToString();

                    }

                }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return foods;
        }
        /// <summary>
        /// Возвращает общий вес ингредиентов на ужин
        /// </summary>
        public class_ingr_in_food[] get_sum_supper(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];

            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'" + "and Food_in_menu.Serve_time_of_food='ужин'" + " group by Ingridients_in_food.Id_ingridients";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_ingr_in_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {

                        foods[i].net = "";

                    }
                    else
                    {
                        foods[i].net = rd.GetDouble(0).ToString();

                    }

                }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return foods;
        }
        /// <summary>
        /// Возвращает общий вес ингередиентов на весь день
        /// </summary>
        public class_ingr_in_food[] get_sum_all_day(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];
            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'" + " group by Ingridients_in_food.Id_ingridients";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_ingr_in_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {

                        foods[i].net = "";

                    }
                    else
                    {
                        foods[i].net = rd.GetDouble(0).ToString();
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return foods;
        }
        /// <summary>
        /// Возвращает калории для блюда на завтрак
        /// </summary>
        public class_food[] get_cal_breakfast(int day)
        {
            class_food[] foods = new class_food[512];
            
            string query = "select Sum(Full_calories) From  Foods join Food_in_menu on Foods.ID_food=Food_in_menu.ID_food where Food_in_menu.Serve_time_of_food='завтрак' and Food_in_menu.day_id='"+ day+"'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {
                        foods[i].count_cal_food = "";
                    }
                    else
                    {
                        foods[i].count_cal_food = rd.GetDouble(0).ToString();
                    }
                }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }
            return foods;
        }
        /// <summary>
        /// Возвращает калории для блюда на обед
        /// </summary>
        public class_food[] get_cal_dinner(int day)
        {
            class_food[] foods = new class_food[512];

            string query = "select Sum(Full_calories) From  Foods join Food_in_menu on Foods.ID_food=Food_in_menu.ID_food where Food_in_menu.Serve_time_of_food='обед' and Food_in_menu.day_id='" + day + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    foods[i] = new class_food();
                    foods[i].result = "OK";
                    if (rd.IsDBNull(0))
                    {

                        foods[i].count_cal_food = "";

                    }
                    else
                    {
                        foods[i].count_cal_food = rd.GetDouble(0).ToString();

                    }

                }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }


            return foods;
        }
        /// <summary>
        /// Возвращает вес 2-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+ AddDayID+"'" + " and IIF.ID_food='" + _food[2].food_id + "'"; 


                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }

                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }


                        }

                    }
                }

            }

            return food;
        }
        /// <summary>
        /// Возвращает вес3-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast3()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[3] != null)
            {

                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID +"'"+"and IIF.ID_food='" + _food[3].food_id + "'"; 



                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();
                                  }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }

                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }


                    }
                }
            }
            return food;
        }
        /// <summary>
        /// Возвращает вес 4-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast4()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[4] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+ AddDayID+"'"+" and IIF.ID_food='" + _food[4].food_id + "'"; ;



                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }


                        }

                    }
                }
            }


            return food;
        }
        /// <summary>
        /// Возвращает вес 5-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast5()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[5] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+"'"+" and IIF.ID_food='" + _food[5].food_id + "'"; ;

                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }

                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }
                                 
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }



                        }


                    }
                }
            }


            return food;
        }
        /// <summary>
        /// Возвращает вес 6-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast6()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[6] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+"'"+" and IIF.ID_food='" + _food[6].food_id + "'"; ;



                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }

                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 7-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast7()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[7] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+"'"+" and IIF.ID_food='" + _food[7].food_id + "'"; ;



                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }

                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }
            return food;
        }
        /// <summary>
        /// Возвращает вес 8-го ингредиента на завтрак
        /// </summary>
        public class_ingr_in_food[] get_ves_breakfast8()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[8] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+"'"+" and IIF.ID_food='" + _food[8].food_id + "'"; ;



                if (_ingr_list_breakfast == null) { _ingr_list_breakfast = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_breakfast.Count(); i++)
                    {

                        if (_ingr_list_breakfast[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_breakfast[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }

                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 1-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[1] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID +"'"+" and IIF.ID_food='" + dinner_food[1].food_id + "'"; 



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }
                        
                               

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 2-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[2].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 3-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner3()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[3] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[3].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 4-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner4()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[4] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[4].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 5-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner5()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[5] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[5].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 6-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner6()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[6] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[6].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 7-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner7()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[7] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[7].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 8-го ингредиента на обед
        /// </summary>
        public class_ingr_in_food[] get_ves_dinner8()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[8] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='обед'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[8].food_id + "'";



                if (_ingr_list_dinner == null) { _ingr_list_dinner = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_dinner.Count(); i++)
                    {

                        if (_ingr_list_dinner[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_dinner[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 1-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[1] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[1].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 2-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[2].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 3-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper3()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[3] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[3].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 4-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper4()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[4] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[4].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 5-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper5()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[5] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[5].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 6-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper6()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[6] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[6].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 7-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper7()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[7] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[7].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает вес 8-го ингредиента на ужин
        /// </summary>
        public class_ingr_in_food[] get_ves_supper8()
        {  class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[8] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='ужин'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[8].food_id + "'";


                if (_ingr_list_supper == null) { _ingr_list_supper = null; }
                else
                {
                    for (int i = 1; i < _ingr_list_supper.Count(); i++)
                    {

                        if (_ingr_list_supper[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list_supper[i].ingr_id + "'";
                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query + g1;
                                SqlDataReader rd = com.ExecuteReader();

                                while (rd.Read())
                                {

                                    food[i] = new class_ingr_in_food();
                                    food[i].result = "OK";
                                    food[i].net = rd.GetDouble(0).ToString();

                                }
                                if (food[i] == null)
                                {
                                    food[i] = new class_ingr_in_food();
                                    food[i].net = "0";

                                    int g = Convert.ToInt32(food[i].net);
                                    g = 0;
                                }
                                rd.Close();
                                rd.Dispose();
                                com.Dispose();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " " + ex.Data);
                                return null;
                            }

                        }
                    }
                }
            }

            return food;
        }
        /// <summary>
        /// Возвращает общее число порций (рассчитанное на определенное количество человек)
        /// </summary>
        public class_queue get_count_serv(int id_queue)
        {
            class_queue queue = new class_queue();
            string query = "select Number_of_mens from Queue where ID_queue='" + id_queue + "'";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {

                    queue = new class_queue();
                    queue.result = "OK";
                    queue.numb_men = rd.GetInt32(0).ToString();

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }
            return queue;

        }
        /// <summary>
        /// Метод для поиска определенных символов в шаблоне и замена их на значения опрделенных переменных.
        /// </summary>
        private void word1(string stubToReplace, string text, word.Document word)
        {
            var range = word.Content;

            range.Find.ClearFormatting();

            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        #endregion

        /// <summary>
        /// Метод который строит отчет "Меню-раскладка на завтрак
        /// </summary>
        public void Report_MEnu_Layout_breakfast()
        {
            var App = new word.Application(Visible = false);

            if (_ingr_list_breakfast[22] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File4);

                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);                   
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);              
                }

                if (_namevrach2 == null)
                {
                    var name = "";
                    word1("[diet_vrach]", name, word);
                }

                if (this._namevrach2 != null)
                {   word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }
                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {   
                        var name = _food[i].name;
                        var name2 = _food[i].count_portc;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name3 ="Кал.:" + " "+ _food[i].calories;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                
                for (int i = 1; i <= 50; i++)
                {
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";

                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";
                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {
                        var name = _ingr_list_breakfast[i].name;
                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {   var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {   var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }
                    
                    if (_ves6_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {   var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {   var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;
                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {
                        var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }
                    }
                  
                }
                App.Visible = true;
                GC.Collect();
            }
            else
            {
                var word = App.Documents.Add(Application.StartupPath + File3);
                
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);                    
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);                  

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);                 
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {   var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name2 = _food[i].count_portc;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }

                for (int i = 1; i <= 50; i++)
                {
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";

                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {
                        var name = _ingr_list_breakfast[i].name;
                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {   var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                             word1("[i" + i + "]", nsme6.ToString(), word);
                         }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[z" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {   var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves6_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {    var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }
                    else
                    {     if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                             word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }
                    }
                    
                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;
                            word1("[date]", name2, word);
                        }
                    }

                    if (_count_serv == null)
                    {  var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }
                    }

                }
                App.Visible = true;
                GC.Collect();
            }
        }
        /// <summary>
        /// Метод который строит отчет "Меню-раскладка на завтрак"
        /// </summary>
        public void Report_Menu_dinner()
        {
            var App = new word.Application(Visible = false);
            
            if (_ingr_list_dinner[22] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File6);
                
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);               
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);       
                }

                if (_namevrach2 == null)
                {   var name = "";
                    word1("[diet_vrach]", name, word);            
                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);                
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (dinner_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);
                    
                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                        word1("[oka" + i + "]", name3, word);
                    }
                }
               
                 for (int i = 1; i <= 50; i++)
                {
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";
                        word1("[" + i + "]", name, word);
                    }
                    if (this._ingr_list_dinner[i] != null)
                    {  var name = _ingr_list_dinner[i].name;
                        word1("[" + i + "]", name, word);
                    }
                     
                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {      if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                         }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                           }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner3[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                            word1("[i" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }


                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }
                }

                App.Visible = true;
                GC.Collect();
            }
            else
            {
                var word = App.Documents.Add(Application.StartupPath + File5);                
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);                    
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);                  
                }

                if (_namevrach2 == null)
                {  var name = "";
                    word1("[diet_vrach]", name, word);       
                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);                    
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (dinner_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);
                    }

                    if (this.dinner_food[i] != null)
                    {   var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                        word1("[oka" + i + "]", name3, word);
                    }
                }               
                for (int i = 1; i <= 50; i++)
                {   pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;                  
                    label1.Text = "Прогресс расчета " + k + "%";

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {

                        var name = _ingr_list_dinner[i].name;


                        word1("[" + i + "]", name, word);
                    }


                    if (_ves_dinner[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                   if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {
                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {  var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {   var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }
                    }                    
                }
                App.Visible = true;
                GC.Collect();
            }
        }

        #region
        /// <summary>
        /// Метод который строит отчет "Меню-раскладка на ужин"
        /// </summary>
        public void Report_MEnu_Layout_supper()
        {
            var App = new word.Application(Visible = false);

            if (_ingr_list_supper[22] != null && _ingr_list_supper[51] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File18);
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);
                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (supper_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);
                    }

                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
                }
                for (int z = 1; z <= 100; z++)
                {
                    if (_ingr_list_all_day[z] != null)
                    {
                        var name5 = _ingr_list_all_day[z].name;
                        word1("[я" + z + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + z + "]", name5, word);
                    }


                    if (_obshves_all_day[z] != null)
                    {
                        var name5 = _obshves_all_day[z].net;
                        word1("[t" + z + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + z + "]", name5, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {
                        var name = _ingr_list_supper[i].name;

                        word1("[" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);
                        }

                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper8[i] == null)
                    {  var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }
                    }
                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {
                        var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {   if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);
                        }
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }
                App.Visible = true;
                GC.Collect();
            }

            if (_ingr_list_supper[22] != null && _obshves_all_day[51] == null)
            {
                var word = App.Documents.Add(Application.StartupPath + File8);

                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);
                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);
                    }

                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
                }
                for (int i =1;i<=50;i++)
                {    
                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {

                        var name = _ingr_list_supper[i].name;


                        word1("[" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {
                        var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }

                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5, word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }
                App.Visible = true;
                GC.Collect();
            }

            else
            {
                if (_ingr_list_supper[22] == null && _obshves_all_day[51] == null)
                {
                    var word = App.Documents.Add(Application.StartupPath + File7);
                    
                    if (_namevrach == null)
                    {    var name = "";
                         word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);

                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";

                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }



                    for (int i = 1; i <= 8; i++)
                    {
                        if (supper_food[i] == null)
                        {
                            var name = "";

                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);

                        }

                        if (this.supper_food[i] != null)
                        {

                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = "Кал.:" + " " + supper_food[i].calories;

                            word1("[Вес" + i + ":]", name1, word);

                            word1("[блюдо" + i + "]", name, word);

                            word1("[kol" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);

                        }
                    }


                    for (int i = 1; i <= 50; i++)
                    {

                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";

                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {

                            var name = _ingr_list_supper[i].name;


                            word1("[" + i + "]", name, word);
                        }


                        if (_ves_supper[i] == null)
                        {

                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {

                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {

                            var name6 = "";
                            word1("[z" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                                word1("[z" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[n" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[b" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[b" + i + "]", name5, word);
                        }

                        if (_ingr_list_all_day[i] != null)
                        {
                            var name5 = _ingr_list_all_day[i].name;
                            word1("[я" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + i + "]", name5, word);
                        }

                        if (_obshves_all_day[i] != null)
                        {
                            var name5 = _obshves_all_day[i].net;
                            word1("[t" + i + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + i + "]", name5, word);
                        }

                        if (_menu_in_day == null)
                        {
                            var name2 = "";
                            word1("[date]", name2, word);
                        }
                        else
                        {
                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;
                                word1("[date]", name2, word);
                            }
                        }

                        if (_count_serv == null)
                        {
                            var name2 = "";
                            word1("[kol]", name2, word);
                        }
                        else
                        {
                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;
                                word1("[kol]", name2, word);
                            }
                        }

                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }
                    App.Visible = true;
                    GC.Collect();
                }
            }

            if (_ingr_list_supper[22] == null && _obshves_all_day[51] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File17);
                
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }                

                for (int i = 1; i <= 8; i++)
                {
                    if (supper_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);

                    }

                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;

                        word1("[Вес" + i + ":]", name1, word);

                        word1("[блюдо" + i + "]", name, word);

                        word1("[kol" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);

                    }
                }

                for (int z = 1; z <= 100; z++)
                {
                    if (_ingr_list_all_day[z] != null)
                    {
                        var name5 = _ingr_list_all_day[z].name;
                        word1("[я" + z + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + z + "]", name5, word);
                    }

                    if (_obshves_all_day[z] != null)
                    {
                        var name5 = _obshves_all_day[z].net;
                        word1("[t" + z + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + z + "]", name5, word);
                    }
                }

                
                for (int i = 1; i <= 50; i++)
                {

                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {

                        var name = _ingr_list_supper[i].name;


                        word1("[" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[b" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[b" + i + "]", name5, word);
                    }

                    
                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;
                            word1("[date]", name2, word);
                        }
                    }

                    if (_count_serv == null)
                    {
                        var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }
                App.Visible = true;
                GC.Collect();
            }
        }
        #endregion        
        #region
        /// <summary>
        /// Метод который строит отчет "Меню-раскладка на весь-день
        /// </summary>
        public void Report_MEnu_Layout_all_day()
        {   // Если на завтрак больше 21,то грузится шаблон File10
            if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File10);

                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";
                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);
                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }
                                
                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";
                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {
                        var name = _ingr_list_breakfast[i].name;
                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {   var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves3_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[z" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves6_breakfast[i] == null)
                    {   var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }
                    if (_ves7_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }
                    if (dinner_food[i] == null)
                    {
                        var name = "";
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);

                    }
                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[ob" + i + "]", name2, word);
                        word1("[oka" + i + "]", name3, word);
                    }
                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";
                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {
                        var name = _ingr_list_dinner[i].name;
                        word1("[obed" + i + "]", name, word);
                    }

                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {
                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                            word1("[c" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {
                        var name6 = "";
                        word1("[d" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                            word1("[d" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }
                    
                    if (_ves_dinner6[i] == null)
                    {
                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {
                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {
                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                            word1("[h" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[и" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[и" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);

                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }

                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {
                        var name = _ingr_list_supper[i].name;
                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {
                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {
                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {
                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {
                        var name6 = "";
                        word1("[r" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                             word1("[r" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {
                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper6[i] == null)
                    {   var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {
                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {
                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[д" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[д" + i + "]", name5, word);
                    }

                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;
                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {
                        var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }
                    }
                   
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }
            else
            { // Если на завтрак больше 21 и общее количество ингредиентов больше 50,то грузим File20 шаблон
                if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File20);

                    if (_namevrach == null)
                    {   var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);
                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";
                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);
                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }
                                       
                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";
                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);
                        }

                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }

                    for (int z = 1; z <= 100; z++)
                    {
                        if (_ingr_list_all_day[z] != null)
                        {
                            var name5 = _ingr_list_all_day[z].name;
                            word1("[я" + z + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + z + "]", name5, word);
                        }

                        if (_obshves_all_day[z] != null)
                        {
                            var name5 = _obshves_all_day[z].net;
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + z + "]", name5.ToString(), word);
                        }

                    }
                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";
                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {
                            var name = _ingr_list_breakfast[i].name;
                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {   var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }
                        
                        if (_ves6_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                                word1("[n" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }
                        if (dinner_food[i] == null)
                        {
                            var name = "";
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);

                        }
                        if (this.dinner_food[i] != null)
                        {
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name3 = "Кал.:" + " " + dinner_food[i].calories;
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[ob" + i + "]", name2, word);
                            word1("[oka" + i + "]", name3, word);
                        }
                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";
                            word1("[obed" + i + "]", name, word);
                        }

                        if (this._ingr_list_dinner[i] != null)
                        {
                            var name = _ingr_list_dinner[i].name;
                            word1("[obed" + i + "]", name, word);
                        }

                        if (_ves_dinner[i] == null)
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner3[i] == null)
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                                word1("[c" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                                word1("[d" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner6[i] == null)
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                                word1("[h" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }
                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[и" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[и" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);

                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = "Кал.:" + " " + supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);
                        }
                        
                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";
                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {
                            var name = _ingr_list_supper[i].name;
                            word1("[sup" + i + "]", name, word);
                        }

                        if (_ves_supper[i] == null)
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                                word1("[r" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);
                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }
                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[д" + i + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[д" + i + "]", name5, word);
                        }

                        if (_menu_in_day == null)
                        {
                            var name2 = "";
                            word1("[date]", name2, word);
                        }
                        else
                        {
                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;
                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {
                            var name2 = "";
                            word1("[kol]", name2, word);
                        }
                        else
                        {
                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;
                                word1("[kol]", name2, word);
                            }

                        }
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }
                    App.Visible = true;
                    GC.Collect();
                }
            }

        #endregion
        #region
            // Если на обед больше 21 ингредиента и общее количество ингредиентов меньше 51,то грузим File11 файл
            if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File11);
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";
                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);
                }
                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }
                
                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";
                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {
                        var name = _ingr_list_breakfast[i].name;
                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[z" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }

                    if (_ves6_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }
                    }

                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);

                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name3 = "Кал.:" + dinner_food[i].calories;
                        word1("[ob" + i + "]", name2, word);
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oka" + i + "]", name3, word);
                    }

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";
                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {
                        var name = _ingr_list_dinner[i].name;
                        word1("[obed" + i + "]", name, word);
                    }

                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {
                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                            word1("[c" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {
                        var name6 = "";
                        word1("[d" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                            word1("[d" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {
                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner8[i] == null)
                    {
                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                            word1("[h" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[з" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[з" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);

                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }

                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {
                        var name = _ingr_list_supper[i].name;
                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {

                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {
                        var name6 = "";
                        word1("[r" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                            word1("[r" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[д" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[д" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {
                        var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }
            else
            {   // Если на обед больше 21 ингредиента и общее количество ингредиентов больше 50,то грузим File24 файл
                if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File24);
                    
                    if (_namevrach == null)
                    {
                        var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);

                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";
                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }

                    if (_obshcal[1] == null)
                    {
                        var name = "";
                        word1("[kav]", name, word);
                    }
                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";
                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);
                        }

                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + " " + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }

                    for (int z = 1; z <= 100; z++)
                    {
                        if (_ingr_list_all_day[z] != null)
                        {
                            var name5 = _ingr_list_all_day[z].name;
                            word1("[я" + z + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + z + "]", name5, word);
                        }

                        if (_obshves_all_day[z] != null)
                        {
                            var name5 = _obshves_all_day[z].net;
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                    }
                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";
                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {
                            var name = _ingr_list_breakfast[i].name;
                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }

                        if (_ves6_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                                word1("[n" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }
                        }

                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }


                        if (dinner_food[i] == null)
                        {
                            var name = "";
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);

                        }

                        if (this.dinner_food[i] != null)
                        {
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name3 = "Кал.:" + dinner_food[i].calories;
                            word1("[ob" + i + "]", name2, word);
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oka" + i + "]", name3, word);
                        }

                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";
                            word1("[obed" + i + "]", name, word);
                        }

                        if (this._ingr_list_dinner[i] != null)
                        {
                            var name = _ingr_list_dinner[i].name;
                            word1("[obed" + i + "]", name, word);
                        }


                        if (_ves_dinner[i] == null)
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner3[i] == null)
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                                word1("[c" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                                word1("[d" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {

                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }


                        if (_ves_dinner6[i] == null)
                        {

                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {

                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                                word1("[h" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[з" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[з" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";

                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);

                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = "Кал.:" + supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);
                        }

                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";
                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {
                            var name = _ingr_list_supper[i].name;
                            word1("[sup" + i + "]", name, word);
                        }
                        
                        if (_ves_supper[i] == null)
                        {

                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {

                            var name6 = "";
                            word1("[r" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                                word1("[r" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper6[i] == null)
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[д" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[д" + i + "]", name5, word);
                        }

                        if (_menu_in_day == null)
                        {
                            var name2 = "";
                            word1("[date]", name2, word);
                        }
                        else
                        {
                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;
                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {

                            var name2 = "";
                            word1("[kol]", name2, word);
                        }
                        else
                        {
                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;

                                word1("[kol]", name2, word);

                            }

                        }

                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }

                    App.Visible = true;
                    GC.Collect();

                }

            }
            #endregion
        #region
            // Если на обед ужин 21 ингредиента и общее количество ингредиентов не больше 50,то грузим File12 файл
            if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File12);
                   if (_namevrach == null)
                {   var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }

                  for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {

                        var name = _ingr_list_breakfast[i].name;

                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }

                    if (_ves6_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }
                    
                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";

                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);

                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        word1("[ob" + i + "]", name2, word);

                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oka" + i + "]", name3, word);

                    }

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";

                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {

                        var name = _ingr_list_dinner[i].name;


                        word1("[obed" + i + "]", name, word);
                    }


                    if (_ves_dinner[i] == null)
                    {

                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {

                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner3[i] == null)
                    {

                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                            word1("[c" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {

                        var name6 = "";
                        word1("[d" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                            word1("[d" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {
                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                            word1("[h" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }


                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[з" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[з" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);


                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
                              
                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";

                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {

                        var name = _ingr_list_supper[i].name;


                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {

                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[r" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                            word1("[r" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper6[i] == null)
                    {
                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }
                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[э" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[э" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {
                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {
                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {
                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);
                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }

            else
            {     // Если на  ужин больше 21 ингредиента и общее количество ингредиентов  больше 50,то грузим File26 файл
                if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File26);

                    if (_namevrach == null)
                    {
                        var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);

                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";

                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";

                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);

                        }

                        if (this._food[i] != null)
                        {

                            var name = _food[i].name;

                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + " " + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }
                    for (int Z = 1; Z <= 100; Z++)

                    {
                        if (_ingr_list_all_day[Z] != null)
                        {
                            var name5 = _ingr_list_all_day[Z].name;
                            word1("[я" + Z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + Z + "]", name5, word);
                        }

                        if (_obshves_all_day[Z] != null)
                        {
                            var name5 = _obshves_all_day[Z].net;
                            word1("[t" + Z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + Z + "]", name5.ToString(), word);
                        }
                    }
                        for (int i = 1; i <= 50; i++)
                        {
                            if (_ingr_list_breakfast[i] == null)
                            {
                                var name = "";

                                word1("[" + i + "]", name, word);
                            }

                            if (this._ingr_list_breakfast[i] != null)
                            {

                                var name = _ingr_list_breakfast[i].name;

                                word1("[" + i + "]", name, word);
                            }

                            if (_ves_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                            else
                            {

                                if (this._ves_breakfast[i] != null)
                                {
                                    var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                    word1("[v" + i + "]", nsme6.ToString(), word);
                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[v" + i + "]", name6, word);
                                }
                            }
                            if (_ves2_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }

                            else
                            {

                                if (this._ves2_breakfast[i] != null)
                                {
                                    var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                    word1("[k" + i + "]", nsme6.ToString(), word);
                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[k" + i + "]", name6, word);
                                }
                            }

                            if (_ves3_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves3_breakfast[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                    word1("[i" + i + "]", nsme6.ToString(), word);
                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[i" + i + "]", name6, word);
                                }
                            }
                            if (_ves4_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[z" + i + "]", name6, word);

                            }

                            else
                            {
                                if (this._ves4_breakfast[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                                    word1("[z" + i + "]", nsme6.ToString(), word);
                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[z" + i + "]", name6, word);
                                }
                            }
                            if (_ves5_breakfast[i] == null)
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves5_breakfast[i] != null)
                                {
                                    var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                    word1("[x" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[x" + i + "]", name6, word);
                                }
                            }


                            if (_ves6_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves6_breakfast[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                    word1("[y" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[y" + i + "]", name6, word);
                                }
                            }

                            if (_ves7_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves7_breakfast[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                    word1("[q" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[q" + i + "]", name6, word);
                                }
                            }

                            if (_ves8_breakfast[i] == null)
                            {

                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves8_breakfast[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                                    word1("[n" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[n" + i + "]", name6, word);
                                }

                            }


                            if (_obshves_breakfast[i] != null)
                            {
                                var name5 = _obshves_breakfast[i].net;
                                word1("[u" + i + "]", name5.ToString(), word);

                            }
                            else
                            {
                                var name5 = "";
                                word1("[u" + i + "]", name5, word);
                            }


                            if (dinner_food[i] == null)
                            {
                                var name = "";

                                word1("[oбедБлюдо" + i + "]", name, word);
                                word1("[oбедВес" + i + ":]", name, word);
                                word1("[ob" + i + "]", name, word);
                                word1("[oka" + i + "]", name, word);

                            }

                            if (this.dinner_food[i] != null)
                            {
                                var name = dinner_food[i].name;
                                var name2 = dinner_food[i].count_portc;
                                var name1 = "Вес:" + " " + dinner_food[i].weight;
                                var name3 = "Кал.:" + " " + dinner_food[i].calories;
                                word1("[ob" + i + "]", name2, word);

                                word1("[oбедВес" + i + ":]", name1, word);
                                word1("[oбедБлюдо" + i + "]", name, word);
                                word1("[oka" + i + "]", name3, word);

                            }

                            if (_ingr_list_dinner[i] == null)
                            {
                                var name = "";

                                word1("[obed" + i + "]", name, word);
                            }

                            if (this._ingr_list_dinner[i] != null)
                            {

                                var name = _ingr_list_dinner[i].name;


                                word1("[obed" + i + "]", name, word);
                            }


                            if (_ves_dinner[i] == null)
                            {

                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                            else
                            {

                                if (this._ves_dinner[i] != null)
                                {
                                    var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                    word1("[a" + i + "]", nsme6.ToString(), word);
                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[a" + i + "]", name6, word);
                                }
                            }
                            if (_ves_dinner2[i] == null)
                            {

                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }

                            else
                            {

                                if (this._ves_dinner2[i] != null)
                                {
                                    var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                    word1("[b" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[b" + i + "]", name6, word);
                                }
                            }

                            if (_ves_dinner3[i] == null)
                            {

                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves_dinner3[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                                    word1("[c" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[c" + i + "]", name6, word);
                                }
                            }
                            if (_ves_dinner4[i] == null)
                            {

                                var name6 = "";
                                word1("[d" + i + "]", name6, word);

                            }

                            else
                            {
                                if (this._ves_dinner4[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                                    word1("[d" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[d" + i + "]", name6, word);
                                }
                            }
                            if (_ves_dinner5[i] == null)
                            {

                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves_dinner5[i] != null)
                                {
                                    var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                    word1("[e" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[e" + i + "]", name6, word);
                                }
                            }


                            if (_ves_dinner6[i] == null)
                            {

                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves_dinner6[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                    word1("[f" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[f" + i + "]", name6, word);
                                }
                            }

                            if (_ves_dinner7[i] == null)
                            {

                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves_dinner7[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                    word1("[g" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[g" + i + "]", name6, word);
                                }
                            }

                            if (_ves_dinner8[i] == null)
                            {

                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                            else
                            {
                                if (this._ves_dinner8[i] != null)
                                {

                                    var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                    var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                                    word1("[h" + i + "]", nsme6.ToString(), word);

                                }
                                else
                                {
                                    var name6 = "";
                                    word1("[h" + i + "]", name6, word);
                                }

                            }


                            if (_obshves_dinner[i] != null)
                            {
                                var name5 = _obshves_dinner[i].net;
                                word1("[з" + i + "]", name5.ToString(), word);

                            }
                            else
                            {
                                var name5 = "";
                                word1("[з" + i + "]", name5, word);
                            }

                            if (supper_food[i] == null)
                            {
                                var name = "";

                                word1("[уБлюдо" + i + "]", name, word);
                                word1("[уВес" + i + ":]", name, word);
                                word1("[yz" + i + "]", name, word);
                                word1("[uka" + i + "]", name, word);


                            }
                            if (this.supper_food[i] != null)
                            {
                                var name = supper_food[i].name;
                                var name2 = supper_food[i].count_portc;
                                var name1 = "Вес:" + " " + supper_food[i].weight;
                                var name3 = "Кал.:" + " " + supper_food[i].calories;
                                word1("[уВес" + i + ":]", name1, word);
                                word1("[уБлюдо" + i + "]", name, word);
                                word1("[yz" + i + "]", name2, word);
                                word1("[uka" + i + "]", name3, word);
                            }
                                          
                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";

                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {

                            var name = _ingr_list_supper[i].name;


                            word1("[sup" + i + "]", name, word);
                        }


                        if (_ves_supper[i] == null)
                        {

                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {

                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {

                            var name6 = "";
                            word1("[r" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                                word1("[r" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[э" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[э" + i + "]", name5, word);
                        }


                        if (_menu_in_day == null)
                        {

                            var name2 = "";

                            word1("[date]", name2, word);
                        }
                        else
                        {
                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;

                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {
                            var name2 = "";

                            word1("[kol]", name2, word);
                        }
                        else
                        {
                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;

                                word1("[kol]", name2, word);
                            }

                        }
                        
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }

                    App.Visible = true;
                    GC.Collect();
                }
                
            }


            #endregion
        #region
            // Если на  завтрак и обед  больше 21 ингредиента и общее количество ингредиентов не  больше 50,то грузим File13 файл
            if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File13);
                
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";
                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }


                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {

                        var name = _ingr_list_breakfast[i].name;

                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }

                    if (_ves6_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);
                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name3 = "Кал.:" + dinner_food[i].calories;
                        word1("[ob" + i + "]", name2, word);
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oka" + i + "]", name3, word);
                    }

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";

                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {

                        var name = _ingr_list_dinner[i].name;


                        word1("[obed" + i + "]", name, word);
                    }


                    if (_ves_dinner[i] == null)
                    {

                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {

                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner3[i] == null)
                    {

                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                            word1("[c" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {

                        var name6 = "";
                        word1("[d" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                            word1("[d" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {

                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                            word1("[h" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[з" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[з" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);


                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
                               
                  if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {
                        var name = _ingr_list_supper[i].name;
                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {
                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {
                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {
                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[r" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                            word1("[r" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[т" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[т" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[т" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[д" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[д" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }
            else
            {   // Если на  завтрак и обед  больше 21 ингредиента и общее количество ингредиентов  больше 50,то грузим File21 файл
                if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File21);
                    
                    if (_namevrach == null)
                    {
                        var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);
                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";
                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";
                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);
                        }

                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + " " + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }

                    for (int z = 1; z <= 100; z++)
                    {
                        if (_ingr_list_all_day[z] != null)
                        {
                            var name5 = _ingr_list_all_day[z].name;
                            word1("[я" + z + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + z + "]", name5, word);
                        }

                        if (_obshves_all_day[z] != null)
                        {
                            var name5 = _obshves_all_day[z].net;
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                    }
                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";

                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {

                            var name = _ingr_list_breakfast[i].name;

                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {

                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[z" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }

                        if (_ves6_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                                word1("[n" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }


                        if (dinner_food[i] == null)
                        {
                            var name = "";
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);
                        }

                        if (this.dinner_food[i] != null)
                        {
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name3 = "Кал.:" + dinner_food[i].calories;
                            word1("[ob" + i + "]", name2, word);
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oka" + i + "]", name3, word);
                        }

                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";

                            word1("[obed" + i + "]", name, word);
                        }

                        if (this._ingr_list_dinner[i] != null)
                        {

                            var name = _ingr_list_dinner[i].name;


                            word1("[obed" + i + "]", name, word);
                        }


                        if (_ves_dinner[i] == null)
                        {

                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {

                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {

                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner3[i] == null)
                        {

                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                                word1("[c" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {

                            var name6 = "";
                            word1("[d" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                                word1("[d" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {

                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }


                        if (_ves_dinner6[i] == null)
                        {

                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {

                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {

                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                                word1("[h" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[з" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[з" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";

                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);


                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = "Кал.:" + supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);
                        }
                  
                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";

                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {

                            var name = _ingr_list_supper[i].name;


                            word1("[sup" + i + "]", name, word);
                        }
                        
                        if (_ves_supper[i] == null)
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {

                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {

                            var name6 = "";
                            word1("[r" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                                word1("[r" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[т" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[т" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[т" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[д" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[д" + i + "]", name5, word);
                        }


                        if (_menu_in_day == null)
                        {

                            var name2 = "";

                            word1("[date]", name2, word);
                        }
                        else
                        {

                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;
                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {
                            var name2 = "";

                            word1("[kol]", name2, word);
                        }
                        else
                        {

                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;

                                word1("[kol]", name2, word);
                            }

                        }                        
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }

                    App.Visible = true;
                    GC.Collect();
                }
            
            
            }
            #endregion
        #region
            // Если на  завтрак и ужин  больше 21 ингредиента и общее количество ингредиентов не  больше 50,то грузим File14 файл
            if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File14);
                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";
                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }

                               
                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);

                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
               
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {

                        var name = _ingr_list_breakfast[i].name;

                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves6_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }


                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";

                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);

                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        word1("[ob" + i + "]", name2, word);
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oka" + i + "]", name3, word);
                    }

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";

                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {
                        var name = _ingr_list_dinner[i].name;
                        word1("[obed" + i + "]", name, word);
                    }
                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {

                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                            word1("[c" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {
                        var name6 = "";
                        word1("[d" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                            word1("[d" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {

                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                            word1("[h" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[и" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[и" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);

                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
                                
                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {

                        var name = _ingr_list_supper[i].name;


                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {
                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[r" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                            word1("[r" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[э" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[э" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }

            else
            {    // Если на  завтрак и ужин  больше 21 ингредиента и общее количество ингредиентов   больше 50,то грузим File23 файл
                if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File23);
                    if (_namevrach == null)
                    {
                        var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);
                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";
                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }


                    if (this._obshcal_supper[1] != null)
                    {
                        var name = _obshcal_supper[1].count_cal_food;
                        word1("[ukav]", name, word);
                    }

                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";

                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);

                        }
                        for (int z = 1; z <= 100; z++)
                        {
                            if (_ingr_list_all_day[z] != null)
                            {
                                var name5 = _ingr_list_all_day[z].name;
                                word1("[я" + z + "]", name5.ToString(), word);

                            }
                            else
                            {
                                var name5 = "";
                                word1("[я" + z + "]", name5, word);
                            }

                            if (_obshves_all_day[z] != null)
                            {
                                var name5 = _obshves_all_day[z].net;
                                word1("[t" + z + "]", name5.ToString(), word);
                            }
                            else
                            {
                                var name5 = "";
                                word1("[t" + z + "]", name5.ToString(), word);
                            }
                        }
                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + " " + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }
                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";

                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {

                            var name = _ingr_list_breakfast[i].name;

                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {

                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[z" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }


                        if (_ves6_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                                word1("[n" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }


                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }


                        if (dinner_food[i] == null)
                        {
                            var name = "";

                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);

                        }

                        if (this.dinner_food[i] != null)
                        {
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            var name3 = "Кал.:" + " " + dinner_food[i].calories;
                            word1("[ob" + i + "]", name2, word);
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oka" + i + "]", name3, word);
                        }

                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";

                            word1("[obed" + i + "]", name, word);
                        }

                        if (this._ingr_list_dinner[i] != null)
                        {
                            var name = _ingr_list_dinner[i].name;
                            word1("[obed" + i + "]", name, word);
                        }
                        if (_ves_dinner[i] == null)
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {

                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner3[i] == null)
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);

                                word1("[c" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                                word1("[d" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {

                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }


                        if (_ves_dinner6[i] == null)
                        {

                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {

                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {

                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                                word1("[h" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }


                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[и" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[и" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);

                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = "Кал.:" + " " + supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);
                        }
                    }

                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";
                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {

                            var name = _ingr_list_supper[i].name;


                            word1("[sup" + i + "]", name, word);
                        }


                        if (_ves_supper[i] == null)
                        {

                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {

                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {

                            var name6 = "";
                            word1("[r" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                                word1("[r" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[э" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[э" + i + "]", name5, word);
                        }


                        if (_menu_in_day == null)
                        {

                            var name2 = "";

                            word1("[date]", name2, word);
                        }
                        else
                        {

                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;

                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {

                            var name2 = "";

                            word1("[kol]", name2, word);
                        }
                        else
                        {

                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;

                                word1("[kol]", name2, word);

                            }

                        }
                       
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }

                    App.Visible = true;
                    GC.Collect();
                }
            
            }

            #endregion
        #region
            // Если на  обед и ужин  больше 21 ингредиента и общее количество ингредиентов не  больше 50,то грузим File15 файл
            if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File15);

                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }


                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }
                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {

                        var name = _ingr_list_breakfast[i].name;

                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }

                    if (_ves6_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";

                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);

                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        word1("[ob" + i + "]", name2, word);
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oka" + i + "]", name3, word);
                    }

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";

                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {
                        var name = _ingr_list_dinner[i].name;
                        word1("[obed" + i + "]", name, word);
                    }

                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {
                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                            word1("[c" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {
                        var name6 = "";
                        word1("[d" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                            word1("[d" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {
                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {
                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                            word1("[h" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[з" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[з" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);
                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
                              
                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {
                        var name = _ingr_list_supper[i].name;
                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {
                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {

                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {

                        var name6 = "";
                        word1("[r" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                            word1("[r" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[э" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[э" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net ;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }

            else

            {
                if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] != null) && (_ingr_list_supper[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File25);

                    if (_namevrach == null)
                    {
                        var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);
                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";

                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }


                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";
                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);
                        }
                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + " " + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }

                    for (int z = 1; z <= 100; z++)
                    {
                        if (_ingr_list_all_day[z] != null)
                        {
                            var name5 = _ingr_list_all_day[z].name;
                            word1("[я" + z + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + z + "]", name5, word);
                        }

                        if (_obshves_all_day[z] != null)
                        {
                            var name5 = _obshves_all_day[z].net;
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                    }
                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";

                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {

                            var name = _ingr_list_breakfast[i].name;

                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[z" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }

                        if (_ves6_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                                word1("[n" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }


                        if (dinner_food[i] == null)
                        {
                            var name = "";

                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);

                        }

                        if (this.dinner_food[i] != null)
                        {
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name3 = "Кал.:" + " " + dinner_food[i].calories;
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            word1("[ob" + i + "]", name2, word);
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oka" + i + "]", name3, word);
                        }

                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";

                            word1("[obed" + i + "]", name, word);
                        }

                        if (this._ingr_list_dinner[i] != null)
                        {
                            var name = _ingr_list_dinner[i].name;
                            word1("[obed" + i + "]", name, word);
                        }

                        if (_ves_dinner[i] == null)
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner3[i] == null)
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                                word1("[c" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                                word1("[d" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {

                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }


                        if (_ves_dinner6[i] == null)
                        {

                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {

                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                                word1("[h" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[з" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[з" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);
                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);
                        }
                                        
                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";

                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {

                            var name = _ingr_list_supper[i].name;


                            word1("[sup" + i + "]", name, word);
                        }


                        if (_ves_supper[i] == null)
                        {

                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {

                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {

                            var name6 = "";
                            word1("[r" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                                word1("[r" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[э" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[э" + i + "]", name5, word);
                        }


                        if (_menu_in_day == null)
                        {

                            var name2 = "";

                            word1("[date]", name2, word);
                        }
                        else
                        {

                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;

                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {

                            var name2 = "";

                            word1("[kol]", name2, word);
                        }
                        else
                        {

                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;

                                word1("[kol]", name2, word);

                            }

                        }
                       
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }

                    App.Visible = true;
                    GC.Collect();
                }

            }

            #endregion
        #region
            // Если на  завтрак,обед и ужин  больше 21 ингредиента и общее количество ингредиентов не  больше 50,то грузим File16 файл
            if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File16);

                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);
                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";
                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);
                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }
                
                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {

                        var name = _ingr_list_breakfast[i].name;

                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves6_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }


                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);
                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        var name3 = dinner_food[i].calories;
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[ob" + i + "]", name2, word);
                        word1("[oka" + i + "]", name3, word);
                    }
                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";
                        word1("[obed" + i + "]", name, word);
                    }
                    if (this._ingr_list_dinner[i] != null)
                    {
                        var name = _ingr_list_dinner[i].name;
                        word1("[obed" + i + "]", name, word);
                    }

                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {
                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                            word1("[c" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {

                        var name6 = "";
                        word1("[d" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                            word1("[d" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {

                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {

                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {

                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {

                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                            word1("[h" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }


                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[з" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[з" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);
                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);
                    }
               
                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";

                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {

                        var name = _ingr_list_supper[i].name;


                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {

                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {

                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper3[i] == null)
                    {
                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {
                        var name6 = "";
                        word1("[r" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                            word1("[r" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {

                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {

                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);

                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {

                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {

                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[э" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[э" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {

                        var name2 = "";

                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";
                }

                App.Visible = true;
                GC.Collect();
            }
            else
            {   // Если на  завтрак,обед и ужин  больше 21 ингредиента и общее количество ингредиентов   больше 50,то грузим File22 файл
                if ((_ingr_list_breakfast[22] != null) && (_ingr_list_dinner[22] != null) && (_ingr_list_supper[22] != null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File22);

                    if (_namevrach == null)
                    {
                        var name = "";

                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);

                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";

                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }
                    for (int z = 1; z <= 100; z++)
                    {
                        if (_ingr_list_all_day[z] != null)
                        {
                            var name5 = _ingr_list_all_day[z].name;
                            word1("[я" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + z + "]", name5, word);
                        }

                        if (_obshves_all_day[z] != null)
                        {
                            var name5 = _obshves_all_day[z].net;
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                    }
                    
                    for (int i = 1; i <= 8; i++)
                    {
                        if (_food[i] == null)
                        {
                            var name = "";
                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);

                        }

                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }
                    for (int i = 1; i <= 50; i++)
                    {
                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";

                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {

                            var name = _ingr_list_breakfast[i].name;

                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {

                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[i" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[z" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }


                        if (_ves6_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                                word1("[n" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }


                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }


                        if (dinner_food[i] == null)
                        {
                            var name = "";
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);
                        }

                        if (this.dinner_food[i] != null)
                        {
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            var name3 = dinner_food[i].calories;
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[ob" + i + "]", name2, word);
                            word1("[oka" + i + "]", name3, word);
                        }
                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";
                            word1("[obed" + i + "]", name, word);
                        }
                        if (this._ingr_list_dinner[i] != null)
                        {
                            var name = _ingr_list_dinner[i].name;
                            word1("[obed" + i + "]", name, word);
                        }

                        if (_ves_dinner[i] == null)
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner3[i] == null)
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                                word1("[c" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {

                            var name6 = "";
                            word1("[d" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);

                                word1("[d" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {

                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }


                        if (_ves_dinner6[i] == null)
                        {

                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {

                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {

                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);

                                word1("[h" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }


                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[з" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[з" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";

                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);
                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);
                        }
                                   

                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";

                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {

                            var name = _ingr_list_supper[i].name;


                            word1("[sup" + i + "]", name, word);
                        }


                        if (_ves_supper[i] == null)
                        {

                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {

                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper3[i] == null)
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);
                                word1("[r" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {

                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {

                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);

                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {

                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {

                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {

                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[э" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[э" + i + "]", name5, word);
                        }


                        if (_menu_in_day == null)
                        {

                            var name2 = "";

                            word1("[date]", name2, word);
                        }
                        else
                        {

                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;

                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {

                            var name2 = "";

                            word1("[kol]", name2, word);
                        }
                        else
                        {

                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;
                                word1("[kol]", name2, word);
                            }

                        }
                       
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";
                    }

                    App.Visible = true;
                    GC.Collect();
                }
            
            }
            #endregion
        #region
            // Если на  завтрак,обед и ужин не больше 21 ингредиента и общее количество ингредиентов не  больше 50,то грузим File9 файл
            if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] == null))
            {
                var App = new word.Application(Visible = false);
                var word = App.Documents.Add(Application.StartupPath + File9);

                if (_namevrach == null)
                {
                    var name = "";
                    word1("[head_vrach]", name, word);
                    word1("[head_vrach1]", name, word);
                    word1("[head_vrach2]", name, word);

                }

                if (this._namevrach != null)
                {
                    word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                }

                if (_namevrach2 == null)
                {
                    var name = "";

                    word1("[diet_vrach]", name, word);
                    word1("[diet_vrach1]", name, word);
                    word1("[diet_vrach2]", name, word);

                }

                if (this._namevrach2 != null)
                {
                    word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                }

                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";
                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                        word1("[ka" + i + "]", name, word);
                    }

                    if (this._food[i] != null)
                    {
                        var name = _food[i].name;
                        var name1 = "Вес:" + " " + _food[i].weight;
                        var name2 = _food[i].count_portc;
                        var name3 = "Кал.:" + " " + _food[i].calories;
                        word1("[kol" + i + "]", name2, word);
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[ka" + i + "]", name3, word);
                    }
                }
                for (int i = 1; i <= 50; i++)
                {
                    pb.Minimum = 0;
                    pb.Maximum = 50;
                    pb.Value = i;
                    int k = i * 2;
                    label1.Text = "Прогресс расчета " + k + "%";

                    if (_ingr_list_breakfast[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list_breakfast[i] != null)
                    {

                        var name = _ingr_list_breakfast[i].name;

                        word1("[" + i + "]", name, word);
                    }

                    if (_ves_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves2_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                            word1("[i" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves4_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                            word1("[z" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves6_breakfast[i] == null)
                    {
                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves7_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8_breakfast[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8_breakfast[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_breakfast[i] != null)
                    {
                        var name5 = _obshves_breakfast[i].net;
                        word1("[u" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[u" + i + "]", name5, word);
                    }


                    if (dinner_food[i] == null)
                    {
                        var name = "";

                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oбедВес" + i + ":]", name, word);
                        word1("[ob" + i + "]", name, word);
                        word1("[oka" + i + "]", name, word);

                    }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name3 = "Кал.:" + " " + dinner_food[i].calories;
                        word1("[ob" + i + "]", name2, word);
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        word1("[oбедВес" + i + ":]", name1, word);
                        word1("[oбедБлюдо" + i + "]", name, word);
                        word1("[oka" + i + "]", name3, word);

                    }

                    if (_ingr_list_dinner[i] == null)
                    {
                        var name = "";

                        word1("[obed" + i + "]", name, word);
                    }

                    if (this._ingr_list_dinner[i] != null)
                    {
                        var name = _ingr_list_dinner[i].name;
                        word1("[obed" + i + "]", name, word);
                    }

                    if (_ves_dinner[i] == null)
                    {
                        var name6 = "";
                        word1("[a" + i + "]", name6, word);
                    }
                    else
                    {
                        if (this._ves_dinner[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                            word1("[a" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner2[i] == null)
                    {
                        var name6 = "";
                        word1("[b" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves_dinner2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                            word1("[b" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner3[i] == null)
                    {
                        var name6 = "";
                        word1("[c" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                            word1("[c" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner4[i] == null)
                    {
                        var name6 = "";
                        word1("[d" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_dinner4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                            word1("[d" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);
                        }
                    }
                    if (_ves_dinner5[i] == null)
                    {
                        var name6 = "";
                        word1("[e" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                            word1("[e" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }
                    }


                    if (_ves_dinner6[i] == null)
                    {
                        var name6 = "";
                        word1("[f" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                            word1("[f" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner7[i] == null)
                    {
                        var name6 = "";
                        word1("[g" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                            word1("[g" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }
                    }

                    if (_ves_dinner8[i] == null)
                    {
                        var name6 = "";
                        word1("[h" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_dinner8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                            word1("[h" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_dinner[i] != null)
                    {
                        var name5 = _obshves_dinner[i].net;
                        word1("[и" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[и" + i + "]", name5, word);
                    }

                    if (supper_food[i] == null)
                    {
                        var name = "";
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[уВес" + i + ":]", name, word);
                        word1("[yz" + i + "]", name, word);
                        word1("[uka" + i + "]", name, word);
                    }
                    if (this.supper_food[i] != null)
                    {
                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;
                        var name3 = "Кал.:" + " " + supper_food[i].calories;
                        word1("[уВес" + i + ":]", name1, word);
                        word1("[уБлюдо" + i + "]", name, word);
                        word1("[yz" + i + "]", name2, word);
                        word1("[uka" + i + "]", name3, word);

                    }

                    if (_ingr_list_supper[i] == null)
                    {
                        var name = "";
                        word1("[sup" + i + "]", name, word);
                    }

                    if (this._ingr_list_supper[i] != null)
                    {
                        var name = _ingr_list_supper[i].name;
                        word1("[sup" + i + "]", name, word);
                    }


                    if (_ves_supper[i] == null)
                    {
                        var name6 = "";
                        word1("[j" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves_supper[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                            word1("[j" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper2[i] == null)
                    {
                        var name6 = "";
                        word1("[l" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                            word1("[l" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper3[i] == null)
                    {
                        var name6 = "";
                        word1("[p" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper3[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                            word1("[p" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper4[i] == null)
                    {
                        var name6 = "";
                        word1("[r" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves_supper4[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                            word1("[r" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);
                        }
                    }
                    if (_ves_supper5[i] == null)
                    {
                        var name6 = "";
                        word1("[s" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                            word1("[s" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }
                    }


                    if (_ves_supper6[i] == null)
                    {
                        var name6 = "";
                        word1("[б" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper6[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                            word1("[б" + i + "]", nsme6.ToString(), word);
                        }

                        else
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper7[i] == null)
                    {
                        var name6 = "";
                        word1("[в" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper7[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                            word1("[в" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }
                    }

                    if (_ves_supper8[i] == null)
                    {
                        var name6 = "";
                        word1("[г" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves_supper8[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves_supper8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                            word1("[г" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                    }

                    if (_obshves_supper[i] != null)
                    {
                        var name5 = _obshves_supper[i].net;
                        word1("[д" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[д" + i + "]", name5, word);
                    }


                    if (_menu_in_day == null)
                    {
                        var name2 = "";
                        word1("[date]", name2, word);
                    }
                    else
                    {

                        if (this._menu_in_day[1] != null)
                        {
                            var name2 = _menu_in_day[1].serve_time;
                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {

                        var name2 = "";

                        word1("[kol]", name2, word);
                    }
                    else
                    {

                        if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;
                            word1("[kol]", name2, word);
                        }

                    }
                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[я" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[я" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net ;
                        word1("[t" + i + "]", name5.ToString(), word);
                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5.ToString(), word);
                    }

                }

                App.Visible = true;
                GC.Collect();
            }

            else
            {   // Если на  завтрак,обед и ужин не больше 21 ингредиента и общее количество ингредиентов   больше 50,то грузим File19 файл
                if ((_ingr_list_breakfast[22] == null) && (_ingr_list_dinner[22] == null) && (_ingr_list_supper[22] == null) && (_obshves_all_day[51] != null))
                {
                    var App = new word.Application(Visible = false);
                    var word = App.Documents.Add(Application.StartupPath + File19);

                    if (_namevrach == null)
                    {
                        var name = "";
                        word1("[head_vrach]", name, word);
                        word1("[head_vrach1]", name, word);
                        word1("[head_vrach2]", name, word);
                    }

                    if (this._namevrach != null)
                    {
                        word1("[head_vrach]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach1]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                        word1("[head_vrach2]", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
                    }

                    if (_namevrach2 == null)
                    {
                        var name = "";

                        word1("[diet_vrach]", name, word);
                        word1("[diet_vrach1]", name, word);
                        word1("[diet_vrach2]", name, word);

                    }

                    if (this._namevrach2 != null)
                    {
                        word1("[diet_vrach]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach1]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                        word1("[diet_vrach2]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
                    }


                    for (int i = 1; i <= 8; i++)
                    {

                        if (_food[i] == null)
                        {
                            var name = "";
                            word1("[блюдо" + i + "]", name, word);
                            word1("[Вес" + i + ":]", name, word);
                            word1("[kol" + i + "]", name, word);
                            word1("[ka" + i + "]", name, word);
                        }

                        if (this._food[i] != null)
                        {
                            var name = _food[i].name;
                            var name1 = "Вес:" + " " + _food[i].weight;
                            var name2 = _food[i].count_portc;
                            var name3 = "Кал.:" + " " + _food[i].calories;
                            word1("[kol" + i + "]", name2, word);
                            word1("[Вес" + i + ":]", name1, word);
                            word1("[блюдо" + i + "]", name, word);
                            word1("[ka" + i + "]", name3, word);
                        }
                    }
                    for (int z = 1; z <= 100; z++)
                    {
                        if (_ingr_list_all_day[z] != null)
                        {
                            var name5 = _ingr_list_all_day[z].name;
                            word1("[я" + z + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[я" + z + "]", name5, word);
                        }
                        if (_obshves_all_day[z] != null)
                        {
                            var name5 = _obshves_all_day[z].net;
                            word1("[t" + z + "]", name5.ToString(), word);
                        }
                        else
                        {
                            var name5 = "";
                            word1("[t" + z + "]", name5.ToString(), word);
                        }

                    }
                      for (int i = 1; i <= 50; i++)
                    {
                        pb.Minimum = 0;
                        pb.Maximum = 50;
                        pb.Value = i;
                        int k = i * 2;
                        label1.Text = "Прогресс расчета " + k + "%";

                        if (_ingr_list_breakfast[i] == null)
                        {
                            var name = "";

                            word1("[" + i + "]", name, word);
                        }

                        if (this._ingr_list_breakfast[i] != null)
                        {

                            var name = _ingr_list_breakfast[i].name;

                            word1("[" + i + "]", name, word);
                        }

                        if (_ves_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                                word1("[v" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[v" + i + "]", name6, word);
                            }
                        }
                        if (_ves2_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves2_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves2_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                                word1("[k" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }

                        if (_ves3_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[i" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves3_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves3_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);
                                word1("[i" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[k" + i + "]", name6, word);
                            }
                        }
                        if (_ves4_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves4_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves4_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);
                                word1("[z" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[z" + i + "]", name6, word);
                            }
                        }
                        if (_ves5_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves5_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves5_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                                word1("[x" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[x" + i + "]", name6, word);
                            }
                        }


                        if (_ves6_breakfast[i] == null)
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves6_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves6_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                                word1("[y" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[y" + i + "]", name6, word);
                            }
                        }

                        if (_ves7_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves7_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves7_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                                word1("[q" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[q" + i + "]", name6, word);
                            }
                        }

                        if (_ves8_breakfast[i] == null)
                        {

                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves8_breakfast[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves8_breakfast[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);
                                word1("[n" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[n" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_breakfast[i] != null)
                        {
                            var name5 = _obshves_breakfast[i].net;
                            word1("[u" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[u" + i + "]", name5, word);
                        }


                        if (dinner_food[i] == null)
                        {
                            var name = "";

                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oбедВес" + i + ":]", name, word);
                            word1("[ob" + i + "]", name, word);
                            word1("[oka" + i + "]", name, word);

                        }

                        if (this.dinner_food[i] != null)
                        {
                            var name = dinner_food[i].name;
                            var name2 = dinner_food[i].count_portc;
                            var name3 = "Кал.:" + " " + dinner_food[i].calories;
                            word1("[ob" + i + "]", name2, word);
                            var name1 = "Вес:" + " " + dinner_food[i].weight;
                            word1("[oбедВес" + i + ":]", name1, word);
                            word1("[oбедБлюдо" + i + "]", name, word);
                            word1("[oka" + i + "]", name3, word);

                        }

                        if (_ingr_list_dinner[i] == null)
                        {
                            var name = "";

                            word1("[obed" + i + "]", name, word);
                        }

                        if (this._ingr_list_dinner[i] != null)
                        {
                            var name = _ingr_list_dinner[i].name;
                            word1("[obed" + i + "]", name, word);
                        }

                        if (_ves_dinner[i] == null)
                        {
                            var name6 = "";
                            word1("[a" + i + "]", name6, word);
                        }
                        else
                        {
                            if (this._ves_dinner[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[1].count_portc) / 1000);
                                word1("[a" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[a" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner2[i] == null)
                        {
                            var name6 = "";
                            word1("[b" + i + "]", name6, word);
                        }

                        else
                        {

                            if (this._ves_dinner2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[2].count_portc) / 1000);
                                word1("[b" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[b" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner3[i] == null)
                        {
                            var name6 = "";
                            word1("[c" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[3].count_portc) / 1000);
                                word1("[c" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[c" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner4[i] == null)
                        {
                            var name6 = "";
                            word1("[d" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_dinner4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[4].count_portc) / 1000);
                                word1("[d" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[d" + i + "]", name6, word);
                            }
                        }
                        if (_ves_dinner5[i] == null)
                        {
                            var name6 = "";
                            word1("[e" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[5].count_portc) / 1000);
                                word1("[e" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[e" + i + "]", name6, word);
                            }
                        }


                        if (_ves_dinner6[i] == null)
                        {
                            var name6 = "";
                            word1("[f" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[6].count_portc) / 1000);
                                word1("[f" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[f" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner7[i] == null)
                        {
                            var name6 = "";
                            word1("[g" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[7].count_portc) / 1000);
                                word1("[g" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[g" + i + "]", name6, word);
                            }
                        }

                        if (_ves_dinner8[i] == null)
                        {
                            var name6 = "";
                            word1("[h" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_dinner8[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_dinner8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(dinner_food[8].count_portc) / 1000);
                                word1("[h" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[h" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_dinner[i] != null)
                        {
                            var name5 = _obshves_dinner[i].net;
                            word1("[и" + i + "]", name5.ToString(), word);

                        }
                        else
                        {
                            var name5 = "";
                            word1("[и" + i + "]", name5, word);
                        }

                        if (supper_food[i] == null)
                        {
                            var name = "";
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[уВес" + i + ":]", name, word);
                            word1("[yz" + i + "]", name, word);
                            word1("[uka" + i + "]", name, word);

                        }
                        if (this.supper_food[i] != null)
                        {
                            var name = supper_food[i].name;
                            var name2 = supper_food[i].count_portc;
                            var name1 = "Вес:" + " " + supper_food[i].weight;
                            var name3 = "Кал.:" + " " + supper_food[i].calories;
                            word1("[уВес" + i + ":]", name1, word);
                            word1("[уБлюдо" + i + "]", name, word);
                            word1("[yz" + i + "]", name2, word);
                            word1("[uka" + i + "]", name3, word);

                        }

                        if (_ingr_list_supper[i] == null)
                        {
                            var name = "";
                            word1("[sup" + i + "]", name, word);
                        }

                        if (this._ingr_list_supper[i] != null)
                        {
                            var name = _ingr_list_supper[i].name;
                            word1("[sup" + i + "]", name, word);
                        }


                        if (_ves_supper[i] == null)
                        {
                            var name6 = "";
                            word1("[j" + i + "]", name6, word);
                        }
                        else
                        {

                            if (this._ves_supper[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[1].count_portc) / 1000);
                                word1("[j" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[j" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper2[i] == null)
                        {
                            var name6 = "";
                            word1("[l" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper2[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper2[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[2].count_portc) / 1000);
                                word1("[l" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[l" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper3[i] == null)
                        {
                            var name6 = "";
                            word1("[p" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper3[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper3[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[3].count_portc) / 1000);
                                word1("[p" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[p" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper4[i] == null)
                        {
                            var name6 = "";
                            word1("[r" + i + "]", name6, word);

                        }

                        else
                        {
                            if (this._ves_supper4[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper4[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[4].count_portc) / 1000);

                                word1("[r" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[r" + i + "]", name6, word);
                            }
                        }
                        if (_ves_supper5[i] == null)
                        {
                            var name6 = "";
                            word1("[s" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper5[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper5[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[5].count_portc) / 1000);
                                word1("[s" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[s" + i + "]", name6, word);
                            }
                        }


                        if (_ves_supper6[i] == null)
                        {
                            var name6 = "";
                            word1("[б" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper6[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper6[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[6].count_portc) / 1000);
                                word1("[б" + i + "]", nsme6.ToString(), word);
                            }

                            else
                            {
                                var name6 = "";
                                word1("[б" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper7[i] == null)
                        {
                            var name6 = "";
                            word1("[в" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper7[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper7[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[7].count_portc) / 1000);
                                word1("[в" + i + "]", nsme6.ToString(), word);

                            }
                            else
                            {
                                var name6 = "";
                                word1("[в" + i + "]", name6, word);
                            }
                        }

                        if (_ves_supper8[i] == null)
                        {
                            var name6 = "";
                            word1("[г" + i + "]", name6, word);
                        }

                        else
                        {
                            if (this._ves_supper8[i] != null)
                            {
                                var name5 = Convert.ToDouble(_ves_supper8[i].net);
                                var nsme6 = (name5 * Convert.ToDouble(supper_food[8].count_portc) / 1000);
                                word1("[г" + i + "]", nsme6.ToString(), word);
                            }
                            else
                            {
                                var name6 = "";
                                word1("[г" + i + "]", name6, word);
                            }

                        }

                        if (_obshves_supper[i] != null)
                        {
                            var name5 = _obshves_supper[i].net;
                            word1("[д" + i + "]", name5.ToString(), word);

                        }
                        else
                        {    var name5 = "";
                            word1("[д" + i + "]", name5, word);
                        }


                        if (_menu_in_day == null)
                        {
                            var name2 = "";
                            word1("[date]", name2, word);
                        }
                        else
                        {
                            if (this._menu_in_day[1] != null)
                            {
                                var name2 = _menu_in_day[1].serve_time;
                                word1("[date]", name2, word);
                            }
                        }
                        if (_count_serv == null)
                        {
                            var name2 = "";

                            word1("[kol]", name2, word);
                        }
                        else
                        {
                            if (this._count_serv != null)
                            {
                                var name2 = _count_serv.numb_men;
                                word1("[kol]", name2, word);
                            }
                        }

                    }

                    App.Visible = true;
                    GC.Collect();
                }
            }
        }        
        #endregion

        /// <summary>
        /// Событие возникающие при нажатии кнопки "OK".Событие при нажатии кнопки создать карточку-раскладку, там происходит открытие шаблона и замена меток на переменные , значения которых получаются в результате SQL запроса
        ///Смысл в том,что если переменная в результате SQL- запроса получает NULL,то метки заменяем на пробелы, а если получает какие-то значения ,то соответсвенно заменяем метки на значения этой переменной. Вообщем такой же принцип что в классе Cards-layout и Food in menu
        /// </summary>
        private void ok_Click(object sender, EventArgs e)
        {
            //Проверяется выбрал ли пользователь значения в комбоксах
            if ((cb_ok.Text == "") || (cb_diets_vrach.Text == ""))
            {
                MessageBox.Show("Вы не выбрали того, кто утверждает меню-раскладку или того, кто составляет меню-раскладку !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {   pb.Visible = true;
                label1.Visible = true;
                this.Size = new Size(290, 225);
                
                //Если время падачи блюда завтрак,то строится отчет:" Меню-раскладка на обед"
                if (serve == "обед")
                {
                    Report_Menu_dinner();
                }
                //Если время падачи блюда завтрак,то строится отчет:" Меню-раскладка на завтрак"
                if (serve == "завтрак")
                {
                    Report_MEnu_Layout_breakfast();
                }
                //Если время падачи блюда завтрак,то строится отчет:" Меню-раскладка на ужин"
                if (serve == "ужин")
                {
                    Report_MEnu_Layout_supper();
                }
            }

            //Если в конструкторе перменная serve=весь день ,то строится отчет:" Меню-раскладка на весь день"
            if (serve == "весь день")
            {
                Report_MEnu_Layout_all_day();
            }
           
           GC.Collect();
        }
        /// <summary>
        /// Отмена
        /// </summary>
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// При выборе с комбокса блюда происходит следующее событие
        /// </summary>
        private void cb_ok_SelectedIndexChanged(object sender, EventArgs e)
        {
            _namevrach = get_person_name_vrach1();
        }
        /// <summary>
        /// При выборе с комбокса блюда происходит следующее событие
        /// </summary>
        private void cb_diets_vrach_SelectedIndexChanged(object sender, EventArgs e)
        {
            _namevrach2 = get_person_name_vrach2();
        }
       
        
      }
}
