using System;
using System.Windows.Forms;

namespace Preventorium
{

    /// <summary>
    /// Класс предоставляет информацию о блюде.
    /// </summary>
    public partial class food : Form
    {

        /// <summary>
        /// Название текущей таблицы.
        /// </summary>
        private const string _current_state = "Foods";

        /// <summary>
        /// Инициализирует экземпляр формы food.
        /// </summary>
        public food()   
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загружает данные из БД и отображеет в таблице.
        /// </summary>
        public void load_data_table()
        {
            bs.DataSource = Program.data_module.get_data_table(_current_state).Tables[_current_state]; //вызываем метод создаваемый запрос к БД
            gw.DataSource = bs;
            gw.Columns[0].Visible= false; //скрываем ненужный столбец
            gw.Update(); //обновляем дата грид
            gw.Show();
        }

        /// <summary>
        /// Нажатие кнопки добавления нового блюда.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddFood_Click(object sender, EventArgs e)
        {
            add_food food = new add_food(Program.data_module);
            food.ShowDialog();
            this.load_data_table(); //обновляем дата грид
        }

        /// <summary>
        /// Нажатие кнопки редактирование блюда.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEditFood_Click(object sender, EventArgs e)
        {
            add_food food = null;
            try
            {
                //вызываем форму редактирования
                food = new add_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                food.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите блюдо!");
            }
            this.load_data_table(); //обновляем дата грид
        }
        
        /// <summary>
        /// Выполняется при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void food_Load(object sender, EventArgs e)
        {
            this.load_data_table();
            gw.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[1].HeaderText = "Название блюда";
            gw.Columns[2].DefaultCellStyle.Format = "0.000";
            gw.Columns[2].Width = 50;
            gw.Columns[2].HeaderText = "Калорий в блюде";
            gw.Columns[3].DefaultCellStyle.Format = "0.00";
            gw.Columns[3].Width = 40;
            gw.Columns[3].HeaderText = "Белков в блюде";
            gw.Columns[4].DefaultCellStyle.Format = "0.00";
            gw.Columns[4].Width = 40;
            gw.Columns[4].HeaderText = "Жиров в блюде";
            gw.Columns[5].DefaultCellStyle.Format = "0.00";
            gw.Columns[5].Width = 40;
            gw.Columns[5].HeaderText = "Углеводов в блюде";
            gw.Columns[6].DefaultCellStyle.Format = "0.00 г.";
            gw.Columns[6].Width = 90;
            gw.Columns[6].HeaderText = "Вес готового блюда";
        }
           
        /// <summary>
        /// Происходит при двойном клике по записи таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_food food = null;
            try
            {
                food = new add_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                food.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите блюдо!");
            }
            this.load_data_table(); //обновляем дата грид
        }

        /// <summary>
        /// Происходит при нажатии кнопки удаления записи из таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                string result2 = Program.add_read_module.del_record_by_id(_current_state, "ID_Food", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите блюдо!");
            }
            this.load_data_table(); //обновляем дата грид
        }

        /// <summary>
        /// Происходит при открытии контекстного меню.
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
        /// Происходит при нажатии кнопок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //если наждата 'Enter', выхываем метод редактирования
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIndex = (gw.CurrentRow.Index - 1);

                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                    }

                    bEditFood_Click(sender,e);

                    gw.CurrentCell = gw[0, rowIndex];
                }
                // Если нажата '+' вызываем метод добавления новой записи
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    bAddFood_Click(sender, e);
                }
                //если нажата 'Del' вызываем метод удаления записи
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
