using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class delete : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string _id;
        //название загружаемой таблицы
        private string table;
        //Конструктор, вызываемый
        //для редактирования
        public delete(db_connect data_module, int record_id, string table_name)
        {
            InitializeComponent();
            this.table = table_name;
            this._id = record_id.ToString();
            this._data_module = data_module;
            this.set_state("OLD");
        }

        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.b_apply.Enabled = true;
                    this.b_cancel.Enabled = true;
                    break;
            }
        }

        //Удаление записи
        private void b_apply_Click(object sender, EventArgs e)
        {
            switch(table)
            {
                case "Queue":
                    string result = Program.add_read_module.del_record_by_id("Queue", "ID_queue", Convert.ToInt32(this._id));
                    if (result == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                    break;

                case "Ingridients":
                    string result1 = Program.add_read_module.del_record_by_id("Ingridients", "Id_ingridients", Convert.ToInt32(this._id));
                    if (result1 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result1);
                    }
                    break;

                case "Foods":
                    string result2 = Program.add_read_module.del_record_by_id("Foods", "ID_Food", Convert.ToInt32(this._id));
                    if (result2 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result2);
                    }
                    break;

                case "Diets":
                    string result3 = Program.add_read_module.del_record_by_id("Diets", "ID_Diets", Convert.ToInt32(this._id));
                    if (result3 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result3);
                    }
                    break;

                case "Book":
                    string result4 = Program.add_read_module.del_record_by_id("Book", "IDBook", Convert.ToInt32(this._id));
                    if (result4 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result4);
                    }
                    break;
                case "Cards":
                    string result5 = Program.add_read_module.del_record_by_id("Cards", "Id_Cards", Convert.ToInt32(this._id));
                    if (result5 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result5);
                    }
                    break;
                case "Person":
                    string result6 = Program.add_read_module.del_record_by_id("Person", "IDPost", Convert.ToInt32(this._id));
                    if (result6 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result6);
                    }
                    break;
                case "Menu":
                    string result7 = Program.add_read_module.del_record_by_id("Menu", "ID_menu", Convert.ToInt32(this._id));
                    if (result7 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result7);
                    }
                    break;
                case "Menu_in_day":
                    string result8 = Program.add_read_module.del_record_by_id("Menu_in_day", "day_id", Convert.ToInt32(this._id));
                    if (result8 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result8);
                    }
                    break;
                case "Users":
                    string result9 = Program.add_read_module.del_record_by_id("Users", "IDPost", Convert.ToInt32(this._id));
                    if (result9 == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result9);
                    }
                    break;
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
