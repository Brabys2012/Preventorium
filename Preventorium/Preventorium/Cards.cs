using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Preventorium
{
    public partial class Cards : Form
    {
        private string _current_state;

        public class_card[] _card_list;

        public Cards()
        {
            InitializeComponent();
        }



        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table_cards("Cards").Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;
            gw.Columns[5].Visible = false;
            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Cards":
                    this.add_new_card();

                    break;
            }

            this.load_data_table(this._current_state);
        }

        //Добавление новой карты
        private void add_new_card()
        {
            add_cards card = new add_cards(Program.data_module);
            card.ShowDialog();
        }

        //редактирование карты
        private void b_edit_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Cards":

                    add_cards card = null;
                    try
                    {
                        card = new add_cards(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()),
                                            gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                            Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        card.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите карту!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        public void card_Load(object sender, EventArgs e)
        {
            
            this.load_data_table("Cards");
            gw.Columns[1].HeaderText = "Блюдо";
            gw.Columns[2].HeaderText = "Ориентировочная стоимость";
            gw.Columns[3].HeaderText = "Метод приготовления";
            gw.Columns[4].HeaderText = "Номер карты";

        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Cards":
                    add_cards card = null;
                    try
                    {
                        card = new add_cards(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()),
                                            gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                            Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                        card.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите карту!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Cards":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), "Cards");
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите карту!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }
        public class_card[] get_card_list()
        {
            class_card[] card = new class_card[512];
            string cell = gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString();
            string query = "select C.Id_Cards, C.Number_Card, C.Method_of_cooking, D.NumOfDiet from Cards C ";
            query += "join Food_In_Diets FIN on C.Id_Cards = FIN.Id_Cards ";
            query += "join Diets D on D.ID_Diets = FIN.ID_Diets ";
            query += "where Number_Card = '" + cell + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                
                  int i = 0;
                  while (rd.Read())
                {
                        i = i + 1;
                        card[i] = new class_card();
                        card[i].result = "OK";
                        
                        card[i].diet_numb = rd.GetString(3).ToString();


                        if (rd.IsDBNull(2))
                        {
                            card[i].method = "";
                        }
                        else
                        {
                            card[i].method = rd.GetString(2);
                        }

                    }
                            
                rd.Close();
                rd.Dispose();
                com.Dispose();
            
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;

            }  return card;

                    }


        public void gw_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          this._card_list = this.get_card_list();
                 

         if (this._card_list != null)
            {
               this.lb_diet.Items.Clear();


            }
            for (int i = 1; i < this._card_list.Count(); i++)
            {
                if (this._card_list[i] != null)
                {

                    lb_diet.Items.Add(_card_list[i].diet_numb);

                    tb_method.Text = _card_list[i].method;
                }
                else
                {
                    break;
                }

            }

                        
            class_card[] card = new class_card[512];
            string cell = gw.Rows[gw.CurrentRow.Index].Cells[3].Value.ToString();
            string query = "select * from Cards where Method_of_cooking='" + cell + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    card[i] = new class_card();
                    card[i].result = "OK";
                 
                    if (rd.IsDBNull(3))
                    {
                        card[i].method = "";
                    }
                    else
                    {
                        card[i].method = rd.GetString(3);
                        tb_method.Text = card[i].method;
                    }
                   
                }
                    rd.Close();
                    rd.Dispose();
                    com.Dispose();
            }

            catch (Exception ex)
            {
               MessageBox.Show( "ERROR_" + ex.Data + " " + ex.Message);
            }

        }

        private void gw_DoubleClick(object sender, EventArgs e)
        {
            this.b_edit_Click(sender, e);
        }

        private void Read_card_Click(object sender, EventArgs e)
        {
            this.b_edit_Click(sender,e);
        }

        private void Del_card_Click(object sender, EventArgs e)
        {
            this.b_delete_Click(sender,e);
        }

        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;

            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];
        }

        

              

        
    }
}

