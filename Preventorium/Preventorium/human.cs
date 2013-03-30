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
    public partial class human : Form
    {
        public human()
        {
            InitializeComponent();
        }
        private string _id;
        private string _current_state;
        // загрузка таблицы в датагрид
        public void load_data_table(string state)
        {

            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;// скрываем не нужный столбец
            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        //Добавление сотрудника
        private void add_new_person()
        {
            add_person person = new add_person(Program.data_module);
            person.ShowDialog();
        }

        public void person_Load(object sender, EventArgs e)
        {
            this.load_data_table("Person");
            //перименование столбцов
            gw.Columns[1].HeaderText = "Фамилия";
            gw.Columns[2].HeaderText = "Имя";
            gw.Columns[3].HeaderText = "Отчество";
            gw.Columns[4].HeaderText = "Должность";
        }

        // редактирование по двойному клику 
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Person":
                    add_person person = null;
                    try
                    {
                        person = new add_person(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        person.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите сотрудника!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }
        // добавление сотрудника
        private void b_add_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Person":
                    this.add_new_person();
                    break;
            }

            this.load_data_table(this._current_state);
        }
        // редактирование
        private void b_edit_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Person":
                    add_person person = null;
                    try
                    {
                        person = new add_person(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        person.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите сотрудника!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);

        }

        //удаление 
        private void b_delete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Person":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите сотрудника!");
                    }
                    break;
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
            gw.CurrentCell = gw[1, rowIndex];

        }

        // редактирование ингридиента, событие для контекстного меню
        private void but_edit_Click(object sender, EventArgs e)
        {
            this.b_edit_Click(sender, e);
        }
        // удаление ингридиента, событие для контекстного меню
        private void but_delete_Click(object sender, EventArgs e)
        {
            this.b_delete_Click(sender, e);
        }
    }
}
