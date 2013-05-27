using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class add_diet_in_food : Form
    {
         //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        public int IDFood;

        /// <summary>
        /// присваиваем статус возможности редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enabled_b_save(object sender, EventArgs e)
        {
            if (this._state == "OLD") { this.set_state("MOD"); }
        }

        /// <summary>
        /// Конструктор, вызываемый при нажатии "Добавить"
        /// </summary>
        /// <param name="data_module"></param>
        public add_diet_in_food(db_connect data_module)
        {
            InitializeComponent();
            //если текст бокс с именем блюда пустой, то блокируем доступ к текст боксам с номером карты и номерами диет
            if (lb_food_name.Text == "") { tb_card_numb.Enabled = false; lb_diet_numb.Enabled = false; }
           
            //получаем список блюд
            class_diet_in_food[] food = new class_diet_in_food[512];
            food = Program.add_read_module.get_list_food_name();
            if (food != null)
            {
                this.lb_food_name.Items.Clear();
                for (int i = 1; i < food.Count(); i++)
                {
                    if (food[i] != null)//если запрос не пустой, то заполняем лист бокс списком блюд
                    {  
                       this.lb_food_name.Items.Add(food[i].food_name);
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
        /// Добавление диеты
        /// </summary>
        private void add_new_diet_in_food()
        {
            add_diet_in_food add_diet = new add_diet_in_food(Program.data_module);
            add_diet.ShowDialog();
        }

        /// <summary>
        /// устанавливаем состояние
        /// </summary>
        /// <param name="state"></param>
        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.Text = "Просмотр";

                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Добавление";
            
                    break;
            }
        }

        /// <summary>
        /// событие при нажатии на кнопку сохранить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_save_Click(object sender, EventArgs e)
        {
            //если не выбрано блюдо
            if (lb_food_name.Text == "") { MessageBox.Show("Вы не выбрали блюдо", "Внимание! ", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else //если не выбран номер диеты
            if (lb_diet_numb.Text == "") { MessageBox.Show("Вы не выбрали диету", "Внимание! ", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                string result = ""; //Результат попытки сохранения/добавления
                switch (this._state)
                {
                    //Если добавляется новая запись...
                    case "NEW":

                        result = Program.add_read_module.add_diet_in_food(this.tb_card_numb.Text,
                            this.lb_food_name.Text,
                            this.lb_diet_numb.Text);
                        this.Close();
                        break;
                }

                if (result == "OK")
                {
                    if (this._state == "NEW")
                    {
                        this.set_state("OLD");
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show(result);
                }
                this.Dispose();
            }
        }

        /// <summary>
        /// нажатие на кнопку отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Лист бокс с номерами диет активируется при выборе блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_food_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_diet_numb.Enabled = true;
            b_save.Enabled = true;
        }

        /// <summary>
        /// Заполняем лист бокс номерами диет при выборе блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_food_name_SelectedValueChanged(object sender, EventArgs e)
        {
            //получаем ID выбранного блюда
            class_food diet = new class_food();
            string query = "select ID_food from Foods "
                         + "where Name_food = '" + lb_food_name.Text + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    diet = new class_food();
                    diet.food_id = rd.GetInt32(0).ToString();
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                diet.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            //поолучаем список диет
            class_diet_in_food[] diet_in_food = new class_diet_in_food[512];
            diet_in_food = Program.add_read_module.get_list_diet_id(Convert.ToInt32(diet.food_id));
            if (diet_in_food != null)
            {
                this.lb_diet_numb.Items.Clear();
                for (int i = 1; i < diet_in_food.Count(); i++)
                {
                    if (diet_in_food[i] != null)
                    {
                        this.lb_diet_numb.Items.Add(diet_in_food[i].diet_numb);
                    }

                    else
                    {
                        break;
                    }
                }
            }

            //Записываем номер карты выбранного блюда в текст бокс 
            class_diet_in_food card = new class_diet_in_food();
            card = Program.add_read_module.get_list_card_id(Convert.ToInt32(diet.food_id));
            if (card != null)
            {
                tb_card_numb.Text = card.card_numb;
            }
        }             

    }
}
