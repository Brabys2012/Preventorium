using System;
using System.Windows.Forms;

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

        public void ingr_Load(object sender, EventArgs e)
        {
            this.load_data_table("Ingridients");
            //перименование столбцов
            gw.Columns[0].Width = 120;
            gw.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[0].HeaderText = "Название ингредиента";
            gw.Columns[1].Width = 40;
            gw.Columns[1].HeaderText = "Калории (на 100г. продукта)";
            gw.Columns[2].Width = 40;
            gw.Columns[2].HeaderText = "Углеводы (на 100г. продукта)";
            gw.Columns[3].Width = 40;
            gw.Columns[3].HeaderText = "Жиры (на 100г. продукта)";
            gw.Columns[4].Width = 80;
            gw.Columns[4].HeaderText = "Белки (на 100г. продукта)";
        }

        /// <summary>
        ///  редактирование по двойному клику 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_ingr ingr = null;
            try
            {
                ingr = new add_ingr(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                ingr.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите ингредиент!");
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
            add_ingr ingr = new add_ingr(Program.data_module);
            ingr.ShowDialog();
            this.load_data_table(this._current_state);
        }

        /// <summary>
        ///  редактирование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void read_but_Click(object sender, EventArgs e)
        {
            add_ingr ingr = null;
            try
            {
                ingr = new add_ingr(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                ingr.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите ингредиент!");
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
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {               
                string result1 = Program.add_read_module.del_record_by_id(_current_state, "Id_ingridients", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                
                if (result1 != "OK")
                {
                    MessageBox.Show("Удаление ингредиента невозможно, т.к он используется в блюде! ", "Внимание !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите ингредиент!");
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

