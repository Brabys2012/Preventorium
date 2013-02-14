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
    public partial class Cards : Form
    {
        public Cards()
        {
            InitializeComponent();
        }

        private string _current_state;

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
    }
}
