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
    public partial class diet_in_food : Form
    {
        public diet_in_food()
        {
            InitializeComponent();
        }

        private string _current_state;

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

        private void b_add_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Food_in_diets":
                    this.add_new_diet_in_food();

                    break;
            }

            this.load_data_table(this._current_state);
        }

        //Добавление новой диеты в блюдо
        private void add_new_diet_in_food()
        {
            add_diet_in_food diet_in_food = new add_diet_in_food(Program.data_module);
            diet_in_food.ShowDialog();
        }

        //редактирование
        private void b_edit_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Food_in_diets":

                    add_diet_in_food diet_in_food = null;
                    try
                    {
                        diet_in_food = new add_diet_in_food(Program.data_module, gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString(),
                                                                                 gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                                                                 gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString(),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[3].Value.ToString()),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString()),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        diet_in_food.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        public void diet_in_food_Load(object sender, EventArgs e)
        {

            this.load_data_table("Food_in_diets");
            gw.Columns[0].HeaderText = "Блюдо";
            gw.Columns[1].HeaderText = "Номер диеты";
            gw.Columns[2].HeaderText = "Номер карты";

        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Food_in_diets":

                    add_diet_in_food diet_in_food = null;
                    try
                    {
                        diet_in_food = new add_diet_in_food(Program.data_module, gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString(),
                                                                                 gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                                                                 gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString(),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[3].Value.ToString()),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString()),
                                                                                 Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        diet_in_food.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

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
    }
}
