using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_queue : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID очереди для загрузки данных (в режиме OLD)
        private string _id;

        // Конструктор, вызываемый при нажатии "Добавить" 
        public add_queue(db_connect data_module)
        {
            InitializeComponent();
            this._data_module = data_module;
            this.set_state("NEW");      
        }

        //Конструктор, вызываемый
        //для редактирования существующей очереди
        public add_queue(db_connect data_module, int queue_id)
        {
            InitializeComponent();
            this._id = queue_id.ToString();
            this._data_module = data_module;
            this.fill_queue_data();
            this.set_state("OLD");
        }


        //Сохраняем/добавляем запись о очереди
        private void enabled_b_save(object sender, EventArgs e)
        {
            if (this._state == "OLD") { this.set_state("MOD"); }
            if ((tb_mens.Text != "") && (tb_start.Text != "") && (tb_end.Text != "") && (tb_numb.Text != "")) { b_save.Enabled = true; }
            else
                b_save.Enabled = false;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            
            string result ="";
            string start = tb_start.Value.ToString("dd.MM.yyyy");
            string end = tb_end.Value.ToString("dd.MM.yyyy");
            //Результат попытки сохранения/добавления очереди
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":
                    result = Program.add_read_module.add_queue(this.tb_mens.Text, this.tb_numb.Text, start,end);
                    this.Close();
                    break;
            
                //Если модифицируется существующая...
                case "MOD":
                    result = Program.add_read_module.upd_queue(Convert.ToInt32(this._id), this.tb_mens.Text,
                                                               this.tb_numb.Text,
                                                               start,
                                                               end);
                                                               break;

                default:
                    result = "NDF";
                    // не используется, однако mvs не позволяет 
                    // дальше работать переменной, которой в одной
                    // из веток кода не присваивается значение
                    break;
            }

            if (result == "OK")
            {
                if (this._state == "NEW")
                {
                    this.set_state("OLD");
                    this.Dispose();
                }
                else
                    if (this._state == "MOD")
                    {
                        this.set_state("OLD");
                    }
            }
            else
            {
                MessageBox.Show("Дата окончания не может быть мень даты начала очереди", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            this.Dispose();
        }

        //устанавливает указанный в параметрах статус как состояние формы, в соответствии с 
        //которым устанавливает параметры всех элементов формы, соответствующие указанному состоянию
        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.Text = "Очередь - Просмотр";
                    this.b_save.Enabled = false;
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Очередь - Добавление";
                    this.b_save.Enabled = false;
                    break;

                case "MOD":
                    this._state = "MOD";
                    this.Text = "Очередь - Редактирование";
                    this.b_save.Enabled = true;
                    break;
            }
        }

        //заполняет форму данными о очереди, полученными из базы данных при просмотре существующей в БД записи
        public void fill_queue_data()
        {
            class_queue queue;
            queue = Program.add_read_module.get_queue(Convert.ToInt32(this._id));
            if (queue.result == "OK")
            {
                this.tb_mens.Text = queue.numb_men;
                this.tb_start.Text = queue.start;
                this.tb_end.Text = queue.end;
                this.tb_numb.Text = queue.numb_queue;
            }
            else
            {
                //Не удалось получить сведений о текущей очереди
                MessageBox.Show(queue.result);
                this.Dispose();
            }
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
