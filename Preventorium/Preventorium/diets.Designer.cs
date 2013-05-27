namespace Preventorium
{
    partial class diets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diets));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_desc = new System.Windows.Forms.TextBox();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.Menu_diets = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gw = new System.Windows.Forms.DataGridView();
            this.Menu_Strip_diets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.read_diets = new System.Windows.Forms.ToolStripMenuItem();
            this.del_diets = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.Menu_diets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.Menu_Strip_diets.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_desc
            // 
            this.tb_desc.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_desc.Location = new System.Drawing.Point(314, 28);
            this.tb_desc.Multiline = true;
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.ReadOnly = true;
            this.tb_desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_desc.Size = new System.Drawing.Size(308, 265);
            this.tb_desc.TabIndex = 3;
            // 
            // Menu_diets
            // 
            this.Menu_diets.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_diets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.bAdd,
            this.toolStripSeparator1,
            this.bEdit,
            this.toolStripSeparator3,
            this.bDelete,
            this.toolStripSeparator2});
            this.Menu_diets.Location = new System.Drawing.Point(0, 0);
            this.Menu_diets.Name = "Menu_diets";
            this.Menu_diets.Size = new System.Drawing.Size(623, 25);
            this.Menu_diets.TabIndex = 4;
            this.Menu_diets.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bAdd
            // 
            this.bAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
            this.bAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(23, 22);
            this.bAdd.Text = "Добавление диеты";
            this.bAdd.Click += new System.EventHandler(this.bAddDiet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bEdit
            // 
            this.bEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(23, 22);
            this.bEdit.Text = "Редактирование диеты";
            this.bEdit.Click += new System.EventHandler(this.bEditDiet_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bDelete
            // 
            this.bDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDelete.Image = global::Preventorium.Properties.Resources.delete_btn;
            this.bDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(23, 22);
            this.bDelete.Text = "Удалить";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // gw
            // 
            this.gw.AllowUserToAddRows = false;
            this.gw.AllowUserToDeleteRows = false;
            this.gw.AllowUserToResizeColumns = false;
            this.gw.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.gw.ContextMenuStrip = this.Menu_Strip_diets;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gw.DefaultCellStyle = dataGridViewCellStyle3;
            this.gw.Location = new System.Drawing.Point(0, 28);
            this.gw.MultiSelect = false;
            this.gw.Name = "gw";
            this.gw.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.gw.Size = new System.Drawing.Size(308, 265);
            this.gw.TabIndex = 5;
            this.gw.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellClick);
            this.gw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellDoubleClick);
            this.gw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gw_KeyDown);
            this.gw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDown);
            // 
            // Menu_Strip_diets
            // 
            this.Menu_Strip_diets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.read_diets,
            this.del_diets});
            this.Menu_Strip_diets.Name = "Menu_Strip_diets";
            this.Menu_Strip_diets.Size = new System.Drawing.Size(155, 70);
            // 
            // read_diets
            // 
            this.read_diets.Image = global::Preventorium.Properties.Resources.kwrite;
            this.read_diets.Name = "read_diets";
            this.read_diets.Size = new System.Drawing.Size(154, 22);
            this.read_diets.Text = "Редактировать";
            this.read_diets.Click += new System.EventHandler(this.read_diets_Click);
            // 
            // del_diets
            // 
            this.del_diets.Image = global::Preventorium.Properties.Resources.delete_btn;
            this.del_diets.Name = "del_diets";
            this.del_diets.Size = new System.Drawing.Size(154, 22);
            this.del_diets.Text = "Удалить";
            this.del_diets.Click += new System.EventHandler(this.del_diets_Click);
            // 
            // diets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 291);
            this.Controls.Add(this.gw);
            this.Controls.Add(this.Menu_diets);
            this.Controls.Add(this.tb_desc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "diets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диеты";
            this.Load += new System.EventHandler(this.diet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.Menu_diets.ResumeLayout(false);
            this.Menu_diets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.Menu_Strip_diets.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.TextBox tb_desc;
        private System.Windows.Forms.ToolStrip Menu_diets;
        private System.Windows.Forms.ToolStripButton bAdd;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bDelete;
        public System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.ContextMenuStrip Menu_Strip_diets;
        private System.Windows.Forms.ToolStripMenuItem read_diets;
        private System.Windows.Forms.ToolStripMenuItem del_diets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;


    }
}