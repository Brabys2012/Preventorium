namespace Preventorium
{
    partial class ingr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ingr));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_ingr = new System.Windows.Forms.ToolStrip();
            this.add_butt = new System.Windows.Forms.ToolStripButton();
            this.read_but = new System.Windows.Forms.ToolStripButton();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Report_Excel = new System.Windows.Forms.ToolStripDropDownButton();
            this.Excel_Exp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.gw = new System.Windows.Forms.DataGridView();
            this.Menu_ingr_strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.read_butt = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_butt = new System.Windows.Forms.ToolStripMenuItem();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.Menu_ingr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.Menu_ingr_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Menu_ingr
            // 
            this.Menu_ingr.GripMargin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Menu_ingr.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ingr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.add_butt,
            this.toolStripSeparator3,
            this.read_but,
            this.toolStripSeparator1,
            this.bDelete,
            this.toolStripSeparator4,
            this.Report_Excel,
            this.toolStripSeparator5});
            this.Menu_ingr.Location = new System.Drawing.Point(0, 0);
            this.Menu_ingr.Name = "Menu_ingr";
            this.Menu_ingr.Size = new System.Drawing.Size(643, 25);
            this.Menu_ingr.TabIndex = 7;
            this.Menu_ingr.Text = "toolStrip1";
            // 
            // add_butt
            // 
            this.add_butt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_butt.Image = ((System.Drawing.Image)(resources.GetObject("add_butt.Image")));
            this.add_butt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_butt.Name = "add_butt";
            this.add_butt.Size = new System.Drawing.Size(23, 22);
            this.add_butt.Text = "Добавить ингридиент";
            this.add_butt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         
            // 
            // read_but
            // 
            this.read_but.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.read_but.Image = ((System.Drawing.Image)(resources.GetObject("read_but.Image")));
            this.read_but.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.read_but.Name = "read_but";
            this.read_but.Size = new System.Drawing.Size(23, 22);
            this.read_but.Text = "Редактировать ингридиент";
            this.read_but.Click += new System.EventHandler(this.read_but_Click);
            // 
            // bDelete
            // 
            this.bDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDelete.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px1;
            this.bDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(23, 22);
            this.bDelete.Text = "Удалить";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Report_Excel
            // 
            this.Report_Excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Report_Excel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Excel_Exp});
            this.Report_Excel.Image = ((System.Drawing.Image)(resources.GetObject("Report_Excel.Image")));
            this.Report_Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Report_Excel.Name = "Report_Excel";
            this.Report_Excel.Size = new System.Drawing.Size(29, 22);
            this.Report_Excel.Text = "Отчет";
            // 
            // Excel_Exp
            // 
            this.Excel_Exp.Image = ((System.Drawing.Image)(resources.GetObject("Excel_Exp.Image")));
            this.Excel_Exp.Name = "Excel_Exp";
            this.Excel_Exp.Size = new System.Drawing.Size(157, 22);
            this.Excel_Exp.Text = "Экспорт в Excel";
            this.Excel_Exp.Click += new System.EventHandler(this.Export_Excel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gw.ContextMenuStrip = this.Menu_ingr_strip;
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
            this.gw.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.gw.Size = new System.Drawing.Size(643, 316);
            this.gw.TabIndex = 8;
            this.gw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellDoubleClick);
            this.gw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gw_KeyDown);
         
            this.gw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDown);
            // 
            // Menu_ingr_strip
            // 
            this.Menu_ingr_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.read_butt,
            this.delete_butt});
            this.Menu_ingr_strip.Name = "Menu_ingr_strip";
            this.Menu_ingr_strip.Size = new System.Drawing.Size(155, 48);
            // 
            // read_butt
            // 
            this.read_butt.Image = global::Preventorium.Properties.Resources._50px_Exquisite_kwrite;
            this.read_butt.Name = "read_butt";
            this.read_butt.Size = new System.Drawing.Size(154, 22);
            this.read_butt.Text = "Редактировать";
            this.read_butt.Click += new System.EventHandler(this.read_but_Click);
            // 
            // delete_butt
            // 
            this.delete_butt.Image = global::Preventorium.Properties.Resources._1305828351_psd_delete_icon800215600_px;
            this.delete_butt.Name = "delete_butt";
            this.delete_butt.Size = new System.Drawing.Size(154, 22);
            this.delete_butt.Text = "Удалить";
            this.delete_butt.Click += new System.EventHandler(this.delete_butt_Click);
            // 
            // ingr
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(643, 341);
            this.Controls.Add(this.gw);
            this.Controls.Add(this.Menu_ingr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ingr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ингредиенты";
            this.Load += new System.EventHandler(this.ingr_Load);
            this.Menu_ingr.ResumeLayout(false);
            this.Menu_ingr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.Menu_ingr_strip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton add_butt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton read_but;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton Report_Excel;
        private System.Windows.Forms.ToolStripMenuItem Excel_Exp;
        private System.Windows.Forms.ToolStripButton bDelete;
        public System.Windows.Forms.DataGridView gw;
        public System.Windows.Forms.ToolStrip Menu_ingr;
        private System.Windows.Forms.ContextMenuStrip Menu_ingr_strip;
        private System.Windows.Forms.ToolStripMenuItem read_butt;
        private System.Windows.Forms.ToolStripMenuItem delete_butt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}