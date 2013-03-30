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
    public partial class add_food_in_menu : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        public string food;
        private string serve;
        private int id;
        private int AddDayID;

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_food_in_menu(db_connect data_module, string serve_time, int menu_id, int day_id)
        {
            AddDayID = day_id;
            id = menu_id;
            serve = serve_time;
            InitializeComponent();

            class_food_in_menu[] food_in_menu = new class_food_in_menu[512];
            food_in_menu = Program.add_read_module.get_foodMenu(serve_time,AddDayID);
            if (food_in_menu != null)
            {
                this.lb_food.Items.Clear();
                for (int i = 1; i < food_in_menu.Count(); i++)
                {
                    if (food_in_menu[i] != null)
                    {
                        this.lb_food.Items.Add(food_in_menu[i].food);
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
        private void add_new_food_in_menu()
        {
            add_food_in_menu food_in_menu = new add_food_in_menu(Program.data_module, serve, id, AddDayID);
            food_in_menu.ShowDialog();
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_food_in_menu_data()
        {

            class_food_in_menu food_in_menu;
            food_in_menu = Program.add_read_module.get_food_in_menu(food);
            if (food_in_menu.result == "OK")
            {
                this.lb_food.Text = food_in_menu.food;
            }
            else
            {
                //Не удалось получить сведений
                MessageBox.Show(food_in_menu.result);
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
                    result = Program.add_read_module.add_food_in_menu(serve, id, AddDayID, this.lb_food.Text, this.tb_serve.Text);
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

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
