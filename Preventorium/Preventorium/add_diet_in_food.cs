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
    public partial class add_diet_in_food : Form
    {
         //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string diet_numb;
        private string card_numb;
        private string food_name;
        private string diet_id;
        private string card_id;
        private string food_id;

        private void enabled_b_save(object sender, EventArgs e)
        {
            this.l_status.Text = "Запись изменена";
            this.b_save.Enabled = true;
            if (this._state == "OLD") { this.set_state("MOD"); };
        }

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_diet_in_food(db_connect data_module)
        {
            InitializeComponent();
            
            class_diet_in_food[] diet_in_food = new class_diet_in_food[512];
            diet_in_food = Program.add_read_module.get_list_diet_id();
            if (diet_in_food != null)
            {
                this.cb_diet_numb.Items.Clear();
                for (int i = 1; i < diet_in_food.Count(); i++)
                {
                    if (diet_in_food[i] != null)
                    {
                        this.cb_diet_numb.Items.Add(diet_in_food[i].diet_numb);
                    }
                    else
                    {
                        break;
                    }
                }
            }


            class_diet_in_food[] card = new class_diet_in_food[512];
            card = Program.add_read_module.get_list_card_id();
            if (card != null)
            {
                this.cb_card_numb.Items.Clear();
                for (int i = 1; i < card.Count(); i++)
                {
                    if (card[i] != null)
                    {
                        this.cb_card_numb.Items.Add(card[i].card_numb);
                    }
                    else
                    {
                        break;
                    }
                }
            }
           
            class_diet_in_food[] food = new class_diet_in_food[512];
            food = Program.add_read_module.get_list_food_name();
            if (food != null)
            {
                this.cb_food_name.Items.Clear();
                for (int i = 1; i < food.Count(); i++)
                {
                    if (food[i] != null)
                    {
                        this.cb_food_name.Items.Add(food[i].food_name);
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



        //Добавление диеты
        private void add_new_diet_in_food()
        {
            add_diet_in_food add_diet = new add_diet_in_food(Program.data_module);
            add_diet.ShowDialog();
        }


        //Конструктор, вызываемый для редактирования
        public add_diet_in_food(db_connect data_module, string diet_in_food_name_food, string diet_in_food_diet_numb, string diet_in_food_card_numb, int food_id, int diet_id, int card_id)
        {
            InitializeComponent();
            
            class_diet_in_food[] diet_in_food = new class_diet_in_food[512];
            diet_in_food = Program.add_read_module.get_list_diet_id();
            if (diet_in_food != null)
            {
                this.cb_diet_numb.Items.Clear();
                for (int i = 1; i < diet_in_food.Count(); i++)
                {
                    if (diet_in_food[i] != null)
                    {
                        this.cb_diet_numb.Items.Add(diet_in_food[i].diet_numb);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            class_diet_in_food[] card = new class_diet_in_food[512];
            card = Program.add_read_module.get_list_card_id();
            if (card != null)
            {
                this.cb_card_numb.Items.Clear();
                for (int i = 1; i < card.Count(); i++)
                {
                    if (card[i] != null)
                    {
                        this.cb_card_numb.Items.Add(card[i].card_numb);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            class_diet_in_food[] food = new class_diet_in_food[512];
            food = Program.add_read_module.get_list_food_name();
            if (food != null)
            {
                this.cb_food_name.Items.Clear();
                for (int i = 1; i < food.Count(); i++)
                {
                    if (food[i] != null)
                    {
                        this.cb_food_name.Items.Add(food[i].food_name);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            this.diet_id = diet_id.ToString();
            this.card_id = card_id.ToString();
            this.food_id = food_id.ToString();
          
            this.set_state("OLD");
           
           this.food_name = diet_in_food_name_food.ToString();
            this.diet_numb = diet_in_food_diet_numb.ToString();
            this.card_numb = diet_in_food_card_numb.ToString();

            this.fill_diet_in_food_data();
            this._data_module = data_module;
           
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_diet_in_food_data()
        {
            
            class_diet_in_food diet_in_food;
            diet_in_food = Program.add_read_module.get_diet_in_food(food_name, diet_numb, card_numb);
            if (diet_in_food.result == "OK")
            {
               
                this.cb_food_name.Text = diet_in_food.food_name;
                this.cb_diet_numb.Text = diet_in_food.diet_numb;
                this.cb_card_numb.Text = diet_in_food.card_numb;
            }
            else
            {
                //Не удалось получить сведений
                MessageBox.Show(diet_in_food.result);
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
                    this.p_status.Text = "";
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
                    this.cb_food_name.Enabled = false;
                    this.cb_card_numb.Enabled = false;
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
                    this.l_status.Text = "Добавление...";

                    result = Program.add_read_module.add_diet_in_food(this.cb_card_numb.Text,
                        this.cb_food_name.Text,
                        this.cb_diet_numb.Text);
                    this.Close();
                    break;


                //Если модифицируется существующая...
                case "MOD":
                    
           class_diet_in_food diet_in_food;
                diet_in_food = Program.add_read_module.get_diet_in_food(food_name, diet_numb, card_numb);

                string food_old = diet_in_food.food_name;
                string diet_old = diet_in_food.diet_numb;
                string card_old = diet_in_food.card_numb;
               
                this.l_status.Text = "Модификация данных... ";
                result = Program.add_read_module.upd_diet_in_food(Convert.ToInt32(this.food_id),
                 Convert.ToInt32(this.diet_id), Convert.ToInt32(this.card_id), this.cb_food_name.Text, this.cb_diet_numb.Text,
                     this.cb_card_numb.Text, food_old, diet_old, card_old);
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
                        this.p_status.Text = "Изменение записи успешно завершено";
                    }
            }
            else
            {
                this.p_status.Text = "Ошибка";
                MessageBox.Show(result);
            }

        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
