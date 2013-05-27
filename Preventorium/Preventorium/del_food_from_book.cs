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
    public partial class del_food_from_book : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string b_id;
        private string c_id;
        private string f_id;
        /// <summary>
        /// конструктор формы
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="card_id"></param>
        /// <param name="food_id"></param>
        /// <param name="book_id"></param>
        public del_food_from_book(db_connect data_module, int card_id, int food_id, int book_id)
        {
            InitializeComponent();
            this.c_id = card_id.ToString();
            this.f_id = food_id.ToString();
            this.b_id = book_id.ToString();
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

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_apply_Click(object sender, EventArgs e)
        {

            string result = Program.add_read_module.del_record_by_food_id("FoodInBook", "IDBook", Convert.ToInt32(this.c_id), Convert.ToInt32(this.f_id), Convert.ToInt32(this.b_id));
                    if (result == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
            
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
