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
        public class_ingr_in_food[] _ves;
        public class_ingr_in_food[] _ves2;
        public class_ingr_in_food[] _ves3;
        public class_ingr_in_food[] _ves4;
        public class_ingr_in_food[] _ves5;
        public class_ingr_in_food[] _ves6;
        public class_ingr_in_food[] _ves7;
        public class_ingr_in_food[] _ves8;
        public class_ingr_in_food[] _obshves;
        /// <summary>
        /// Это поле список людей работающих  в данной предметной области
        /// </summary>
        public class_person[] _person;

        private readonly string File = @"\1.docx";
        private readonly string File1 = @"\2.docx";
        private readonly string File3 = @"\3.docx";

        public class_food[] _food;
        public class_queue _count_serv;
       
        public class_menu_in_food[] _menu_in_day;
      
        public class_ingridients[] _ingr_list;
        public Menu_layout(int day,int queue)
        {
            AddDayID = day;
            queue_id = queue;
            InitializeComponent();
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
                Cb_diet_vrach2.Items.Clear();
                
            }
            for (int i = 1; i < this._person.Count(); i++)
            {
                if (this._person[i] != null)
                {

                    this.cb_ok.Items.Add(this._person[i].name.Trim() + " " + this._person[i].surname + " " + this._person[i].secondname);
                    this.cb_diets_vrach.Items.Add(this._person[i].name.Trim() + " " + this._person[i].surname + " " + this._person[i].secondname);
                    this.Cb_diet_vrach2.Items.Add(this._person[i].name.Trim() + " " + this._person[i].surname + " " + this._person[i].secondname);
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
            _ingr_list = get_ingr_list(AddDayID);
            _ves = get_ves_breakfast();
            _ves2 = get_ves_breakfast2();
            _ves3 = get_ves_breakfast3();
            _ves4 = get_ves_breakfast4();
            _ves5 = get_ves_breakfast5();
            _ves6 = get_ves_breakfast6();
            _ves7 = get_ves_breakfast7();
            _ves8 = get_ves_breakfast8();
            _obshves = get_sum_breakfast(AddDayID);
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
        public class_ingr_in_food[] get_ves_breakfast()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];

            if (_food[1] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '"+ AddDayID+"'";


                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'" + "and IIF.ID_food='" + _food[1].food_id + "'";
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

        public class_ingr_in_food[] get_ves_breakfast2()
        {
            class_ingr_in_food[] food = new class_ingr_in_food[512];
            if (_food[2] != null)
            {
                string query = "select IIF.Net_weight from Foods F " +
      " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
      " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
      " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id ='"+ AddDayID+"'" + " and IIF.ID_food='" + _food[2].food_id + "'"; ;


                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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



                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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



                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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

                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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



                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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



                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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



                if (_ingr_list == null) { _ingr_list = null; }
                else
                {
                    for (int i = 1; i < _ingr_list.Count(); i++)
                    {

                        if (_ingr_list[i] != null)
                        {
                            string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
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

        public void Report_MEnu_Layout()
        {

            var App = new word.Application(Visible = false);

            
            if (_ingr_list[23] != null)
            {
                var word = App.Documents.Add(Application.StartupPath + File3);

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
                    if (_ingr_list[i] == null)
                    {
                        var name = "";


                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list[i] != null)
                    {

                        var name = _ingr_list[i].name;


                        word1("[" + i + "]", name, word);
                    }

                    if (_ves[i] == null)
                    {
                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc));
                            word1("[v" + i + "]", nsme6.ToString(), word);
                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves2[i] != null)
                        {
                            var name5 = _ves2[i].net;
                            word1("[k" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3[i] != null)
                        {
                            var name5 = _ves3[i].net;
                            word1("[i" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves4[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves4[i] != null)
                        {
                            var name5 = _ves4[i].net;
                            word1("[z" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5[i] != null)
                        {
                            var name5 = _ves5[i].net;
                            word1("[x" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }

                    if (_ves5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5[i] != null)
                        {
                            var name5 = _ves5[i].net;
                            word1("[x" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }

                    if (_ves6[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6[i] != null)
                        {
                            var name5 = _ves6[i].net;
                            word1("[y" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7[i] != null)
                        {
                            var name5 = _ves7[i].net;
                            word1("[q" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8[i] != null)
                        {
                            var name5 = _ves8[i].net;
                            word1("[n" + i + "]", name5, word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }
                    }

                }

                App.Visible = true;
                GC.Collect();
            }
            else
            {
                var word = App.Documents.Add(Application.StartupPath + File1);

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

                    if (_ingr_list[i] == null)
                    {
                        var name = "";

                        word1("[" + i + "]", name, word);
                    }

                    if (this._ingr_list[i] != null)
                    {

                        var name = _ingr_list[i].name;


                        word1("[" + i + "]", name, word);
                    }


                    if (_ves[i] == null)
                    {

                        var name6 = "";
                        word1("[v" + i + "]", name6, word);
                    }
                    else
                    {

                        if (this._ves[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                            word1("[v" + i + "]", nsme6.ToString(), word);


                        }
                        else
                        {
                            var name6 = "";
                            word1("[v" + i + "]", name6, word);
                        }
                    }
                    if (_ves2[i] == null)
                    {

                        var name6 = "";
                        word1("[k" + i + "]", name6, word);
                    }

                    else
                    {

                        if (this._ves2[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves2[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                            word1("[k" + i + "]", nsme6.ToString(), word);


                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }

                    if (_ves3[i] == null)
                    {

                        var name6 = "";
                        word1("[i" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves3[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves3[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);

                            word1("[i" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[k" + i + "]", name6, word);
                        }
                    }
                    if (_ves4[i] == null)
                    {

                        var name6 = "";
                        word1("[z" + i + "]", name6, word);

                    }

                    else
                    {
                        if (this._ves4[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves4[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                            word1("[z" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[z" + i + "]", name6, word);
                        }
                    }
                    if (_ves5[i] == null)
                    {

                        var name6 = "";
                        word1("[x" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves5[i] != null)
                        {
                            var name5 = Convert.ToDouble(_ves5[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                            word1("[x" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[x" + i + "]", name6, word);
                        }
                    }


                    if (_ves6[i] == null)
                    {

                        var name6 = "";
                        word1("[y" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves6[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves6[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                            word1("[y" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[y" + i + "]", name6, word);
                        }
                    }

                    if (_ves7[i] == null)
                    {

                        var name6 = "";
                        word1("[q" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves7[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves7[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                            word1("[q" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[q" + i + "]", name6, word);
                        }
                    }

                    if (_ves8[i] == null)
                    {

                        var name6 = "";
                        word1("[n" + i + "]", name6, word);
                    }

                    else
                    {
                        if (this._ves8[i] != null)
                        {

                            var name5 = Convert.ToDouble(_ves8[i].net);
                            var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                            word1("[n" + i + "]", nsme6.ToString(), word);

                        }
                        else
                        {
                            var name6 = "";
                            word1("[n" + i + "]", name6, word);
                        }

                    }


                    if (_obshves[i] != null)
                    {
                        var name5 = _obshves[i].net;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ( (cb_ok.Text == "") || (cb_diets_vrach.Text == "") )
            {
                MessageBox.Show("Вы не выбрали того, кто утверждает меню-раскладку или того, кто составляет меню-раскладку !!!","Внимание !!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            
            }

            Report_MEnu_Layout();
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
