using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_book : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID справочника для загрузки данных (в режиме OLD)
        private string _id;

          private void enabled_b_save(object sender, EventArgs e)
          {
              this.l_status.Text = "Запись изменена";
              this.b_save.Enabled = true;
              if (this._state == "OLD") { this.set_state("MOD"); };
          }

          // Конструктор, вызываемый при нажатии "Добавить"
           public add_book(db_connect data_module)
        {
            InitializeComponent();
            this._data_module = data_module;
            this.set_state("NEW");
        }

           //Конструктор, вызываемый
           //для редактирования существующего справочника
           public add_book(db_connect data_module, int ingr_id)
        {
            InitializeComponent();
            this._id = ingr_id.ToString();
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
                       this.status.Text = "";
                       this.b_save.Enabled = false;
                       break;

                   case "NEW":
                       this._state = "NEW";
                       this.Text = "Справочники - Добавление";
                       this.b_save.Enabled = false;
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
                    this.l_status.Text = "Добавление нового справочника...";

                    result = Program.add_read_module.add_book(this.tb_author.Text,
                        this.tb_year.Text,
                        this.tb_name.Text);
                    this.Close();
                    break;
                    

                //Если модифицируется существующая...
              case "MOD":
                    this.l_status.Text = "Модификация данных о справочнике.. ";
                 result = Program.add_read_module.upd_book(Convert.ToInt32(this._id), 
                     this.tb_author.Text,
                     this.tb_year.Text, 
                     this.tb_name.Text);
                 this.Close();
                    break;

                default:
                    this.l_status.Text = "Ошибка";
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
                        this.status.Text = "Изменение записи успешно завершено";
                    }
            }
            else
            {
                this.status.Text = "Ошибка";
                MessageBox.Show(result);
            }

        
           }

           private void b_abolition_Click(object sender, EventArgs e)
           {
               this.Close();
           }

    }
}
