using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_person : Form
    {
        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID для загрузки данных (в режиме OLD)
        private string post_id;

        private void enabled_b_save(object sender, EventArgs e)
        {  
            if ((tb_name.Text !="") && (tb_surname.Text !="") && ( tb_sec_name.Text!="") &&(tb_post.Text !=""))
        {
            this.b_save.Enabled = true;
        }
            else
                b_save.Enabled = false;
            
            if (this._state == "OLD") { this.set_state("MOD"); };
        }

        // Конструктор, вызываемый при нажатии "Добавить"
        public add_person(db_connect data_module)
        {
            InitializeComponent();
            this.set_state("NEW");
        }

        //Добавление сотрудника
        private void add_new_person()
        {
            add_person add_person = new add_person(Program.data_module);
            add_person.ShowDialog();
        }


        //Конструктор, вызываемый для редактирования
        public add_person(db_connect data_module, int post_id)
        {
            InitializeComponent();
            this.post_id = post_id.ToString();
            this._data_module = data_module;
            this.fill_person_data();
            this.set_state("OLD");
        }

        //заполняет форму данными, полученными из базы данных при просмотре существующей в БД записи
        public void fill_person_data()
        {
            class_person person;
            person = Program.add_read_module.get_person(Convert.ToInt32(this.post_id));
            if (person.result == "OK")
            {
                this.tb_surname.Text = person.surname;
                this.tb_name.Text = person.name;
                this.tb_sec_name.Text = person.secondname;
                this.tb_post.Text = person.post;
            }
            else
            {   //Не удалось получить сведений
                MessageBox.Show(person.result);
                this.Dispose();
            }
        }


        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.Text = "Просмотр";
                    this.b_save.Enabled = false;
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Добавление";
                    this.b_save.Enabled = false;
                    break;

                case "MOD":
                    this._state = "MOD";
                    this.Text = "Редактирование";
                    this.b_save.Enabled = true;
                    break;
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
                        string result; //Результат попытки сохранения/добавления
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":
                    result = Program.add_read_module.add_person(
                        this.tb_surname.Text,
                        this.tb_name.Text,
                        this.tb_sec_name.Text,
                        this.tb_post.Text);
                    this.Close();
                    break;

                //Если модифицируется существующая...
                case "MOD":

                    class_person person;
                    person = Program.add_read_module.get_person(Convert.ToInt32(this.post_id));

                result = Program.add_read_module.upd_person(Convert.ToInt32(this.post_id),
                    this.tb_surname.Text,
                     this.tb_name.Text,
                     this.tb_sec_name.Text,
                     this.tb_post.Text);
                    this.Close();
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
                MessageBox.Show(result);
            }

            this.Update();
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
