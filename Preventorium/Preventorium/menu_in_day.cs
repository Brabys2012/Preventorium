using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class menu_in_day : Form
    {
        private string _current_state;
        private string _id ;
        private int AddMenuID;

            public menu_in_day(int menu_id)
        {
            AddMenuID = menu_id;
            InitializeComponent();
        }
        
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_menu_in_day(state,Convert.ToString( AddMenuID)).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;
            gw.Columns[2].Visible = false;
            gw.Update();
            gw.Show();
            this._current_state = state;

        }

        private void menu_Load(object sender, EventArgs e)
        {
            this.load_data_table("Menu_in_day");
            gw.Columns[1].HeaderText = "Меню на";
        }

        //Удаление меню
        private void b_delete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Menu_in_day":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString()), "Menu_in_day");
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите дату!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }
        
        /// <summary>
        /// Добавление меню
        /// </summary>
        private void add_new_menu()
        {
            add_menu_in_day menu = new add_menu_in_day(Program.data_module, Convert.ToInt32(this.AddMenuID));
            menu.ShowDialog();
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Menu_in_day":
                    this.add_new_menu();

                    break;
            }

            this.load_data_table(this._current_state);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            this.b_delete_Click(sender, e);
        }

        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;

            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];
        }

        private void b_edit_Click(object sender, EventArgs e)
        {
          try
            {
                int day_id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString());
                int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
             
                food_in_menu form = new food_in_menu(id, day_id);
                form.ShowDialog();
           }

            catch (Exception ex)
            {
            
            }
        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int day_id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString());
                int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                food_in_menu form = new food_in_menu(id, day_id);
                form.ShowDialog();
            }

            catch (Exception ex)

            { 
            
            }
        }

    }
}
