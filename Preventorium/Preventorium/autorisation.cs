using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Preventorium
{
    public partial class Autorisation : Form
    {
        public class_person[] _person;
        public class_person _pass;
        public class_person role;
        string hash;

        public class_person user;
        public Autorisation()
        {
            InitializeComponent();
            linkLabel.Visible = false;
        }
          
        public string getMd5Hash(string input)
        {
         // создаем объект этого класса. Отмечу, что он создается не через new, а вызовом метода Create
            MD5 md5Hasher = MD5.Create();

            // Преобразуем входную строку в массив байт и вычисляем хэш
         byte [] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        
            // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
            StringBuilder sBuilder = new StringBuilder();

            // Преобразуем каждый байт хэша в шестнадцатеричную строку
            for (int i = 0; i < data.Length; i++)
            {
                //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
                sBuilder.Append(data[i].ToString("x2"));
                sBuilder.ToString();
            }
                    return sBuilder.ToString();
        }

        private void Autorisation_Load(object sender, EventArgs e)
        {
            db_settings db = new db_settings();
            if ((Program.user_set.NOT_FILE == "OK"))
            {
                db.Text = "Настройки подключения к БД";
                db.ShowDialog();
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

            class_person user;

            string query = "select Password from Users join Person on Users.IDPost=Person.IDPost where  Users.Login='" + tb_log.Text + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();
                // Если есть строки, полученные из БД в результате запроса
                if (rd.HasRows)
                {
                    // Зполняем поля пользователя
                    user = new class_person();
                    user.id = rd.GetBytes(...);
                }
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
        public class_person get_role()
        {

            class_person role = new class_person();

            string query = "select role from Users join Person on Users.IDPost=Person.IDPost where  Users.Login='" + tb_log.Text + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;

                SqlDataReader rd = com.ExecuteReader();

                while (rd.Read())
                {
                    i = i + 1;
                    role = new class_person();
                    role.result = "OK";
                    role.post = rd.GetString(0);
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
            return role;
        }
          
        private void ok_Click(object sender, EventArgs e)
        {
            hash = getMd5Hash(tb_pass.Text); 
            user= users();
        }

        public class_person users()
        {     try
            {
                if (tb_log.Text == "")
                {
                    MessageBox.Show("Вы не ввели пароль или не ввели логин!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    db_settings db = new db_settings();

                    if (Program.data_module.ConnStatus == (ConnectionStatus.CONNECTED))
                    {
                        _person = get_user();
                        _person = get_user();
                        _pass = get_password();
                        if (_pass.pass == hash)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();

                            role = get_role();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //fill_person_list();
                    }
                    else
                    {
                        if (Program.data_module.connect_to_db() != (ConnectionStatus.CONNECTED))
                        {
                            db.Text = "Настройки подключения к БД";
                            if (db.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                if ((Program.data_module.connect_to_db() == ConnectionStatus.CONNECTED))
                                {
                                    _person = get_user();
                                    //fill_person_list();
                                }
                                else
                                {
                                    linkLabel.Visible = true;
                                    
                                }
                            }
                            else { this.Close(); }
                        }

                        else
                        {
                            _person = get_user();
                            _pass = get_password();
                            //fill_person_list();
                        }

                        if (_pass.pass == hash)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();

                            role = get_role();
                        }

                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }

            catch(Exception ex)
            {
            }
            return role;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tb_pass.UseSystemPasswordChar = !chb_pass.Checked; ;
        }

        
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            db_settings db = new db_settings();
            db.Show();
        }

      
         
       
    }
}
