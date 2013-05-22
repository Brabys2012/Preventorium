using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class queue : Form
    {
        /// <summary>
        /// Переменная содержит имя таблицы
        /// </summary>
        private string _current_state;

        //Построение формы
        public queue()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод загружает данные дата грид
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;//скрываем ненужный столбец
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

        //редактирование очереди
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
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        //Переименовывем столбцы
        public void queue_Load(object sender, EventArgs e)
        {
            this.load_data_table("Queue");
            gw.Columns[1].HeaderText = "Число человек";
            gw.Columns[2].HeaderText = "Дата начала очереди";
            gw.Columns[3].HeaderText = "Дата окончания очереди";
            gw.Columns[4].HeaderText = "Продолжительность";
            gw.Columns[5].HeaderText = "Номер очереди";
        }

        //Событие обрабатывает двойной клик по записи и вызывет её на редактирование
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
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        //Удаление записи
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
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        //Контекстное меню
        private void Read_queue_Click(object sender, EventArgs e)
        {
            this.bEdit_Click(sender,e); //Редактироание записи
        }

        //Контекстное меню
        private void delete_queue_Click(object sender, EventArgs e)
        {
            this.bDelete_Click(sender,e);//Удаление записи
        }

        //Метод обрабатывает событие нажатия правой кнопкой мыши при вызове контекстного меню и вызывает его для нужной(выбранной) строки
        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;

            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];// 0  - это номер столбца
        }

        //Работа с записями с клавиатуры
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Если нажата клавиша Enter, то вызываем на редактирование
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIndex = (gw.CurrentRow.Index - 1);

                    if (rowIndex < 0)
                    {
                        rowIndex = 0;
                    }

                    this.bEdit_Click(sender, e);

                    gw.CurrentCell = gw[1, rowIndex];
                }

                //Если нажат '+', то добавляем новую запись
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    bAdd_Click(sender, e);
                }

                //Если нажата клавиша 'Del', то вызываем на удаление
                if (e.KeyCode == Keys.Delete)
                {

                    bDelete_Click(sender, e);
                }
            }
            catch
            { }
        }

    }
}
