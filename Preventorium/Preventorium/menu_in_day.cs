using System;
using System.Windows.Forms;

namespace Preventorium
{
    /// <summary>
    /// Данный класс содержит дату о меню созданном на определенный день
    /// </summary>
    public partial class menu_in_day : Form
    {
        private string _current_state; //Содержит имя таблицы
        private int AddMenuID; //содержит ID меню
        private int queue; //содержит ID очереди

        //Конструктор формы
        public menu_in_day(int menu_id, int ID_queue)
        {
            AddMenuID = menu_id;
            queue = ID_queue;
            InitializeComponent();
        }
        
        //Загружаем данные из БД
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_menu_in_day(state,Convert.ToString( AddMenuID)).Tables[state];
            gw.DataSource = bs; //Передаем данные в дата грид
            //Скрываем столбцы
            gw.Columns[0].Visible = false;
            gw.Columns[2].Visible = false;
            //Обновляем дата гоид
            gw.Update();
            gw.Show();
            this._current_state = state;

        }

        //Вызываем метод загрузки данных из БД и передаем имя таблицы в виде параметра
        private void menu_Load(object sender, EventArgs e)
        {
            this.load_data_table("Menu_in_day");
            gw.Columns[1].HeaderText = "Меню на";//Переименовываем столбец
        }

        //Удаление меню
        private void b_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                //вызываем форму удаления
                string result = Program.add_read_module.del_record_by_id(_current_state, "day_id", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите дату!");
            }
            //обновляем дата грид вызывая метод загрузки данных из БД
            this.load_data_table(this._current_state);
        }

        /// <summary>
        /// Создание нового меню на день
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_add_Click(object sender, EventArgs e)
        {
            add_menu_in_day menu = new add_menu_in_day(Program.data_module, Convert.ToInt32(this.AddMenuID));
            menu.ShowDialog();
            //обновляем дата грид вызывая метод загрузки данных из БД
            this.load_data_table(this._current_state);
        }

        /// <summary>
        /// Метод обрабатывает вызов контекстного меню и вызывает его для нужной(выбранной) строки
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
        /// Вызываем форму содержащую блюда на завтрак, обед и ужин, а также передаем ид очереди, дня и меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_edit_Click(object sender, EventArgs e)
        {
          try
            {
                int day_id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString());//получаем текущий ид дня
                int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());//получаем текущий ид меню
             
                food_in_menu form = new food_in_menu(id, day_id, queue);//вызываем форму содержащую блюда в меню
                form.ShowDialog();
           }

            catch (Exception)
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Вызываем форму содержащую блюда на завтрак, обед и ужин, а также передаем ид очереди, дня и меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int day_id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString());
                int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                food_in_menu form = new food_in_menu(id, day_id, queue);
                form.ShowDialog();
            }

            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Обработчик события нажатия на клавиатуре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //при нажатии 'Enter' вызываем метод редактирования
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIndex = (gw.CurrentRow.Index - 1);

                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                    }

                    b_edit_Click(sender, e);

                    gw.CurrentCell = gw[0, rowIndex];
                }

                //При нажатии '+' вызываем метод добавления новой записи
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    b_add_Click(sender, e);
                }
                //При нажатии 'Del' вызываем метод удаления записи
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
