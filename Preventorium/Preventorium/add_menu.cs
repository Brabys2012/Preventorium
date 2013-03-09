using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_menu : Form
    {
       //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        public string numb_queue;
        public string queue_id;

        private void enabled_b_save(object sender, EventArgs e)
        {
            if (this._state == "OLD") { this.set_state("MOD"); }
            if (cb_numb_queue.Text != "") { b_save.Enabled = true; }
        }

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_menu(db_connect data_module)
        {
            InitializeComponent();
            
            class_queue[] queue = new class_queue[512];
            queue = Program.add_read_module.get_numb_queue();
            if (queue != null)
            {
                this.cb_numb_queue.Items.Clear();
                for (int i = 1; i < queue.Count(); i++)
                {
                    if (queue[i] != null)
                    {
                        this.cb_numb_queue.Items.Add(queue[i].numb_queue);
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

        //Добавление меню
        private void add_new_menu()
        {
            add_menu menu = new add_menu(Program.data_module);
            menu.ShowDialog();
        }


        /*//Конструктор, вызываемый для редактирования
        public add_menu(db_connect data_module, string food_in_book_card, string food_in_book_food, string food_in_book_book, int card_id, int food_id, int book_id)
        {
            InitializeComponent();

            class_queue[] queue = new class_queue[512];
            queue = Program.add_read_module.get_numb_queue();
            if (queue != null)
            {
                this.cb_numb_queue.Items.Clear();
                for (int i = 1; i < queue.Count(); i++)
                {
                    if (queue[i] != null)
                    {
                        this.cb_numb_queue.Items.Add(queue[i].numb_queue);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            this.queue_id = queue_id.ToString();
          
            this.set_state("OLD");

            this.numb_queue = numb_queue.ToString();

            this.fill_menu_data();
            this._data_module = data_module;
           
        }*/

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_menu_data()
        {

            class_menu menu;
            menu = Program.add_read_module.get_menu(numb_queue);
            if (menu.result == "OK")
            {
                this.cb_numb_queue.Text = menu.numb_queue;
            }
            else
            {
                //Не удалось получить сведений
                MessageBox.Show(menu.result);
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
                    this.b_save.Enabled = false;
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Добавление";
                    this.b_save.Enabled = false;
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
                    result = Program.add_read_module.add_menu(this.cb_numb_queue.Text);
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
