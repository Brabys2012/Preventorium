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
        private int AddDayID;
        private int queue_id;
        private string serve;
        public class_ingr_in_food[] _ves_breakfast;
        public class_ingr_in_food[] _ves2_breakfast;
        public class_ingr_in_food[] _ves3_breakfast;
        public class_ingr_in_food[] _ves4_breakfast;
        public class_ingr_in_food[] _ves5_breakfast;
        public class_ingr_in_food[] _ves6_breakfast;
        public class_ingr_in_food[] _ves7_breakfast;
        public class_ingr_in_food[] _ves8_breakfast;
        public class_ingr_in_food[] _ves_dinner;
        public class_ingr_in_food[] _ves_dinner2;
        public class_ingr_in_food[] _ves_dinner3;
        public class_ingr_in_food[] _ves_dinner4;
        public class_ingr_in_food[] _ves_dinner5;
        public class_ingr_in_food[] _ves_dinner6;
        public class_ingr_in_food[] _ves_dinner7;
        public class_ingr_in_food[] _ves_dinner8;

        public class_ingr_in_food[] _ves_supper;
        public class_ingr_in_food[] _ves_supper2;
        public class_ingr_in_food[] _ves_supper3;
        public class_ingr_in_food[] _ves_supper4;
        public class_ingr_in_food[] _ves_supper5;
        public class_ingr_in_food[] _ves_supper6;
        public class_ingr_in_food[] _ves_supper7;
        public class_ingr_in_food[] _ves_supper8;

        public class_ingr_in_food[] _obshves_breakfast;
        public class_ingr_in_food[] _obshves_dinner;
        public class_ingr_in_food[] _obshves_supper;
          public class_ingr_in_food[]   _obshves_all_day;
        /// <summary>
        /// Это поле список людей работающих  в данной предметной области
        /// </summary>
        public class_person[] _person;

               
        private readonly string File3 = @"\Reports\Меню-раскладка_завтрак_22 ингр.docx";
        private readonly string File4 = @"\Reports\Меню-раскладка_завтрак_47 ингр.docx";
        private readonly string File5 = @"\Reports\Меню-раскладка_обед_22 ингр.docx";
        private readonly string File6 = @"\Reports\Меню-раскладка_обед_47 ингр.docx";
        private readonly string File7 = @"\Reports\Меню-раскладка_ужин_22 ингр.docx";
        private readonly string File8 = @"\Reports\Меню-раскладка_ужин_47 ингр.docx";
        
        public class_food[] _food;
        public class_food[] dinner_food;
        public class_queue _count_serv;
        public class_food[] supper_food;
       
        public class_menu_in_food[] _menu_in_day;
        public class_ingridients[] _ingr_list_breakfast;
        public class_ingridients[] _ingr_list_dinner;
        public class_ingridients[] _ingr_list_supper;
        public class_ingridients[] _ingr_list_all_day;
       
        public Menu_layout(int day, int queue)
        {
            
            AddDayID = day;
            queue_id = queue;
            InitializeComponent();
        
        }
       

        public Menu_layout(string serves,int day, int queue)
        {
            serve = serves;
            AddDayID = day;
            queue_id = queue;
            InitializeComponent();
            this.Text = "Расчет меню-раскладки на "+ serves;
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

                    this.cb_ok.Items.Add(this._person[i].name.Trim() + " " + this._person[i].surname + " " + this._person[i].secondname);
                    this.cb_diets_vrach.Items.Add(this._person[i].name.Trim() + " " + this._person[i].surname + " " + this._person[i].secondname);
                  
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
            string query = "select *  from Person ";


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
                    person[i].name = rd.GetString(1).ToString();
                    person[i].surname = rd.GetString(2).ToString();
                    person[i].secondname = rd.GetString(3).ToString();
                    person[i].id = rd.GetInt32(0).ToString();


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
            _obshves_breakfast = get_sum_breakfast(AddDayID);
            _obshves_dinner = get_sum_dinner(AddDayID);
            _obshves_supper = get_sum_supper(AddDayID);
            _obshves_all_day = get_sum_all_day(AddDayID);


            _menu_in_day = this.menu_in_day();
            _count_serv = this.get_count_serv(queue_id);
            this._person = this.get_person_list();
            fill_person_list();
        }
        public class_menu_in_food[] menu_in_day()
        {
            class_menu_in_food[] menu_in_day = new class_menu_in_food[512];

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
                    menu_in_day[i] = new class_menu_in_food();
                    menu_in_day[i].result = "OK";
                    menu_in_day[i].service = rd.GetDateTime(1).ToShortDateString();
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
        public class_food[] get_food_breakfast(int date)
        {

            class_food[] food = new class_food[512];

            string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food from Food_in_menu FIM" +
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
        public class_food[] get_food_dinner(int date)
        {

            class_food[] food = new class_food[512];

            string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food from Food_in_menu FIM" +
                     " join Foods F on F.ID_food = FIM.ID_food " +
                 " where FIM.Serve_time_of_food ='" + serve+"'" + "  and day_id='" + date + "'";

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
        public class_food[] get_food_supper(int date)
        {

            class_food[] food = new class_food[512];

            string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food from Food_in_menu FIM" +
                     " join Foods F on F.ID_food = FIM.ID_food " +
                 " where FIM.Serve_time_of_food ='" + serve + "'" + "  and day_id='" + date + "'";

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
        public class_ingridients[] get_ingr_list_dinner(int date)
        {

            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
             " join Foods F on F.ID_food = FIM.ID_food" +
             " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
             " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
             " where FIM.Serve_time_of_food ='"+serve+"'"+" and day_id = '" + date + "'";

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
        public class_ingridients[] get_ingr_list_supper(int date)
        {

            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
             " join Foods F on F.ID_food = FIM.ID_food" +
             " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
             " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
             " where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id = '" + date + "'";

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
        public class_ingr_in_food[] get_sum_dinner(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];

            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'" + "and Food_in_menu.Serve_time_of_food='"+ serve+"'" + " group by Ingridients_in_food.Id_ingridients";

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
        public class_ingr_in_food[] get_sum_supper(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];

            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'" + "and Food_in_menu.Serve_time_of_food='" + serve + "'" + " group by Ingridients_in_food.Id_ingridients";

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
        public class_ingr_in_food[] get_sum_all_day(int day)
        {
            class_food[] food = new class_food[512];
            class_ingr_in_food[] foods = new class_ingr_in_food[512];

            string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food " + "  where Food_in_menu.day_id='" + day + "'"+" group by Ingridients_in_food.Id_ingridients";

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
        public class_ingr_in_food[] get_ves_breakfast2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+ AddDayID+"'" + " and IIF.ID_food='" + _food[2].food_id + "'"; ;


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
        public class_ingr_in_food[] get_ves_breakfast3()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[3] != null)
            {

                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+" and IIF.ID_food='" + _food[3].food_id + "'"; ;



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
        public class_ingr_in_food[] get_ves_breakfast4()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[4] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+ AddDayID+" and IIF.ID_food='" + _food[4].food_id + "'"; ;



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
        public class_ingr_in_food[] get_ves_breakfast5()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[5] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+" and IIF.ID_food='" + _food[5].food_id + "'"; ;

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
        public class_ingr_in_food[] get_ves_breakfast6()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[6] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+" and IIF.ID_food='" + _food[6].food_id + "'"; ;



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
        public class_ingr_in_food[] get_ves_breakfast7()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[7] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+" and IIF.ID_food='" + _food[7].food_id + "'"; ;



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
        public class_ingr_in_food[] get_ves_breakfast8()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[8] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+AddDayID+" and IIF.ID_food='" + _food[8].food_id + "'"; ;



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
        public class_ingr_in_food[] get_ves_dinner()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[1] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID +"'"+" and IIF.ID_food='" + dinner_food[1].food_id + "'"; 



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
        public class_ingr_in_food[] get_ves_dinner2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[2].food_id + "'";



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
        public class_ingr_in_food[] get_ves_dinner3()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[3] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[3].food_id + "'";



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
        public class_ingr_in_food[] get_ves_dinner4()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[4] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[4].food_id + "'";



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
        public class_ingr_in_food[] get_ves_dinner5()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[5] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[5].food_id + "'";



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
        public class_ingr_in_food[] get_ves_dinner6()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[6] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[6].food_id + "'";



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
        public class_ingr_in_food[] get_ves_dinner7()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[7] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[7].food_id + "'";



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
        public class_ingr_in_food[] get_ves_dinner8()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (dinner_food[8] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + dinner_food[8].food_id + "'";



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
        public class_ingr_in_food[] get_ves_supper()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[1] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[1].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[2].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper3()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[3] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[3].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper4()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[4] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[4].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper5()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[5] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[5].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper6()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[6] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[6].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper7()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[7] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[7].food_id + "'";


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
        public class_ingr_in_food[] get_ves_supper8()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (supper_food[8] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food ='" + serve + "'" + " and day_id ='" + AddDayID + "'" + " and IIF.ID_food='" + supper_food[8].food_id + "'";


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
        private void word1(string stubToReplace, string text, word.Document word)
        {
            var range = word.Content;

            range.Find.ClearFormatting();

            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);

        }
        public void Report_MEnu_Layout_breakfast()
        {

            var App = new word.Application(Visible = false);


            if (_ingr_list_breakfast[23] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File4);

                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);

                    }

                    if (this._food[i] != null)
                    {

                        var name = _food[i].name;

                        var name1 = "Вес:" + " " + _food[i].weight;

                        word1("[Вес" + i + ":]", name1, word);

                        word1("[блюдо" + i + "]", name, word);

                    }
                }
           
                for (int i = 1; i < 51; i++)
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
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc));
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
                            var name5 = _ves2_breakfast[i].net;
                            word1("[k" + i + "]", name5, word);

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
                            var name5 = _ves3_breakfast[i].net;
                            word1("[i" + i + "]", name5, word);

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
                            var name5 = _ves4_breakfast[i].net;
                            word1("[z" + i + "]", name5, word);

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
                            var name5 = _ves5_breakfast[i].net;
                            word1("[x" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
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
                            var name5 = _ves5_breakfast[i].net;
                            word1("[x" + i + "]", name5, word);

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
                            var name5 = _ves6_breakfast[i].net;
                            word1("[y" + i + "]", name5, word);

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
                            var name5 = _ves7_breakfast[i].net;
                            word1("[q" + i + "]", name5, word);

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
                            var name5 = _ves8_breakfast[i].net;
                            word1("[n" + i + "]", name5, word);

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
                            var name2 = _menu_in_day[1].service;

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

                var namevr2 = cb_diets_vrach.Text;
                var namevr1 = this.cb_ok.Text;
                word1("[diet_vrach]", namevr2, word);
                word1("[head_vrach]", namevr1, word);

                for (int i = 1; i <= 8; i++)
                {
                    if (_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);

                    }

                    if (this._food[i] != null)
                    {

                        var name = _food[i].name;
                        var name2 = _food[i].count_portc;
                        var name1 = "Вес:" + " " + _food[i].weight;

                        word1("[Вес" + i + ":]", name1, word);

                        word1("[блюдо" + i + "]", name, word);

                        word1("[kol" + i + "]", name2, word);

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
                            var name2 = _menu_in_day[1].service;

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
        public void Report_Menu_dinner()
        {
            var App = new word.Application(Visible = false);
            
            if (_ingr_list_dinner[23] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File6);

                var namevr2 = cb_diets_vrach.Text;
                var namevr1 = this.cb_ok.Text;
                word1("[diet_vrach]", namevr2, word);
                word1("[head_vrach]", namevr1, word);

                for (int i = 1; i <= 8; i++)
                {
                    if (dinner_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);
                                            }

                    if (this.dinner_food[i] != null)
                    {
                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;
                        word1("[Вес" + i + ":]", name1, word);
                        word1("[блюдо" + i + "]", name, word);
                        word1("[kol" + i + "]", name2, word);
                    }
                }
                 for (int i = 1; i <= 50; i++)
                {
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
                            var name2 = _menu_in_day[1].service;

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

                var namevr2 = cb_diets_vrach.Text;
                var namevr1 = this.cb_ok.Text;
                word1("[diet_vrach]", namevr2, word);
                word1("[head_vrach]", namevr1, word);

                for (int i = 1; i <= 8; i++)
                {
                    if (dinner_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);

                    }

                    if (this.dinner_food[i] != null)
                    {

                        var name = dinner_food[i].name;
                        var name2 = dinner_food[i].count_portc;
                        var name1 = "Вес:" + " " + dinner_food[i].weight;

                        word1("[Вес" + i + ":]", name1, word);

                        word1("[блюдо" + i + "]", name, word);

                        word1("[kol" + i + "]", name2, word);

                    }
                }

                for (int i = 1; i <= 50; i++)
                {

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
                            var name2 = _menu_in_day[1].service;

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

        public void  Report_MEnu_Layout_supper()
        {
            var App = new word.Application(Visible = false);         
            if (_ingr_list_supper[23] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File8);
                                
                var namevr2 = cb_diets_vrach.Text;
                var namevr1 = this.cb_ok.Text;
                word1("[diet_vrach]", namevr2, word);
                word1("[head_vrach]", namevr1, word);

                for (int i = 1; i <= 8; i++)
                {
                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);

                    }

                    if (this.supper_food[i] != null)
                    {

                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;

                        word1("[Вес" + i + ":]", name1, word);

                        word1("[блюдо" + i + "]", name, word);

                        word1("[kol" + i + "]", name2, word);

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
                            var name2 = _menu_in_day[1].service;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {   var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {    if (this._count_serv != null)
                        {
                            var name2 = _count_serv.numb_men;

                            word1("[kol]", name2, word);

                        }

                    }

                    if (_ingr_list_all_day[i] != null)
                    {
                        var name5 = _ingr_list_all_day[i].name;
                        word1("[q" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[q" + i + "]", name5, word);
                    }

                    if (_obshves_all_day[i] != null)
                    {
                        var name5 = _obshves_all_day[i].net + " " +  "кг";
                        word1("[t" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[t" + i + "]", name5, word);
                    }
                }
                App.Visible = true;
                GC.Collect();
            }
            
            else
            {
                var word = App.Documents.Add(Application.StartupPath + File7);

                var namevr2 = cb_diets_vrach.Text;
                var namevr1 = this.cb_ok.Text;
                word1("[diet_vrach]", namevr2, word);
                word1("[head_vrach]", namevr1, word);

                for (int i = 1; i <= 8; i++)
                {
                    if (supper_food[i] == null)
                    {
                        var name = "";

                        word1("[блюдо" + i + "]", name, word);
                        word1("[Вес" + i + ":]", name, word);
                        word1("[kol" + i + "]", name, word);

                    }

                    if (this.supper_food[i] != null)
                    {

                        var name = supper_food[i].name;
                        var name2 = supper_food[i].count_portc;
                        var name1 = "Вес:" + " " + supper_food[i].weight;

                        word1("[Вес" + i + ":]", name1, word);

                        word1("[блюдо" + i + "]", name, word);

                        word1("[kol" + i + "]", name2, word);

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
                        word1("[q" + i + "]", name5.ToString(), word);

                    }
                    else
                    {
                        var name5 = "";
                        word1("[q" + i + "]", name5, word);
                    }
                    
                    if (_obshves_all_day[i] != null)
                    {
                        var name5= _obshves_all_day[i].net + " " +"кг";
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
                            var name2 = _menu_in_day[1].service;

                            word1("[date]", name2, word);
                        }
                    }
                    if (_count_serv == null)
                    {   var name2 = "";
                        word1("[kol]", name2, word);
                    }
                    else
                    {    if (this._count_serv != null)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((cb_ok.Text == "") || (cb_diets_vrach.Text == ""))
            {
                MessageBox.Show("Вы не выбрали того, кто утверждает меню-раскладку или того, кто составляет меню-раскладку !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (serve == "обед")
            {
                Report_Menu_dinner(); 
            }
              if (serve == "завтрак")
            {
                Report_MEnu_Layout_breakfast();
            }
              if (serve == "ужин")
              {
                  Report_MEnu_Layout_supper();
              }
                        
            GC.Collect();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
