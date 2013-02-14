using System;
using System.Linq;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_cards : Form
    {

        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string card_id;
        private string food_name;
        private string food_id;

        private void enabled_b_save(object sender, EventArgs e)
        {
            this.b_save.Enabled = true;
            if (this._state == "OLD") { this.set_state("MOD"); };
        }

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_cards(db_connect data_module)
        {
            InitializeComponent();
            
            class_card[] card = new class_card[512];
            card = Program.add_read_module.get_list_food_name_in_card();
            if (card != null)
            {
                this.cb_food.Items.Clear();
                for (int i = 1; i < card.Count(); i++)
                {
                    if (card[i] != null)
                    {
                        this.cb_food.Items.Add(card[i].food_name);
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

        //Добавление карты
        private void add_new_cards()
        {
            add_cards card = new add_cards(Program.data_module);
            card.ShowDialog();
        }

        //Конструктор, вызываемый для редактирования
        public add_cards(db_connect data_module, int card_id, string food_name, int food_id)
        {
            InitializeComponent();
            
            class_card[] card = new class_card[512];
            card = Program.add_read_module.get_list_food_name_in_card();
            if (card != null)
            {
                this.cb_food.Items.Clear();
                for (int i = 1; i < card.Count(); i++)
                {
                    if (card[i] != null)
                    {
                        this.cb_food.Items.Add(card[i].food_name);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            this.card_id = card_id.ToString();
            this.food_id = food_id.ToString();  
            this.set_state("OLD");
            this.food_name = food_name.ToString();
            this.fill_card_data();
            this._data_module = data_module;
           
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_card_data()
        {     
            class_card card;
            card = Program.add_read_module.get_card(Convert.ToInt32(this.card_id), food_name);
            if (card.result == "OK")
            {
               
                this.cb_food.Text = card.food_name;
                this.tb_cost.Text = card.cost;
                this.tb_method.Text = card.method;
                this.tb_card_numb.Text = card.card_numb;
            }
            else
            {
                //Не удалось получить сведений
                MessageBox.Show(card.result);
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

                    result = Program.add_read_module.add_card(this.cb_food.Text,
                        this.tb_cost.Text,
                        this.tb_method.Text,
                        this.tb_card_numb.Text);
                    this.Close();
                    break;


                //Если модифицируется существующая...
                case "MOD":

                result = Program.add_read_module.upd_card(Convert.ToInt32(this.card_id),
                Convert.ToInt32(this.food_id),
                this.cb_food.Text, this.tb_cost.Text,
                     this.tb_method.Text,
                     this.tb_card_numb.Text);
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

            this.Dispose();

        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
