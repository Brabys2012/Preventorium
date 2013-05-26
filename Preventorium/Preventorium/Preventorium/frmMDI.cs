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
using System.Data.SqlClient;
using word = Microsoft.Office.Interop.Word;

namespace Preventorium
{

    /// <summary>
    /// Главная MDI форма программы.
    /// </summary>
    public partial class frmMDI : Form
    {
         #region Форма MDI.
        /// <summary>
        /// Содержит логин по-ля
        /// </summary>
        string login;
        /// <summary>
        /// Содержит проффессию пол-ля
        /// </summary>
        class_person prof;

       /// <summary>
        ///  Инициализирует главную MDI форму программы.
       /// </summary>
       /// <param name="professia"></param>
        public frmMDI(class_person professia, string log )
        {
            prof = professia;
            login = log;
            InitializeComponent();
        }

        /// <summary>
        /// Происходит при закгрузке формы.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (prof.role == "Пользователь-диет_сестра")
            { // Если роль пользователь: Пользователь-диет_сестра то отключаем на главной форме меню персонал
                 this.Person.Visible = false;
                 toolStripSeparator1.Visible = false;
            }
            //Если роль пользователь: Администратор-глав_врач,то переименовываем меню сменить пароль
            if (prof.role == "Администратор-глав_врач")
            {
                usersToolStripMenuItem.Text = "Назначение прав пользователям";
            }
          
            status.Text = "Подключение к базе данных ...";
                      // Если не удалось подключиться к БД, то выводим сообщение пользователю
          if (Program.data_module.ConnStatus!= ConnectionStatus.CONNECTED)
                {
                    status.Text = "Ошибка подключения к базе данных.";
                     // Выключяем не нужные пункты меню ,если подключиться не удалось
                     this.frmMDI_MainMenu_Menu.Enabled = false;
                     this.frmMDI_MainMenu_Queue.Enabled = false;
                     this.frmMDI_MainMenu_Digest.Enabled = false;
                     this.frmMDI_MainMenu_Reports.Enabled = false;
                     this.frmMDI_MainMenu_Windiw.Enabled = false;
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
            MessageBox.Show("Раздел находится в разработке!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
           
        /// <summary>
        /// Нажатие на меню блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Food_Click(object sender, EventArgs e)
        {
            food frm = new food();
            frm.MdiParent = this;
            frm.Show();  
        }

       

        /// <summary>
        ///  Нажатие на меню отчет карта раскладка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Cards_layout_Click(object sender, EventArgs e)
        {
            Cards_layout frm = new Cards_layout();
            frm.MdiParent = this;
            frm.Show();
        }

        /// <summary>
        ///  Нажатие на меню диеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Diet_Click(object sender, EventArgs e)
        {
            diets frm = new diets();
            frm.MdiParent = this;
            frm.Show();  
        }

        /// <summary>
        ///  Нажатие на меню кулинарная книга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cooking_book_Click(object sender, EventArgs e)
        {
            cooking_book frm = new cooking_book();
            frm.MdiParent = this;
            frm.Show();  
        }

        /// <summary>
        ///  Нажатие на меню очередь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_queue_Click(object sender, EventArgs e)
        {
            queue form_queue = new queue();
            form_queue.MdiParent = this;
            form_queue.Show();
        }

        /// <summary>
        ///  Нажатие на меню диеты в блюде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void b_diet_in_food_Click(object sender, EventArgs e)
        {
            diet_in_food form_d_in = new diet_in_food();
            form_d_in.MdiParent = this;
            form_d_in.Show();
        }

        /// <summary>
        ///  Нажатие на меню карта-раскладка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cards_Click(object sender, EventArgs e)
        {
            Cards form = new Cards();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        ///  Нажатие на меню персонал
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Person_Click(object sender, EventArgs e)
        {
            human form = new human();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        ///  Нажатие на меню :создание меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_add_menu_Click(object sender, EventArgs e)
        {
            menu form = new menu();
            form.MdiParent = this;
            form.Show();
        }

       /// <summary>
        ///  Нажатие на меню отчет карта раскладка
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        private void b_report_Click(object sender, EventArgs e)
        {
            Cards_layout form = new Cards_layout();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// Назначение ролей пользователям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {   users form = new users(prof, login);
            form.MdiParent = this;
            form.Show();
        }
              
    }
}
