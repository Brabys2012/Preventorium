using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class cooking_book : Form
    {
        private string _current_state;

        public cooking_book()
        {
            InitializeComponent();
        }

        public void load_data_table(string state)
        {

            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;

            gw.Update();
            gw.Show();
            this._current_state = state;
        }


        //Добавление справочника
        private void add_new_book()
        {
            add_book book = new add_book(Program.data_module);
            book.ShowDialog();
        }

        private void bAddBook_Click(object sender, EventArgs e)
        {

            switch (this._current_state)
            {
                case "Book":
                    this.add_new_book();
                    break;
            }

            this.load_data_table(this._current_state);
        }

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
            this.load_data_table(this._current_state);
        }

        public void book_Load(object sender, EventArgs e)
        {

            this.load_data_table("Book");
            gw.Columns[1].HeaderText = "Автор(ы)";
            gw.Columns[2].DefaultCellStyle.Format = "##.00 год.";
            gw.Columns[2].HeaderText = "Год выпуска";
            gw.Columns[3].HeaderText = "Название";

        }

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
            this.load_data_table(this._current_state);
        }

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
            this.load_data_table(this._current_state);
        }

        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;
            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];
        }

        private void Read_menu_book_Click(object sender, EventArgs e)
        {
            this.bEditBook_Click(sender,e);
        }

        private void delete_menu_book_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender, e);
        }
    }
}
