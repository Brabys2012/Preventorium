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
    /// <summary>
    /// данный класс содержит информацию о том, какие диеты содержатся в блюде
    /// </summary>
    public partial class diet_in_food : Form
    {
        /// <summary>
        /// конструктор формы
        /// </summary>
        public diet_in_food()
        {
            InitializeComponent();
        }

        private string _current_state;//содержит название таблицы

        /// <summary>
        /// метод загружает данные в дата грид, скрывает ненужные столбцы и вызывает метод который создает запрос к БД
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table_diet_in_food("Food_In_Diets").Tables[state];
            gw.DataSource = bs;
            gw.Columns[3].Visible = false;
            gw.Columns[4].Visible = false;
            gw.Columns[5].Visible = false;
            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        /// <summary>
        /// добавление диеты в блюдо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_add_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Food_in_diets":
                    this.add_new_diet_in_food();

                    break;
            }

            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// Добавление новой диеты в блюдо
        /// </summary>
        private void add_new_diet_in_food()
        {
            add_diet_in_food diet_in_food = new add_diet_in_food(Program.data_module);
            diet_in_food.ShowDialog();
        }

        /// <summary>
        /// вызываем метод загрузки данных в дата грид, а также переименовываем и форматируем столбцы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void diet_in_food_Load(object sender, EventArgs e)
        {

            this.load_data_table("Food_in_diets");
            gw.Columns[0].HeaderText = "Блюдо";
            gw.Columns[1].Width = 40;
            gw.Columns[1].HeaderText = "Номер диеты";
            gw.Columns[2].Width = 100;
            gw.Columns[2].HeaderText = "Номер карты";

        }

        /// <summary>
        /// удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_delete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Food_in_diets":
                    del_diet_from_food del = null;
                    try
                    {
                        del = new del_diet_from_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[3].Value.ToString()), Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString()), Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        /// <summary>
        /// контексное меню в датагриде правой кнопкой , а также выделение строки правой кнопкой
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
        /// удаление через контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_Click(object sender, EventArgs e)
        {
            this.b_delete_Click(sender, e);
        }

        /// <summary>
        /// обработка события нажатия на клавиши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {                
                //если нажата '+' то добавление записи
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    b_add_Click(sender, e);
                }
                //если нажата 'Del' то удаление записи
                if (e.KeyCode == Keys.Delete)
                {

                    b_delete_Click(sender, e);
                }
            }
            catch
            { }
        }

      
    }
}
