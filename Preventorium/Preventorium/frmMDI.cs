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

    /// <summary>
    /// Главная MDI форма программы.
    /// </summary>
    public partial class frmMDI : Form
    {

        #region Форма MDI.

        /// <summary>
        /// Инициализирует главную MDI форму программы.
        /// </summary>
        public frmMDI()
        {
            InitializeComponent();     
        }
        /// <summary>
        /// Происходит при закгрузке формы.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Инициализируем настройки подключения к БД
            db_settings db_set = new db_settings();

            // Преверяем если конфигурационнго файла нету,то выводим форму настроек для измения настроек
            if (( Program.user_set.NOT_FILE=="OK"))
            {
                if (db_set.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                      if ((Program.data_module.ConnStatus == ConnectionStatus.DISCONNECTED) || (Program.data_module.ConnStatus == ConnectionStatus.CONNECT_ERROR))
                    {
                        this.status.Text = "Подключение к базе данных ...";
                        this.Update();
                        if (Program.data_module.connect_to_db() != ConnectionStatus.CONNECTED)
                        {
                            // Не удалось подключиться к базе данных
                           
                            this.status.Text = "Отключен от базы данных.";
                            this.frmMDI_MainMenu_Menu.Enabled = false;
                            this.frmMDI_MainMenu_Queue.Enabled = false;
                            this.frmMDI_MainMenu_Digest.Enabled= false;
                            this.frmMDI_MainMenu_Reports.Enabled = false;
                            this.frmMDI_MainMenu_Windiw.Enabled = false;
                            this.Cards.Enabled = false;

                            return;
                        }
                        this.status.Text = "Подключен к базе данных";
                        this.frmMDI_MainMenu_Menu.Enabled = true;
                        this.frmMDI_MainMenu_Queue.Enabled = true;
                        this.frmMDI_MainMenu_Digest.Enabled = true;
                        this.frmMDI_MainMenu_Reports.Enabled = true;
                        this.frmMDI_MainMenu_Windiw.Enabled = true;
                        this.Cards.Enabled = true;

                    }
                    else
                    {
                        // Подключаемся к БД
                        status.Text = "Подключение к базе данных ...";

                        // Если не удалось подключиться к БД, то выводим сообщение пользователю
                        if (Program.data_module.connect_to_db() != ConnectionStatus.CONNECTED)
                        {
                            status.Text = "Ошибка подключения к базе данных.";
                            // Выключяем не нужные пункты меню ,если подключиться не удалось
                             this.frmMDI_MainMenu_Menu.Enabled = false;
                            this.frmMDI_MainMenu_Queue.Enabled = false;
                            this.frmMDI_MainMenu_Digest.Enabled= false;
                            this.frmMDI_MainMenu_Reports.Enabled = false;
                            this.frmMDI_MainMenu_Windiw.Enabled = false;
                            this.Cards.Enabled = false;
                            return;
                        }
                        // Если успешно подключились, то изменяем статус программы
                        status.Text = "Подключен к базе данных.";
                        // Включяем  пункты меню ,если подключиться  удалось
                        this.frmMDI_MainMenu_Menu.Enabled = true;
                        this.frmMDI_MainMenu_Queue.Enabled = true;
                        this.frmMDI_MainMenu_Digest.Enabled = true;
                        this.frmMDI_MainMenu_Reports.Enabled = true;
                        this.frmMDI_MainMenu_Windiw.Enabled = true;
                        this.Cards.Enabled = true;

                    }
                }
            }

            else
            {
                status.Text = "Подключение к базе данных ...";
                                // Если не удалось подключиться к БД, то выводим сообщение пользователю
                if (Program.data_module.connect_to_db() != ConnectionStatus.CONNECTED)
                {
                    status.Text = "Ошибка подключения к базе данных.";
                    // Выключяем не нужные пункты меню ,если подключиться не удалось
                    this.frmMDI_MainMenu_Menu.Enabled = false;
                    this.frmMDI_MainMenu_Queue.Enabled = false;
                    this.frmMDI_MainMenu_Digest.Enabled = false;
                    this.frmMDI_MainMenu_Reports.Enabled = false;
                    this.frmMDI_MainMenu_Windiw.Enabled = false;
                    this.Cards.Enabled = false;
                    return;
                }
                // Если успешно подключились, то изменяем статус программы
                status.Text = "Подключен к базе данных.";
                this.frmMDI_MainMenu_Menu.Enabled = true;
                // Включяем  пункты меню ,если подключиться  удалось
                this.frmMDI_MainMenu_Queue.Enabled = true;
                this.frmMDI_MainMenu_Digest.Enabled = true;
                this.frmMDI_MainMenu_Reports.Enabled = true;
                this.frmMDI_MainMenu_Windiw.Enabled = true;
                this.Cards.Enabled = true;
            }
        }
        
        /// <summary>
        /// Происходит при закрытии формы.
        /// </summary>
        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Спрашиваем у пользователя желает ли он выйти, если он ответит Да, то сохраняем настройки и закрываем форму
            if (MessageBox.Show("Вы желаете завершить работу в программе?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Program.user_set.SaveSettingsToFile();
                e.Cancel = false;
            }
            // Если пользователь ответил Нет, то отменяем закрытие формы.
            else
                e.Cancel = true;
        }

        #endregion


        #region Меню Справлчники.

        /// <summary>
        /// Происходит при выборе пункта меню Справочники -> Ингридиенты.
        /// </summary>
        private void frmMDI_MainMenu_Digest_Ingridients_Click(object sender, EventArgs e)
        {
            ingr frm = new ingr();
            frm.MdiParent = this;
            frm.Show();           
        }

        #endregion

        #region Меню Сервис.

        /// <summary>
        /// Происходит при выборе пункта меню Сервис -> Параметры.
        /// </summary>
        private void frmMDI_MainMenu_Service_Parameters_Click(object sender, EventArgs e)
        {
              //TODO: Доработать!!!: Переделать вывод сообщений пользователю MessageBox.Show() в нормальное и понятное представление.

            // Инициализируем пользовательские настройки
            db_settings db_set = new db_settings();
                            
            
                // Отображаем форму настроек, и, если пользователь изменил настройки, то изменяем подключение
                if (db_set.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Если в данный момент подключение к базе данных отсутствует
                    if ((Program.data_module.ConnStatus == ConnectionStatus.DISCONNECTED) || (Program.data_module.ConnStatus == ConnectionStatus.CONNECT_ERROR))
                    {
                        this.status.Text = "Подключение к базе данных ...";
                        this.Update();
                        
                        if (Program.data_module.connect_to_db() != ConnectionStatus.CONNECTED)
                        {
                            // Не удалось подключиться к базе данных
                           
                            this.status.Text = "Отключен от базы данных.";
                            // Выключяем не нужные пункты меню ,если подключиться не удалось
                            this.frmMDI_MainMenu_Menu.Enabled = false;
                            this.frmMDI_MainMenu_Queue.Enabled = false;
                            this.frmMDI_MainMenu_Digest.Enabled = false;
                            this.frmMDI_MainMenu_Reports.Enabled = false;
                            this.frmMDI_MainMenu_Windiw.Enabled = false;
                            this.Cards.Enabled = false;
                            return;
                        }
                        else
                        {
                            //Успешное подключение к базе данных
                            // Включяем  пункты меню ,если подключиться удалось
                            this.status.Text = "Подключен к базе данных";
                            this.frmMDI_MainMenu_Menu.Enabled = true;
                            this.frmMDI_MainMenu_Queue.Enabled = true;
                            this.frmMDI_MainMenu_Digest.Enabled = true;
                            this.frmMDI_MainMenu_Reports.Enabled = true;
                            this.frmMDI_MainMenu_Windiw.Enabled = true;
                            this.Cards.Enabled = true;
                           
                        }
                    }
                }
            }
        
        
        #endregion

        #region Меню Окно.

        /// <summary>
        /// Происходит при выборе пункта меню Окно -> Каскадом
        /// </summary>
        private void frmMDI_MainMenu_Windiw_Сascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        /// <summary>
        /// Происходит при выборе пункта меню Окно -> Слева направо.
        /// </summary>
        private void frmMDI_MainMenu_Windiw_Vertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        /// <summary>
        /// Происходит при выборе пункта меню Окно -> Сверху вниз.
        /// </summary>
        private void frmMDI_MainMenu_Windiw_Horizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        /// <summary>
        /// Происходит при выборе пункта меню Окно -> Закрыть все.
        /// </summary>
        private void frmMDI_MainMenu_Windiw_СloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        #region Меню Справка.

        /// <summary>
        /// Происходит при выборе пункта меню Справка -> О программе
        /// </summary>
        private void frmMDI_MainMenu_Help_About_Click(object sender, EventArgs e)
        {
            frmAbout _fa = new frmAbout();
            _fa.ShowDialog();
        }
        /// <summary>
        /// Происходит при выборе пункта меню Справка -> Помощь.
        /// </summary>
        private void frmMDI_MainMenu_Help_Help_Click(object sender, EventArgs e)
        {

        }

        #endregion

     


        private void Food_Click(object sender, EventArgs e)
        {
            food frm = new food();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void Report_ingr_Click(object sender, EventArgs e)
        {
            ingr frm = new ingr();
            frm.ingr_Load(sender, e);
            frm.Excel(frm.gw);
        }

        private void Cards_layout_Click(object sender, EventArgs e)
        {
            Cards_layout frm = new Cards_layout();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void Diet_Click(object sender, EventArgs e)
        {
            diets frm = new diets();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void Cooking_book_Click(object sender, EventArgs e)
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

        private void Cards_Click(object sender, EventArgs e)
        {
            Cards form = new Cards();
            form.MdiParent = this;
            form.Show();
        }

        private void Person_Click(object sender, EventArgs e)
        {
            human form = new human();
            form.MdiParent = this;
            form.Show();
        }

        
    }
}
