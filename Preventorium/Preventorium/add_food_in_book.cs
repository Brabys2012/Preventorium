using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class add_food_in_book : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string food;
        //public string result;
        public string card_numb;
        public string book;
        public string food_id;
        public int book_id;
        public string author;

        private void enabled_b_save(object sender, EventArgs e)
        {
            if (this._state == "OLD") { this.set_state("MOD"); }
            if (lb_food.Text != "") { b_save.Enabled = true; }
        }

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_food_in_book(db_connect data_module, int book_id, string _author)
        {
            InitializeComponent();
            author = _author;
            
            food_in_book[] food_in_book = new food_in_book[512];
            food_in_book = Program.add_read_module.get_list_food_in_book_id(book_id);
            if (food_in_book != null)
            {
                this.lb_food.Items.Clear();
                for (int i = 1; i < food_in_book.Count(); i++)
                {
                    if (food_in_book[i] != null)
                    {
                        this.lb_food.Items.Add(food_in_book[i].food);
                    }
                    else
                    {
                        break;
                    }
                }
            }
   
            this._data_module = data_module;
            this.set_state("NEW");

        }

        //Добавление блюда
        private void add_new_food_in_book()
        {
            add_food_in_book add_food = new add_food_in_book(Program.data_module, book_id, author);
            add_food.ShowDialog();
        }


        //Конструктор, вызываемый для редактирования
        public add_food_in_book(db_connect data_module, string food_in_book_card, string food_in_book_food, string food_in_book_book, int card_id, int food_id, int book_id)
        {
            InitializeComponent();

            food_in_book[] food_in_book = new food_in_book[512];
            food_in_book = Program.add_read_module.get_list_food_in_book_id(book_id);
            if (food_in_book != null)
            {
                this.lb_food.Items.Clear();
                for (int i = 1; i < food_in_book.Count(); i++)
                {
                    if (food_in_book[i] != null)
                    {
                        this.lb_food.Items.Add(food_in_book[i].food_id);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            this.food_id = food_id.ToString();
          
            this.set_state("OLD");

            this.food = food_in_book_food.ToString();

            this.fill_food_in_book_data();
            this._data_module = data_module;
           
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_food_in_book_data()
        {

            food_in_book food_in_book;
            food_in_book = Program.add_read_module.get_food_in_book(food);
            if (food_in_book.result == "OK")
            {
                this.lb_food.Text = food_in_book.food;
            }
            else
            {
                //Не удалось получить сведений
                MessageBox.Show(food_in_book.result);
                this.Dispose();
            }
        }


        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.Text = "Просмотр";
                    this.b_save.Enabled = true;
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Добавление";
                    this.b_save.Enabled = true;
                    break;

                case "MOD":
                    this._state = "MOD";
                    this.Text = "Редактирование";
                    this.b_save.Enabled = true;
                    break;
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {

            string result; //Результат попытки сохранения/добавления
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":
                    string query = "Select Number_Card from Cards "
                            + "join Foods F on F.ID_food = Cards.ID_food "
                            + "where F.Name_food = '" + lb_food.Text + "'";
                      try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    if (rd.IsDBNull(0))
                    {
                        card_numb = "";
                    }
                    else
                    {
                        card_numb = rd.GetString(0);
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

               catch (Exception ex)
               {
                   result = "ERROR_" + ex.Data + " " + ex.Message;
               }
                    result = Program.add_read_module.add_food_in_book(card_numb,
                        this.lb_food.Text,
                        book, author);
                    this.Close();
                    break;

                default:
                    result = "NDF";
                    // не используется, однако mvs не позволяет 
                    // дальше работать переменной, которой в одной
                    // из веток кода не присваивается значение
                    break;
            }

            if (result == "OK")
            {
                if (this._state == "NEW")
                {
                    this.set_state("OLD");
                    this.Dispose();
                }
                else
                    if (this._state == "MOD")
                    {
                        this.set_state("OLD");
                    }
            }
            else
            {
                MessageBox.Show(result);
            }

            this.Update();
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
