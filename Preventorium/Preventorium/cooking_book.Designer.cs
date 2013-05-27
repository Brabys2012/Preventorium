namespace Preventorium
{
    partial class cooking_book
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cooking_book));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.bAdd = new System.Windows.Forms.ToolStripButton();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.Menu_book = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gw = new System.Windows.Forms.DataGridView();
            this.Menu_Strip_book = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Read_menu_book = new System.Windows.Forms.ToolStripMenuItem();
            this.delete_menu_book = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.Menu_book.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.Menu_Strip_book.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
            this.bAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(23, 22);
            this.bAdd.Text = "Добавить справочник";
            this.bAdd.Click += new System.EventHandler(this.bAddBook_Click);
            // 
            // bEdit
            // 
            this.bEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(23, 22);
            this.bEdit.Text = "Редактировать справочник";
            this.bEdit.Click += new System.EventHandler(this.bEditBook_Click);
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
            // Menu_book
            // 
            this.Menu_book.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_book.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.bAdd,
            this.toolStripSeparator3,
            this.bEdit,
            this.toolStripSeparator2,
            this.bDelete,
            this.toolStripSeparator4});
            this.Menu_book.Location = new System.Drawing.Point(0, 0);
            this.Menu_book.Name = "Menu_book";
            this.Menu_book.Size = new System.Drawing.Size(341, 25);
            this.Menu_book.TabIndex = 3;
            this.Menu_book.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            this.gw.ContextMenuStrip = this.Menu_Strip_book;
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
            this.gw.Size = new System.Drawing.Size(341, 237);
            this.gw.TabIndex = 4;
            this.gw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellDoubleClick);
            this.gw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gw_KeyDown);
            this.gw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gw_MouseDown);
            // 
            // Menu_Strip_book
            // 
            this.Menu_Strip_book.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Read_menu_book,
            this.delete_menu_book});
            this.Menu_Strip_book.Name = "Menu_Strip_book";
            this.Menu_Strip_book.Size = new System.Drawing.Size(155, 70);
            // 
            // Read_menu_book
            // 
            this.Read_menu_book.Image = global::Preventorium.Properties.Resources.kwrite;
            this.Read_menu_book.Name = "Read_menu_book";
            this.Read_menu_book.Size = new System.Drawing.Size(154, 22);
            this.Read_menu_book.Text = "Редактировать";
            this.Read_menu_book.Click += new System.EventHandler(this.Read_menu_book_Click);
            // 
            // delete_menu_book
            // 
            this.delete_menu_book.Image = global::Preventorium.Properties.Resources.delete_btn;
            this.delete_menu_book.Name = "delete_menu_book";
            this.delete_menu_book.Size = new System.Drawing.Size(154, 22);
            this.delete_menu_book.Text = "Удалить";
            this.delete_menu_book.Click += new System.EventHandler(this.delete_menu_book_Click);
            // 
            // cooking_book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 262);
            this.Controls.Add(this.gw);
            this.Controls.Add(this.Menu_book);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cooking_book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кулинарный справочник";
            this.Load += new System.EventHandler(this.book_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.Menu_book.ResumeLayout(false);
            this.Menu_book.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
            this.Menu_Strip_book.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripButton bAdd;
        private System.Windows.Forms.ToolStripButton bEdit;
        private System.Windows.Forms.ToolStripButton bDelete;
        private System.Windows.Forms.ToolStrip Menu_book;
        public System.Windows.Forms.DataGridView gw;
        private System.Windows.Forms.ContextMenuStrip Menu_Strip_book;
        private System.Windows.Forms.ToolStripMenuItem Read_menu_book;
        private System.Windows.Forms.ToolStripMenuItem delete_menu_book;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}