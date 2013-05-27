namespace Preventorium
{
    partial class add_book
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
            this.l_author = new System.Windows.Forms.Label();
            this.gb_book = new System.Windows.Forms.GroupBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_year = new System.Windows.Forms.TextBox();
            this.l_name = new System.Windows.Forms.Label();
            this.l_year = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.gb_data = new System.Windows.Forms.GroupBox();
            this.gw = new System.Windows.Forms.DataGridView();
            this.context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.b_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.b_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gb_book.SuspendLayout();
            this.gb_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.context.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // l_author
            // 
            this.l_author.AutoSize = true;
            this.l_author.Location = new System.Drawing.Point(6, 16);
            this.l_author.Name = "l_author";
            this.l_author.Size = new System.Drawing.Size(52, 18);
            this.l_author.TabIndex = 0;
            this.l_author.Text = "Автор:";
            // 
            // gb_book
            // 
            this.gb_book.Controls.Add(this.tb_name);
            this.gb_book.Controls.Add(this.tb_year);
            this.gb_book.Controls.Add(this.l_name);
            this.gb_book.Controls.Add(this.l_year);
            this.gb_book.Controls.Add(this.tb_author);
            this.gb_book.Controls.Add(this.l_author);
            this.gb_book.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_book.Location = new System.Drawing.Point(12, 12);
            this.gb_book.Name = "gb_book";
            this.gb_book.Size = new System.Drawing.Size(260, 157);
            this.gb_book.TabIndex = 0;
            this.gb_book.TabStop = false;
            this.gb_book.Text = "Введите сведения о справочнике:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(6, 81);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(245, 25);
            this.tb_name.TabIndex = 3;
            this.tb_name.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_year
            // 
            this.tb_year.Location = new System.Drawing.Point(9, 126);
            this.tb_year.Name = "tb_year";
            this.tb_year.Size = new System.Drawing.Size(114, 25);
            this.tb_year.TabIndex = 5;
            this.tb_year.TextChanged += new System.EventHandler(this.enabled_b_save);
            this.tb_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_year_KeyPress);
            // 
            // l_name
            // 
            this.l_name.AutoSize = true;
            this.l_name.Location = new System.Drawing.Point(6, 60);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(73, 18);
            this.l_name.TabIndex = 2;
            this.l_name.Text = "Название:";
            // 
            // l_year
            // 
            this.l_year.AutoSize = true;
            this.l_year.Location = new System.Drawing.Point(6, 105);
            this.l_year.Name = "l_year";
            this.l_year.Size = new System.Drawing.Size(92, 18);
            this.l_year.TabIndex = 4;
            this.l_year.Text = "Год выпуска:";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(6, 37);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(245, 25);
            this.tb_author.TabIndex = 1;
            this.tb_author.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // b_save
            // 
            this.b_save.Enabled = false;
            this.b_save.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(29, 175);
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
            this.b_abolition.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_abolition.Location = new System.Drawing.Point(188, 175);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(75, 23);
            this.b_abolition.TabIndex = 2;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // gb_data
            // 
            this.gb_data.Controls.Add(this.gw);
            this.gb_data.Controls.Add(this.toolStrip1);
            this.gb_data.Location = new System.Drawing.Point(279, -13);
            this.gb_data.Name = "gb_data";
            this.gb_data.Size = new System.Drawing.Size(374, 214);
            this.gb_data.TabIndex = 3;
            this.gb_data.TabStop = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gw.ContextMenuStrip = this.context;
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
            this.gw.Size = new System.Drawing.Size(368, 170);
            this.gw.TabIndex = 1;
            this.gw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gw_KeyDown);
            this.gw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDown);
            // 
            // context
            // 
            this.context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDelete});
            this.context.Name = "contextMenuStrip1";
            this.context.Size = new System.Drawing.Size(119, 26);
            // 
            // bDelete
            // 
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(118, 22);
            this.bDelete.Text = "Удалить";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.b_add,
            this.toolStripSeparator3,
            this.b_delete,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(368, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // b_add
            // 
            this.b_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(23, 22);
            this.b_add.Text = "Добавить";
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // b_delete
            // 
            this.b_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(23, 22);
            this.b_delete.Text = "Удалить";
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // add_book
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(653, 200);
            this.Controls.Add(this.gb_data);
            this.Controls.Add(this.gb_book);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_abolition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_book";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сведения о справочнике";
            this.Load += new System.EventHandler(this.add_food_Load);
            this.gb_book.ResumeLayout(false);
            this.gb_book.PerformLayout();
            this.gb_data.ResumeLayout(false);
            this.gb_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.context.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_author;
        private System.Windows.Forms.GroupBox gb_book;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_year;
        private System.Windows.Forms.Label l_name;
        private System.Windows.Forms.Label l_year;
        private System.Windows.Forms.TextBox tb_author;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.GroupBox gb_data;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton b_add;
        private System.Windows.Forms.ToolStripButton b_delete;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ContextMenuStrip context;
        private System.Windows.Forms.ToolStripMenuItem bDelete;
        public System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}