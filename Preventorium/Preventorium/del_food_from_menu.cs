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
    public partial class del_food_from_menu : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string food;
        private string time;
        /// <summary>
        /// конструктор формы
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="food_id"></param>
        /// <param name="serve"></param>
        public del_food_from_menu(db_connect data_module, int food_id, string serve)
        {
            InitializeComponent();
            this.food = food_id.ToString();
            this.time = serve.ToString();
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

            string result = Program.add_read_module.del_food_menu("Food_in_menu", Convert.ToInt32(food), time);
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
