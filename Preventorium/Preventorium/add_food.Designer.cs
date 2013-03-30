﻿namespace Preventorium
{
    partial class add_food
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_food));
            this.gb_food_data = new System.Windows.Forms.GroupBox();
            this.tb_weight = new System.Windows.Forms.TextBox();
            this.l_weight = new System.Windows.Forms.Label();
            this.gb_chem_contain = new System.Windows.Forms.GroupBox();
            this.tb_calories = new System.Windows.Forms.TextBox();
            this.tb_carbo = new System.Windows.Forms.TextBox();
            this.l_carbo = new System.Windows.Forms.Label();
            this.l_calories = new System.Windows.Forms.Label();
            this.tb_fats = new System.Windows.Forms.TextBox();
            this.l_fats = new System.Windows.Forms.Label();
            this.l_proteins = new System.Windows.Forms.Label();
            this.tb_proteins = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.l_nameFood = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gw = new System.Windows.Forms.DataGridView();
            this.Menu_food = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.read_menu_food = new System.Windows.Forms.ToolStripMenuItem();
            this.b_del_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ingr_food = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.b_card = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_diet_numb = new System.Windows.Forms.ListBox();
            this.tb_card_numb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_method = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_cost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_food_data.SuspendLayout();
            this.gb_chem_contain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.Menu_food.SuspendLayout();
            this.menu_ingr_food.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_food_data
            // 
            this.gb_food_data.Controls.Add(this.tb_weight);
            this.gb_food_data.Controls.Add(this.l_weight);
            this.gb_food_data.Controls.Add(this.gb_chem_contain);
            this.gb_food_data.Controls.Add(this.tb_name);
            this.gb_food_data.Controls.Add(this.l_nameFood);
            this.gb_food_data.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_food_data.Location = new System.Drawing.Point(12, 11);
            this.gb_food_data.Name = "gb_food_data";
            this.gb_food_data.Size = new System.Drawing.Size(210, 290);
            this.gb_food_data.TabIndex = 0;
            this.gb_food_data.TabStop = false;
            this.gb_food_data.Text = "Сведения о блюде:";
            // 
            // tb_weight
            // 
            this.tb_weight.Location = new System.Drawing.Point(10, 73);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(184, 24);
            this.tb_weight.TabIndex = 3;
            this.tb_weight.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // l_weight
            // 
            this.l_weight.AutoSize = true;
            this.l_weight.Location = new System.Drawing.Point(7, 57);
            this.l_weight.Name = "l_weight";
            this.l_weight.Size = new System.Drawing.Size(123, 17);
            this.l_weight.TabIndex = 2;
            this.l_weight.Text = "Вес готового блюда:";
            // 
            // gb_chem_contain
            // 
            this.gb_chem_contain.Controls.Add(this.tb_calories);
            this.gb_chem_contain.Controls.Add(this.tb_carbo);
            this.gb_chem_contain.Controls.Add(this.l_carbo);
            this.gb_chem_contain.Controls.Add(this.l_calories);
            this.gb_chem_contain.Controls.Add(this.tb_fats);
            this.gb_chem_contain.Controls.Add(this.l_fats);
            this.gb_chem_contain.Controls.Add(this.l_proteins);
            this.gb_chem_contain.Controls.Add(this.tb_proteins);
            this.gb_chem_contain.Location = new System.Drawing.Point(10, 103);
            this.gb_chem_contain.Name = "gb_chem_contain";
            this.gb_chem_contain.Size = new System.Drawing.Size(191, 181);
            this.gb_chem_contain.TabIndex = 4;
            this.gb_chem_contain.TabStop = false;
            this.gb_chem_contain.Text = "Химический состав:";
            // 
            // tb_calories
            // 
            this.tb_calories.Location = new System.Drawing.Point(6, 35);
            this.tb_calories.Name = "tb_calories";
            this.tb_calories.Size = new System.Drawing.Size(175, 24);
            this.tb_calories.TabIndex = 9;
            this.tb_calories.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_carbo
            // 
            this.tb_carbo.Location = new System.Drawing.Point(9, 154);
            this.tb_carbo.Name = "tb_carbo";
            this.tb_carbo.Size = new System.Drawing.Size(175, 24);
            this.tb_carbo.TabIndex = 7;
            this.tb_carbo.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // l_carbo
            // 
            this.l_carbo.AutoSize = true;
            this.l_carbo.Location = new System.Drawing.Point(6, 138);
            this.l_carbo.Name = "l_carbo";
            this.l_carbo.Size = new System.Drawing.Size(71, 17);
            this.l_carbo.TabIndex = 6;
            this.l_carbo.Text = "Углеводов:";
            // 
            // l_calories
            // 
            this.l_calories.AutoSize = true;
            this.l_calories.Location = new System.Drawing.Point(6, 15);
            this.l_calories.Name = "l_calories";
            this.l_calories.Size = new System.Drawing.Size(110, 17);
            this.l_calories.TabIndex = 0;
            this.l_calories.Text = "Калорий в блюде:";
            // 
            // tb_fats
            // 
            this.tb_fats.Location = new System.Drawing.Point(9, 115);
            this.tb_fats.Name = "tb_fats";
            this.tb_fats.Size = new System.Drawing.Size(175, 24);
            this.tb_fats.TabIndex = 5;
            this.tb_fats.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // l_fats
            // 
            this.l_fats.AutoSize = true;
            this.l_fats.Location = new System.Drawing.Point(6, 99);
            this.l_fats.Name = "l_fats";
            this.l_fats.Size = new System.Drawing.Size(49, 17);
            this.l_fats.TabIndex = 4;
            this.l_fats.Text = "Жиров:";
            // 
            // l_proteins
            // 
            this.l_proteins.AutoSize = true;
            this.l_proteins.Location = new System.Drawing.Point(3, 56);
            this.l_proteins.Name = "l_proteins";
            this.l_proteins.Size = new System.Drawing.Size(52, 17);
            this.l_proteins.TabIndex = 2;
            this.l_proteins.Text = "Белков:";
            // 
            // tb_proteins
            // 
            this.tb_proteins.Location = new System.Drawing.Point(6, 76);
            this.tb_proteins.Name = "tb_proteins";
            this.tb_proteins.Size = new System.Drawing.Size(175, 24);
            this.tb_proteins.TabIndex = 3;
            this.tb_proteins.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(10, 33);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(184, 24);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // l_nameFood
            // 
            this.l_nameFood.AutoSize = true;
            this.l_nameFood.Location = new System.Drawing.Point(7, 17);
            this.l_nameFood.Name = "l_nameFood";
            this.l_nameFood.Size = new System.Drawing.Size(105, 17);
            this.l_nameFood.TabIndex = 0;
            this.l_nameFood.Text = "Название блюда:";
            // 
            // b_save
            // 
            this.b_save.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(12, 307);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 1;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_abolition.Location = new System.Drawing.Point(143, 307);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(75, 23);
            this.b_abolition.TabIndex = 2;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gw);
            this.groupBox1.Controls.Add(this.menu_ingr_food);
            this.groupBox1.Location = new System.Drawing.Point(224, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 345);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // gw
            // 
            this.gw.AllowUserToAddRows = false;
            this.gw.AllowUserToDeleteRows = false;
            this.gw.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gw.ContextMenuStrip = this.Menu_food;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gw.DefaultCellStyle = dataGridViewCellStyle3;
            this.gw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gw.Location = new System.Drawing.Point(3, 41);
            this.gw.MultiSelect = false;
            this.gw.Name = "gw";
            this.gw.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gw.RowHeadersVisible = false;
            this.gw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gw.ShowCellErrors = false;
            this.gw.ShowEditingIcon = false;
            this.gw.ShowRowErrors = false;
            this.gw.Size = new System.Drawing.Size(667, 301);
            this.gw.TabIndex = 5;
            this.gw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellDoubleClick);
            this.gw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDown);
            // 
            // Menu_food
            // 
            this.Menu_food.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.read_menu_food,
            this.b_del_menu});
            this.Menu_food.Name = "Menu_food";
            this.Menu_food.Size = new System.Drawing.Size(155, 48);
            // 
            // read_menu_food
            // 
            this.read_menu_food.Image = global::Preventorium.Properties.Resources._50px_Exquisite_kwrite;
            this.read_menu_food.Name = "read_menu_food";
            this.read_menu_food.Size = new System.Drawing.Size(154, 22);
            this.read_menu_food.Text = "Редактировать";
            this.read_menu_food.Click += new System.EventHandler(this.read_menu_food_Click);
            // 
            // b_del_menu
            // 
            this.b_del_menu.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px1;
            this.b_del_menu.Name = "b_del_menu";
            this.b_del_menu.Size = new System.Drawing.Size(154, 22);
            this.b_del_menu.Text = "Удалить";
            this.b_del_menu.Click += new System.EventHandler(this.b_del_menu_Click);
            // 
            // menu_ingr_food
            // 
            this.menu_ingr_food.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu_ingr_food.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.bAdd,
            this.toolStripSeparator3,
            this.bEdit,
            this.toolStripSeparator4,
            this.bDelete,
            this.toolStripSeparator5,
            this.b_card,
            this.toolStripSeparator2});
            this.menu_ingr_food.Location = new System.Drawing.Point(3, 16);
            this.menu_ingr_food.Name = "menu_ingr_food";
            this.menu_ingr_food.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu_ingr_food.Size = new System.Drawing.Size(667, 25);
            this.menu_ingr_food.TabIndex = 4;
            this.menu_ingr_food.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bAdd
            // 
            this.bAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
            this.bAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(23, 22);
            this.bAdd.Text = "Добавить ингридиенты в блюдо";
            this.bAdd.Click += new System.EventHandler(this.bAddIngr_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bEdit
            // 
            this.bEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(23, 22);
            this.bEdit.Text = "Редактировать_состав_блюда";
            this.bEdit.Click += new System.EventHandler(this.bEditIngr_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bDelete
            // 
            this.bDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDelete.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px;
            this.bDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(23, 22);
            this.bDelete.Text = "Удалить";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // b_card
            // 
            this.b_card.Image = ((System.Drawing.Image)(resources.GetObject("b_card.Image")));
            this.b_card.Name = "b_card";
            this.b_card.Size = new System.Drawing.Size(184, 22);
            this.b_card.Text = "Создать карточку-раскладку";
            this.b_card.Click += new System.EventHandler(this.b_card_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, -12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb_food_data);
            this.splitContainer1.Panel1.Controls.Add(this.b_save);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.b_abolition);
            this.splitContainer1.Panel1MinSize = 110;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lb_diet_numb);
            this.splitContainer1.Panel2.Controls.Add(this.tb_card_numb);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.tb_method);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.tb_cost);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2MinSize = 1;
            this.splitContainer1.Size = new System.Drawing.Size(900, 345);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(136, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Показано по диетам:";
            // 
            // lb_diet_numb
            // 
            this.lb_diet_numb.FormattingEnabled = true;
            this.lb_diet_numb.Location = new System.Drawing.Point(139, 32);
            this.lb_diet_numb.Name = "lb_diet_numb";
            this.lb_diet_numb.Size = new System.Drawing.Size(89, 199);
            this.lb_diet_numb.TabIndex = 18;
            // 
            // tb_card_numb
            // 
            this.tb_card_numb.Location = new System.Drawing.Point(12, 97);
            this.tb_card_numb.Name = "tb_card_numb";
            this.tb_card_numb.Size = new System.Drawing.Size(121, 20);
            this.tb_card_numb.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Номер карты:";
            // 
            // tb_method
            // 
            this.tb_method.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_method.Location = new System.Drawing.Point(277, 33);
            this.tb_method.Multiline = true;
            this.tb_method.Name = "tb_method";
            this.tb_method.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_method.Size = new System.Drawing.Size(611, 191);
            this.tb_method.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(278, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Способ приготовления:";
            // 
            // tb_cost
            // 
            this.tb_cost.Location = new System.Drawing.Point(12, 53);
            this.tb_cost.Name = "tb_cost";
            this.tb_cost.Size = new System.Drawing.Size(121, 20);
            this.tb_cost.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 36);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ориентировочная\r\nстоимость блюда:";
            // 
            // add_food
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(900, 336);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_food";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сведения о блюде";
            this.Load += new System.EventHandler(this.add_food_Load);
            this.gb_food_data.ResumeLayout(false);
            this.gb_food_data.PerformLayout();
            this.gb_chem_contain.ResumeLayout(false);
            this.gb_chem_contain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.Menu_food.ResumeLayout(false);
            this.menu_ingr_food.ResumeLayout(false);
            this.menu_ingr_food.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_food_data;
        private System.Windows.Forms.Label l_nameFood;
        private System.Windows.Forms.GroupBox gb_chem_contain;
        private System.Windows.Forms.TextBox tb_fats;
        private System.Windows.Forms.Label l_fats;
        private System.Windows.Forms.TextBox tb_proteins;
        private System.Windows.Forms.Label l_proteins;
        private System.Windows.Forms.Label l_calories;
        private System.Windows.Forms.TextBox tb_weight;
        private System.Windows.Forms.Label l_weight;
        private System.Windows.Forms.TextBox tb_carbo;
        private System.Windows.Forms.Label l_carbo;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.TextBox tb_calories;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStrip menu_ingr_food;
        private System.Windows.Forms.ToolStripButton bAdd;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bDelete;
        public System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.ToolStripButton b_card;
        private System.Windows.Forms.ContextMenuStrip Menu_food;
        private System.Windows.Forms.ToolStripMenuItem read_menu_food;
        private System.Windows.Forms.ToolStripMenuItem b_del_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tb_card_numb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_method;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_cost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_diet_numb;
        private System.Windows.Forms.Label label1;


    }
}