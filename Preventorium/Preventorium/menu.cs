using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class menu : Form
    {
           private string _current_state;

           public menu()
           {
               InitializeComponent();
           }

           public void load_data_table(string state)
           {
               bs.DataSource = Program.data_module.get_menu("Menu").Tables[state];
               gw.DataSource = bs;
               gw.Columns[0].Visible = false;
               gw.Columns[1].Visible = false;
               gw.Update();
               gw.Show();
               this._current_state = state;
           }

           private void menu_Load(object sender, EventArgs e)
           {
               this.load_data_table("Menu");
               gw.Columns[2].HeaderText = "Номер очереди";
               gw.Columns[3].HeaderText = "Количество человек";
               gw.Columns[4].HeaderText = "Дата начала";
               gw.Columns[5].HeaderText = "Дата окончания";
           }

           //Удаление меню
           private void b_delete_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Menu":
                       delete del = null;
                       try
                       {
                           del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), "Menu");
                           del.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите очередь!");
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
               add_menu menu = new add_menu(Program.data_module);
               menu.ShowDialog();
           }

           private void b_add_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Menu":
                       this.add_new_menu();

                       break;
               }

               this.load_data_table(this._current_state);
           }

           private void b_editMenu_Click(object sender, EventArgs e)
           {
               this.b_edit_Click(sender, e);
           }

           private void b_delMenu_Click(object sender, EventArgs e)
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
               int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
               int queue = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString());
               menu_in_day form = new menu_in_day(id, queue);
               form.ShowDialog();
           }

           private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
               int queue=Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString());
               menu_in_day form = new menu_in_day(id,queue);
               form.ShowDialog();
           }
        
       }
}
