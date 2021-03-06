﻿using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace Preventorium
{

    /// <summary>
    /// Форма настройки программы и подключения к БД.
    /// </summary>
    public partial class db_settings : Form
    {            
        /// <summary>
        /// Инициализирует форму настройки программы и подключения к БД.
        /// </summary>
        public   db_settings()
        {
            InitializeComponent();
            this.t_server.Text = Program.user_set._server;         
            this.t_schema.Text = Program.user_set._schema;
            this.cb_win_auth.Checked = Program.user_set._win_auth;
            lUser.Enabled = lPass.Enabled = t_user.Enabled = t_pass.Enabled = !cb_win_auth.Checked;
            this.t_user.Text = Program.user_set._login;
            this.t_pass.Text = Program.user_set._password;        
      }
              
        /// <summary>
        /// Происходит при нажатии на кнопку Применить.
        /// </summary>
        private void b_apply_Click(object sender, EventArgs e)
         {           
            // Если при загрузке настроек произошла ошибка, то сообщаем пользователю и завершаем метод
            if (!Program.user_set.SetDBSettings(this.t_server.Text, this.t_schema.Text, this.cb_win_auth.Checked, this.t_user.Text, this.t_pass.Text))
            {
                MessageBox.Show("Параметры указаны неверно!\nУкажите корректные данные для подключения.");
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                  return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
        /// <summary>
        /// Происходит при нажатии на кнопку Отмена.
        /// </summary>
        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Происходит при смене состояния флажка Проверка подлинности Windows.
        /// </summary>
        private void cb_win_auth_CheckedChanged(object sender, EventArgs e)
        {
            // Активируем или деактивируем элменты управления
            lUser.Enabled = lPass.Enabled = t_user.Enabled = t_pass.Enabled = !cb_win_auth.Checked;
            if ((t_user.Text != "") || (t_pass.Text != ""))
            {
                if ((Program.data_module.ConnStatus == ConnectionStatus.CONNECTED))
                {
                    b_apply.Enabled = false;
                }
                else
                {
                    b_apply.Enabled = true;
                }
            }    
          }
        /// <summary>
        /// Метод вызывается при изменении настроек, при изменении настроек происходит переподключение БД        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void off_connect(object sender, EventArgs e)
       {
           // Если название сервера не равно пустой строке ,это условие идет отдельно, если добавить в уловия нижеЮто почему-то оно не срабатывает   
            if ((t_schema.Text != ""))                
            {
                if ((Program.user_set._server != t_server.Text) || (Program.user_set._schema != t_schema.Text))
                {
                    this.b_apply.Enabled = true;
                    this.b_abolition.Enabled = false;
                    Program.data_module.disconnect_db();
                }
            }

            // Если имя пользователя  не равно пустой строке ,это условие идет отдельно, если добавить в уловия нижеЮто почему-то оно не срабатывает   
            if ((t_user.Text != ""))
            {
                if ((t_pass.Text != "")) 

                    if ((Program.user_set._password != t_pass.Text) || (Program.user_set._login != t_user.Text))
                    {
                        this.b_apply.Enabled = true;
                        this.b_abolition.Enabled = false;
                        Program.data_module.disconnect_db();
                    }
            }           

        }
        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void db_settings_Load(object sender, EventArgs e)
       {
           if ((Program.data_module.ConnStatus == ConnectionStatus.CONNECTED))
           {
               b_apply.Enabled = false;
           }
           else
           {
               b_apply.Enabled = true;
           }
       }

     
      }
}
