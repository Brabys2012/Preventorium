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
            gw.Columns[4].Visible = false;
            gw.Update();
            gw.Show();
            this._current_state = state;
        }

        //Добавление новой записи
        private void bAdd_Click(object sender, EventArgs e)
        {
            add_queue queue = new add_queue(Program.data_module);
            queue.ShowDialog();
            this.load_data_table(this._current_state);
        }

        //редактирование очереди
        private void bEdit_Click(object sender, EventArgs e)
        {
               add_queue queue = null;
               try
               {
                   queue = new add_queue(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                   queue.ShowDialog();
               }
               catch (Exception)
               {
                   MessageBox.Show("Выберите очередь!");
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
            gw.Columns[5].HeaderText = "Номер очереди";
        }

        //Событие обрабатывает двойной клик по записи и вызывет её на редактирование
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           add_queue queue = null;
           try
           {
              queue = new add_queue(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
              queue.ShowDialog();
           }
              catch (Exception)
           {
               MessageBox.Show("Выберите очередь!");
           }
           this.load_data_table(this._current_state);//обновляем дата грид
        }

        //Удаление записи
        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                string result = Program.add_read_module.del_record_by_id(_current_state, "ID_queue", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите очередь!");
            }
            this.load_data_table(this._current_state); //обновляем дата грид
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
