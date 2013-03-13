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
            this.b_diet_in_food = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Queue = new System.Windows.Forms.ToolStripMenuItem();
            this.b_queue = new System.Windows.Forms.ToolStripMenuItem();
            this.b_add_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Digest = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Digest_Ingridients = new System.Windows.Forms.ToolStripMenuItem();
            this.Diets_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Cooking_book_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Cards_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Person = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Service = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Service_Parameters = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.ingr_Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.b_report = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Windiw = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Windiw_Сascade = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Windiw_Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMDI_MainMenu_Windiw_Horizontal = new System.Windows.Forms.ToolStripMenuItem();
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
            this.frmMDI_MainMenu_Service,
            this.frmMDI_MainMenu_Reports,
            this.frmMDI_MainMenu_Windiw,
            this.frmMDI_MainMenu_Help});
            this.frmMDI_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.frmMDI_MainMenu.MdiWindowListItem = this.frmMDI_MainMenu_Windiw;
            this.frmMDI_MainMenu.Name = "frmMDI_MainMenu";
            this.frmMDI_MainMenu.Size = new System.Drawing.Size(675, 24);
            this.frmMDI_MainMenu.TabIndex = 0;
            this.frmMDI_MainMenu.Text = "MenuStrip";
            // 
            // frmMDI_MainMenu_Menu
            // 
            this.frmMDI_MainMenu_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Food,
            this.b_diet_in_food});
            this.frmMDI_MainMenu_Menu.Name = "frmMDI_MainMenu_Menu";
            this.frmMDI_MainMenu_Menu.Size = new System.Drawing.Size(53, 20);
            this.frmMDI_MainMenu_Menu.Text = "Меню";
            // 
            // Food
            // 
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(157, 22);
            this.Food.Text = "Блюда";
            this.Food.Click += new System.EventHandler(this.Food_Click);
            // 
            // b_diet_in_food
            // 
            this.b_diet_in_food.Name = "b_diet_in_food";
            this.b_diet_in_food.Size = new System.Drawing.Size(157, 22);
            this.b_diet_in_food.Text = "Диеты в блюде";
            this.b_diet_in_food.Click += new System.EventHandler(this.b_diet_in_food_Click);
            // 
            // frmMDI_MainMenu_Queue
            // 
            this.frmMDI_MainMenu_Queue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b_queue,
            this.b_add_menu});
            this.frmMDI_MainMenu_Queue.Name = "frmMDI_MainMenu_Queue";
            this.frmMDI_MainMenu_Queue.Size = new System.Drawing.Size(66, 20);
            this.frmMDI_MainMenu_Queue.Text = "Очередь";
            // 
            // b_queue
            // 
            this.b_queue.Name = "b_queue";
            this.b_queue.Size = new System.Drawing.Size(223, 22);
            this.b_queue.Text = "Просмотреть очереди";
            this.b_queue.Click += new System.EventHandler(this.b_queue_Click);
            // 
            // b_add_menu
            // 
            this.b_add_menu.Name = "b_add_menu";
            this.b_add_menu.Size = new System.Drawing.Size(197, 22);
            this.b_add_menu.Text = "Меню для очереди";
            this.b_add_menu.Click += new System.EventHandler(this.b_add_menu_Click);
            // 
            // frmMDI_MainMenu_Digest
            // 
            this.frmMDI_MainMenu_Digest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Digest_Ingridients,
            this.Diets_menu,
            this.Cooking_book_menu,
            this.Cards_Menu,
            this.Person});
            this.frmMDI_MainMenu_Digest.Name = "frmMDI_MainMenu_Digest";
            this.frmMDI_MainMenu_Digest.Size = new System.Drawing.Size(94, 20);
            this.frmMDI_MainMenu_Digest.Text = "Справочники";
            // 
            // frmMDI_MainMenu_Digest_Ingridients
            // 
            this.frmMDI_MainMenu_Digest_Ingridients.Image = ((System.Drawing.Image)(resources.GetObject("frmMDI_MainMenu_Digest_Ingridients.Image")));
            this.frmMDI_MainMenu_Digest_Ingridients.Name = "frmMDI_MainMenu_Digest_Ingridients";
            this.frmMDI_MainMenu_Digest_Ingridients.Size = new System.Drawing.Size(213, 22);
            this.frmMDI_MainMenu_Digest_Ingridients.Text = "Ингредиенты";
            this.frmMDI_MainMenu_Digest_Ingridients.Click += new System.EventHandler(this.frmMDI_MainMenu_Digest_Ingridients_Click);
            // 
            // Diets_menu
            // 
            this.Diets_menu.Name = "Diets_menu";
            this.Diets_menu.Size = new System.Drawing.Size(213, 22);
            this.Diets_menu.Text = "Диеты";
            this.Diets_menu.Click += new System.EventHandler(this.Diet_Click);
            // 
            // Cooking_book_menu
            // 
            this.Cooking_book_menu.Name = "Cooking_book_menu";
            this.Cooking_book_menu.Size = new System.Drawing.Size(213, 22);
            this.Cooking_book_menu.Text = "Кулинарный справочник";
            this.Cooking_book_menu.Click += new System.EventHandler(this.Cooking_book_Click);
            // 
            // Cards_Menu
            // 
            this.Cards_Menu.Name = "Cards_Menu";
            this.Cards_Menu.Size = new System.Drawing.Size(213, 22);
            this.Cards_Menu.Text = "Карта-раскладка";
            this.Cards_Menu.Click += new System.EventHandler(this.Cards_Click);
            // 
            // Person
            // 
            this.Person.Name = "Person";
            this.Person.Size = new System.Drawing.Size(213, 22);
            this.Person.Text = "Персонал";
            this.Person.Click += new System.EventHandler(this.Person_Click);
            // 
            // frmMDI_MainMenu_Service
            // 
            this.frmMDI_MainMenu_Service.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Service_Parameters});
            this.frmMDI_MainMenu_Service.Name = "frmMDI_MainMenu_Service";
            this.frmMDI_MainMenu_Service.Size = new System.Drawing.Size(59, 20);
            this.frmMDI_MainMenu_Service.Text = "&Сервис";
            // 
            // frmMDI_MainMenu_Service_Parameters
            // 
            this.frmMDI_MainMenu_Service_Parameters.Name = "frmMDI_MainMenu_Service_Parameters";
            this.frmMDI_MainMenu_Service_Parameters.Size = new System.Drawing.Size(138, 22);
            this.frmMDI_MainMenu_Service_Parameters.Text = "&Параметры";
            this.frmMDI_MainMenu_Service_Parameters.Click += new System.EventHandler(this.frmMDI_MainMenu_Service_Parameters_Click);
            // 
            // frmMDI_MainMenu_Reports
            // 
            this.frmMDI_MainMenu_Reports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingr_Excel,
            this.b_report});
            this.frmMDI_MainMenu_Reports.Name = "frmMDI_MainMenu_Reports";
            this.frmMDI_MainMenu_Reports.Size = new System.Drawing.Size(60, 20);
            this.frmMDI_MainMenu_Reports.Text = "Отчеты";
            // 
            // ingr_Excel
            // 
            this.ingr_Excel.Image = ((System.Drawing.Image)(resources.GetObject("ingr_Excel.Image")));
            this.ingr_Excel.Name = "ingr_Excel";
            this.ingr_Excel.Size = new System.Drawing.Size(278, 22);
            this.ingr_Excel.Text = "Отчет по ингридиентам";
            this.ingr_Excel.Click += new System.EventHandler(this.Report_ingr_Click);
            // 
            // b_report
            // 
            this.b_report.Image = ((System.Drawing.Image)(resources.GetObject("b_report.Image")));
            this.b_report.Name = "b_report";
            this.b_report.Size = new System.Drawing.Size(278, 22);
            this.b_report.Text = "Сформировать карточку - раскладку";
            this.b_report.Click += new System.EventHandler(this.b_report_Click);
            // 
            // frmMDI_MainMenu_Windiw
            // 
            this.frmMDI_MainMenu_Windiw.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Windiw_Сascade,
            this.frmMDI_MainMenu_Windiw_Vertical,
            this.frmMDI_MainMenu_Windiw_Horizontal,
            this.frmMDI_MainMenu_Windiw_СloseAll});
            this.frmMDI_MainMenu_Windiw.Name = "frmMDI_MainMenu_Windiw";
            this.frmMDI_MainMenu_Windiw.Size = new System.Drawing.Size(48, 20);
            this.frmMDI_MainMenu_Windiw.Text = "Окно";
            // 
            // frmMDI_MainMenu_Windiw_Сascade
            // 
            this.frmMDI_MainMenu_Windiw_Сascade.Name = "frmMDI_MainMenu_Windiw_Сascade";
            this.frmMDI_MainMenu_Windiw_Сascade.Size = new System.Drawing.Size(156, 22);
            this.frmMDI_MainMenu_Windiw_Сascade.Text = "Каскадом";
            this.frmMDI_MainMenu_Windiw_Сascade.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_Сascade_Click);
            // 
            // frmMDI_MainMenu_Windiw_Vertical
            // 
            this.frmMDI_MainMenu_Windiw_Vertical.Name = "frmMDI_MainMenu_Windiw_Vertical";
            this.frmMDI_MainMenu_Windiw_Vertical.Size = new System.Drawing.Size(156, 22);
            this.frmMDI_MainMenu_Windiw_Vertical.Text = "Слева направо";
            this.frmMDI_MainMenu_Windiw_Vertical.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_Vertical_Click);
            // 
            // frmMDI_MainMenu_Windiw_Horizontal
            // 
            this.frmMDI_MainMenu_Windiw_Horizontal.Name = "frmMDI_MainMenu_Windiw_Horizontal";
            this.frmMDI_MainMenu_Windiw_Horizontal.Size = new System.Drawing.Size(156, 22);
            this.frmMDI_MainMenu_Windiw_Horizontal.Text = "Сверху вниз";
            this.frmMDI_MainMenu_Windiw_Horizontal.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_Horizontal_Click);
            // 
            // frmMDI_MainMenu_Windiw_СloseAll
            // 
            this.frmMDI_MainMenu_Windiw_СloseAll.Name = "frmMDI_MainMenu_Windiw_СloseAll";
            this.frmMDI_MainMenu_Windiw_СloseAll.Size = new System.Drawing.Size(156, 22);
            this.frmMDI_MainMenu_Windiw_СloseAll.Text = "Закрыть все";
            this.frmMDI_MainMenu_Windiw_СloseAll.Click += new System.EventHandler(this.frmMDI_MainMenu_Windiw_СloseAll_Click);
            // 
            // frmMDI_MainMenu_Help
            // 
            this.frmMDI_MainMenu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmMDI_MainMenu_Help_Help,
            this.frmMDI_MainMenu_Help_Sep1,
            this.frmMDI_MainMenu_Help_About});
            this.frmMDI_MainMenu_Help.Name = "frmMDI_MainMenu_Help";
            this.frmMDI_MainMenu_Help.Size = new System.Drawing.Size(65, 20);
            this.frmMDI_MainMenu_Help.Text = "&Справка";
            // 
            // frmMDI_MainMenu_Help_Help
            // 
            this.frmMDI_MainMenu_Help_Help.Name = "frmMDI_MainMenu_Help_Help";
            this.frmMDI_MainMenu_Help_Help.Size = new System.Drawing.Size(161, 22);
            this.frmMDI_MainMenu_Help_Help.Text = "Помощь";
            this.frmMDI_MainMenu_Help_Help.Click += new System.EventHandler(this.frmMDI_MainMenu_Help_Help_Click);
            // 
            // frmMDI_MainMenu_Help_Sep1
            // 
            this.frmMDI_MainMenu_Help_Sep1.Name = "frmMDI_MainMenu_Help_Sep1";
            this.frmMDI_MainMenu_Help_Sep1.Size = new System.Drawing.Size(158, 6);
            // 
            // frmMDI_MainMenu_Help_About
            // 
            this.frmMDI_MainMenu_Help_About.Name = "frmMDI_MainMenu_Help_About";
            this.frmMDI_MainMenu_Help_About.Size = new System.Drawing.Size(161, 22);
            this.frmMDI_MainMenu_Help_About.Text = "О программе ...";
            this.frmMDI_MainMenu_Help_About.Click += new System.EventHandler(this.frmMDI_MainMenu_Help_About_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
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
        private System.Windows.Forms.ToolStripMenuItem ingr_Excel;
        private System.Windows.Forms.ToolStripMenuItem Diets_menu;
        private System.Windows.Forms.ToolStripMenuItem Cooking_book_menu;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Help_Help;
        private System.Windows.Forms.ToolStripSeparator frmMDI_MainMenu_Help_Sep1;
        public System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripMenuItem b_queue;
        private System.Windows.Forms.ToolStripMenuItem b_diet_in_food;
        private System.Windows.Forms.ToolStripMenuItem Cards_Menu;
        private System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Digest_Ingridients;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Menu;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Reports;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Digest;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Queue;
        public System.Windows.Forms.ToolStripMenuItem frmMDI_MainMenu_Windiw;
        private System.Windows.Forms.ToolStripMenuItem Person;
        private System.Windows.Forms.ToolStripMenuItem b_add_menu;
        private System.Windows.Forms.ToolStripMenuItem b_report;
    }
}



