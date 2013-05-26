namespace Preventorium
{
    partial class frmMDI
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.frmMDI_MainMenu = new System.Windows.Forms.MenuStrip();
            this.frmMDI_MainMenu_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Food = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.b_diet_in_food = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Queue = new System.Windows.Forms.ToolStripMenuItem();
            this.b_queue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.b_add_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Digest = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Digest_Ingridients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Diets_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Cooking_book_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Cards_Menu = new System.Windows.Forms.ToolStripSeparator();
            this.Person = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Cards = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.b_report = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Service = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Service_Parameters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Windiw = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Windiw_Сascade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.frmMDI_MainMenu_Windiw_Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.frmMDI_MainMenu_Windiw_Horizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.frmMDI_MainMenu_Windiw_СloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Help_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Help_Sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.frmMDI_MainMenu_Help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.frmMDI_MainMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmMDI_MainMenu
            // 
            this.frmMDI_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Menu,
            this.frmMDI_MainMenu_Queue,
            this.frmMDI_MainMenu_Digest,
            this.frmMDI_MainMenu_Reports,
            this.frmMDI_MainMenu_Service,
            this.frmMDI_MainMenu_Windiw,
            this.frmMDI_MainMenu_Help});
            this.frmMDI_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.frmMDI_MainMenu.MdiWindowListItem = this.frmMDI_MainMenu_Windiw;
            this.frmMDI_MainMenu.Name = "frmMDI_MainMenu";
            this.frmMDI_MainMenu.Size = new System.Drawing.Size(675, 25);
            this.frmMDI_MainMenu.TabIndex = 0;
            this.frmMDI_MainMenu.Text = "MenuStrip";
            // 
            // frmMDI_MainMenu_Menu
            // 
            this.frmMDI_MainMenu_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Food,
            this.toolStripSeparator2,
            this.b_diet_in_food});
            this.frmMDI_MainMenu_Menu.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Menu.Name = "frmMDI_MainMenu_Menu";
            this.frmMDI_MainMenu_Menu.Size = new System.Drawing.Size(55, 21);
            this.frmMDI_MainMenu_Menu.Text = "Меню";
            // 
            // Food
            // 
            this.Food.Image = global::Preventorium.Properties.Resources.food_001;
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(164, 22);
            this.Food.Text = "Блюда";
            this.Food.Click += new System.EventHandler(this.Food_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // b_diet_in_food
            // 
            this.b_diet_in_food.Image = global::Preventorium.Properties.Resources.food_027;
            this.b_diet_in_food.Name = "b_diet_in_food";
            this.b_diet_in_food.Size = new System.Drawing.Size(164, 22);
            this.b_diet_in_food.Text = "Диеты в блюде";
            this.b_diet_in_food.Click += new System.EventHandler(this.b_diet_in_food_Click);
            // 
            // frmMDI_MainMenu_Queue
            // 
            this.frmMDI_MainMenu_Queue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b_queue,
            this.toolStripSeparator4,
            this.b_add_menu});
            this.frmMDI_MainMenu_Queue.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Queue.Name = "frmMDI_MainMenu_Queue";
            this.frmMDI_MainMenu_Queue.Size = new System.Drawing.Size(71, 21);
            this.frmMDI_MainMenu_Queue.Text = "Очередь";
            // 
            // b_queue
            // 
            this.b_queue.Image = ((System.Drawing.Image)(resources.GetObject("b_queue.Image")));
            this.b_queue.Name = "b_queue";
            this.b_queue.Size = new System.Drawing.Size(208, 22);
            this.b_queue.Text = "Просмотреть очереди";
            this.b_queue.Click += new System.EventHandler(this.b_queue_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // b_add_menu
            // 
            this.b_add_menu.Image = ((System.Drawing.Image)(resources.GetObject("b_add_menu.Image")));
            this.b_add_menu.Name = "b_add_menu";
            this.b_add_menu.Size = new System.Drawing.Size(208, 22);
            this.b_add_menu.Text = "Меню для очереди";
            this.b_add_menu.Click += new System.EventHandler(this.b_add_menu_Click);
            // 
            // frmMDI_MainMenu_Digest
            // 
            this.frmMDI_MainMenu_Digest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Digest_Ingridients,
            this.toolStripSeparator6,
            this.Diets_menu,
            this.toolStripSeparator7,
            this.Cooking_book_menu,
            this.Cards_Menu,
            this.Person,
            this.toolStripSeparator1,
            this.Cards});
            this.frmMDI_MainMenu_Digest.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Digest.Name = "frmMDI_MainMenu_Digest";
            this.frmMDI_MainMenu_Digest.Size = new System.Drawing.Size(98, 21);
            this.frmMDI_MainMenu_Digest.Text = "Справочники";
            // 
            // frmMDI_MainMenu_Digest_Ingridients
            // 
            this.frmMDI_MainMenu_Digest_Ingridients.Image = ((System.Drawing.Image)(resources.GetObject("frmMDI_MainMenu_Digest_Ingridients.Image")));
            this.frmMDI_MainMenu_Digest_Ingridients.Name = "frmMDI_MainMenu_Digest_Ingridients";
            this.frmMDI_MainMenu_Digest_Ingridients.Size = new System.Drawing.Size(221, 22);
            this.frmMDI_MainMenu_Digest_Ingridients.Text = "Ингредиенты";
            this.frmMDI_MainMenu_Digest_Ingridients.Click += new System.EventHandler(this.frmMDI_MainMenu_Digest_Ingridients_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // Diets_menu
            // 
            this.Diets_menu.Image = global::Preventorium.Properties.Resources.food_026;
            this.Diets_menu.Name = "Diets_menu";
            this.Diets_menu.Size = new System.Drawing.Size(221, 22);
            this.Diets_menu.Text = "Диеты";
            this.Diets_menu.Click += new System.EventHandler(this.Diet_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(218, 6);
            // 
            // Cooking_book_menu
            // 
            this.Cooking_book_menu.Image = ((System.Drawing.Image)(resources.GetObject("Cooking_book_menu.Image")));
            this.Cooking_book_menu.Name = "Cooking_book_menu";
            this.Cooking_book_menu.Size = new System.Drawing.Size(221, 22);
            this.Cooking_book_menu.Text = "Кулинарный справочник";
            this.Cooking_book_menu.Click += new System.EventHandler(this.Cooking_book_Click);
            // 
            // Cards_Menu
            // 
            this.Cards_Menu.Name = "Cards_Menu";
            this.Cards_Menu.Size = new System.Drawing.Size(218, 6);
            this.Cards_Menu.Click += new System.EventHandler(this.Cards_Click);
            // 
            // Person
            // 
            this.Person.Image = ((System.Drawing.Image)(resources.GetObject("Person.Image")));
            this.Person.Name = "Person";
            this.Person.Size = new System.Drawing.Size(221, 22);
            this.Person.Text = "Персонал";
            this.Person.Click += new System.EventHandler(this.Person_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // Cards
            // 
            this.Cards.Image = ((System.Drawing.Image)(resources.GetObject("Cards.Image")));
            this.Cards.Name = "Cards";
            this.Cards.Size = new System.Drawing.Size(221, 22);
            this.Cards.Text = "Карточка - раскладка";
            this.Cards.Click += new System.EventHandler(this.Cards_Click);
            // 
            // frmMDI_MainMenu_Reports
            // 
            this.frmMDI_MainMenu_Reports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b_report});
            this.frmMDI_MainMenu_Reports.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Reports.Name = "frmMDI_MainMenu_Reports";
            this.frmMDI_MainMenu_Reports.Size = new System.Drawing.Size(66, 21);
            this.frmMDI_MainMenu_Reports.Text = "Отчёты";
            // 
            // b_report
            // 
            this.b_report.Image = global::Preventorium.Properties.Resources.Microsoft_Office_Word;
            this.b_report.Name = "b_report";
            this.b_report.Size = new System.Drawing.Size(295, 22);
            this.b_report.Text = "Сформировать карточку - раскладку";
            this.b_report.Click += new System.EventHandler(this.b_report_Click);
            // 
            // frmMDI_MainMenu_Service
            // 
            this.frmMDI_MainMenu_Service.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Service_Parameters,
            this.toolStripSeparator3,
            this.usersToolStripMenuItem});
            this.frmMDI_MainMenu_Service.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Service.Name = "frmMDI_MainMenu_Service";
            this.frmMDI_MainMenu_Service.Size = new System.Drawing.Size(62, 21);
            this.frmMDI_MainMenu_Service.Text = "&Сервис";
            // 
            // frmMDI_MainMenu_Service_Parameters
            // 
            this.frmMDI_MainMenu_Service_Parameters.Image = ((System.Drawing.Image)(resources.GetObject("frmMDI_MainMenu_Service_Parameters.Image")));
            this.frmMDI_MainMenu_Service_Parameters.Name = "frmMDI_MainMenu_Service_Parameters";
            this.frmMDI_MainMenu_Service_Parameters.Size = new System.Drawing.Size(226, 22);
            this.frmMDI_MainMenu_Service_Parameters.Text = "Параметры подключения";
            this.frmMDI_MainMenu_Service_Parameters.Click += new System.EventHandler(this.frmMDI_MainMenu_Service_Parameters_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.usersToolStripMenuItem.Text = "Сменить пароль";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // frmMDI_MainMenu_Windiw
            // 
            this.frmMDI_MainMenu_Windiw.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Windiw_Сascade,
            this.toolStripSeparator14,
            this.frmMDI_MainMenu_Windiw_Vertical,
            this.toolStripSeparator15,
            this.frmMDI_MainMenu_Windiw_Horizontal,
            this.toolStripSeparator16,
            this.frmMDI_MainMenu_Windiw_СloseAll});
            this.frmMDI_MainMenu_Windiw.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Windiw.Name = "frmMDI_MainMenu_Windiw";
            this.frmMDI_MainMenu_Windiw.Size = new System.Drawing.Size(50, 21);
            this.frmMDI_MainMenu_Windiw.Text = "Окна";
            // 
            // frmMDI_MainMenu_Windiw_Сascade
            // 
            this.frmMDI_MainMenu_Windiw_Сascade.Name = "frmMDI_MainMenu_Windiw_Сascade";
            this.frmMDI_MainMenu_Windiw_Сascade.Size = new System.Drawing.Size(160, 22);
            this.frmMDI_MainMenu_Windiw_Сascade.Text = "Каскадом";
            this.frmMDI_MainMenu_Windiw_Сascade.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_Сascade_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(157, 6);
            // 
            // frmMDI_MainMenu_Windiw_Vertical
            // 
            this.frmMDI_MainMenu_Windiw_Vertical.Name = "frmMDI_MainMenu_Windiw_Vertical";
            this.frmMDI_MainMenu_Windiw_Vertical.Size = new System.Drawing.Size(160, 22);
            this.frmMDI_MainMenu_Windiw_Vertical.Text = "Слева направо";
            this.frmMDI_MainMenu_Windiw_Vertical.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_Vertical_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(157, 6);
            // 
            // frmMDI_MainMenu_Windiw_Horizontal
            // 
            this.frmMDI_MainMenu_Windiw_Horizontal.Name = "frmMDI_MainMenu_Windiw_Horizontal";
            this.frmMDI_MainMenu_Windiw_Horizontal.Size = new System.Drawing.Size(160, 22);
            this.frmMDI_MainMenu_Windiw_Horizontal.Text = "Сверху вниз";
            this.frmMDI_MainMenu_Windiw_Horizontal.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_Horizontal_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(157, 6);
            // 
            // frmMDI_MainMenu_Windiw_СloseAll
            // 
            this.frmMDI_MainMenu_Windiw_СloseAll.Name = "frmMDI_MainMenu_Windiw_СloseAll";
            this.frmMDI_MainMenu_Windiw_СloseAll.Size = new System.Drawing.Size(160, 22);
            this.frmMDI_MainMenu_Windiw_СloseAll.Text = "Закрыть все";
            this.frmMDI_MainMenu_Windiw_СloseAll.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_СloseAll_Click);
            // 
            // frmMDI_MainMenu_Help
            // 
            this.frmMDI_MainMenu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Help_Help,
            this.frmMDI_MainMenu_Help_Sep1,
            this.frmMDI_MainMenu_Help_About});
            this.frmMDI_MainMenu_Help.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frmMDI_MainMenu_Help.Name = "frmMDI_MainMenu_Help";
            this.frmMDI_MainMenu_Help.Size = new System.Drawing.Size(69, 21);
            this.frmMDI_MainMenu_Help.Text = "&Справка";
            // 
            // frmMDI_MainMenu_Help_Help
            // 
            this.frmMDI_MainMenu_Help_Help.Name = "frmMDI_MainMenu_Help_Help";
            this.frmMDI_MainMenu_Help_Help.Size = new System.Drawing.Size(164, 22);
            this.frmMDI_MainMenu_Help_Help.Text = "Помощь";
            this.frmMDI_MainMenu_Help_Help.Click += new System.EventHandler(this.frmMDI_MainMenu_Help_Help_Click);
            // 
            // frmMDI_MainMenu_Help_Sep1
            // 
            this.frmMDI_MainMenu_Help_Sep1.Name = "frmMDI_MainMenu_Help_Sep1";
            this.frmMDI_MainMenu_Help_Sep1.Size = new System.Drawing.Size(161, 6);
            // 
            // frmMDI_MainMenu_Help_About
            // 
            this.frmMDI_MainMenu_Help_About.Name = "frmMDI_MainMenu_Help_About";
            this.frmMDI_MainMenu_Help_About.Size = new System.Drawing.Size(164, 22);
            this.frmMDI_MainMenu_Help_About.Text = "О программе ...";
            this.frmMDI_MainMenu_Help_About.Click += new System.EventHandler(this.frmMDI_MainMenu_Help_About_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(675, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(66, 17);
            this.status.Text = "Состояние";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.frmMDI_MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.frmMDI_MainMenu;
            this.Name = "frmMDI";
            this.Text = "Санаторий - профилакторий ИГХТУ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMDI_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.frmMDI_MainMenu.ResumeLayout(false);
            this.frmMDI_MainMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip frmMDI_MainMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Help_About;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Windiw_Horizontal;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Service;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Service_Parameters;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Windiw_Сascade;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Windiw_Vertical;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Windiw_СloseAll;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Help;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem Food;
        private System.Windows.Forms.ToolStripMenuItem Diets_menu;
        private System.Windows.Forms.ToolStripMenuItem Cooking_book_menu;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Help_Help;
        private System.Windows.Forms.ToolStripSeparator frmMDI_MainMenu_Help_Sep1;
        public System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripMenuItem b_queue;
        private System.Windows.Forms.ToolStripMenuItem b_diet_in_food;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Digest_Ingridients;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Menu;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Reports;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Digest;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Queue;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Windiw;
        private System.Windows.Forms.ToolStripMenuItem Person;
        private System.Windows.Forms.ToolStripMenuItem b_add_menu;
        private System.Windows.Forms.ToolStripMenuItem b_report;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator Cards_Menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Cards;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}



