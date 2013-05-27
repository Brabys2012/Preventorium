using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.Common;

namespace Preventorium
{
    public partial class ingr : Form
    {

        public ingr()
        {
            InitializeComponent();
        }

        private string _current_state;

        /// <summary>
        ///  загрузка таблицы в датагрид
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[5].Visible = false;// скрываем не нужный столбец
            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        /// <summary>
        /// Добавление ингредиента
        /// </summary>
        private void add_new_ingr()
        {
            add_ingr ingr = new add_ingr(Program.data_module);
            ingr.ShowDialog();
        }

   

        public void ingr_Load(object sender, EventArgs e)
        {
            this.load_data_table("Ingridients");
            //перименование столбцов
            gw.Columns[0].HeaderText = "Название ингредиента";
            gw.Columns[1].Width = 50;
            gw.Columns[1].HeaderText = "Калории";
            gw.Columns[2].Width = 50;
            gw.Columns[2].HeaderText = "Углеводы";
            gw.Columns[3].Width = 40;
            gw.Columns[3].HeaderText = "Жиры";
            gw.Columns[4].Width = 80;
            gw.Columns[4].HeaderText = "Белки";
        }

        /// <summary>
        ///  редактирование по двойному клику 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients":
                    add_ingr ingr = null;
                    try
                    {
                        ingr = new add_ingr(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        ingr.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите ингредиент!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }
        /// <summary>
        ///  добавление ингридиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_but_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients":
                    this.add_new_ingr();
                    break;
            }

            this.load_data_table(this._current_state);
        }

        /// <summary>
        ///  редактирование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void read_but_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients":
                    add_ingr ingr = null;
                    try
                    {
                        ingr = new add_ingr(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        ingr.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите ингредиент!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);

        }

       
        /// <summary>
        /// удаление 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void bDelete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Ingridients":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()), _current_state);
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите ингредиент!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }
        /// <summary>
        ///  выделение строки правой кнопкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;
            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[0, rowIndex];// 0  - это номер столбца
        }

        /// <summary>
        /// / редактирование ингридиента, событие для контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void read_butt_Click(object sender, EventArgs e)
        {
            this.read_but_Click(sender, e);
        }
        /// <summary>
        ///  удаление ингридиента, событие для контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void delete_butt_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender, e);
        }

        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    int rowIndex = (gw.CurrentRow.Index - 1);

                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                    }

                    this.read_but_Click(sender, e);

                    gw.CurrentCell = gw[0, rowIndex];
                }

                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    add_but_Click(sender, e);
                }

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

