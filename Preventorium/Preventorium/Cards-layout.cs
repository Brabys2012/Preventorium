using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Библиотека работы с Word
using word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class Cards_layout : Form
    {
        /// <summary>
        /// Это поле содержит названия ингредиентов и id
        /// </summary>
        public class_ingridients[] _ingr_list;
        /// <summary>
        /// Эти поля содержат значения по ингридиентам, т.е белки ,жиры,углеводы, и т.д для каждого отдельного ингридиента в данном случае для первого
        /// </summary>
        public class_ingridients[] _ingr_list1;
        /// <summary>
        /// Значения для 2-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list2;
        /// <summary>
        /// Значения для 3-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list3;
        /// <summary>
        /// Значения для 4-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list4;
        /// <summary>
        /// Значения для 5-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list5;
        /// <summary>
        /// Значения для 6-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list6;
        /// <summary>
        /// Значения для 7-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list7;
        /// <summary>
        /// Значения для 8-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list8;
        /// <summary>
        /// Значения для 9-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list9;
        /// <summary>
        /// Значения для 10-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list10;
        /// <summary>
        /// Значения для 11-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list11;
        /// <summary>
        /// Значения для 12-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list12;
        /// <summary>
        /// Значения для 13-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list13;
        /// <summary>
        /// Значения для 14-го ингридиента и т.д
        /// </summary>
        public class_ingridients[] _ingr_list14;

        /// <summary>
        /// Эти поля содержат значения вес нетто/брутто блюда
        /// </summary>
        public class_ingr_food[] _ves_list;
        /// <summary>
        /// Вес брутто/нетто для 1-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list1;
        /// <summary>
        /// Вес брутто/нетто для 2-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list2;
        /// <summary>
        /// Вес брутто/нетто для 3-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list3;
        /// <summary>
        /// Вес брутто/нетто для 4-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list4;
        /// <summary>
        /// Вес брутто/нетто для 5-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list5;
        /// <summary>
        /// Вес брутто/нетто для 6-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list6;
        /// <summary>
        /// Вес брутто/нетто для 7-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list7;
        /// <summary>
        /// Вес брутто/нетто для 8-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list8;
        /// <summary>
        /// Вес брутто/нетто для 9-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list9;
        /// <summary>
        /// Вес брутто/нетто для 10-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list10;
        /// <summary>
        /// Вес брутто/нетто для 11-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list11;

        /// <summary>
        /// Вес брутто/нетто для 12-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list12;
        /// <summary>
        /// Вес брутто/нетто для 13-го блюда
        /// </summary>
        public class_ingr_food[] _ves_list13;

        /// <summary>
        /// Это поле содержит список блюд 
        /// </summary>
        public class_food[] _food_list;
        /// <summary>
        /// Это поле содержит значения имя блюда,общую калорийность и т.д
        /// </summary>
        public class_food[] _food_list1;

        public class_cards[] _food_list2;
        /// <summary>
        /// Это поле содержит id диеты по которому будем вытаскивать диеты
        /// </summary>
        public class_diet[] _idDiet;
        /// <summary>
        /// Это поле содержит  диеты
        /// </summary>

        public class_diet[] _Diet;
        /// <summary>
        /// Это поле список людей работающих  в данной предметной области
        /// </summary>
        public class_person[] _person;

        public class_book[] _foodyear;
        /// <summary>
        /// СОдержит id книги по которому ,будем вытаскивать книги
        /// </summary>
        public class_book[] _id_book;
        /// <summary>
        /// Поле Содержит атрибуты первой книги
        /// </summary>

        public class_book[] _book;
        /// <summary>
        /// Поле Содержит атрибуты 2-ой книги
        /// </summary>
        public class_book[] _book1;
        /// <summary>
        /// Поле Содержит атрибуты 3-ой книги
        /// </summary>
        public class_book[] _book2;
        /// <summary>
        /// Поле Содержит атрибуты 4-ой книги
        /// </summary>
        public class_book[] _book3;
        /// <summary>
        /// Поле Содержит атрибуты 5-ой книги
        /// </summary>
        public class_book[] _book4;
        /// <summary>
        /// Содержит значение: Имя блюда ,которое записывается через конструктор,когда пользователь нажимает создать картчку-раскладку в форме add_food
        /// </summary>
        public string foods;

        /// <summary>
        /// Содержит ФИО кто утверждает карту-раскладку
        /// </summary>
        public class_person _namevrach;
        /// <summary>
        /// Содержит ФИО кто составляет карту-раскладку
        /// </summary>
        public class_person _namevrach2;
        /// <summary>
        /// Содержит ФИО кто составляет карту-раскладку
        /// </summary>
        public class_person _namevrach3;


        /// <summary>
        /// Шаблон карточки раскладки в Word , который будем заполнять
        /// </summary>
        private readonly string File = @"\Reports\Карточка-раскладка.docx";

        /// <summary>
        /// Конструктор составления карточки-раскладки
        /// </summary>
        public Cards_layout()
        {         
            InitializeComponent();
        }
       
        /// <summary>
        /// Конструктор составления карточки-раскладки в который передается наименование блюда 
        /// </summary>
        /// <param name="food"></param>
        public Cards_layout(string food )
        {   foods = food;
            InitializeComponent();
            this.Text = "Формирование карточки-раскладки для блюда: " + foods;            
        }
        /// <summary>
        /// Событие которое выполянется при загрузке формы, в котором будет заполняться  комбобокс списками блюд 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {                       
            // Метод который содержит sql запрос ,который возвращает по имени блюда значения: наименование блюда и т.д
            this._food_list = this.food();
            // Метод заполняет комбобокс блюдами
            fill_foods_list();
            //В комбокс записывается имя блюда переданное через конструктор
            //cb_food.Text = foods;
            // Имя блюда подсвечивается в комбоксе чтобы пользователь не выбирал блюдо из списка
            cb_food.SelectedItem = foods;
        }
        /// <summary>
        /// Заполняет комбобокс списком рабочих в профилактории
        /// </summary>
        private void fill_person_list()
        {
            if (this._person != null)
            {   this.cb_ok.Items.Clear();
                this.cb_diets_vrach.Items.Clear();
                Cb_diet_vrach2.Items.Clear();
            }

            for (int i = 1; i < this._person.Count(); i++)
            {
                if (this._person[i] != null)
                {

                    this.cb_ok.Items.Add(this._person[i].post);
                    this.cb_diets_vrach.Items.Add(this._person[i].post);
                    this.Cb_diet_vrach2.Items.Add(this._person[i].post);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Метод содержит sql запрос,который возвращает список должностей
        /// </summary>
        /// <returns>имена,фамилии и т.д</returns>
        public class_person[] get_person_list()
        {
            class_person[] person = new class_person[512];
            string query = "select IDUsers,post  from Users ";
            
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
                   
                    person[i].post = rd.GetString(1).ToString();
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
        /// Метод содержит sql запрос,который возвращает Ф.И.О работающего в профике по должности,который утверждает карту-раскладку
        /// </summary>
        /// <returns>имена,фамилии и т.д</returns>
        public class_person get_person_name_vrach1()
        {
            class_person person = new class_person();
            string query = "select *  from Users where Post='"+ cb_ok.Text+"'";
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
                    if (rd.IsDBNull(4))
                    { person.surname = ""; }
                    else
                    {
                        person.surname = rd.GetString(4).ToString();
                    }

                    if (rd.IsDBNull(5))
                    { person.name = ""; }
                    else
                    {
                        person.name = rd.GetString(5).ToString();
                    }

                    if (rd.IsDBNull(6))
                    { person.secondname = ""; }
                    else
                    {
                        person.secondname = rd.GetString(6).ToString();
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


            return person;

        }
        /// <summary>
        /// Метод содержит sql запрос,который возвращает Ф.И.О работающего в профике по должности,который составляет карту-раскладку
        /// </summary>
        /// <returns></returns>
        public class_person get_person_name_vrach2()
        {
            class_person person = new class_person();
            string query = "select *  from Users where Post='" + cb_diets_vrach.Text + "'";
            string query2 = query;
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query2;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    person = new class_person();
                    person.result = "OK";
                    if (rd.IsDBNull(4))
                    { person.surname = ""; }
                    else
                    {
                        person.surname = rd.GetString(4).ToString();
                    }

                    if (rd.IsDBNull(5))
                    { person.name = ""; }
                    else
                    {
                        person.name = rd.GetString(5).ToString();
                    }

                    if (rd.IsDBNull(6))
                    { person.secondname = ""; }
                    else
                    {
                        person.secondname = rd.GetString(6).ToString();
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
            return person;
        }
        /// <summary>
        /// Метод содержит sql запрос,который возвращает Ф.И.О работающего в профике по должности,который составляет карту-раскладку
        /// </summary>
        public class_person get_person_name_vrach3()
        {
            class_person person = new class_person();
            string query = "select *  from Users where Post='" + Cb_diet_vrach2.Text + "'";
            string query2 = query;
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query2;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {

                    person = new class_person();
                    person.result = "OK";
                    if (rd.IsDBNull(4))
                    { person.surname = ""; }
                    else
                    {
                        person.surname = rd.GetString(4).ToString();
                    }

                    if (rd.IsDBNull(5))
                    { person.name = ""; }
                    else
                    {
                        person.name = rd.GetString(5).ToString();
                    }

                    if (rd.IsDBNull(6))
                    { person.secondname = ""; }
                    else
                    {
                        person.secondname = rd.GetString(6).ToString();
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
            return person;
        }
        /// <summary>
        /// Метод который по sql запросу возвращает наименование блюд
        /// </summary>
        /// <returns> имя блюда </returns>
        public class_food[] food()
        {
            class_food[] foods_list = new class_food[512];
            string query = "select *  from Foods ";
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
                    foods_list[i] = new class_food();
                    foods_list[i].result = "OK";
                    if (rd.IsDBNull(1))
                    { foods_list[i].name = ""; }
                    else
                    foods_list[i].name = rd.GetString(1).ToString();
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

            return foods_list;
        }

        /// <summary>
        /// Возвращает по наименованию блюда значения общий вес блюда и т.п
        /// </summary>
        /// <returns>Общий вес,общую калорийность и т.д </returns>
        public class_food[] food1()
        {
            class_food[] foods_list1 = new class_food[512];

            string query = "select *  from Foods where Name_food='";

            string query1 = this.cb_food.Text + "'";                      

            string query3 = query + query1; ;
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query3;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    foods_list1[i] = new class_food();
                    foods_list1[i].result = "OK";
                    
                    if (rd.IsDBNull(1))
                    {
                        foods_list1[i].food_id = ""; }
                    else
                    {
                        foods_list1[i].food_id = rd.GetInt32(0).ToString();
                    }

                    if (rd.IsDBNull(1))
                    {
                        foods_list1[i].name = "";
                    }
                    else
                    {
                        foods_list1[i].name = rd.GetString(1).ToString();
                    }

                    if (rd.IsDBNull(2))
                    {
                        foods_list1[i].calories = "0";
                    }
                    else
                    {
                        foods_list1[i].calories = rd.GetDouble(2).ToString();
                    }

                    if (rd.IsDBNull(3))
                    {
                        foods_list1[i].proteins = "0";
                    }
                    else
                    {
                        foods_list1[i].proteins = rd.GetDouble(3).ToString();
                    }

                    if (rd.IsDBNull(4))
                    {
                        foods_list1[i].fats = "0";
                    }
                    else
                    {
                        foods_list1[i].fats = rd.GetDouble(4).ToString();
                    }

                    if (rd.IsDBNull(5))
                    {
                        foods_list1[i].carbo = "0";
                    }
                    else
                    {
                        foods_list1[i].carbo = rd.GetDouble(5).ToString();
                    }

                    if (rd.IsDBNull(6))
                    {
                        foods_list1[i].weight = "0";
                    }
                    else
                    {
                        foods_list1[i].weight = rd.GetDouble(6).ToString();
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

            return foods_list1;
        }
        /// <summary>
        /// Возвращает id и название  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list()
        {
            class_ingridients[] ingr_list = new class_ingridients[512];

            string query = "select Foods.Name_food, ingridient_name, Ingridients.Id_ingridients, InF.ID_food from Ingridients join Ingridients_in_food InF on InF.Id_ingridients = Ingridients.Id_ingridients join Foods on Foods.ID_food = InF.ID_food";
            if (this.cb_food.Text != "")
                query += " where Foods.Name_food = '" + this.cb_food.Text + "'";
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
                    ingr_list[i] = new class_ingridients();
                    ingr_list[i].result = "OK";
                    if (rd.IsDBNull(1))
                    {
                        ingr_list[i].name = "";
                    }
                    else
                        ingr_list[i].name = rd.GetString(1).ToString();
                    if (rd.IsDBNull(2))
                    {
                        ingr_list[i].ingr_id = "";
                    }
                    else
                        ingr_list[i].ingr_id = rd.GetInt32(2).ToString();
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
        /// Возвращает сведения о жирах,белках,углеводах для 1-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list1()
        {   class_ingridients[] ingr_list = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
            // string query1 = cb_ingr1.Text + "'";
            // for (int k = 1; k < this._ingr_list.Count(); k++)

            if (this._ingr_list[1] != null)
            {
                string query1 = _ingr_list[1].name + "'";
                string query2 = query + query1;
                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list[i] = new class_ingridients();
                        ingr_list[i].result = "OK";
                        ingr_list[i].calories = rd.GetDouble(1).ToString();
                        ingr_list[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list[i].protein = rd.GetDouble(4).ToString();
                        ingr_list[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 2-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list2()
        {   class_ingridients[] get_ingr2 = new class_ingridients[512];
            
            string query = "select *  from Ingridients where ingridient_name='";
         
            if (this._ingr_list[2] != null)
            {               
                string query1 = _ingr_list[2].name + "'";
                string query2 = query + query1;
                try
                {    
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        get_ingr2[i] = new class_ingridients();
                        get_ingr2[i].result = "OK";

                        get_ingr2[i].calories = rd.GetDouble(1).ToString();
                        get_ingr2[i].uglevod = rd.GetDouble(2).ToString();
                        get_ingr2[i].zhiri = rd.GetDouble(3).ToString();
                        get_ingr2[i].protein = rd.GetDouble(4).ToString();
                        get_ingr2[i].ingr_id = rd.GetInt32(5).ToString();
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
            return get_ingr2;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 3-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list3()
        {
            class_ingridients[] ingr_list3 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                   
            if (this._ingr_list[3] != null)
            {
                string query1 = _ingr_list[3].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list3[i] = new class_ingridients();
                        ingr_list3[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();

                        ingr_list3[i].calories = rd.GetDouble(1).ToString();
                        ingr_list3[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list3[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list3[i].protein = rd.GetDouble(4).ToString();
                        ingr_list3[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list3;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 4-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list4()
        {  class_ingridients[] ingr_list4 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                        
            if (this._ingr_list[4] != null)
            {
                string query1 = _ingr_list[4].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list4[i] = new class_ingridients();
                        ingr_list4[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        ingr_list4[i].ingr_id = rd.GetInt32(5).ToString();
                        ingr_list4[i].calories = rd.GetDouble(1).ToString();
                        ingr_list4[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list4[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list4[i].protein = rd.GetDouble(4).ToString();
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
            return ingr_list4;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 5-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list5()
        {
            class_ingridients[] ingr_list5 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                   
            if (this._ingr_list[5] != null)
            {
                string query1 = _ingr_list[5].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list5[i] = new class_ingridients();
                        ingr_list5[i].result = "OK";

                        ingr_list5[i].calories = rd.GetDouble(1).ToString();
                        ingr_list5[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list5[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list5[i].protein = rd.GetDouble(4).ToString();
                        ingr_list5[i].ingr_id = rd.GetInt32(5).ToString();
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
            return ingr_list5;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для6-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list6()
        {   class_ingridients[] ingr_list6 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                       
            if (this._ingr_list[6] != null)
            {
                string query1 = _ingr_list[6].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list6[i] = new class_ingridients();
                        ingr_list6[i].result = "OK";
                        ingr_list6[i].calories = rd.GetDouble(1).ToString();
                        ingr_list6[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list6[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list6[i].protein = rd.GetDouble(4).ToString();
                        ingr_list6[i].ingr_id = rd.GetInt32(5).ToString();
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
            return ingr_list6;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 7-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list7()
        {   class_ingridients[] ingr_list7 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                   
            if (this._ingr_list[7] != null)
            {
                string query1 = _ingr_list[7].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list7[i] = new class_ingridients();
                        ingr_list7[i].result = "OK";
                        ingr_list7[i].calories = rd.GetDouble(1).ToString();
                        ingr_list7[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list7[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list7[i].protein = rd.GetDouble(4).ToString();
                        ingr_list7[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list7;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 8-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list8()
        {   class_ingridients[] ingr_list8 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                     
            if (this._ingr_list[8] != null)
            {
                string query1 = _ingr_list[8].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list8[i] = new class_ingridients();
                        ingr_list8[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list8[i].calories = rd.GetDouble(1).ToString();
                        ingr_list8[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list8[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list8[i].protein = rd.GetDouble(4).ToString();
                        ingr_list8[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list8;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 9-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list9()
        {   class_ingridients[] ingr_list9 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                     
            if (this._ingr_list[9] != null)
            {
                string query1 = _ingr_list[9].name + "'";

                string query2 = query + query1;
                      try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list9[i] = new class_ingridients();
                        ingr_list9[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list9[i].calories = rd.GetDouble(1).ToString();
                        ingr_list9[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list9[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list9[i].protein = rd.GetDouble(4).ToString();
                        ingr_list9[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list9;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 10-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list10()
        {

            class_ingridients[] ingr_list10 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                     
            if (this._ingr_list[10] != null)
            {
                string query1 = _ingr_list[10].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list10[i] = new class_ingridients();
                        ingr_list10[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list10[i].calories = rd.GetDouble(1).ToString();
                        ingr_list10[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list10[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list10[i].protein = rd.GetDouble(4).ToString();
                        ingr_list10[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list10;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 11-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list11()
        {   class_ingridients[] ingr_list11 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                     
            if (this._ingr_list[11] != null)
            {
                string query1 = _ingr_list[11].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list11[i] = new class_ingridients();
                        ingr_list11[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list11[i].calories = rd.GetDouble(1).ToString();
                        ingr_list11[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list11[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list11[i].protein = rd.GetDouble(4).ToString();
                        ingr_list11[i].ingr_id = rd.GetInt32(5).ToString();
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
            return ingr_list11;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 12-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list12()
        {  class_ingridients[] ingr_list12 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                      
            if (this._ingr_list[12] != null)
            {
                string query1 = _ingr_list[12].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list12[i] = new class_ingridients();
                        ingr_list12[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list12[i].calories = rd.GetDouble(1).ToString();
                        ingr_list12[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list12[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list12[i].protein = rd.GetDouble(4).ToString();
                        ingr_list12[i].ingr_id = rd.GetInt32(5).ToString();
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
            return ingr_list12;

        }
        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 13-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list13()
        {   class_ingridients[] ingr_list13 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";
                      
            if (this._ingr_list[13] != null)
            {
                string query1 = _ingr_list[13].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list13[i] = new class_ingridients();
                        ingr_list13[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list13[i].calories = rd.GetDouble(1).ToString();
                        ingr_list13[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list13[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list13[i].protein = rd.GetDouble(4).ToString();
                        ingr_list13[i].ingr_id = rd.GetInt32(5).ToString();
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

            return ingr_list13;

        }

        /// <summary>
        /// Возвращает сведения о жирах,белках,углеводах для 14-го  ингредиента
        /// </summary>
        public class_ingridients[] get_ingr_list14()
        {  class_ingridients[] ingr_list14 = new class_ingridients[512];
            string query = "select *  from Ingridients where ingridient_name='";

            if (this._ingr_list[14] != null)
            {
                string query1 = _ingr_list[14].name + "'";

                string query2 = query + query1;


                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();

                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        ingr_list14[i] = new class_ingridients();
                        ingr_list14[i].result = "OK";
                        // customers_list1[i].name = rd.GetString(0).ToString();
                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();
                        ingr_list14[i].calories = rd.GetDouble(1).ToString();
                        ingr_list14[i].uglevod = rd.GetDouble(2).ToString();
                        ingr_list14[i].zhiri = rd.GetDouble(3).ToString();
                        ingr_list14[i].protein = rd.GetDouble(4).ToString();
                        ingr_list14[i].ingr_id = rd.GetInt32(5).ToString();
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
            return ingr_list14;

        }

        /// <summary>
        /// Метод содержит sql запрос, который по id_food возвращает номер карточки-раскладки,метод приготовления блюда,цену блюда
        /// </summary>
        public class_cards[] food2()
        {
            class_cards[] card = new class_cards[512];

            string query = "select *  from Cards where ID_food='";

            for (int t = 1; t < this._food_list1.Count(); t++)

                if (this._food_list1[t] != null)
                {

                    string guer1 = this._food_list1[t].food_id;

                    string query4 = guer1 + "'";

                    string query2 = query + query4;
                    
                    try
                    {
                        SqlCommand com = Program.data_module._conn.CreateCommand();
                        com.CommandText = query2;

                        SqlDataReader rd = com.ExecuteReader();
                        int i = 0;
                        while (rd.Read())
                        {
                            i = i + 1;
                            card[i] = new class_cards();
                            card[i].result = "OK";
                            card[i].id = rd.GetInt32(0).ToString();
                            card[i].cost = rd.GetSqlMoney(2).ToString();
                            if (rd.IsDBNull(3))
                            { card[i].opis = ""; }
                            else
                            {
                                card[i].opis = rd.GetString(3);
                            }
                            card[i].nam_card = rd.GetString(4);

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
                } return card;
        }

        /// <summary>
        /// Возвращает вес брутто/нетто первого ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list()
        {  class_ingr_food[] ves_list = new class_ingr_food[512];
            string query = "select *  from Ingridients_in_food where Id_ingridients='";

                if (_ingr_list1 == null)
            {
                _ingr_list1 = null;

            }
            else
            {           
                if (this._ingr_list[1] != null)
                {

                    string guer = this._ingr_list[1].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";

                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {
                            string guer2 = this._food_list1[t].food_id;

                            string query4 = guer2 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list[i] = new class_ingr_food();
                                    ves_list[i].result = "OK";

                                    if (rd.IsDBNull(2))
                                    {
                                        ves_list[i].net = "0";
                                    }
                                    else
                                    {
                                        ves_list[i].net = rd.GetDouble(2).ToString();
                                    }

                                    if (rd.IsDBNull(1))
                                    {
                                        ves_list[i].bruto = "0";
                                    }
                                    else
                                    {
                                        ves_list[i].bruto = rd.GetDouble(1).ToString();   
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
                        }
                }
            }

            return ves_list;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто второго ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list1()
        {
            class_ingr_food[] ves_list2 = new class_ingr_food[512];
            
            string query = "select *  from Ingridients_in_food where Id_ingridients='";

               if (this._ingr_list[2] != null)
            {

                string guer = this._ingr_list[2].ingr_id;

                string query1 = guer + "'";

                string query3 = "and ID_food='";


                for (int t = 1; t < this._food_list1.Count(); t++)

                    if (this._food_list1[t] != null)
                    {

                        string guer1 = this._food_list1[t].food_id;

                        string query4 = guer1 + "'";

                        string query2 = query + query1 + query3 + query4;

                        try
                        {
                            SqlCommand com = Program.data_module._conn.CreateCommand();
                            com.CommandText = query2;
                            SqlDataReader rd = com.ExecuteReader();

                            int i = 0;
                            while (rd.Read())
                            {
                                i = i + 1;
                                ves_list2[i] = new class_ingr_food();
                                ves_list2[i].result = "OK";

                                if (rd.IsDBNull(2))
                                {
                                    ves_list2[i].net = "0";
                                }
                                else
                                {
                                    ves_list2[i].net = rd.GetDouble(2).ToString();
                                }

                                if (rd.IsDBNull(1))
                                {
                                    ves_list2[i].bruto = "0";
                                }
                                else
                                {
                                    ves_list2[i].bruto = rd.GetDouble(1).ToString();
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
                    }
            }

            return ves_list2;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 3-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list2()
        {class_ingr_food[] ves_list2 = new class_ingr_food[512];
              string query = "select *  from Ingridients_in_food where Id_ingridients='";

            if (_ingr_list3 == null)
            {
                _ingr_list3 = null;

            }
            else
            {

                for (int k = 1; k < this._ingr_list3.Count(); k++)

                    if (this._ingr_list3[k] != null)
                    {
                        string g = this._ingr_list3[k].ingr_id;

                        string query1 = g + "'";

                        string query3 = "and ID_food='";


                        for (int t = 1; t < this._food_list1.Count(); t++)

                            if (this._food_list1[t] != null)
                            {

                                string guer1 = this._food_list1[t].food_id;

                                string query4 = guer1 + "'";

                                string query2 = query + query1 + query3 + query4;
                                
                                try
                                {
                                    SqlCommand com = Program.data_module._conn.CreateCommand();
                                    com.CommandText = query2;
                                    SqlDataReader rd = com.ExecuteReader();

                                    int i = 0;
                                    while (rd.Read())
                                    {
                                        i = i + 1;
                                        ves_list2[i] = new class_ingr_food();
                                        ves_list2[i].result = "OK";

                                        if (rd.IsDBNull(2))
                                        {
                                            ves_list2[i].net = "0";
                                        }
                                        else
                                        {
                                            ves_list2[i].net = rd.GetDouble(2).ToString();
                                        }

                                        if (rd.IsDBNull(1))
                                        {
                                            ves_list2[i].bruto = "0";
                                        }
                                        else
                                        {
                                            ves_list2[i].bruto = rd.GetDouble(1).ToString();
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
                            }
                    }
            }
            return ves_list2;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 4-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list3()
        {    class_ingr_food[] ves_list3 = new class_ingr_food[512];
            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            if (_ingr_list4 == null)
            {
                _ingr_list4 = null;

            }
            else
            {
                for (int k = 1; k < this._ingr_list4.Count(); k++)

                    if (this._ingr_list4[k] != null)
                    {

                        string guer = this._ingr_list4[k].ingr_id;

                        string query1 = guer + "'";

                        string query3 = "and ID_food='";

                        for (int t = 1; t < this._food_list1.Count(); t++)

                            if (this._food_list1[t] != null)
                            {

                                string guer1 = this._food_list1[t].food_id;

                                string query4 = guer1 + "'";

                                string query2 = query + query1 + query3 + query4;

                                try
                                {
                                    SqlCommand com = Program.data_module._conn.CreateCommand();
                                    com.CommandText = query2;
                                    SqlDataReader rd = com.ExecuteReader();

                                    int i = 0;
                                    while (rd.Read())
                                    {
                                        i = i + 1;
                                        ves_list3[i] = new class_ingr_food();
                                        ves_list3[i].result = "OK";
                                        if (rd.IsDBNull(2))
                                        {
                                            ves_list3[i].net = "0";
                                        }
                                        else
                                        {
                                            ves_list3[i].net = rd.GetDouble(2).ToString();
                                        }

                                        if (rd.IsDBNull(1))
                                        {
                                            ves_list3[i].bruto = "0";
                                        }
                                        else
                                        {
                                            ves_list3[i].bruto = rd.GetDouble(1).ToString();
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
                            }
                    }
            }
            return ves_list3;
        }

        /// <summary>
        /// Возвращает вес брутто/нетто 5-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list4()
        {
            class_ingr_food[] ves_list4 = new class_ingr_food[512];
            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            if (_ingr_list5 == null)
            {
                _ingr_list5 = null;

            }
            else
            {
                for (int k = 1; k < this._ingr_list5.Count(); k++)

                    if (this._ingr_list5[k] != null)
                    {
                        string guer = this._ingr_list5[k].ingr_id;

                        string query1 = guer + "'";

                        string query3 = "and ID_food='";


                        for (int t = 1; t < this._food_list1.Count(); t++)

                            if (this._food_list1[t] != null)
                            {

                                string guer1 = this._food_list1[t].food_id;

                                string query4 = guer1 + "'";

                                string query2 = query + query1 + query3 + query4;

                                try
                                {
                                    SqlCommand com = Program.data_module._conn.CreateCommand();
                                    com.CommandText = query2;
                                    SqlDataReader rd = com.ExecuteReader();

                                    int i = 0;
                                    while (rd.Read())
                                    {
                                        i = i + 1;
                                        ves_list4[i] = new class_ingr_food();
                                        ves_list4[i].result = "OK";

                                        ves_list4[i].net = rd.GetDouble(2).ToString();
                                        ves_list4[i].bruto = rd.GetDouble(1).ToString();
                                        // customers_list1[i].name = rd.GetString(0).ToString();
                                        // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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
            return ves_list4;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 6-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list5()
        {  class_ingr_food[] ves_list5 = new class_ingr_food[512];
             string query = "select *  from Ingridients_in_food where Id_ingridients='";
              for (int k = 1; k < this._ingr_list6.Count(); k++)

                if (this._ingr_list6[k] != null)
                {
                    string guer = this._ingr_list6[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list5[i] = new class_ingr_food();
                                    ves_list5[i].result = "OK";

                                    ves_list5[i].net = rd.GetDouble(2).ToString();
                                    ves_list5[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list5;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 7-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list6()
        {
            class_ingr_food[] ves_list6 = new class_ingr_food[512];

            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            for (int k = 1; k < this._ingr_list7.Count(); k++)

                if (this._ingr_list7[k] != null)
                {

                    string guer = this._ingr_list7[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";

                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list6[i] = new class_ingr_food();
                                    ves_list6[i].result = "OK";

                                    ves_list6[i].net = rd.GetDouble(2).ToString();
                                    ves_list6[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list6;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 8-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list7()
        {

            class_ingr_food[] ves_list7 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            for (int k = 1; k < this._ingr_list8.Count(); k++)

                if (this._ingr_list8[k] != null)
                {

                    string g = this._ingr_list8[k].ingr_id;

                    string query1 = g + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list7[i] = new class_ingr_food();
                                    ves_list7[i].result = "OK";

                                    ves_list7[i].net = rd.GetDouble(2).ToString();
                                    ves_list7[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list7;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 9-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list8()
        {

            class_ingr_food[] ves_list8 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            for (int k = 1; k < this._ingr_list9.Count(); k++)

                if (this._ingr_list9[k] != null)
                {

                    string guer = this._ingr_list9[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";
                    

                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list8[i] = new class_ingr_food();
                                    ves_list8[i].result = "OK";

                                    ves_list8[i].net = rd.GetDouble(2).ToString();
                                    ves_list8[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list8;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 10-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list9()
        {

            class_ingr_food[] ves_list9 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            for (int k = 1; k < this._ingr_list10.Count(); k++)

                if (this._ingr_list10[k] != null)
                {

                    string guer = this._ingr_list10[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list9[i] = new class_ingr_food();
                                    ves_list9[i].result = "OK";

                                    ves_list9[i].net = rd.GetDouble(2).ToString();
                                    ves_list9[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list9;
          }
        /// <summary>
        /// Возвращает вес брутто/нетто 11-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list10()
        {

            class_ingr_food[] ves_list10 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";



            for (int k = 1; k < this._ingr_list11.Count(); k++)

                if (this._ingr_list11[k] != null)
                {

                    string guer = this._ingr_list11[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list10[i] = new class_ingr_food();
                                    ves_list10[i].result = "OK";

                                    ves_list10[i].net = rd.GetDouble(2).ToString();
                                    ves_list10[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list10;

       }

        /// <summary>
        /// Возвращает вес брутто/нетто 12-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list11()
        {

            class_ingr_food[] ves_list11 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";

            for (int k = 1; k < this._ingr_list12.Count(); k++)

                if (this._ingr_list12[k] != null)
                {

                    string guer = this._ingr_list12[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list11[i] = new class_ingr_food();
                                    ves_list11[i].result = "OK";

                                    ves_list11[i].net = rd.GetDouble(2).ToString();
                                    ves_list11[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list11;
        }

        /// <summary>
        /// Возвращает вес брутто/нетто 13-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list12()
        {

            class_ingr_food[] ves_list13 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";



            for (int k = 1; k < this._ingr_list13.Count(); k++)

                if (this._ingr_list13[k] != null)
                {

                    string guer = this._ingr_list13[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list13[i] = new class_ingr_food();
                                    ves_list13[i].result = "OK";
                                    ves_list13[i].net = rd.GetDouble(2).ToString();
                                    ves_list13[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list13;

        }
        /// <summary>
        /// Возвращает вес брутто/нетто 14-го ингредиента определенного блюда
        /// </summary>
        public class_ingr_food[] ves_list13()
        {

            class_ingr_food[] ves_list14 = new class_ingr_food[512];


            string query = "select *  from Ingridients_in_food where Id_ingridients='";



            for (int k = 1; k < this._ingr_list14.Count(); k++)

                if (this._ingr_list14[k] != null)
                {

                    string guer = this._ingr_list14[k].ingr_id;

                    string query1 = guer + "'";

                    string query3 = "and ID_food='";


                    for (int t = 1; t < this._food_list1.Count(); t++)

                        if (this._food_list1[t] != null)
                        {

                            string guer1 = this._food_list1[t].food_id;

                            string query4 = guer1 + "'";

                            string query2 = query + query1 + query3 + query4;

                            try
                            {
                                SqlCommand com = Program.data_module._conn.CreateCommand();
                                com.CommandText = query2;
                                SqlDataReader rd = com.ExecuteReader();

                                int i = 0;
                                while (rd.Read())
                                {
                                    i = i + 1;
                                    ves_list14[i] = new class_ingr_food();
                                    ves_list14[i].result = "OK";
                                    ves_list14[i].net = rd.GetDouble(2).ToString();
                                    ves_list14[i].bruto = rd.GetDouble(1).ToString();
                                    // customers_list1[i].name = rd.GetString(0).ToString();
                                    // customers_list1[i].ingr_id = rd.GetInt32(1).ToString();

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

            return ves_list14;
            
        }
              
        /// <summary>
        /// Метод заполняет комбобокс блюдами
        /// </summary>
        private void fill_foods_list()
        {
           
            for (int i = 1; i < this._food_list.Count(); i++)
            {
                if (this._food_list[i] != null)
                {

                    this.cb_food.Items.Add(this._food_list[i].name.Trim());
                     }
                else
                {
                    break;
                }
                
            }
           
        }
        /// <summary>
        /// Событие при нажатии кнопки создать карточку-раскладку, там происходит открытие шаблона и замена меток на переменные , значения которых получаются в результате SQL запроса
        /// Смысл в том,что если переменная в результате SQL- запроса получает NULL,то метки заменяем на пробелы, а если получает какие-то значения ,то соответсвенно заменяем метки на значения этой переменной. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
           
        public void bt_ok_Click(object sender, EventArgs e)
        {
            //Проверяем выбрал ли пользователь все необходимые данные, для составления карточки-раскладки 
            if ((cb_food.Text == "") || (cb_ok.Text=="") || (cb_diets_vrach.Text == "") && (Cb_diet_vrach2.Text == ""))
            {
                MessageBox.Show("Вы не выбрали того,кто утвержадет карточку-раскладку или ответственного за диеты !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Запускаем Word       
            var App = new word.Application();
            // Скрываем Word чтобы пользователь не видел,как заполняется шаблон
            App.Visible = false;

            // Открываем шаблон по указанному пути
            var word = App.Documents.Add(Application.StartupPath + File);

            //Записываем в переменую наименование блюда с комбокса
            var bludo = this.cb_food.Text;
            
            //Заменяем метку на  переменую наименование блюда с комбокса
             word1("{bludo}", bludo, word);            
          
            //Если запрос вернул пустое поле,то заменяем метку на пробел 
            if (_namevrach == null)
            {
                var name = "";
                word1("{namevrach}", name, word);              
            }
           
            //Если запрос вернул значение ФИО ,то заменяем метку на это значение 
            if (this._namevrach != null)
            {
                word1("{namevrach}", _namevrach.surname + " " + _namevrach.name + " " + _namevrach.secondname, word);
            }

            //Аналогично выше написанному
            if (_namevrach2 == null)
            {
                var name = "";
                word1("[sister]", name, word);
            }

            if (this._namevrach2 != null)
            {
                word1("[sister]", _namevrach2.surname + " " + _namevrach2.name + " " + _namevrach2.secondname, word);
            }

            if (_namevrach3 == null)
            {
                var name = "";
                word1("[doctor]", name, word);

            }

            if (this._namevrach3 != null)
            {
                word1("[doctor]", _namevrach3.surname + " " + _namevrach3.name + " " + _namevrach3.secondname, word);
            }

            //Если запрос вернул пустое поле,то заменяем метку на пробел 
            if (_book[1] == null)
            {
                var name = "";            
                word1("[book]",name, word);              
            }
            //Если запрос вернул значения о кулинарной книге ,то заменяем метку на эти значения 
            if (this._book[1] != null)
            {
                var name = "Автор:" + _book[1].author + "  " + " Название: " + _book[1].name + "  " + "Год: " + _book[1].year;

                var name1 = _book[1].year;
                word1("[book]", name, word);
               
            }
                       
                if (_foodyear[1] == null)
                {
                    var name = "";
                    word1("[year]", name, word);
                }
                //Если запрос вернул максимальную дату выпуска  кулинарной книги ,то заменяем метку на это значение 
                   if (this._foodyear[1] != null)
                {
                      var name1 = _foodyear[1].year;
                    word1("[year]", name1, word);

                }
                             
            if (_book1[1] == null)
            {
                var name = "";
                var name1 = "";

                word1("[year2]", name1, word);
                word1("[book2]", name, word);
            }

            if (this._book1[1] != null)
            {

                var name = "Автор:" + _book1[1].author + "  " + " Название: " + _book1[1].name + "  " + "Год: " + _book1[1].year;

                var name1 = _book1[1].year;

                   word1("[book2]", name, word);
            }
           

            if (_book2[1] == null)
            {
                var name = "";
                var name1 = "";

                word1("[year3]", name1, word);
                word1("[book3]", name, word);
            }

            if (this._book2[1] != null)
            {

                var name = "Автор:" + _book2[1].author + "  " + " Название: " + _book2[1].name + "  " + "Год: " + _book2[1].year;
                        
                word1("[book3]", name, word);
            }

            if (_book3[1] == null)
            {
                var name = "";
                                
                word1("[book4]", name, word);
            }

            if (this._book3[1] != null)
            {
                var name = "Автор: " + _book3[1].author + "  " + " Название: " + _book3[1].name + "  " + "Год: " + _book3[1].year;
                
                word1("[book4]", name, word);
            }

            if (_book4[1] == null)
            {
                var name = "";
                  word1("[book5]", name, word);
            }

            if (this._book4[1] != null)
            {
                var name = "Автор:" + _book4[1].author + "  " + " Название: " + _book4[1].name + "  " + "Год: " + _book4[1].year;

                word1("[book5]", name, word);
            }

            //Если запрос вернул пустое значение наименования ингредиента ,то заменяем метку на пробел
            if (_ingr_list[1] == null)
            {
                var name = "";                
                word1("[i]", name, word);
            }

            //Если запрос вернул значение: наименование ингредиента,то заменяем метку на это значение
            if (this._ingr_list[1] != null)
            { 
                var name = _ingr_list[1].name;
                 word1("[i]", name, word);
            }

            //Цикл для заполнения меток в шаблоне, т.к метки имеют вид [i1]  и т.д. НАчинаем цикл с двух т.к первая метка имеет вид [i] 
            for (int i = 2; i <= 14; i++)
            {
                //Если запрос вернул пустое значение наименования ингредиента ,то заменяем метку на пробел
                if (_ingr_list[i] == null)
                {
                    var name2 = "";
                    word1("[i"+i+"]", name2, word);
                }
                else
                { //Если запрос вернул значение: наименование ингредиента,то заменяем метку на это значение 
                    if (this._ingr_list[i] != null)
                    {
                        var name2 = _ingr_list[i].name;
                        word1("[i" + i + "]", name2, word);
                    }

                }
            }

            //Если запрос вернул пустое значение номер диеты ,то заменяем метку на пробел
            if (_Diet[1] == null)
            {
                var diet1 = "";
                word1("[d]", diet1, word);
            }

            //Если запрос вернул значение: номер диеты ,то заменяем метку на это значение 
            if (this._Diet[1] != null)
            {
                var diet1 = _Diet[1].numbDiet;
                word1("[d]", diet1, word);
            }
                     
           
                if (_Diet[2] == null)
                {
                    var name = "";
                    word1("[d1]", name, word);
                }

                else
                    if (this._Diet[2] != null)
                    {

                        var diet2 = _Diet[2].numbDiet;
                        word1("[d1]", diet2, word);
                    }
           

            if (_Diet[3] == null)
            {
                var diet3 = "";

                word1("[d2]", diet3, word);
            }
            else
            {
                if (this._Diet[3] != null)
                {

                    var diet3 = _Diet[3].numbDiet;


                    word1("[d2]", diet3, word);
                }
            }


            if (_Diet[4] == null)
            {
                var diet4 = "";


                word1("[d3]", diet4, word);
            }
            else
            {
                if (this._Diet[4] != null)
                {

                    var diet4 = _Diet[4].numbDiet;


                    word1("[d3]", diet4, word);
                }
            }

            if (_Diet[5] == null)
            {
                var diet5 = "";


                word1("[d4]", diet5, word);
            }
            else
            {
                if (this._Diet[5] != null)
                {

                    var diet5 = _Diet[5].numbDiet;


                    word1("[d4]", diet5, word);
                }
            }


            if (_Diet[6] == null)
            {
                var diet6 = "";


                word1("[d5]", diet6, word);
            }
            else
            {
                if (this._Diet[6] != null)
                {

                    var diet6 = _Diet[6].numbDiet;


                    word1("[d5]", diet6, word);
                }
            }


            if (_Diet[7] == null)
            {
                var diet7 = "";


                word1("[d6]", diet7, word);
            }
            else
            {
                if (this._Diet[7] != null)
                {

                    var diet7 = _Diet[7].numbDiet;


                    word1("[d6]", diet7, word);
                }
            }


            if (_Diet[8] == null)
            {
                var diet9 = "";


                word1("[d7]", diet9, word);
            }
            else
            {
                if (this._Diet[8] != null)
                {

                    var diet10 = _Diet[8].numbDiet;


                    word1("[d7]", diet10, word);
                }
            }


            if (_Diet[9] == null)
            {
                var diet10 = "";


                word1("[d8]", diet10, word);
            }
            else
            {
                if (this._Diet[9] != null)
                {

                    var diet10 = _Diet[9].numbDiet;


                    word1("[d8]", diet10, word);
                }
            }



            if (_Diet[10] == null)
            {
                var diet11 = "";


                word1("[d9]", diet11, word);
            }
            else
            {
                if (this._Diet[10] != null)
                {

                    var diet11 = _Diet[10].numbDiet;


                    word1("[d9]", diet11, word);
                }
            }



            if (_Diet[11] == null)
            {
                var diet12 = "";


                word1("[d10]", diet12, word);
            }
            else
            {
                if (this._Diet[11] != null)
                {

                    var diet12 = _Diet[11].numbDiet;


                    word1("[d10]", diet12, word);
                }
            }

            if (_Diet[12] == null)
            {
                var diet12 = "";


                word1("[d11]", diet12, word);
            }
            else
            {
                if (this._Diet[12] != null)
                {

                    var diet12 = _Diet[12].numbDiet;


                    word1("[d11]", diet12, word);
                }
            }
          

            if (_Diet[13] == null)
            {
                var diet13 = "";


                word1("[d12]", diet13, word);
            }
            else
            {
                if (this._Diet[13] != null)
                {

                    var diet13 = _Diet[13].numbDiet;


                    word1("[d12]", diet13, word);
                }
            }
            if (_Diet[14] == null)
            {
                var diet14 = "";


                word1("[d13]", diet14, word);
            }
            else
            {
                if (this._Diet[14] != null)
                {

                    var diet14 = _Diet[14].numbDiet;


                    word1("[d13]", diet14, word);
                }
            }
            if (_Diet[15] == null)
            {
                var diet15 = "";


                word1("[d14]", diet15, word);
            }
            else
            {
                if (this._Diet[15] != null)
                {

                    var diet15 = _Diet[15].numbDiet;


                    word1("[d14]", diet15, word);
                }
            }
            if (_Diet[16] == null)
            {
                var diet16 = "";


                word1("[d15]", diet16, word);
            }
            else
            {
                if (this._Diet[16] != null)
                {

                    var diet16 = _Diet[16].numbDiet;


                    word1("[d15]", diet16, word);
                }
            }
            if (_Diet[17] == null)
            {
                var diet17 = "";


                word1("[d16]", diet17, word);
            }
            else
            {
                if (this._Diet[17] != null)
                {

                    var diet18 = _Diet[17].numbDiet;


                    word1("[d16]", diet18, word);
                }
            }
            if (_Diet[18] == null)
            {
                var diet18 = "";


                word1("[d17]", diet18, word);
            }
            else
            {
                if (this._Diet[18] != null)
                {

                    var diet19 = _Diet[18].numbDiet;


                    word1("[d17]", diet19, word);
                }
            }

            if (_Diet[19] == null)
            {
                var diet19 = "";


                word1("[d18]", diet19, word);
            }
            else
            {
                if (this._Diet[19] != null)
                {

                    var diet19 = _Diet[19].numbDiet;


                    word1("[d18]", diet19, word);
                }
            }

            if (_Diet[20] == null)
            {
                var diet20 = "";


                word1("[d19]", diet20, word);
            }
            else
            {
                if (this._Diet[20] != null)
                {

                    var diet20 = _Diet[20].numbDiet;


                    word1("[d19]", diet20, word);
                }
            }


            if (_Diet[21] == null)
            {
                var diet21 = "";


                word1("[d20]", diet21, word);
            }
            else
            {
                if (this._Diet[21] != null)
                {

                    var diet21 = _Diet[21].numbDiet;


                    word1("[d20]", diet21, word);
                }
            }
                                   
            if (_ingr_list1[1] == null)
            {
                var cal = "";
                var prot = "";
                var ugl = "";
                var zhiri = "";

                word1("[k]", cal, word);
                word1("[u]", ugl, word);
                word1("[b]", prot, word);
                word1("[z]", zhiri, word);
            }
            else
            {              
                    if (this._ingr_list1[1] != null)
                    {
                        var cal = this._ingr_list1[1].calories;
                        var prot = this._ingr_list1[1].protein;
                        var ugl = this._ingr_list1[1].uglevod;
                        var zhiri = this._ingr_list1[1].zhiri;

                        word1("[k]", cal, word);
                        word1("[u]", ugl, word);
                        word1("[b]", prot, word);
                        word1("[z]", zhiri, word);
                    }                
            }

            if (_ingr_list2[1] == null)
            {
                var cal2 = "";
                var prot2 = "";
                var ugl2 = "";
                var zhiri2 = "";

                word1("[k2]", cal2, word);
                word1("[u2]", ugl2, word);
                word1("[b2]", prot2, word);
                word1("[z2]", zhiri2, word);

            }
            else
            {             
                    if (this._ingr_list2[1] != null)
                    {
                        var cal2 = this._ingr_list2[1].calories;
                        var prot2 = this._ingr_list2[1].protein;
                        var ugl2 = this._ingr_list2[1].uglevod;

                        var zhiri2 = this._ingr_list2[1].zhiri;
                        word1("[k2]", cal2, word);
                        word1("[u2]", ugl2, word);
                        word1("[b2]", prot2, word);
                        word1("[z2]", zhiri2, word);
                    }
                
            }
            
            if (_ingr_list3[1] == null)
            {
                var cal3 = "";
                var prot3 = "";
                var ugl3 = "";
                var zhiri3 = "";

                word1("[k3]", cal3, word);
                word1("[u3]", ugl3, word);
                word1("[b3]", prot3, word);
                word1("[z3]", zhiri3, word);
            }
            else
            {               
                    if (this._ingr_list3[1] != null)
                    {   var cal3 = this._ingr_list3[1].calories.Trim();
                        var prot3 = this._ingr_list3[1].protein;
                        var ugl3 = this._ingr_list3[1].uglevod;

                        var zhiri3 = this._ingr_list3[1].zhiri;

                        word1("[k3]", cal3, word);
                        word1("[u3]", ugl3, word);
                        word1("[b3]", prot3, word);
                        word1("[z3]", zhiri3, word);
                    }
                
            }
            
            if (_ingr_list4[1] == null)
            {
                var cal4 = "";
                var prot4 = "";
                var ugl4 = "";
                var zhiri4 = "";

                word1("[k4]", cal4, word);
                word1("[u4]", ugl4, word);
                word1("[b4]", prot4, word);
                word1("[z4]", zhiri4, word);
            }
            else
            { 
                    if (this._ingr_list4[1] != null)
                    {
                        var cal4 = this._ingr_list4[1].calories.Trim();
                        var prot4 = this._ingr_list4[1].protein;
                        var ugl4 = this._ingr_list4[1].uglevod;
                        var zhiri4 = this._ingr_list4[1].zhiri;

                        word1("[k4]", cal4, word);
                        word1("[u4]", ugl4, word);
                        word1("[b4]", prot4, word);
                        word1("[z4]", zhiri4, word);
                    }                
            }

            if (_ingr_list5[1] == null)
            {
                var cal5 = "";
                var prot5 = "";
                var ugl5 = "";
                var zhiri5 = "";

                word1("[k5]", cal5, word);
                word1("[u5]", ugl5, word);
                word1("[b5]", prot5, word);
                word1("[z5]", zhiri5, word);
            }
            else
            {        if (this._ingr_list5[1] != null)
                    {
                        var cal5 = this._ingr_list5[1].calories.Trim();
                        var prot5 = this._ingr_list5[1].protein;
                        var ugl5 = this._ingr_list5[1].uglevod;
                        var zhiri5 = this._ingr_list5[1].zhiri;

                        word1("[k5]", cal5, word);
                        word1("[u5]", ugl5, word);
                        word1("[b5]", prot5, word);
                        word1("[z5]", zhiri5, word);
                    }
            }

            if (_ingr_list6[1] == null)
            {
                var cal6 = "";
                var prot6 = "";
                var ugl6 = "";
                var zhiri6 = "";

                word1("[k6]", cal6, word);
                word1("[u6]", ugl6, word);
                word1("[b6]", prot6, word);
                word1("[z6]", zhiri6, word);
            }
            else
            {    if (this._ingr_list6[1] != null)
                    {
                        var cal6 = this._ingr_list6[1].calories.Trim();
                        var prot6 = this._ingr_list6[1].protein;
                        var ugl6 = this._ingr_list6[1].uglevod;
                        var zhiri6 = this._ingr_list6[1].zhiri;

                        word1("[k6]", cal6, word);
                        word1("[u6]", ugl6, word);
                        word1("[b6]", prot6, word);
                        word1("[z6]", zhiri6, word);
                    }
                
            }

            if (_ingr_list7[1] == null)
            {
                var cal7 = "";
                var prot7 = "";
                var ugl7 = "";
                var zhiri7 = "";

                word1("[k7]", cal7, word);
                word1("[u7]", ugl7, word);
                word1("[b7]", prot7, word);
                word1("[z7]", zhiri7, word);
            }
            else
            {       if (this._ingr_list7[1] != null)
                    {
                        var cal7 = this._ingr_list7[1].calories.Trim();
                        var prot7 = this._ingr_list7[1].protein;
                        var ugl7 = this._ingr_list7[1].uglevod;
                        var zhiri7 = this._ingr_list7[1].zhiri;

                        word1("[k7]", cal7, word);
                        word1("[u7]", ugl7, word);
                        word1("[b7]", prot7, word);
                        word1("[z7]", zhiri7, word);
                    }              
            }

            if (_ingr_list8[1] == null)
            {
                var cal8 = "";
                var prot8 = "";
                var ugl8 = "";
                var zhiri8 = "";

                word1("[k8]", cal8, word);
                word1("[u8]", ugl8, word);
                word1("[b8]", prot8, word);
                word1("[z8]", zhiri8, word);
            }
            else
            {     if (this._ingr_list8[1] != null)
                    {
                        var cal8 = this._ingr_list8[1].calories.Trim();
                        var pro8 = this._ingr_list8[1].protein;
                        var ugl8 = this._ingr_list8[1].uglevod;
                        var zhiri8 = this._ingr_list8[1].zhiri;

                        word1("[k8]", cal8, word);
                        word1("[u8]", ugl8, word);
                        word1("[b8]", pro8, word);
                        word1("[z8]", zhiri8, word);
                    }
                
            }

            if (_ingr_list9[1] == null)
            {
                var cal9 = "";
                var prot9 = "";
                var ugl9 = "";
                var zhiri9 = "";

                word1("[k9]", cal9, word);
                word1("[u9]", ugl9, word);
                word1("[b9]", prot9, word);
                word1("[z9]", zhiri9, word);
            }
            else
            {
                if (this._ingr_list9[1] != null)
                    {
                        var cal9 = this._ingr_list9[1].calories.Trim();
                        var prot9 = this._ingr_list9[1].protein;
                        var ugl9 = this._ingr_list9[1].uglevod;
                        var zhiri9 = this._ingr_list9[1].zhiri;

                        word1("[k9]", cal9, word);
                        word1("[u9]", ugl9, word);
                        word1("[b9]", prot9, word);
                        word1("[z9]", zhiri9, word);
                    }
                
            }


            if (_ingr_list10[1] == null)
            {
                var cal10 = "";
                var prot10 = "";
                var ugl10 = "";
                var zhiri10 = "";

                word1("[k10]", cal10, word);
                word1("[u10]", ugl10, word);
                word1("[b10]", prot10, word);
                word1("[z10]", zhiri10, word);
            }
            else
            {
                if (this._ingr_list10[1] != null)
                    {
                        var cal10 = this._ingr_list10[1].calories.Trim();
                        var prot10 = this._ingr_list10[1].protein;
                        var ugl10 = this._ingr_list10[1].uglevod;
                        var zhiri10 = this._ingr_list10[1].zhiri;

                        word1("[k10]", cal10, word);
                        word1("[u10]", ugl10, word);
                        word1("[b10]", prot10, word);
                        word1("[z10]", zhiri10, word);
                    }
                
            }

            if (_ingr_list11[1] == null)
            {
                var cal11 = "";
                var prot11 = "";
                var ugl11 = "";
                var zhiri11 = "";

                word1("[k11]", cal11, word);
                word1("[u11]", ugl11, word);
                word1("[b11]", prot11, word);
                word1("[z11]", zhiri11, word);
            }
            else
            {
                if (this._ingr_list11[1] != null)
                    {
                        var cal11 = this._ingr_list11[1].calories.Trim();
                        var prot11 = this._ingr_list11[1].protein;
                        var ugl11 = this._ingr_list11[1].uglevod;
                        var zhiri11 = this._ingr_list11[1].zhiri;

                        word1("[k11]", cal11, word);
                        word1("[u11]", ugl11, word);
                        word1("[b11]", prot11, word);
                        word1("[z11]", zhiri11, word);
                    }
                
            }

            if (_ingr_list12[1] == null)
            {
                var cal12 = "";
                var prot12 = "";
                var ugl12 = "";
                var zhiri12 = "";

                word1("[k12]", cal12, word);
                word1("[u12]", ugl12, word);
                word1("[b12]", prot12, word);
                word1("[z12]", zhiri12, word);
            }
            else
            {
                if (this._ingr_list12[1] != null)
                    {
                        var cal12 = this._ingr_list12[1].calories.Trim();
                        var prot12 = this._ingr_list12[1].protein;
                        var ugl12 = this._ingr_list12[1].uglevod;
                        var zhiri12 = this._ingr_list12[1].zhiri;

                        word1("[k12]", cal12, word);
                        word1("[u12]", ugl12, word);
                        word1("[b12]", prot12, word);
                        word1("[z12]", zhiri12, word);
                    }
                
            }

            if (_ingr_list13[1] == null)
            {
                var cal13 = "";
                var prot13 = "";
                var ugl13 = "";
                var zhiri13 = "";

                word1("[k13]", cal13, word);
                word1("[u13]", ugl13, word);
                word1("[b13]", prot13, word);
                word1("[z13]", zhiri13, word);
            }
            else
            {
                if (this._ingr_list13[1] != null)
                    {
                        var cal13 = this._ingr_list13[1].calories.Trim();
                        var prot13 = this._ingr_list13[1].protein;
                        var ugl13 = this._ingr_list13[1].uglevod;
                        var zhiri13 = this._ingr_list13[1].zhiri;

                        word1("[k13]", cal13, word);
                        word1("[u13]", ugl13, word);
                        word1("[b13]", prot13, word);
                        word1("[z13]", zhiri13, word);
                    }
                
            }

            if (_ingr_list14[1] == null)
            {
                var cal14 = "";
                var prot14 = "";
                var ugl14 = "";
                var zhiri14 = "";
                word1("[k14]", cal14, word);
                word1("[u14]", ugl14, word);
                word1("[b14]", prot14, word);
                word1("[z14]", zhiri14, word);
            }
            else
            {  if (this._ingr_list14[1] != null)
                    {
                        var cal14 = this._ingr_list14[1].calories.Trim();
                        var prot14 = this._ingr_list14[1].protein;
                        var ugl14 = this._ingr_list14[1].uglevod;
                        var zhiri14 = this._ingr_list14[1].zhiri;
                        word1("[k14]", cal14, word);
                        word1("[u14]", ugl14, word);
                        word1("[b14]", prot14, word);
                        word1("[z14]", zhiri14, word);
                    }                
            }

            if (this._ves_list[1] == null)
            {
                var net = "";
                var br = "";
                word1("[n]", net, word);
                word1("[br]", br, word);

            }
            else
            {
                    if (this._ves_list[1] != null)
                    {
                        var net = this._ves_list[1].net.Trim();
                        var bruto = this._ves_list[1].bruto.Trim();
                        word1("[n]", net, word);
                        word1("[br]", bruto, word);

                    }               
            }

            if (this._ves_list1[1] == null)
            {
                var net1 = "";
                var br1 = "";


                word1("[n1]", net1, word);
                word1("[br1]", br1, word);

            }
            else
            {
                   if (this._ves_list1[1] != null)
                    {
                        var net1 = this._ves_list1[1].net.Trim();
                        var bruto1 = this._ves_list1[1].bruto.Trim();
                        word1("[n1]", net1, word);
                        word1("[br1]", bruto1, word);
                    }               
            }

            if (this._ves_list2[1] == null)
            {
                var net1 = "";
                var br1 = "";
                word1("[n2]", net1, word);
                word1("[br2]", br1, word);
            }
            else
            {                
                    if (this._ves_list2[1] != null)
                    {
                        var net2 = this._ves_list2[1].net.Trim();
                        var bruto2 = this._ves_list2[1].bruto.Trim();
                        word1("[n2]", net2, word);
                        word1("[br2]", bruto2, word);
                    }               
            }

            if (this._ves_list3[1] == null)
            {
                var net1 = "";
                var br1 = "";

                word1("[n3]", net1, word);
                word1("[br3]", br1, word);

            }
            else
            {    if (this._ves_list3[1] != null)
                    {   var net3 = this._ves_list3[1].net.Trim();
                        var bruto3 = this._ves_list3[1].bruto.Trim();
                        word1("[n3]", net3, word);
                        word1("[br3]", bruto3, word);
                    }
            }

            if (this._ves_list4[1] == null)
            {
                var net1 = "";
                var br1 = "";
                word1("[n4]", net1, word);
                word1("[br4]", br1, word);

            }
            else
            {               
                    if (this._ves_list4[1] != null)
                    {
                        var net4 = this._ves_list4[1].net.Trim();
                        var bruto4 = this._ves_list4[1].bruto.Trim();
                        word1("[n4]", net4, word);
                        word1("[br4]", bruto4, word);

                    }                
            }

            if (this._ves_list5[1] == null)
            {
                var net1 = "";
                var br1 = "";
                word1("[n5]", net1, word);
                word1("[br5]", br1, word);

            }
            else
            {               
                    if (this._ves_list5[1] != null)
                    {
                        var net5 = this._ves_list5[1].net.Trim();
                        var bruto5 = this._ves_list5[1].bruto.Trim();
                        word1("[n5]", net5, word);
                        word1("[br5]", bruto5, word);

                    }                
            }

            if (this._ves_list6[1] == null)
            {
                var net6 = "";
                var br6 = "";
                word1("[n6]", net6, word);
                word1("[br6]", br6, word);

            }
            else
            {          if (this._ves_list6[1] != null)
                    {
                         var net6 = this._ves_list6[1].net.Trim();
                       var bruto6 = this._ves_list6[1].bruto.Trim();
                        word1("[n6]", net6, word);
                        word1("[br6]", bruto6, word);
                    }               
            }
            
            if (this._ves_list7[1] == null)
            {
                var net7 = "";
                var br7 = "";

                word1("[n7]", net7, word);
                word1("[br7]", br7, word);

            }
            else
            {
                    if (this._ves_list7[1] != null)
                    {
                        var net7 = this._ves_list7[1].net.Trim();
                        var br7 = this._ves_list7[1].bruto.Trim();
                        word1("[n7]", net7, word);
                        word1("[br7]", br7, word);

                    }                
            }

            if (this._ves_list8[1] == null)
            {
                var net8 = "";
                var br8 = "";
                word1("[n8]", net8, word);
                word1("[br8]", br8, word);

            }
            else
            {
                    if (this._ves_list8[1] != null)
                    {
                        var net8 = this._ves_list8[1].net.Trim();
                        var br8 = this._ves_list8[1].bruto.Trim();
                        word1("[n8]", net8, word);
                        word1("[br8]", br8, word);
                    }                
            }

            if (this._ves_list9[1] == null)
            {
                var net9 = "";
                var br9 = "";
                word1("[n9]", net9, word);
                word1("[br9]", br9, word);

            }
            else
            {    if (this._ves_list9[1] != null)
                    {
                        var net9 = this._ves_list9[1].net.Trim();
                        var br9 = this._ves_list9[1].bruto.Trim();
                        word1("[n9]", net9, word);
                        word1("[br9]", br9, word);
                    }                
            }

            if (this._ves_list10[1] == null)
            {
                var net10 = "";
                var br10 = "";
                word1("[n10]", net10, word);
                word1("[br10]", br10, word);

            }
            else
            {
                if (this._ves_list10[1] != null)
                    {
                        var net10 = this._ves_list10[1].net.Trim();
                        var br10 = this._ves_list10[1].bruto.Trim();
                        word1("[n10]", net10, word);
                        word1("[br10]", br10, word);

                    }                
            }


            if (this._ves_list11[1] == null)
            {
                var net11 = "";
                var br11 = "";
                word1("[n11]", net11, word);
                word1("[br11]", br11, word);

            }
            else
            {
                    if (this._ves_list11[1] != null)
                    {
                        var net11 = this._ves_list11[1].net.Trim();
                        var br11 = this._ves_list11[1].bruto.Trim();
                        word1("[n11]", net11, word);
                        word1("[br11]", br11, word);

                    }                
            }

            if (this._ves_list12[1] == null)
            {
                var net12 = "";
                var br12 = "";
                word1("[n12]", net12, word);
                word1("[br12]", br12, word);
            }
            else
            {       if (this._ves_list12[1] != null)
                    {   var net12 = this._ves_list12[1].net.Trim();
                        var br12 = this._ves_list12[1].bruto.Trim();
                        word1("[n12]", net12, word);
                        word1("[br12]", br12, word);
                    }                
            }

               if (this._ves_list13[1] == null)
            {
                var net13 = "";
                var br13 = "";
                word1("[n13]", net13, word);
                word1("[br13]", br13, word);

            }
            else
            {
                    if (this._ves_list13[1] != null)
                    {   var net13 = this._ves_list13[1].net.Trim();
                        var br13 = this._ves_list13[1].bruto.Trim();
                        word1("[n13]", net13, word);
                        word1("[br13]", br13, word);
                    }                
            }

               if (_food_list2[1] == null)
               {
                   var id = "";
                   var opis = "";
                   var cost = "";

                   word1("{id}", id, word);
                   word1("[opis]", opis, word);
                   word1("[opis1]", opis, word);
                   word1("[opis2]", opis, word);
                   word1("[opis3]", opis, word);
                   word1("[opis4]", opis, word);
                   word1("[opis5]", opis, word);
                   word1("[opis6]", opis, word);
                   word1("{price}", cost, word);
               }
               else
               {
                   if (this._food_list2[1] != null)
                       {
                           var id = this._food_list2[1].nam_card.Trim();
                           string opis = this._food_list2[1].opis.Trim();
                           var cost = this._food_list2[1].cost.Trim();
                           word1("{id}", id, word);                          
                           word1("{price}", cost, word);

                       // Делим строку на подстроки т.к метод приготовления может быть больше 255 символов,а  Word не позволяет заменить метки на переменную больше 255 символов
                           // Т.о метод приготовления   выгрузиться в шаблон 1785 символов максимум, думаю должно хватить  
                       if ((opis.Length >= 255) && (opis.Length <=510))
                           {
                               int stroka = opis.Length - 255;
                               word1("[opis]", opis.Substring(0, 255), word);
                               word1("[opis1]", opis.Substring(255, stroka), word);
                               word1("[opis2]", "", word);
                               word1("[opis3]", "", word);
                               word1("[opis4]", "", word);
                               word1("[opis5]", "", word);
                               word1("[opis6]", "", word);

                           }
                           
                          if ((opis.Length < 255))
                           {
                               word1("[opis]", opis, word);
                               word1("[opis1]", "", word);
                               word1("[opis2]", "", word);
                               word1("[opis3]", "", word);
                               word1("[opis4]", "", word);
                               word1("[opis5]", "", word);
                               word1("[opis6]", "", word);
                              
                           }

                             if ((opis.Length > 510) &&  (opis.Length <= 765) )
                             {
                                 word1("[opis]", opis.Substring(0, 255), word);
                                 int stroka= opis.Length-510;
                                 word1("[opis1]", opis.Substring(255, 255), word);
                                 word1("[opis2]", opis.Substring(510, stroka),word);
                                 word1("[opis3]", "", word);
                                 word1("[opis4]", "", word);
                                 word1("[opis5]", "", word);
                                 word1("[opis6]", "", word);
                             
                             }

                             if ((opis.Length > 765) && (opis.Length <= 1020))
                             
                             {
                                 word1("[opis]", opis.Substring(0, 255), word);
                                 int stroka = opis.Length - 765;
                                 word1("[opis1]", opis.Substring(255, 255), word);
                                 word1("[opis2]", opis.Substring(510, 255), word);
                                 word1("[opis3]", opis.Substring(765, stroka), word);
                                 word1("[opis4]", "", word);
                                 word1("[opis5]", "", word);
                                 word1("[opis6]", "", word);
                             
                             }

                             if ((opis.Length > 1020) && (opis.Length <= 1275))
                             {
                                 word1("[opis]", opis.Substring(0, 255), word);
                                 int stroka = opis.Length - 1020;
                                 word1("[opis1]", opis.Substring(255, 255), word);
                                 word1("[opis2]", opis.Substring(510, 255), word);
                                 word1("[opis3]", opis.Substring(765, 255), word);
                                 word1("[opis4]", opis.Substring(1020, stroka), word);
                                 word1("[opis5]", "", word);
                                 word1("[opis6]", "", word);
                             
                             }

                           if ((opis.Length > 1275) && (opis.Length <= 1530))
                             {
                                 word1("[opis]", opis.Substring(0, 255), word);
                                 int stroka = opis.Length - 1275; ;
                                 word1("[opis1]", opis.Substring(255, 255), word);
                                 word1("[opis2]", opis.Substring(510, 255), word);
                                 word1("[opis3]", opis.Substring(765, 255), word);
                                 word1("[opis4]", opis.Substring(1020, 255), word);
                                 word1("[opis5]", opis.Substring(1275, stroka), word);
                                 word1("[opis6]", "", word);
                              }

                           if ((opis.Length > 1530) && (opis.Length <= 1785))
                           {
                               word1("[opis]", opis.Substring(0, 255), word);
                               int stroka = opis.Length - 1530; ;
                               word1("[opis1]", opis.Substring(255, 255), word);
                               word1("[opis2]", opis.Substring(510, 255), word);
                               word1("[opis3]", opis.Substring(765, 255), word);
                               word1("[opis4]", opis.Substring(1020, 255), word);
                               word1("[opis5]", opis.Substring(1275, 255), word);
                               word1("[opis6]", opis.Substring(1530, stroka), word);

                           }

                         }                    
               }

               if (this._food_list1 == null)
            {
                var net1 = "";
                var br1 = "";
                word1("[n1]", net1, word);
                word1("[br1]", br1, word);
            }
            else
            {
                    if (this._food_list1[1] != null)
                    {
                        var cal = this._food_list1[1].calories.Trim();
                        var ugl = this._food_list1[1].carbo.Trim();
                        var fat = this._food_list1[1].fats.Trim();
                        var prot = this._food_list1[1].proteins.Trim();
                        var weight = this._food_list1[1].weight.Trim();

                        word1("{ves}", weight, word);
                        word1("[kal]", cal, word);
                        word1("[ul]", ugl, word);
                        word1("[zh]", fat, word);
                        word1("[be]", prot, word);
                    }                
            }

            // Включаем  документ с заполненным шаблоном в Word
            
            App.Visible = true;   
            // Очищащем лишнии процессы при закрытии Wлокумента Word ,иначе процесс  WORD.EXE будет висеть даже при закрытии жокумента Word
            GC.Collect();

        }
        /// <summary>
        /// Метод для поиска определенных символов в шаблоне и замена их на значения опрделенных переменных.
        /// </summary>
        /// <param name="stubToReplace"></param>
        /// <param name="text"></param>
        /// <param name="word"></param>
        private void word1(string stubToReplace, string text, word.Document word)
        {
            var range = word.Content;

           range.Find.ClearFormatting();
                             
           range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);          

        }

        /// <summary>
        /// Возвращает id диеты и номер диеты
        /// </summary>
         public class_diet[] diet()
        {
            class_diet[] id_diet = new class_diet[512];
            string query = "select NumofDiet, FD.ID_Diets, FD.ID_food from Diets join Food_In_Diets FD on FD.ID_Diets =Diets.ID_Diets";

            query += " where ID_food ='";

            for (int t = 1; t < this._food_list1.Count(); t++)

                if (this._food_list1[t] != null)
                {

                    string guer1 = this._food_list1[t].food_id;

                    string query4 = query + guer1 + "'";

                    try
                    {
                        SqlCommand com = Program.data_module._conn.CreateCommand();
                        com.CommandText = query4;

                        SqlDataReader rd = com.ExecuteReader();
                        int i = 0;
                        while (rd.Read())
                        {
                            i = i + 1;
                            id_diet[i] = new class_diet();
                            id_diet[i].result = "OK";
                            id_diet[i].diet_id = rd.GetInt32(1).ToString();
                            id_diet[i].numbDiet = rd.GetString(0);
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
            return id_diet;

        }


         /// <summary>
         /// При выборе с комбокса блюда происходит следующее событие
         /// </summary>
        private void cb_food_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._food_list1 = this.food1();
            this._food_list2 = this.food2();
            this._ingr_list = this.get_ingr_list();
            this._ingr_list1 = this.get_ingr_list1();
            this._ingr_list2 = this.get_ingr_list2();
            this._ingr_list3 = this.get_ingr_list3();
            this._ingr_list4 = this.get_ingr_list4();
            this._ingr_list5 = this.get_ingr_list5();
            this._ingr_list6 = this.get_ingr_list6();
            this._ingr_list7 = this.get_ingr_list7();
            this._ingr_list8 = this.get_ingr_list8();
            this._ingr_list9 = this.get_ingr_list9();
            this._ingr_list10 = this.get_ingr_list10();
            this._ingr_list11 = this.get_ingr_list11();
            this._ingr_list12 = this.get_ingr_list12();
            this._ingr_list13 = this.get_ingr_list13();
            this._ingr_list14 = this.get_ingr_list14();
           
            this._ves_list = this.ves_list();
            this._ves_list1 = this.ves_list1();
            this._ves_list2 = this.ves_list2();
            this._ves_list3 = ves_list3();
            this._ves_list4 = ves_list4();
            this._ves_list5 = ves_list5();
            this._ves_list6 = ves_list6();
            this._ves_list7 = ves_list7();
            this._ves_list8 = ves_list8();
            this._ves_list9 = ves_list9();
            this._ves_list10 = ves_list10();
            this._ves_list11 = ves_list11();
            this._ves_list12 = ves_list12();
            this._ves_list13 = ves_list13();

            this._Diet = this.diet();
            this._id_book = get_id_book_list();
            this._book = get_book_list();
            this._book1 = get_book_list1();
            this._book2 = get_book_list2();
            this._book3 = get_book_list3();
            this._book4 = get_book_list4();
            this._foodyear = get_book_year();
            this.bt_ok.Enabled = true;
            this._person = this.get_person_list();
            fill_person_list();          
          }

        /// <summary>
        /// Возвращает id книги
        /// </summary>
        public class_book[] get_id_book_list()
        {
            class_book[] book = new class_book[512];
            string query = "select *  from FoodinBook where ID_food='";

            for (int t = 1; t < this._food_list1.Count(); t++)

                if (this._food_list1[t] != null)
                {
                    string guery1 = this._food_list1[t].food_id + "'";
                    string query2 = query + guery1;

                    try
                    {
                        SqlCommand com = Program.data_module._conn.CreateCommand();
                        com.CommandText = query2;

                        SqlDataReader rd = com.ExecuteReader();
                        int i = 0;
                        while (rd.Read())
                        {
                            i = i + 1;
                            book[i] = new class_book();
                            book[i].result = "OK";
                            book[i].book_id = rd.GetInt32(2).ToString();
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
                } return book;
        }

        /// <summary>
        /// Возвращает автора ,название и год выпуска кулинарной книги
        /// </summary>
        public class_book[] get_book_list()
        {
            class_book[] book = new class_book[512];
            string query = "select *  from Book where IDBook='";

            if (this._id_book[1] != null)
            {   string guer1 = this._id_book[1].book_id + "'";
                string query2 = query + guer1;
                  try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;
                    SqlDataReader rd = com.ExecuteReader();
                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        book[i] = new class_book();
                        book[i].result = "OK";
                        book[i].author = rd.GetString(1).ToString();
                        book[i].year = rd.GetInt32(2).ToString();
                        book[i].name = rd.GetString(3).ToString();

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
            return book;
           
        }

        /// <summary>
        /// Возвращает название и год выпуска кулинарной книги
        /// </summary>
        public class_book[] get_book_list1()
        {
            class_book[] book = new class_book[512];
            string query = "select *  from Book where IDBook='";
                    

            if (this._id_book[2] != null)
            {

                string guer1 = this._id_book[2].book_id + "'";

                string query2 = query + guer1;

                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;

                    SqlDataReader rd = com.ExecuteReader();
                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        book[i] = new class_book();
                        book[i].result = "OK";
                        book[i].author = rd.GetString(1).ToString();
                        book[i].year = rd.GetInt32(2).ToString();
                        book[i].name = rd.GetString(3).ToString();

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
            return book;
        }

        /// <summary>
        /// Возвращает  название и год выпуска кулинарной книги
        /// </summary>
        public class_book[] get_book_list2()
        {
            class_book[] book = new class_book[512];
            string query = "select *  from Book where IDBook='";
                     
            if (this._id_book[3] != null)
            {

                string guer1 = this._id_book[3].book_id + "'";
                 string query2 = query + guer1;

                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;

                    SqlDataReader rd = com.ExecuteReader();
                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        book[i] = new class_book();
                        book[i].result = "OK";
                        book[i].author = rd.GetString(1);

                        book[i].year = rd.GetInt32(2).ToString();
                        book[i].name = rd.GetString(3);


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
            return book;



        }
        /// <summary>
        /// Возвращает  название и год выпуска кулинарной книги
        /// </summary>
        public class_book[] get_book_list3()
        {
            class_book[] book = new class_book[512];
            string query = "select *  from Book where IDBook='";

            if (this._id_book[4] != null)
            {
                string guer1 = this._id_book[4].book_id + "'";
                 string query2 = query + guer1;

                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;

                    SqlDataReader rd = com.ExecuteReader();
                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        book[i] = new class_book();
                        book[i].result = "OK";
                        book[i].author = rd.GetString(1).ToString();

                        book[i].year = rd.GetInt32(2).ToString();
                        book[i].name = rd.GetString(3);


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
            return book;
          }
        /// <summary>
        /// Возвращает  название и год выпуска кулинарной книги
        /// </summary>
        public class_book[] get_book_list4()
        {   class_book[] book = new class_book[512];
            string query = "select *  from Book where IDBook='";
              
            if (this._id_book[5] != null)
            {   string guery1 = this._id_book[5].book_id + "'";
            string query2 = query + guery1;

                try
                {
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query2;

                    SqlDataReader rd = com.ExecuteReader();
                    int i = 0;
                    while (rd.Read())
                    {
                        i = i + 1;
                        book[i] = new class_book();
                        book[i].result = "OK";
                        book[i].author = rd.GetString(1).ToString();

                        book[i].year = rd.GetInt32(2).ToString();
                        book[i].name = rd.GetString(3);


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
            return book;

        }

        /// <summary>
        /// Возвращает самый максимальный год выпуска кулинарной книги
        /// </summary>
        public class_book[] get_book_year()
        { 
            class_book[] book = new class_book[512];
            string query = "select MAX(B.Year) as Year from Book B join FoodInBook FIB on FIB.IDBook = B.IDBook where FIB.ID_food ='";
                  for (int t = 1; t < this._food_list1.Count(); t++)

                      if (this._food_list1[t] != null)
                      {
                          string guery1 = this._food_list1[t].food_id + "'";
                          string query2 = query + guery1;
                         
                                  try
                                  {
                                      SqlCommand com = Program.data_module._conn.CreateCommand();
                                      com.CommandText = query2;
                                      SqlDataReader rd = com.ExecuteReader();
                                      int i = 0;
                                      while (rd.Read())
                                      {
                                          i = i + 1;
                                          book[i] = new class_book();
                                          book[i].result = "OK";
                                          if (rd.IsDBNull(0))
                                          {
                                              book[i].year = "";
                                          }
                                          else
                                          {
                                              book[i].year = rd.GetInt32(0).ToString();
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
                              }
                          
                      
                          return book;                   
        }

        /// <summary>
        /// Отмена
        /// </summary>
        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// При выборе с комбокса ,кто утверждает карту-раскладку ,происходит следующее событие
        /// </summary>
        private void cb_ok_SelectedIndexChanged(object sender, EventArgs e)
        {
            _namevrach = get_person_name_vrach1();
        }

        /// <summary>
        /// При выборе с комбокса ,кто составляет карту-раскладку ,происходит следующее событие
        /// </summary>
        private void cb_diets_vrach_SelectedIndexChanged(object sender, EventArgs e)
        {
            _namevrach2 = get_person_name_vrach2();
        }

        /// <summary>
        /// При выборе с комбокса ,кто составляет карту-раскладку ,происходит следующее событие
        /// </summary>
        private void Cb_diet_vrach2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _namevrach3 = get_person_name_vrach3();
        }
               
        
    }
}
        

            
       
   
        
        
        



















