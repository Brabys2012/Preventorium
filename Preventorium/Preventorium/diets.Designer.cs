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
            this.tb_desc = new System.Windows.Forms.TextBox();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.Menu_diets = new System.Windows.Forms.ToolStrip();
            this.bAdd = new System.Windows.Forms.ToolStripButton();
            this.bEdit = new System.Windows.Forms.ToolStripButton();
            this.bDelete = new System.Windows.Forms.ToolStripButton();
            this.gw = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.Menu_diets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_desc
            // 
            this.tb_desc.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_desc.Location = new System.Drawing.Point(0, 209);
            this.tb_desc.Multiline = true;
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.ReadOnly = true;
            this.tb_desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_desc.Size = new System.Drawing.Size(481, 81);
            this.tb_desc.TabIndex = 3;
            // 
            // Menu_diets
            // 
            this.Menu_diets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAdd,
            this.bEdit,
            this.bDelete});
            this.Menu_diets.Location = new System.Drawing.Point(0, 0);
            this.Menu_diets.Name = "Menu_diets";
            this.Menu_diets.Size = new System.Drawing.Size(494, 25);
            this.Menu_diets.TabIndex = 4;
            this.Menu_diets.Text = "toolStrip1";
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
            // gw
            // 
            this.gw.AllowUserToAddRows = false;
            this.gw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gw.Location = new System.Drawing.Point(0, 28);
            this.gw.Name = "gw";
            this.gw.ReadOnly = true;
            this.gw.RowHeadersVisible = false;
            this.gw.ShowCellErrors = false;
            this.gw.ShowCellToolTips = false;
            this.gw.ShowEditingIcon = false;
            this.gw.ShowRowErrors = false;
            this.gw.Size = new System.Drawing.Size(494, 175);
            this.gw.TabIndex = 5;
            this.gw.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellClick);
            this.gw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gw_CellDoubleClick);
            // 
            // diets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 291);
            this.Controls.Add(this.gw);
            this.Controls.Add(this.Menu_diets);
            this.Controls.Add(this.tb_desc);
            this.Name = "diets";
            this.Text = "Диеты";
            this.Load += new System.EventHandler(this.diet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.Menu_diets.ResumeLayout(false);
            this.Menu_diets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gw)).EndInit();
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
        private System.Windows.Forms.DataGridView gw;


    }
}