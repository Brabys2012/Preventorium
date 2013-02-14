using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net.Sockets;

namespace Preventorium
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db_settings db_set = new db_settings();
            string result;
            //Если в данный момент подключение к базе данных отсутствует
            if (Program.data_module.get_connect_status() == "CONNECTED")
            {
                this.status.Text = "Отключение от базы данных...";
                this.Update();
                result = Program.data_module.disconnect_db();
                if (!(result == "OK"))
                {
                    //Не удалось отлкючиться от БД
                    MessageBox.Show(result);
                    this.status.Text = "Подключен к базе данных";
                    return;
                }
                else
                {
                    //Успешное отключение от БД
                    this.status.Text = "Отключен от базы данных";
                    //b_connect_to_db.Text = "Подключиться";
                }
            }
            
            if (db_set.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Если в данный момент подключение к базе данных отсутствует
                if (Program.data_module.get_connect_status() == "DISCONNECTED")
                {
                    this.status.Text = "Подключение к базе данных...";
                    this.Update();
                    result = Program.data_module.connect_to_db();
                    if (!(result == "OK"))
                    {
                        //Не удалось подключиться к базе данных
                        MessageBox.Show(result);
                        this.status.Text = "Отключен от базы данных";
                        return;
                    }
                    else
                    {
                        //Успешное подключение к базе данных
                        this.status.Text = "Подключен к базе данных";
                        // b_connect_to_db.Text = "Отключиться";
                    }
                }
            } 
        }

        private void main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.user_set.saveSettingsToFile();
            

           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Ping ping = new Ping();

            string s;
            s = Program.user_set._server;
           //  String hostname = Dns.GetHostName();
    

            try
            {
                IPHostEntry ips = Dns.GetHostEntry(s);
                string ip = ips.AddressList[0].ToString();
                PingReply reply1 = ping.Send(ip, 1);

                  if (reply1.Address == null)
                  { MessageBox.Show("Сервер не найден\n Пожалуйста ввойдите в меню Сервис и укажите нужный Server"); }

                else
                {

                    db_settings db_set = new db_settings();
                    string result;
                    //Если в данный момент подключение к базе данных отсутствует
                    if (Program.data_module.get_connect_status() == "DISCONNECTED")
                    {
                        this.status.Text = "Подключение к базе данных...";
                        this.Update();
                        result = Program.data_module.connect_to_db();
                        if (!(result == "OK"))
                        {
                            //Не удалось подключиться к базе данных
                            MessageBox.Show(result);
                            this.status.Text = "Отключен от базы данных";
                            return;
                        }
                        else
                        {
                            //Успешное подключение к базе данных
                            this.status.Text = "Подключен к базе данных";
                            // b_connect_to_db.Text = "Отключиться";
                        }
                    }

                    else
                        //Если в данный момент подключены к базе, то...
                        if (Program.data_module.get_connect_status() == "CONNECTED")
                        {
                            this.status.Text = "Отключение от базы данных...";
                            this.Update();
                            result = Program.data_module.disconnect_db();
                            if (!(result == "OK"))
                            {
                                //Не удалось отлкючиться от БД
                                MessageBox.Show(result);
                                this.status.Text = "Подключен к базе данных";
                                return;
                            }
                            else
                            {
                                //Успешное отключение от БД
                                this.status.Text = "Отключен от базы данных";
                                // b_connect_to_db.Text = "Подключиться";
                            }

                        }

                    this.Update();
                }
            }

            catch
            { MessageBox.Show("Сервер не найден\n Пожалуйста ввойдите в меню Сервис и укажите нужный Server"); }
        }
        

        private void чтотоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ingr frm = new ingr();
            frm.MdiParent = this;
            frm.Show();           
        }

        private void блюдаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            food frm = new food();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void отчетПоИнгридиентамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ingr frm = new ingr();
            frm.ingr_Load(sender, e);
            frm.Excel(frm.gw);
        }

        private void создатьКарточкураскладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cards_layout frm = new Cards_layout();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void диетыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            diets frm = new diets();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void кулинарнаяКнигаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cooking_book frm = new cooking_book();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void b_queue_Click(object sender, EventArgs e)
        {
            queue form_queue = new queue();
            form_queue.MdiParent = this;
            form_queue.Show();
        }

        private void b_diet_in_food_Click(object sender, EventArgs e)
        {
            diet_in_food form_d_in = new diet_in_food();
            form_d_in.MdiParent = this;
            form_d_in.Show();
        }

        private void картараскладкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cards form = new Cards();
            form.MdiParent = this;
            form.Show();
        }
    }
}
