using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class Autorisation : Form
    {
        public class_person[] _person;
        public class_person _pass;

        public string user;
        public Autorisation()
        {
            InitializeComponent();
        }

        private void Autorisation_Load(object sender, EventArgs e)
        {  db_settings db = new db_settings();
        if ((Program.user_set.NOT_FILE == "OK"))
        {
            db.ShowDialog();
        }
            if (Program.data_module.connect_to_db() != (ConnectionStatus.CONNECTED))
            {
              
                if (db.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (Program.data_module.ConnStatus == ConnectionStatus.DISCONNECTED)
                    {
                        Program.data_module.connect_to_db();
                        _person = get_user();
                        fill_person_list();
                    }

                    else
                    {
                       
                        tb_pass.Enabled = false;

                    }
                }
            }


            else
            {
                _person = get_user();
                fill_person_list();
            }
        }
               
            
        public class_person[] get_user()
        {

            class_person[] user = new class_person[512];

            string query = "select * from Person";
                        try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    user[i] = new class_person();
                    user[i].result = "OK";
                    user[i].post = rd.GetString(4);
                 }

                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }
             return user;
        }
        public class_person get_password()
        {

            class_person user = new class_person();

            string query = "select Password from Users join Person on Users.IDPost=Person.IDPost where Person.Post='" + cb_login.Text + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    user = new class_person();
                    user.result = "OK";
                    user.pass = rd.GetString(0);
                }
                if (user == null)
                {
                     i = i + 1;
                    user = new class_person();
                    user.pass = "";
                    string password = (user.pass);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;
            }
            return user;
        }
        private void fill_person_list()
        {
            if (this._person != null)
            {
                this.cb_login.Items.Clear();
           }
            for (int i = 1; i < this._person.Count(); i++)
            {
                if (this._person[i] != null)
                {

                    this.cb_login.Items.Add(this._person[i].post.Trim() );
                   
                }
                else
                {
                    break;
                }
            }
        }

        private void cb_login_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pass = get_password();
        }

        private void ok_Click(object sender, EventArgs e)
        {
           user= users();
        }

        public string users()
        {
            try
            {
                if (cb_login.Text == "")
                {
                    MessageBox.Show("Вы не ввели пароль или не выбрали профессию!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {

                    if (_pass.pass == tb_pass.Text)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                         Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный пароль !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
            }
            catch
            {
            }
            return cb_login.Text;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         
       
    }
}
