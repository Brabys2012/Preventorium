using System;
using System.Linq;
using System.Windows.Forms;

using System.Drawing;


namespace Preventorium
{
    public partial class add_cards : Form
    {

        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        private string card_id;
        private string food_name;
        private string food_id;

        /// <summary>
        /// событие активирует возможность сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enabled_b_save(object sender, EventArgs e)
        {
            if (this._state == "OLD") { this.set_state("MOD"); }
            //если блюдо выбрано и номер карты не пустой то кнопка "Созранить" активируется
            if ((cb_food.Text != "") && (tb_card_numb.Text != "")) { b_save.Enabled = true; }
         }

        /// <summary>
        /// Конструктор, вызываемый при нажатии "Добавить"
        /// </summary>
        /// <param name="data_module"></param>
        public add_cards(db_connect data_module)
        {
            InitializeComponent();
            
            //получаем список блюд
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

        /// <summary>
        /// Добавление карты
        /// </summary>
        private void add_new_cards()
        {
            add_cards card = new add_cards(Program.data_module);
            card.ShowDialog();
        }

        /// <summary>
        /// Конструктор, вызываемый для редактирования
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="card_id"></param>
        /// <param name="food_name"></param>
        /// <param name="food_id"></param>
        public add_cards(db_connect data_module, int card_id, string food_name, int food_id)
        {
            InitializeComponent();
            cb_food.Visible = false;
            label1.Visible = false;
            this.b_save.Location = new System.Drawing.Point(10, 130);
            this.b_cancel.Location = new System.Drawing.Point(160, 130);
            this.Size = new Size(520, 195);
          label2.Location= new System.Drawing.Point(5, 10);
          tb_cost.Location = new System.Drawing.Point(10, 30);
          label4.Location = new System.Drawing.Point(5, 55);

          tb_card_numb.Location = new System.Drawing.Point(10, 75);
            //получаем список блюд
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

        /// <summary>
        /// заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        /// </summary>
        public void fill_card_data()
        {     
            class_card card;
            card = Program.add_read_module.get_card(food_name);
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

        /// <summary>
        /// метод устанавливает состояние формы
        /// </summary>
        /// <param name="state"></param>
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

        /// <summary>
        /// событие при сохранении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.food_name, this.tb_cost.Text,
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

        /// <summary>
        /// событие при нажатии кнопки отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true; 
        }

             
    }
}
