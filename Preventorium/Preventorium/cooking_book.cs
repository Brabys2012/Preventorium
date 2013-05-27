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
        /// Добавление справочника
        /// </summary>
        private void add_new_book()
        {
            add_book book = new add_book(Program.data_module);
            book.ShowDialog();
        }

        /// <summary>
        /// Добавление нового справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddBook_Click(object sender, EventArgs e)
        {

            switch (this._current_state)
            {
                case "Book":
                    this.add_new_book();
                    break;
            }

            this.load_data_table(this._current_state);//обновление дата грид
        }

        /// <summary>
        /// Редактирование справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEditBook_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Book":
                    add_book book = null;
                    try
                    {
                        book = new add_book(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        book.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите справочник!");
                    }
                    break;

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
            gw.Columns[1].HeaderText = "Автор(ы)";
            gw.Columns[2].DefaultCellStyle.Format = "## год.";
            gw.Columns[2].HeaderText = "Год выпуска";
            gw.Columns[3].HeaderText = "Название";
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
                case "Book":
                    add_book book = null;
                    try
                    {
                        book = new add_book(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        book.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите справочник!");
                    }
                    break;

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
            switch (this._current_state)
            {
                case "Book":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите справочник!");
                    }
                    break;
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
        /// редактирование через контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Read_menu_book_Click(object sender, EventArgs e)
        {
            this.bEditBook_Click(sender,e);
        }

        /// <summary>
        /// удаление через контекстное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_menu_book_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender, e);
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
