using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class diets : Form
    {
        public diets()
        {
            InitializeComponent();
        }

        private string _current_state;

        public void load_data_table(string state)
        {

            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;
            gw.Columns[2].Visible = false;

            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        private void bAddDiet_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    this.add_new_diet();
                    break;
            }

            this.load_data_table(this._current_state);
        }

        //Добавление новой диеты
        private void add_new_diet()
        {
            add_diet diet = new add_diet(Program.data_module);
            diet.ShowDialog();
        }

        //редактирование диет
        public void bEditDiet_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    add_diet diet = null;
                    try
                    {
                        diet = new add_diet(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        diet.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите диету!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        public void diet_Load(object sender, EventArgs e)
        {

            this.load_data_table("Diets");
            gw.Columns[1].HeaderText = "Номер диеты";
                        
        }

        private void gw_CellClick(object sender, DataGridViewCellEventArgs e)
        {  

            class_diet diet = new class_diet();
            string cell = gw.CurrentCell.Value.ToString();
            string query = "select ID_Diets, NumOfDiet, Description from Diets";
            query += " where NumOfDiet = '" + cell +"'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    diet.result = "OK";
                    diet.diet_id = rd.GetInt32(0).ToString();
                    if (rd.IsDBNull(2))
                    {
                        diet.description = "";
                    }
                    else
                    {
                        diet.description = rd.GetString(2);
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                diet.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            tb_desc.Text = diet.description;
        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    add_diet diet = null;
                    try
                    {
                        diet = new add_diet(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        diet.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите диету!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Diets":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите диету!");
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

        private void read_diets_Click(object sender, EventArgs e)
        {
            this.bEditDiet_Click(sender, e);
        }

        private void del_diets_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender,e);
        }

        
    }
}
