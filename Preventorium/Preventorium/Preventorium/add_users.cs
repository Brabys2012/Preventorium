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
        /// <summary>
        /// Содержит id пользователя
        /// </summary>
        int id_person;
        /// <summary>
        /// содержит роль пользователя
        /// </summary>
        private class_person proff;
        /// <summary>
        /// содержит статус модифициирования записей
        /// </summary>
        private string _state;
        private db_connect _data_module;
        /// <summary>
        /// СОдержит переменные,роль,пароль пользователей
        /// </summary>
        class_person[] person;
        /// <summary>
        /// Содержит модификатор,который означает что идет реадактирование пароля администратором
        /// </summary>
        string read;
        /// <summary>
        /// Содержит хэш функцию символов вводимых с текст бокса
        /// </summary>
        string hash;
        /// <summary>
        /// Содержит пароль пользователя
        /// </summary>
        public class_person[] _pass;
        /// <summary>
        /// Содержит долженость пол-ля
        /// </summary>
        string posts;
        /// <summary>
        /// Содержит значение старого до ввода нового логина
        /// </summary>
        string old_log;

        /// <summary>
        /// Конструктор формы, в котором сожержатся перменнные  название роли и должнсть , означает что адмтнистратор нажал кнопку добавить пароль на форме USers
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="prof"></param>
        /// <param name="post"></param>

        public add_users(db_connect data_module, class_person prof, string post, int ID)
        {
            InitializeComponent();
            this._data_module = data_module;
            proff = prof;
            posts = post;
            id_person = ID;
            this.set_state("NEW");
        }

        /// <param name="data_module">Конструктор формы, в котором сожержатся перменнные  название роли, id и модификатор MOD означает ,что админисратор нажал кнопку редактировать пароль на форме USers</param>
        public add_users(db_connect data_module, class_person prof, int id, string red)
        {
            InitializeComponent();
            this._data_module = data_module;
            proff = prof;
            id_person = id;
            read = red;
            old_log = tb_pass.Text;
            this.set_state(red);
        }

        /// <summary>
        /// Конструктор формы, в котором сожержатся перменнные  название роли, id , означает что пользователь нажал кнопку добавить пароль на форме USers
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="prof"></param>
        /// <param name="id"></param>
        public add_users(db_connect data_module, class_person prof, int id)
        {
            InitializeComponent();
            this._data_module = data_module;
            proff = prof;
            id_person = id;
            this.set_state("NEW");
        }
        /// <summary>
        /// Событие когда пользователь меняет знаения в текст боксе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void enabled(object sender, EventArgs e)
        {
            if ((tb_new_pass.Text != "") && (cb_role.Text != ""))
            {
                b_save.Enabled = true;
            }

            Program.add_read_module.upd_login(tb_pass.Text, id_person);
        }

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_users_Load(object sender, EventArgs e)
        {
            try
            { // Если роль пользователя  Администратор-глав_врач и read = MOD ,то идет реадктирование логина и пароля
                if ((proff.role == "Администратор-глав_врач") && (read == "MOD"))
                {
                    this.Size = new Size(230, 270);
                    this.label3.Visible = true;
                    this.tb_pass.Location = new System.Drawing.Point(7, 80);
                    this.tb_pass.Size = new System.Drawing.Size(205, 210);
                    this.tb_new_pass.Location = new System.Drawing.Point(7, 165);
                    this.tb_new_pass.Size = new System.Drawing.Size(205, 212);
                    this.tb_old_pass.Location = new System.Drawing.Point(7, 125);
                    this.tb_old_pass.Size = new System.Drawing.Size(205, 210);
                    this.b_save.Location = new System.Drawing.Point(7, 195);
                    this.cancel.Location = new System.Drawing.Point(125, 195);
                    //возвращает роль пол-ля 
                    person = get_password();
                    //добавляет роль пол-ля в комбобокс 
                    cb_role.Items.Add(person[1].role);

                    //если роль пол-ля Администратор-глав_врач": то подсвечиваем запись Администратор-глав_врач
                    if (person[1].role == "Администратор-глав_врач")
                    {
                        //подсвечиваем запись в комбобокесе
                        cb_role.SelectedItem = ("Администратор-глав_врач");
                        //добавляет роль пол-ля в комбобокс 
                        cb_role.Items.Add("Пользователь-диет_сестра");
                    }

                    if (person[1].role == "Пользователь-диет_сестра")
                    {  //добавляет роль пол-ля в комбобокс 
                        cb_role.Items.Add("Администратор-глав_врач");
                        cb_role.SelectedItem = "Пользователь-диет_сестра";
                    }
                    b_save.Enabled = true;
                    tb_pass.Text = person[1].login;
                    this.cb_role.Location = new System.Drawing.Point(7, 30);
                    this.cb_role.Size = new System.Drawing.Size(205, 205);
                    label3.Location = new System.Drawing.Point(7, 10);
                    label2.Location = new System.Drawing.Point(7, 60);
                    label5.Location = new System.Drawing.Point(7, 105);
                    label1.Location = new System.Drawing.Point(7, 148);
                    old_log = tb_pass.Text;
                }

                // означает АДминистратор только добавляет пароль
                if (read != "MOD")
                    if ((proff.role == "Администратор-глав_врач"))
                    {
                        this.Size = new Size(270, 225);
                        // _person = get_user();                      
                        cb_role.Items.Add("Администратор-глав_врач");
                        cb_role.Items.Add("Пользователь-диет_сестра");
                        cb_role.SelectedIndex = 0;
                        label1.Text = "Введите пароль:";
                        label1.Location = new System.Drawing.Point(7, 152);
                        this.tb_new_pass.Location = new System.Drawing.Point(7, 172);
                        label5.Visible = false;
                        tb_old_pass.Visible = false;
                        this.tb_pass.Location = new System.Drawing.Point(7, 70);
                        this.tb_new_pass.Location = new System.Drawing.Point(7, 115);
                        label1.Location = new System.Drawing.Point(7, 95);
                        this.b_save.Location = new System.Drawing.Point(7, 145);
                        this.cancel.Location = new System.Drawing.Point(166, 145);
                        tb_pass.Text = person[1].login;
                        old_log = tb_pass.Text;

                    }
                // если пол-ль зашел с ролью : "Пользователь-диет_сестра"
                if (proff.role == "Пользователь-диет_сестра")
                {
                    this.Size = new Size(230, 220);
                    this.label3.Visible = false;
                    this.tb_pass.Location = new System.Drawing.Point(7, 30);
                    this.tb_pass.Size = new System.Drawing.Size(205, 210);
                    this.tb_new_pass.Location = new System.Drawing.Point(7, 125);// 205 210
                    this.tb_new_pass.Size = new System.Drawing.Size(205, 210);//7 80
                    this.tb_old_pass.Size = new System.Drawing.Size(205, 210);
                    this.b_save.Location = new System.Drawing.Point(7, 155);
                    this.cancel.Location = new System.Drawing.Point(125, 155);
                    this.tb_old_pass.Location = new System.Drawing.Point(7, 80);
                    person = get_password();
                    this.cb_role.Items.Add(proff.role);
                    cb_role.SelectedIndex = 0;
                    b_save.Enabled = true;
                    cb_role.Visible = false;
                    label5.Location = new System.Drawing.Point(7, 60);
                    label2.Location = new System.Drawing.Point(7, 10);
                    label1.Location = new System.Drawing.Point(7, 105);
                    tb_pass.Text = person[1].login;
                    old_log = person[1].login;
                }
            }

            catch { }
        }

        /// <summary>
        /// Статусы при добавлении,редактирования паролей
        /// </summary>
        /// <param name="state"></param>
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
                    if (proff.role == "Пользователь-диет_сестра")
                    {
                        this.Text = "Редактирование логина или пароля";
                    }

                    if (proff.role == "Администратор-глав_врач")
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
        /*     public class_person[] get_user()
             {
                 class_person[] user = new class_person[512];
                 string query = "select Post from Users ";
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
                         if (rd.IsDBNull(0))
                         {
                             user[i].post = "";
                         }
                         else
                         user[i].post = rd.GetString(0);
                     }

                     if (user[i].post == null)
                     {
                         user[i] = new class_person();
                         user[i].post= "";

                         int g = Convert.ToInt32(user[i].post);
                         g = 0;
                
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

        /*   public class_person get_user_id()
           {
               class_person user = new class_person();
                string query = "select IDUsers from Users where Post='"+ posts+"'";
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
           }*/

        /// <summary>
        /// Событие закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, EventArgs e)
        {
            tb_pass.Text = old_log;
            Close();
        }

        /// <summary>
        ///  Возвращает хэш-функцию вводимых символов с текст бокса
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getMd5Hash(string input)
        {
            // создаем объект этого класса. Отмечу, что он создается не через new, а вызовом метода Create
            MD5 md5Hasher = MD5.Create();

            // Преобразуем входную строку в массив байт и вычисляем хэш

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

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

        /* public class_person[] get_post_role()
          {
              class_person[] user = new class_person[512];

              string query = "select * from Users where IDUsers='" + id_person + "'";
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
                      if (rd.IsDBNull(0))
                      { user[i].post_id = ""; }
                      else
                          user[i].post_id = rd.GetInt32(0).ToString();

                      if (rd.IsDBNull(1))
                      { user[i].login = ""; }
                      else
                          user[i].login = rd.GetString(1);

                      if (rd.IsDBNull(2))
                      { user[i].pass = ""; }
                      else
                          user[i].pass = rd.GetString(2);

                      if (rd.IsDBNull(3))
                      { user[i].role = ""; }
                      else
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
          }*/

        /// <summary>
        /// Возвращает логин ,пароль, роль польязователя
        /// </summary>
        /// <returns></returns>
        public class_person[] get_password()
        {
            class_person[] user = new class_person[512];

            string query = "select * from Users  where   IDUsers='" + id_person + "'";
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
                    if (rd.IsDBNull(0))
                    { user[i].post_id = ""; }
                    else
                        user[i].post_id = rd.GetInt32(0).ToString();

                    if (rd.IsDBNull(1))
                    { user[i].login = ""; }
                    else
                        user[i].login = rd.GetString(1);

                    if (rd.IsDBNull(2))
                    { user[i].pass = ""; }
                    else
                        user[i].pass = rd.GetString(2);

                    if (rd.IsDBNull(3))
                    { user[i].role = ""; }
                    else
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

        /// <summary>
        /// Событие при нажатии "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_save_Click(object sender, EventArgs e)
        {
            if ((tb_pass.Text == "") || cb_role.Text == "")
            {
                MessageBox.Show("Поля: Логин,роль пользователя, не могут быть пустыми", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                hash = getMd5Hash(tb_new_pass.Text);

                string result = ""; //Результат попытки сохранения/добавления пароля

                switch (this._state)
                {
                    case "NEW":
                        //Если пользователь редактирует свой логин или пароль
                        if (proff.role == "Пользователь-диет_сестра")
                        { // Возвращается пароль пользователя
                            _pass = get_password();
                            // Если текст боксы нового или старого пароля пусты ,то обновляется логин и пароль ,а в метод передается логин с текст бокса, а пароль в результате переменной pass
                            if ((tb_new_pass.Text == "") || tb_old_pass.Text == "")
                            {//Если пол-ль не поменял пароль ,то заменяем логин если указан верно старый пароль
                                if (old_log == tb_pass.Text)
                                {
                                    result = Program.add_read_module.upd_passwords(id_person, tb_pass.Text);
                                }
                                else
                                    //Если пол-ль  поменял пароль ,то заменяем логин и пароль если указан верно старый пароль
                                    result = Program.add_read_module.upd_password(id_person, this.tb_pass.Text, (this._pass[1].pass), (this.cb_role.Text));
                            }
                            // Иначе логи и пароль обновляется,а в метод добавляется логин с текстбокса ,а пароль с переменной hash
                            else
                            //Если пол-ль не поменял логин ,то заменяем пароль если указана верно старый пароль
                            {
                                if (old_log == tb_pass.Text)
                                { // Сравнивается пароль из БД с значением из текстбокса старого пароля
                                    if (_pass[1].pass == getMd5Hash(tb_old_pass.Text))
                                    {
                                        result = Program.add_read_module.upd_passwordss(id_person, tb_pass.Text, this.hash);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы неправильно указали старый пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = "OK";
                                    }

                                }
                                else
                                {   // Если пользователь изменил логин,то меняется и логин и пароль при верном страром пароле
                                    // Если старый пароль указан не верно,то вылазит сообщение о неверном пароле
                                    if (_pass[1].pass == getMd5Hash(tb_old_pass.Text))
                                    {
                                        result = Program.add_read_module.upd_password(id_person, this.tb_pass.Text, (this.hash), (this.cb_role.Text));
                                        result = "OK";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы неправильно указали старый пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = "OK";
                                    }
                                }
                            }
                        }
                        // Иначе администратор добавляет пароль
                        else
                        {
                            if (proff.role == "Администратор-глав_врач")
                            {
                                result = Program.add_read_module.add_password(posts, this.tb_pass.Text, (this.hash), (this.cb_role.Text), id_person);
                            }
                        }
                        break;
                    // Если администратор редактирует пароль                    
                    case "MOD":
                        if (proff.role == "Администратор-глав_врач")
                        {  // Возвращается пароль пользователя
                            _pass = get_password();
                            // Если текст боксы нового или старого пароля пусты ,то обновляется логин и пароль ,а в метод передается логин с текст бокса, а пароль в результате переменной pass
                            if ((tb_new_pass.Text == "") || tb_old_pass.Text == "")
                            {    //Если пол-ль не поменял логин ,то заменяем пароль если указана верно старый пароль
                                if (old_log == tb_pass.Text)
                                {
                                    result = Program.add_read_module.upd_passwords(id_person, tb_pass.Text);
                                }
                                else
                                    //Если пол-ль  поменял пароль ,то заменяем логин и пароль если указан верно старый пароль
                                    result = Program.add_read_module.upd_password(id_person, this.tb_pass.Text, (this._pass[1].pass), (this.cb_role.Text));
                            }
                            else
                            { //Если пол-ль не поменял логин ,то заменяем пароль если указана верно старый пароль
                                if (old_log == tb_pass.Text)
                                {
                                    if (_pass[1].pass == getMd5Hash(tb_old_pass.Text))
                                    {
                                        result = Program.add_read_module.upd_passwordss(id_person, tb_pass.Text, this.hash);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы неправильно указали старый пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = "OK";
                                    }

                                }
                                else
                                {// Если пользователь изменил логин,то меняется и логин и пароль при верном страром пароле
                                    // Если старый пароль указан не верно,то вылазит сообщение о неверном пароле
                                    if (_pass[1].pass == getMd5Hash(tb_old_pass.Text))
                                    {
                                        result = Program.add_read_module.upd_password(id_person, this.tb_pass.Text, (this.hash), (this.cb_role.Text));
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы неправильно указали старый пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = "OK";
                                    }

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
                    MessageBox.Show("Логин уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Dispose();
            }        
                
       }
        /// <summary>
        /// Событие смены роли в комбоксе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_role_SelectedIndexChanged(object sender, EventArgs e)
        {

            Program.add_read_module.upd_login(cb_role.Text, id_person);
                               
        }

    }
}

