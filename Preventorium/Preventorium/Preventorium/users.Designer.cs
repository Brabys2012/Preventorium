namespace Preventorium
{
    partial class users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(users));
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.ts = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.b_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.b_read = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cancel_password = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.gw = new System.Windows.Forms.DataGridView();
            this.c_menu_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.b_add_menu_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.read_menu_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.delete_menu_strip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.c_menu_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.b_add,
            this.toolStripSeparator1,
            this.b_read,
            this.toolStripSeparator4,
            this.cancel_password,
            this.toolStripSeparator3});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(435, 25);
            this.ts.TabIndex = 1;
            this.ts.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // b_add
            // 
            this.b_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_add.Image = global::Preventorium.Properties.Resources.add_button1;
            this.b_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(23, 22);
            this.b_add.Text = "Назначить права пользлвателю";
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // b_read
            // 
            this.b_read.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_read.Image = global::Preventorium.Properties.Resources._50px_Exquisite_kwrite;
            this.b_read.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_read.Name = "b_read";
            this.b_read.Size = new System.Drawing.Size(23, 22);
            this.b_read.Text = "Редактирование логина и/или пароля";
            this.b_read.Click += new System.EventHandler(this.b_read_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // cancel_password
            // 
            this.cancel_password.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancel_password.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px1;
            this.cancel_password.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel_password.Name = "cancel_password";
            this.cancel_password.Size = new System.Drawing.Size(23, 22);
            this.cancel_password.Text = "Сбросить пароль и логин";
            this.cancel_password.Click += new System.EventHandler(this.cancel_password_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // gw
            // 
            this.gw.AllowUserToAddRows = false;
            this.gw.AllowUserToDeleteRows = false;
            this.gw.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            this.gw.ContextMenuStrip = this.c_menu_strip;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gw.DefaultCellStyle = dataGridViewCellStyle3;
            this.gw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gw.Location = new System.Drawing.Point(0, 25);
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
            this.gw.Size = new System.Drawing.Size(435, 254);
            this.gw.TabIndex = 4;
            this.gw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gw_KeyDown);
            this.gw.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDoubleClick);
            this.gw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDown);
            // 
            // c_menu_strip
            // 
            this.c_menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b_add_menu_strip,
            this.toolStripSeparator5,
            this.read_menu_strip,
            this.toolStripSeparator6,
            this.delete_menu_strip});
            this.c_menu_strip.Name = "c_menu_strip";
            this.c_menu_strip.Size = new System.Drawing.Size(155, 82);
            // 
            // b_add_menu_strip
            // 
            this.b_add_menu_strip.Image = global::Preventorium.Properties.Resources.add_button;
            this.b_add_menu_strip.Name = "b_add_menu_strip";
            this.b_add_menu_strip.Size = new System.Drawing.Size(154, 22);
            this.b_add_menu_strip.Text = "Добавить";
            this.b_add_menu_strip.Click += new System.EventHandler(this.b_add_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(151, 6);
            // 
            // read_menu_strip
            // 
            this.read_menu_strip.Image = global::Preventorium.Properties.Resources._50px_Exquisite_kwrite;
            this.read_menu_strip.Name = "read_menu_strip";
            this.read_menu_strip.Size = new System.Drawing.Size(154, 22);
            this.read_menu_strip.Text = "Редактировать";
            this.read_menu_strip.Click += new System.EventHandler(this.b_read_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(151, 6);
            // 
            // delete_menu_strip
            // 
            this.delete_menu_strip.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px1;
            this.delete_menu_strip.Name = "delete_menu_strip";
            this.delete_menu_strip.Size = new System.Drawing.Size(154, 22);
            this.delete_menu_strip.Text = "Удалить";
            this.delete_menu_strip.Click += new System.EventHandler(this.cancel_password_Click);
            // 
            // users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 279);
            this.Controls.Add(this.gw);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сменить пароль";
            this.Load += new System.EventHandler(this.users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.c_menu_strip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton b_add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.ToolStripButton b_read;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip c_menu_strip;
        private System.Windows.Forms.ToolStripMenuItem b_add_menu_strip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem read_menu_strip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem delete_menu_strip;
        private System.Windows.Forms.ToolStripButton cancel_password;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}