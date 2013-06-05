using System;
using System.Windows.Forms;

namespace Preventorium
{
    /// <summary>
    /// класс содержит информацию о кулинаргый справочниках
    /// </summary>
    public partial class cooking_book : Form
    {
        private string _current_state;//содержит название таблицы

        /// <summary>
        /// конструктор формы
        /// </summary>
        public cooking_book()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод заполняет дата грид данными и вызывает метод который создает запрос к БД, а также скрывает столбцы
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;

            gw.Update();//обновляем дата грид
            gw.Show();
            this._current_state = state;
        }

        /// <summary>
        /// Добавление нового справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddBook_Click(object sender, EventArgs e)
        {
            add_book book = new add_book(Program.data_module);
            book.ShowDialog();
            this.load_data_table(this._current_state);//обновление дата грид
        }

        /// <summary>
        /// Редактирование справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEditBook_Click(object sender, EventArgs e)
        {
            add_book book = null;
            try
            {
                 book = new add_book(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                 book.ShowDialog();
            }
            catch (Exception)
            {
                 MessageBox.Show("Выберите справочник!");
            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// метод форматирует и переименовывает столбцы, а также вызывает метод заполняющий дата грид
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void book_Load(object sender, EventArgs e)
        {
            this.load_data_table("Book");
            gw.Columns[1].Width = 180;
            gw.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[1].HeaderText = "Автор(ы)";
            gw.Columns[2].Width = 100;
            gw.Columns[2].DefaultCellStyle.Format = "## год.";
            gw.Columns[2].HeaderText = "Год выпуска";
            gw.Columns[3].Width = 250;
            gw.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[3].HeaderText = "Название";
        }

        /// <summary>
        /// редактирование по двойному клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             add_book book = null;
             try
             {
                 book = new add_book(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                 book.ShowDialog();
             }
             catch (Exception)
             {
                 MessageBox.Show("Выберите справочник!");
             }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
               string result4 = Program.add_read_module.del_record_by_id(_current_state, "IDBook", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            catch (Exception)
            {
               MessageBox.Show("Выберите справочник!");
            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// метод вызывает контекстное меню для нужной(выбранной) строки
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
        /// метод обрабатывает события нажати я на клавиши
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
                    bEditBook_Click(sender, e);
                    gw.CurrentCell = gw[0, rowIndex];
                }
                //если нажата '+', то добавление записи
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    bAddBook_Click(sender, e);
                }
                //если нажата 'Del', то удаление записи
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
