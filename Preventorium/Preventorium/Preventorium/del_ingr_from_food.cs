using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class del_ingr_from_food : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string _id;
        private string f_id;
        /// <summary>
        /// консруктор формы
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="ingr_id"></param>
        /// <param name="food_id"></param>
        public del_ingr_from_food(db_connect data_module, int ingr_id, int food_id)
        {
            InitializeComponent();
            this._id = ingr_id.ToString();
            this.f_id = food_id.ToString();
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

                    string result = Program.add_read_module.del_record_by_ingr_id("Ingridients_in_food", "Id_ingridients", Convert.ToInt32(this._id), Convert.ToInt32(this.f_id));
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
