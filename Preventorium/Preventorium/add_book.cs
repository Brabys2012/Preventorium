using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Preventorium
{
    public partial class add_book : Form
    {
        private string _current_state;

        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID справочника для загрузки данных (в режиме OLD)
        private string _id;

          private void enabled_b_save(object sender, EventArgs e)
          {
                if (this._state == "OLD") { this.set_state("MOD"); };
              // Включается кнопка "Сохранить" если текстбоксы не пустые
              if ((tb_author.Text != "") && (tb_name.Text != "") && (tb_year.Text != "")) { b_save.Enabled = true; }
          }

          // Конструктор, вызываемый при нажатии "Добавить"
           public add_book(db_connect data_module)
        {
            InitializeComponent();
            gb_data.Visible = false;
            this.Size = new Size(295, 232);
            this._data_module = data_module;
            this.set_state("NEW");
        }

           //Конструктор, вызываемый
           //для редактирования существующего справочника
           public add_book(db_connect data_module, int id)
        {
            InitializeComponent();
            this._id = id.ToString();
            this._data_module = data_module;
            this.fill_book_data();
            this.set_state("OLD");
        }

        //заполняет форму данными о справочнике, полученными из базы данных при просмотре существующей в БД записи
           public void fill_book_data()
        {
            class_book book;
            book = Program.add_read_module.get_book(Convert.ToInt32(this._id));
            if (book.result == "OK")
            {
                this.tb_author.Text = book.author;
                this.tb_year.Text = book.year;
                this.tb_name.Text = book.name;
                
            }
            else
            {
                //Не удалось получить сведений о текущем справочнике
                MessageBox.Show(book.result);
                this.Dispose();
            }
        }


           public void set_state(string state)
           {
               switch (state)
               {
                   case "OLD":
                       this._state = "OLD";
                       this.Text = "Справочники - Просмотр";
                       break;

                   case "NEW":
                       this._state = "NEW";
                       this.Text = "Справочники - Добавление";
                       break;

                   case "MOD":
                       this._state = "MOD";
                       this.Text = "Справочники - Редактирование";
                       this.b_save.Enabled = true;
                       break;
               }
           }

           private void b_save_Click(object sender, EventArgs e)
           {   
             string result; //Результат попытки сохранения/добавления справочника
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":

                    result = Program.add_read_module.add_book(this.tb_author.Text,
                        this.tb_year.Text,
                        this.tb_name.Text);
                    this.Close();
                    break;
                    

                //Если модифицируется существующая...
              case "MOD":
                 result = Program.add_read_module.upd_book(Convert.ToInt32(this._id), 
                     this.tb_author.Text,
                     this.tb_year.Text, 
                     this.tb_name.Text);
                 this.Close();
                    break;

                default:
                    result = "Ошибка";
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
            this.Dispose();
           }

           private void b_abolition_Click(object sender, EventArgs e)
           {
               this.Close();
           }

           public void load_data_table(string state)
           {
               bs.DataSource = Program.data_module.get_food_in_book("FoodInBook", Convert.ToInt32(this._id)).Tables[state];
               gw.DataSource = bs;
               gw.Columns[0].Visible = false;
               gw.Columns[1].Visible = false;
               gw.Columns[2].Visible = false;
               gw.Columns[5].Visible = false;
               gw.Update();
               gw.Show();
               this._current_state = state;
           }

           private void add_food_Load(object sender, EventArgs e)
           {
               this.load_data_table("FoodInBook");
               gw.Columns[4].HeaderText = "Блюдо";
               gw.Columns[3].HeaderText = "Номер карты";
           }

           //Удаление блюда из справочника
           private void b_delete_Click(object sender, EventArgs e)
           {
               this.load_data_table(this._current_state);
               switch (this._current_state)
               {
                   case "FoodInBook":
                       del_food_from_book del = null;
                       try
                       {
                           del = new del_food_from_book(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString()), Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString()));
                           del.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;
               }
               this.load_data_table(this._current_state);
           }

           /// <summary>
           /// Блюда в кулинарный справочник
           /// </summary>
           private void add_new_food_in_book(int id_book, string author, string year)
           {
               add_food_in_book food_in_book = new add_food_in_book(Program.data_module, id_book, author, year);
               food_in_book.book = this.tb_name.Text;
               food_in_book.ShowDialog();
           }

           private void b_add_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "FoodInBook":
                       string author = tb_author.Text;
                       string year = tb_year.Text;
                       this.add_new_food_in_book(Convert.ToInt32(_id), author, year);

                       break;
               }

               this.load_data_table(this._current_state);
           }

           private void bDelete_Click(object sender, EventArgs e)
           {
               this.b_delete_Click(sender, e);
           }

           private void gw_MouseDown(object sender, MouseEventArgs e)
           {
               int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
               if (rowIndex == -1) return;
               gw.ClearSelection();
               gw.Rows[rowIndex].Selected = true;
               gw.CurrentCell = gw[3, rowIndex];
           }

           private void gw_KeyDown(object sender, KeyEventArgs e)
           {
               try
               {                  
                   if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                   {
                       b_add_Click(sender, e);
                   }

                   if (e.KeyCode == Keys.Delete)
                   {

                       bDelete_Click(sender, e);
                   }
               }
               catch
               { }
           }

    }
}
