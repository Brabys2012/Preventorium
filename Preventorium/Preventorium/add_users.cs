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
    public partial class add_users : Form
    {
        private class_person _id;
        int id_person;
        private class_person proff;
        private string _state;
        private db_connect _data_module;
        class_person[] person;
        string read;
        string hash;
        public class_person _pass;
        
        public class_person[] _person;

        
        public add_users(db_connect data_module, class_person prof)
        {
            InitializeComponent();
            this._data_module = data_module;
            proff = prof;
             this.set_state("NEW");        
        }

        public add_users(db_connect data_module, class_person prof,int id,string red)
        {
            InitializeComponent();
            this._data_module = data_module;
            proff = prof;
            id_person = id;
            read = red;
            this.set_state(red);
        }

        public add_users(db_connect data_module,class_person prof,int id)
        {
            InitializeComponent();
            this._data_module = data_module;
            proff = prof;
            id_person = id;
             this.set_state("NEW");
        }

        public void enabled(object sender, EventArgs e)
        {

            if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox2.Text != "") && (comboBox1.Text != ""))
            {
                b_save.Enabled = true;
            }

        }
        private void add_users_Load(object sender, EventArgs e)
        {
            try
            {
                if ( (proff.post == "Администратор-глав_врач") && (read == "MOD") )
                {
                    this.Size = new Size(230, 270);
                    this.label3.Visible = true;
                    this.textBox1.Location = new System.Drawing.Point(7, 80);
                    this.textBox1.Size = new System.Drawing.Size(205, 210);
                    this.textBox2.Location = new System.Drawing.Point(7, 165);
                    this.textBox2.Size = new System.Drawing.Size(205, 212);
                    this.textBox3.Location = new System.Drawing.Point(7, 125);
                    this.textBox3.Size = new System.Drawing.Size(205, 210);
                    this.b_save.Location = new System.Drawing.Point(7, 195);
                    this.cancel.Location = new System.Drawing.Point(125, 195);
                    person = get_post_role();
                    comboBox2.Items.Add(person[1].role);
                    comboBox2.Items.Add("Администратор-глав_врач");
                    comboBox2.Items.Add("Пользователь-диет_сестра");
                    
                    if (person[1].role == "Администратор-глав_врач")
                    {
                        comboBox2.Items.Remove("Администратор-глав_врач");
                        comboBox2.SelectedItem = ("Администратор-глав_врач");
                    }
                    if (person[1].role == "Пользователь-диет_сестра")
                    {
                        comboBox2.Items.Remove("Пользователь-диет_сестра");
                        comboBox2.SelectedItem = "Пользователь-диет_сестра";
                    }
                    b_save.Enabled = true;
                    textBox1.Text = person[1].login;
                    comboBox1.Visible = false;
                    this.comboBox2.Location = new System.Drawing.Point(7, 30);
                    this.comboBox2.Size = new System.Drawing.Size(205, 205);
                    label3.Location = new System.Drawing.Point(7, 10);
                    label4.Visible = false;
                    label2.Location = new System.Drawing.Point(7, 60);
                    label5.Location = new System.Drawing.Point(7, 105);
                    label1.Location = new System.Drawing.Point(7,148);
                    

                }
                if (read != "MOD")

                    if ((proff.post == "Администратор-глав_врач"))
                    {
                        this.Size = new Size(270, 270);
                        _person = get_user();
                        fill_person_list();
                        comboBox2.Items.Add("Администратор-глав_врач");
                        comboBox2.Items.Add("Пользователь-диет_сестра");
                        comboBox2.SelectedIndex = 0;
                        label1.Text = "Введите пароль:";
                        label1.Location = new System.Drawing.Point(7, 152);
                        this.textBox2.Location = new System.Drawing.Point(7, 172);
                        label5.Visible = false;
                        textBox3.Visible = false;
                        this.b_save.Location = new System.Drawing.Point(7, 205);
                        this.cancel.Location = new System.Drawing.Point(166, 205);
                    }

                if (proff.post == "Пользователь-диет_сестра")
                {
                    this.Size = new Size(230, 220);
                    this.label3.Visible = false;
                    this.textBox1.Location = new System.Drawing.Point(7, 30);
                    this.textBox1.Size = new System.Drawing.Size(205, 210);
                    this.textBox2.Location = new System.Drawing.Point(7, 125);// 205 210
                    this.textBox2.Size = new System.Drawing.Size(205, 210);//7 80
                    this.textBox3.Size = new System.Drawing.Size(205, 210);
                    this.b_save.Location = new System.Drawing.Point(7, 155);
                    this.cancel.Location = new System.Drawing.Point(125, 155);
                    this.textBox3.Location = new System.Drawing.Point(7, 80);

                    person = get_post_role();
                    this.comboBox2.Items.Add(proff.post);
                    comboBox2.SelectedIndex = 0;
                    b_save.Enabled = true;
                    textBox1.Text = person[1].login;
                    //textBox2.Text = person[1].pass;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    label4.Visible = false;
                    label5.Location = new System.Drawing.Point(7, 60);
                    label2.Location = new System.Drawing.Point(7, 10);
                    label1.Location = new System.Drawing.Point(7, 105);
                }
            }

            catch { }
        }
        private void fill_person_list()
        {
           
            for (int i = 1; i < this._person.Count(); i++)
            {
                if (this._person[i] != null)
                {
                    this.comboBox1.Items.Add(this._person[i].post.Trim());
                    comboBox1.Text = _person[i].post;
                }
                else
                {
                    
                    break;
                }
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
                    if (proff.post == "Пользователь-диет_сестра")
                    {

                        this.Text = "Редактирование логина или пароля";
                    }

                    if (proff.post == "Администратор-глав_врач")
                    {
                        this.Text = "Добавление логина и/или пароля пользователям";
                    }

                    break;

                case "MOD":
                    this._state = "MOD";
                    this.Text = "Редактирование логина и/или пароля пользователя";
                    this.b_save.Enabled = true;
                    break;
            }
        }
        public class_person[] get_user()
        {

            class_person[] user = new class_person[512];

            string query = "select Post from Person where IDPost not in (select IDPost from Users)";
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
                    user[i].post = rd.GetString(0);
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

        public class_person get_user_id()
        {
            class_person user = new class_person();
             string query = "select IDPost from Person where Post='"+ comboBox1.Text+"'";
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
                    user.post_id = rd.GetInt32(0).ToString();
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

        public class_person[] get_post_role()
        {
            class_person[] user = new class_person[512];

            string query = "select * from Users where IDPost='"+ id_person+ "'";
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
                    user[i].post_id = rd.GetInt32(0).ToString();
                    user[i].login = rd.GetString(1);
                    user[i].pass = rd.GetString(2);
                    user[i].role = rd.GetString(3);
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

        private void close_Click(object sender, EventArgs e)
        {
            Close();  
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


             public class_person get_password()
             {

                 class_person user = new class_person();

                 string query = "select Password from Users join Person on Users.IDPost=Person.IDPost where  Users.Login='" + textBox1.Text + "'";
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
        private void b_save_Click(object sender, EventArgs e)
        {
                        
            if ((textBox1.Text == "") || comboBox2.Text =="")
            {
                MessageBox.Show("Поля: Логин,роль пользователя, не могут быть пустыми","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {   hash = getMd5Hash(textBox2.Text);

                string result=""; //Результат попытки сохранения/добавления ингредиента

                switch (this._state)
                {
                    //Если добавляется новая запись...
                    case "NEW":
                          if (proff.post == "Пользователь-диет_сестра")
                          {
                              _pass = get_password();

                              if ((textBox2.Text == "") || textBox3.Text == "")
                              {
                                  result = Program.add_read_module.upd_password(id_person, this.textBox1.Text, (this._pass.pass), (this.comboBox2.Text));
                              }
                              else
                              {
                                  if (_pass.pass == getMd5Hash(textBox3.Text))
                                  {
                                      result = Program.add_read_module.upd_password(id_person, this.textBox1.Text, (this.hash), (this.comboBox2.Text));
                                  }
                                  else
                                  {
                                      MessageBox.Show("Вы неправильно указали старый пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  }
                              }
                         }
                        else
                        {
                           if (proff.post == "Администратор-глав_врач")
                            {
                                result = Program.add_read_module.add_password(_id, this.textBox1.Text, (this.hash), (this.comboBox2.Text)); 
                            }
                        }
                        break;
                                           
                    case "MOD":
                        if (proff.post == "Администратор-глав_врач")
                        {
                            _pass = get_password();
                            
                            if ((textBox2.Text == "") || textBox3.Text == "")
                            {
                                result = Program.add_read_module.upd_password(id_person, this.textBox1.Text, (this._pass.pass), (this.comboBox2.Text));
                            }
                            else
                            {
                                if (_pass.pass == getMd5Hash(textBox3.Text))
                                {
                                    result = Program.add_read_module.upd_password(id_person, this.textBox1.Text, (this.hash), (this.comboBox2.Text));
                                }
                                else
                                {
                                    MessageBox.Show("Вы неправильно указали старый пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

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
                    

                }

                this.Dispose();
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _id=get_user_id();
            enabled(sender,e);
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.add_read_module.upd_login(textBox1.Text, id_person);
       }

        }
    }

