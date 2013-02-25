using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class food : Form
    {
        private string _current_state;

        public food()   
        {
            InitializeComponent();
        }
       
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible= false;

            gw.Update();
            gw.Show();
            this._current_state = state;
        }

         //Добавление блюда
        private void add_new_food()
        {
            add_food food = new add_food(Program.data_module);
            food.ShowDialog();
        }
        
        private void bAddFood_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Foods":
                       this.add_new_food();
                       break;
               }

               this.load_data_table(this._current_state);
           }

        // Редактирование блюд
           private void bEditFood_Click(object sender, EventArgs e)
           {
                switch (this._current_state)
            {
                case "Foods":
                   add_food food = null;
                    try
                    {
                        food = new add_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        food.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                    break;
       
            }
                 this.load_data_table(this._current_state);
        }

        public void food_Load(object sender, EventArgs e)
           {

               this.load_data_table("Foods");
               gw.Columns[1].HeaderText = "Название блюда";
               gw.Columns[2].HeaderText = "Калории";
               gw.Columns[3].HeaderText = "Белки";
               gw.Columns[4].HeaderText = "Жиры";
               gw.Columns[5].HeaderText = "Углеводы";
               gw.Columns[6].HeaderText = "Вес готового блюда";
              
           }

           private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               switch (this._current_state)
               {
                   case "Foods":
                       add_food food = null;
                       try
                       {
                           food = new add_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                           food.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;

               }
               this.load_data_table(this._current_state);
           }

           private void bDelete_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Foods":
                       delete del = null;
                       try
                       {
                           del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
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

           private void gw_MouseDown(object sender, MouseEventArgs e)
           {

               int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
               if (rowIndex == -1) return;

               gw.ClearSelection();
               gw.Rows[rowIndex].Selected = true;
               gw.CurrentCell = gw[1, rowIndex];
           }

           
        

           private void delete_memu_strip_Click(object sender, EventArgs e)
           {
               this.bDelete_Click(sender, e);
           }

           private void menu_strip_food_read_Click(object sender, EventArgs e)
           {

               this.bEditFood_Click(sender, e);
           }    
    }
}
