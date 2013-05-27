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
    public partial class add_menu_in_day : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        public string day;
        public string day_id;
        private int id;

        private void enabled_b_save(object sender, EventArgs e)
        {
            if (this._state == "OLD") { this.set_state("MOD"); }
        }

        public add_menu_in_day(db_connect data_module, int menu_id)
        {
            id = menu_id;
            InitializeComponent();
            this._data_module = data_module;
            this.set_state("NEW");
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_menu_data()
        {

            class_menu_in_day menu;
            menu = Program.add_read_module.get_menu_in_day(Convert.ToInt32(this.day_id), day);
            if (menu.result == "OK")
            {
                this.b_date.Text = menu.day;
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
                    string date = b_date.Value.ToString("dd.MM.yyyy");
                    result = Program.add_read_module.add_menu_in_day(date, id);
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
                MessageBox.Show("Эта дата уже есть в меню!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Update();
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
