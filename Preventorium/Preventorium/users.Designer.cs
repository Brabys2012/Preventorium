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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.ts = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.b_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.b_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.b_read = new System.Windows.Forms.ToolStripButton();
            this.gw = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
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
            this.b_delete,
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
            // b_delete
            // 
            this.b_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_delete.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px1;
            this.b_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(23, 22);
            this.b_delete.Text = "Удаление пароля пользователю";
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // b_read
            // 
            this.b_read.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.b_read.Image = global::Preventorium.Properties.Resources._50px_Exquisite_kwrite;
            this.b_read.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_read.Name = "b_read";
            this.b_read.Size = new System.Drawing.Size(23, 22);
            this.b_read.Text = "Редактирование логина и/или пароля";
            this.b_read.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gw
            // 
            this.gw.AllowUserToAddRows = false;
            this.gw.AllowUserToDeleteRows = false;
            this.gw.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gw.DefaultCellStyle = dataGridViewCellStyle15;
            this.gw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gw.Location = new System.Drawing.Point(0, 25);
            this.gw.MultiSelect = false;
            this.gw.Name = "gw";
            this.gw.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gw.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.gw.RowHeadersVisible = false;
            this.gw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gw.ShowCellErrors = false;
            this.gw.ShowEditingIcon = false;
            this.gw.ShowRowErrors = false;
            this.gw.Size = new System.Drawing.Size(435, 254);
            this.gw.TabIndex = 4;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 279);
            this.Controls.Add(this.gw);
            this.Controls.Add(this.ts);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ваш логин и пароль";
            this.Load += new System.EventHandler(this.users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton b_add;
        private System.Windows.Forms.ToolStripButton b_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.ToolStripButton b_read;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}