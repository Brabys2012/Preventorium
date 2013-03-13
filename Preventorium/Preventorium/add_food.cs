using System;
using System.Drawing;
using System.Windows.Forms;

namespace Preventorium
{
    /// <summary>
    /// Форма добавления и редактирования ингридиентов в блюде
    /// </summary>
    public partial class add_food : Form
    {
        public string name_old;
        private string _current_state;

        /// <summary>
        /// модуль, через который работать с базой
        /// </summary>
        private db_connect _data_module;
        /// <summary>
        /// Состояние (new/old/mod)
        /// </summary>
        private string _state;
        //ID блюда для загрузки данных (в режиме OLD)
        private string _id;
        
        // Конструктор, вызываемый при нажатии "Добавить" 
        public add_food(db_connect data_module)
        {
            InitializeComponent();
            groupBox1.Visible = false;
            groupBox1.Enabled = false;
            this.Size = new Size(240, 150);
            this._data_module = data_module;
            this.b_save.Location = new Point(22,85);
            this.b_abolition.Location = new Point(132, 85);
            l_weight.Visible = false;
            gb_food_data.Size = new Size(205, 65);
            gb_chem_contain.Visible = false;
            tb_calories.Enabled = false;
            tb_carbo.Enabled = false;
            tb_fats.Enabled = false;
            tb_proteins.Enabled = false;
            tb_weight.Enabled = false;
           
            this.set_state("NEW");
            }

        //Конструктор, вызываемый
        //для редактирования существующего блюда
        public add_food(db_connect data_module, int food_id)
        {
            InitializeComponent();
            this._id = food_id.ToString();
            this._data_module = data_module;
            tb_calories.Enabled = false;
            tb_carbo.Enabled = false;
            tb_fats.Enabled = false;
            tb_proteins.Enabled = false;
            tb_weight.Enabled = false;
            this.fill_food_data();
            this.set_state("OLD");                 
        }


        //Сохраняем/добавляем запись о блюде
        private void enabled_b_save(object sender, EventArgs e)
        {
                               
            Program.add_read_module.upd_food_(tb_name.Text, _id);
            
            if (this._state == "OLD") { this.set_state("MOD"); };
          
            if (tb_name.Text != "")
            {
                this.b_save.Enabled = true;
                return;
            }
             
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            string result; //Результат попытки сохранения/добавления блюда
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":
                    result = Program.add_read_module.add_food(this.tb_name.Text,
         this.tb_calories.Text,
         this.tb_proteins.Text,
         this.tb_fats.Text,
         this.tb_carbo.Text,
         this.tb_weight.Text);
                    this.Close();
                    break;

                //Если модифицируется существующая...
                case "MOD":
                    result = Program.add_read_module.upd_food(Convert.ToInt32(this._id),
                    this.tb_name.Text,
         this.tb_calories.Text,
         this.tb_proteins.Text,
         this.tb_fats.Text,
         this.tb_carbo.Text,
         this.tb_weight.Text);
                    break;

                default:
                    result = "Ошибка ";
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


        //устанавливает указанный в параметрах статус как состояние формы, в соответствии с 
        //которым устанавливает параметры всех элементов формы, соответствующие указанному состоянию
        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.Text = "Блюдо - Просмотр";
                    this.b_save.Enabled = true;
                 
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Блюдо - Добавление";
                    if (tb_name.Text !="")
            
                    this.b_save.Enabled = false;
                    break;

                case "MOD":
              
                    this._state = "MOD";
                   this.b_save.Enabled = true;
                    break;
            }
        }

        //заполняет форму данными о блюде, полученными из базы данных при просмотре существующей в БД записи
        public void fill_food_data()
        {
            class_food food;
            food = Program.add_read_module.get_food(Convert.ToInt32(this._id));
            if (food.result == "OK")
            {
                this.tb_name.Text = food.name;
                this.tb_calories.Text = food.calories;
                this.tb_proteins.Text = food.proteins;
                this.tb_fats.Text = food.fats;
                this.tb_carbo.Text = food.carbo;
                this.tb_weight.Text = food.weight;
                this.Update();
            }
            else
            {
                //Не удалось получить сведений о текущем блюде
                MessageBox.Show(food.result);
                this.Dispose();
            }
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            tb_name.Text = name_old; 
            this.Dispose();
        }

        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table2("Ingridients_in_food", Convert.ToInt32(this._id)).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;
            gw.Columns[4].Visible = false;
            gw.Columns[5].Visible = false;
            gw.Update();
            gw.Show();
            this._current_state = state;
           
        }

        private void add_food_Load(object sender, EventArgs e)
        {
            this.load_data_table("Ingridients_in_food");
            gw.Columns[1].HeaderText = "Ингредиенты";
            gw.Columns[2].DefaultCellStyle.Format = "##.00 г.";
            gw.Columns[2].HeaderText = "Брутто вес";
            gw.Columns[3].DefaultCellStyle.Format = "##.00 г.";
            gw.Columns[3].HeaderText = "Нетто вес";
            name_old = tb_name.Text;
                      
        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients_in_food":
                    add_ingr_in_food ingr_in_food = null;
                    try
                    {
                      
                        ingr_in_food = new add_ingr_in_food(Program.data_module, gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString(),
                                                                                 gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString()),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        ingr_in_food.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите ингридиент!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
            this.fill_food_data();
            this.Update();
        }

        //Удаление ингредиента из блюда
        private void bDelete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients_in_food":
                    del_ingr_from_food del = null;
                    try
                    {
                        this.load_data_table(this._current_state);
                        del = new del_ingr_from_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString()), Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите ингридиент!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
            this.fill_food_data();
            this.Update();
        }

        //Редактирование ингредиента в блюде
        private void bEditIngr_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients_in_food":

                    add_ingr_in_food ingr_in_food = null;
                    try
                    {
                        this.load_data_table(this._current_state);

                        
                        
                        ingr_in_food = new add_ingr_in_food(Program.data_module, gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString(),
                                                                                 gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString()),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        ingr_in_food.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите ингридиент!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
            this.fill_food_data();
            this.Update();
        }

        /// <summary>
        /// Добавление нового ингридиента в блюдо.
        /// </summary>
        private void add_new_ingr_in_food(string id)
        {
            add_ingr_in_food ingr_in_food = new add_ingr_in_food(Program.data_module, id);
            ingr_in_food.food_name = this.tb_name.Text;
            ingr_in_food.ShowDialog();
        }

        private void bAddIngr_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients_in_food":
                    this.add_new_ingr_in_food(_id);
                    
                    break;
            }

            this.load_data_table(this._current_state);
            this.fill_food_data();
            this.Update();
        }

       

        private void read_menu_food_Click(object sender, EventArgs e)
        {
            this.bEditIngr_Click(sender,e);
        }

        private void b_del_menu_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender,e);
        }

        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;

            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];
        }

        private void b_card_Click(object sender, EventArgs e)
        {
            Cards_layout form = new Cards_layout(tb_name.Text);
            form.ShowDialog();
        }

    }
}
