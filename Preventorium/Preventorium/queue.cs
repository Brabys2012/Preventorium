using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class queue : Form
    {
        private string _current_state;

        public queue()
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

        //Добавление очереди
        private void add_new_queue()
        {
            add_queue queue = new add_queue(Program.data_module);
            queue.ShowDialog();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Queue":
                    this.add_new_queue();
                    break;
            }

            this.load_data_table(this._current_state);
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Queue":
                    add_queue queue = null;
                    try
                    {
                        queue = new add_queue(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        queue.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите очередь!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        public void queue_Load(object sender, EventArgs e)
        {
            this.load_data_table("Queue");
            gw.Columns[1].HeaderText = "Число человек";
            gw.Columns[2].HeaderText = "Дата начала очереди";
            gw.Columns[3].HeaderText = "Дата окончания очереди";
            gw.Columns[4].HeaderText = "Продолжительность";
            gw.Columns[5].HeaderText = "Номер очереди";
        }

        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this._current_state)
            {
                case "Queue":
                    add_queue queue = null;
                    try
                    {
                        queue = new add_queue(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        queue.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите очередь!");
                    }
                    break;
            }
            this.load_data_table(this._current_state);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Queue":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
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

        private void Read_queue_Click(object sender, EventArgs e)
        {
            this.bEdit_Click(sender,e);
        }

        private void delete_queue_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender,e);
        }

    }
}
