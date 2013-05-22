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
        
        /// <summary>
        /// записывается пароль и роль в переменную
        /// </summary>
        public class_person _pass;
        /// <summary>
        /// записывается пароль и роль в переменную
        /// </summary>
        public string  LOG;
     
        /// <summary>
        /// Содержит хэш -функции вводимых в текс тбокс символов
        /// </summary>
        string hash;
             
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Autorisation()
        {
            InitializeComponent();
            linkLabel.Visible = false;
        }

        /// <summary>
        /// Возвращает хэш-функцию вводимых символов с текст бокса
        /// </summary>
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

        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        private void Autorisation_Load(object sender, EventArgs e)
        { //конфигурационного файла не обнаружено ,то предлагает ввести параметры подключения к БД
           db_settings db = new db_settings();
           if ((Program.user_set.NOT_FILE == "OK"))
           {
               db.Text = "Настройки подключения к БД";
               db.ShowDialog();
           }                  
        }

        /// <summary>
        /// </summary>
        /*public class_person[] get_user()
        {
            class_person[] user = new class_person[512];
              string query = "select * from Users";
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
        }*/
        /// <summary>
        /// Возвращает пароль и роль пользователя по логину
        /// </summary>
        public class_person get_password()
        {
            class_person user = new class_person();
            string query = "select Password,role from Users where Login='" + tb_log.Text + "'";
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
                    user.role = rd.GetString(1);
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
   /*     public class_person get_role()
        {
            class_person role = new class_person();
             string query = "select role from Users  where  Login='" + tb_log.Text + "'";
            try
            {                SqlCommand com = Program.data_module._conn.CreateCommand();
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
        }*/

        /// <summary>
        /// Событие при нажатии кнопки "OK"
        /// </summary>
        private void ok_Click(object sender, EventArgs e)
        {   // записывается в переменную хэш фунцкии и текстбокса
            hash = getMd5Hash(tb_pass.Text); 
          users();
        }

        /// <summary>
        /// Метод проверки логина и пароля,а также подключения БД
        /// </summary>
        public void users()
        {     try
            {
                if (tb_log.Text == "")
                {
                    MessageBox.Show("Вы не ввели пароль или не ввели логин!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    db_settings db = new db_settings();

                    //Если статус коннект,то идет проверка пароля вводимого с тукст бокса
                    if (Program.data_module.ConnStatus == (ConnectionStatus.CONNECTED))
                    {  
                        _pass = get_password();
                        if (_pass.pass == hash)
                        {
                            _pass = get_password();
                            LOG = tb_log.Text;
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();                            
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                      
                    }
                    else
                    {      //Если статус не равен коннект,то грузится форма подключения к БД
                        if (Program.data_module.connect_to_db() != (ConnectionStatus.CONNECTED))
                        {
                            db.Text = "Настройки подключения к БД";
                            if (db.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {//Если статус коннект,то идет проверка пароля вводимого с тукст бокса
                                if ((Program.data_module.connect_to_db() == ConnectionStatus.CONNECTED))
                                {
                                    _pass = get_password();
                                    
                                    if (_pass.pass == hash)
                                    {
                                        _pass = get_password();
                                        LOG = tb_log.Text;
                                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                        Close();                                       
                                    }

                                    else
                                    {
                                        MessageBox.Show("Неправильный логин или пароль !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                 //Если статус не равен коннект,то грузится форма авторизации с ссылкой на настройки подключения К БД,
                                else
                                {
                                    linkLabel.Visible = true;                                    
                                }
                            }
                            else { this.Close(); }
                        }
                        //Если статус коннект,то в переменную _pass записывается роль и пароль пользователя
                        else
                        {   
                            _pass = get_password();
                           // идет проверка пароля вводимого с текст бокса
                            if (_pass.pass == hash)
                            {
                                _pass = get_password();
                                LOG = tb_log.Text;
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                Close();                              
                            }

                            else
                            {
                                MessageBox.Show("Неправильный логин или пароль !!!", "Внимание !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                       
                    }

                }
            }

            catch(Exception ex)
            {
            }
            
        }

        /// <summary>
        /// Отмена
        /// </summary>
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Если чекс бокс нажать то включается отображенние вводимых символов
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tb_pass.UseSystemPasswordChar = !chb_pass.Checked; ;
        }

        /// <summary>
        /// при нажатии на ссылку грузится форма подкчения к бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            db_settings db = new db_settings();
            db.Show();
        }     
      
               
    }
}
