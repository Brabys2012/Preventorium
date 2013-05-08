using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class add_ingr_in_food : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string ingr_name;
        public string food_name;
        private string ingr_id;
        private int id;

        private void enabled_b_save(object sender, EventArgs e)
       {
            if (this._state == "OLD") { this.set_state("MOD"); };
            // Включается кнопка "Сохранить" если текстбоксы не пустые
            if ((tb_gross.Text != "") && (tb_net.Text != ""))  { this.b_save.Enabled = true; }   
        }

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_ingr_in_food(db_connect data_module, int food_id)
        {
            InitializeComponent();
            this.lb_ingr.Items.Clear();
            class_ingr_in_food[] ingr_in_food = new class_ingr_in_food[512];
            ingr_in_food = Program.add_read_module.get_list_ingr_id(food_id);
            if (ingr_in_food != null)
            {
                for (int i = 1; i < ingr_in_food.Count(); i++)
                {
                    if (ingr_in_food[i] != null)
                    {
                        this.lb_ingr.Items.Add(ingr_in_food[i].ingr_name);
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

        //Добавление ингридиента
        private void add_new_ingr_in_food()
        {
            add_ingr_in_food add_ingr = new add_ingr_in_food(Program.data_module, id);
            add_ingr.ShowDialog();
        }


        //Конструктор, вызываемый для редактирования
        public add_ingr_in_food(db_connect data_module, string ingr_in_food_name_food, string ingr_in_food_ingr_name, int ingr_id, int food_id)
        {
            InitializeComponent();
            this.lb_ingr.Items.Clear();
            class_ingr_in_food[] ingr_in_food = new class_ingr_in_food[512];
            ingr_in_food = Program.add_read_module.get_list_ingr_id(food_id);
            if (ingr_in_food != null)
            {
                this.lb_ingr.Items.Clear();
                for (int i = 1; i < ingr_in_food.Count(); i++)
                {
                    if (ingr_in_food[i] != null)
                    {
                        this.lb_ingr.Items.Add(ingr_in_food[i].ingr_name);
                    }

                    else
                    {
                        break;
                    }
                }
            }

            
            this.ingr_id = ingr_id.ToString();
          
            this.set_state("OLD");
           
            this.food_name = ingr_in_food_name_food.ToString();
            this.ingr_name = ingr_in_food_ingr_name.ToString();
         
            this.fill_ingr_in_food_data();
            this._data_module = data_module;
           
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_ingr_in_food_data()
        {
            
            class_ingr_in_food ingr_in_food;
            ingr_in_food = Program.add_read_module.get_ingr_in_food(ingr_name,food_name);
            if (ingr_in_food.result == "OK")
            {
               
                this.tb_gross.Text = ingr_in_food.gross;
                this.tb_net.Text = ingr_in_food.net;
                this.lb_ingr.Text = ingr_in_food.ingr_name;
            }
            else
            {
                //Не удалось получить сведений
                MessageBox.Show(ingr_in_food.result);
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
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Добавление";
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
            try
            {
                if (lb_ingr.Text == "") { MessageBox.Show("Выберите ингредиент!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    string brutto = tb_gross.Text;
                    string netto = tb_net.Text;
                    if (Convert.ToDouble(brutto) < Convert.ToDouble(netto))
                    {
                        MessageBox.Show("Вес брутто не может быть меньше веса нетто!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string result; //Результат попытки сохранения/добавления
                        switch (this._state)
                        {
                            //Если добавляется новая запись...
                            case "NEW":

                                result = Program.add_read_module.add_ingr_in_food(food_name,
                                 this.tb_gross.Text,
                                 this.tb_net.Text,
                                 this.lb_ingr.Text);
                                this.Close();
                                break;

                            //Если модифицируется существующая...
                            case "MOD":

                                class_ingr_in_food ingr_in_food;
                                ingr_in_food = Program.add_read_module.get_ingr_in_food(ingr_name, food_name);

                                string ingr_old = ingr_in_food.ingr_name;
                                string food_old = ingr_in_food.food_name;
                                string food_ID = ingr_in_food.id_food;

                                add_ingr_in_food ingr_in_foods = new add_ingr_in_food(Program.data_module, id);


                                result = Program.add_read_module.upd_ingr_in_food(Convert.ToInt32(this.ingr_id),
                                  food_name,
                                    this.tb_gross.Text,
                                     this.tb_net.Text,
                                     this.lb_ingr.Text,
                                     ingr_old, food_ID);
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
                }
            }
            catch
            {
                MessageBox.Show("Вес не может содержать букв!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

                         
    }
}
