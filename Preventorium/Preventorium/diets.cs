using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    /// <summary>
    /// данный класс содержит информацию о диетах
    /// </summary>
    public partial class diets : Form
    {
        /// <summary>
        /// конструктор формы
        /// </summary>
        public diets()
        {
            InitializeComponent();
        }

        private string _current_state;//содержит название таблицы

        /// <summary>
        /// метод скрывает ненужные столбцы и вызывает метод выполняющий запрос к БД
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {

            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;
            gw.Columns[2].Visible = false;

            gw.Update();//обновляем дата грид
            gw.Show();
            this._current_state = state;
        }

        /// <summary>
        /// добавление диеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddDiet_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    this.add_new_diet();
                    break;
            }

            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// Добавление новой диеты
        /// </summary>
        private void add_new_diet()
        {
            add_diet diet = new add_diet(Program.data_module);
            diet.ShowDialog();
        }

        /// <summary>
        /// редактирование диет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void bEditDiet_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    add_diet diet = null;
                    try
                    {
                        diet = new add_diet(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        diet.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите диету!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// вызываем метод загрузки данных из БД и переменовываем столбец
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void diet_Load(object sender, EventArgs e)
        {
            this.load_data_table("Diets");
            gw.Columns[1].HeaderText = "Номер диеты";            
        }

        /// <summary>
        /// метод выполняет загрузку содержания диеты в текст бокс при выборе конкретного номера диеты в дата гриде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_CellClick(object sender, DataGridViewCellEventArgs e)
        {  
            //запросом к БД получаем содержание диеты по конкретному ид диеты
            class_diet diet = new class_diet();
            string cell = gw.CurrentCell.Value.ToString();
            string query = "select ID_Diets, NumOfDiet, Description from Diets";
            query += " where NumOfDiet = '" + cell +"'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    diet.result = "OK";
                    diet.diet_id = rd.GetInt32(0).ToString();
                    if (rd.IsDBNull(2))
                    {
                        diet.description = "";
                    }
                    else
                    {
                        diet.description = rd.GetString(2);
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                diet.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            tb_desc.Text = diet.description;//заполняем текст бокс полученными данными
        }

        /// <summary>
        /// редактирование по двойному клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    add_diet diet = null;
                    try
                    {
                        diet = new add_diet(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        diet.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите диету!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите диету!");
                    }
                    break;


            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// метод вызывает контекстное меню для нужной (выбранной) строки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;
            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];
        }

        /// <summary>
        /// редактирование через контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void read_diets_Click(object sender, EventArgs e)
        {
            this.bEditDiet_Click(sender, e);
        }

        /// <summary>
        /// удаление через контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_diets_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender,e);
        }

        /// <summary>
        /// метод обрабатывает события нажатия на клавиши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //если нажата 'Enter' то редактирование
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIndex = (gw.CurrentRow.Index - 1);

                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                    }
                     bEditDiet_Click(sender, e);
                     gw.CurrentCell = gw[1, rowIndex];
                }
                //если нажата '+' то добавление новой записи
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    bAddDiet_Click(sender, e);
                }
                //если нажата 'Del' то удаление записи
                if (e.KeyCode == Keys.Delete)
                {

                    bDelete_Click(sender, e);
                }
            }
            catch
            { }
        }

        
    }
}
