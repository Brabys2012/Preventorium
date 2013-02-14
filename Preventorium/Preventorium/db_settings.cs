using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace Preventorium
{
    public partial class db_settings : Form
    {

        public db_settings()
        {
            InitializeComponent(); 
            this.t_server.Text = Program.user_set._server;
            this.t_schema.Text = Program.user_set._schema;
            this.t_user.Text = Program.user_set._login;
            this.t_pass.Text = Program.user_set._password;
            this.cb_win_auth.Checked = Program.user_set._win_auth;
        }

        private void cb_user_con_string_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_win_auth.Checked)
            {
                this.t_pass.Enabled = false;
                this.t_user.Enabled = false;
            }
            else
            {
                this.t_pass.Enabled = true;
                this.t_user.Enabled = true;
            }
        }

        private void b_apply_Click(object sender, EventArgs e)
        {
            Ping ping = new Ping();

            string s;
            s = this.t_server.Text;
          
            try
            {
                IPHostEntry ips = Dns.GetHostEntry(s);
                string ip = ips.AddressList[0].ToString();
                PingReply reply1 = ping.Send(ip, 250);

                if (reply1.Address == null)
                { MessageBox.Show("Сервер не найден\n Пожалуйста ввойдите в меню Сервис и укажите нужный Server"); }
                else
                {
                      if (!(Program.user_set.setDBSettings(this.t_server.Text, this.t_schema.Text, this.t_user.Text, this.t_pass.Text,
                                                        this.cb_win_auth.Checked)))
                    {
                        MessageBox.Show("Параметры указаны неверно!\nУкажите корректные данные для подключения.");
                        return;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }

            catch { MessageBox.Show("Сервер не найден\n Пожалуйста ввойдите в меню Сервис и укажите нужный Server"); }
        }

        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_win_auth_CheckedChanged(object sender, EventArgs e)
        {
            lUser.Enabled = lPass.Enabled = t_user.Enabled = t_pass.Enabled = b_abolition.Enabled = !cb_win_auth.Checked;
        }

        private void db_settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.b_apply_Click(sender,e);
        }

       
    }
}
