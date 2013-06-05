using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class human : Form
    {
        public human()
        {
            InitializeComponent();
        }
        private string _current_state;
        // загрузка таблицы в датагрид
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;// скрываем не нужный столбец
            gw.Columns[1].Visible = false;// скрываем не нужный столбец
            gw.Columns[2].Visible = false;// скрываем не нужный столбец
            gw.Columns[3].Visible = false;// скрываем не нужный столбец
            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        public void person_Load(object sender, EventArgs e)
        {
            this.load_data_table("Users");
            //перименование столбцов
            gw.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[4].HeaderText = "Фамилия";
            gw.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[5].HeaderText = "Имя";
            gw.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[6].HeaderText = "Отчество";
            gw.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[7].HeaderText = "Должность";
        }

        // редактирование по двойному клику 
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                    add_person person = null;
                    try
                    {
                        person = new add_person(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        person.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Выберите сотрудника!");
                    }
            this.load_data_table(this._current_state);
        }
        // добавление сотрудника
        private void b_add_Click(object sender, EventArgs e)
        {
            add_person person = new add_person(Program.data_module);
            person.ShowDialog();
            this.load_data_table(this._current_state);
        }

        // редактирование
        private void b_edit_Click(object sender, EventArgs e)
        {
            add_person person = null;
            try
            {
                person = new add_person(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                person.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите сотрудника!");
            }
            this.load_data_table(this._current_state);

        }

        //удаление 
        private void b_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                string result = Program.add_read_module.del_record_by_id(_current_state, "IDUsers", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите сотрудника!");
            }
            this.load_data_table(this._current_state);
        }

        // контексное меню в датагриде правой кнопкой , а также выделение строки правой кнопкой
        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;
            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[4, rowIndex];
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
                    b_edit_Click(sender, e);
                    gw.CurrentCell = gw[0, rowIndex];
                }

                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    b_add_Click(sender, e);
                }

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
