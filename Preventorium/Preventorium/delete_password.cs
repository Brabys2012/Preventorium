using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class delete_password : Form
    {
        /// <summary>
        /// модуль, через который работать с базой
        /// </summary>
        private db_connect _data_module;
        /// <summary>
        ///  Состояние (new/old/mod)
       /// </summary>
        private string _state;
          /// <summary>
        /// ID для загрузки данных (в режиме OL
       /// </summary>
        private string _id;
        //название загружаемой таблицы
        private string table;
        /// <summary>
        /// Конструктор, вызываемый    для редактирования
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="u_id"></param>
        /// <param name="table_name"></param>
   
        public delete_password(db_connect data_module, int u_id, string table_name)
        {
            InitializeComponent();
            this.table = table_name;
            this._id = u_id.ToString();
            this._data_module = data_module;
            this.set_state("OLD");
        }
        /// <summary>
        /// Состояние удаления
        /// </summary>
        /// <param name="state"></param>
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
        /// Обновление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_apply_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case "Users":
                    string result = Program.add_read_module.del_record_by_password(table,Convert.ToInt32(this._id));
                   
                    if (result == "OK")
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                    break;               

            }
        }

        /// <summary>
        /// Отмена 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
