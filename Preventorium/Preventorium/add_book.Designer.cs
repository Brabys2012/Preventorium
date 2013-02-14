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
            this.l_author = new System.Windows.Forms.Label();
            this.gb_book = new System.Windows.Forms.GroupBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_year = new System.Windows.Forms.TextBox();
            this.l_name = new System.Windows.Forms.Label();
            this.l_year = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.l_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.gb_book.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_author
            // 
            this.l_author.AutoSize = true;
            this.l_author.Location = new System.Drawing.Point(6, 25);
            this.l_author.Name = "l_author";
            this.l_author.Size = new System.Drawing.Size(40, 13);
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
            this.gb_book.Location = new System.Drawing.Point(12, 12);
            this.gb_book.Name = "gb_book";
            this.gb_book.Size = new System.Drawing.Size(260, 150);
            this.gb_book.TabIndex = 0;
            this.gb_book.TabStop = false;
            this.gb_book.Text = "Введите сведения о справочнике:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(9, 81);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(245, 20);
            this.tb_name.TabIndex = 3;
            this.tb_name.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_year
            // 
            this.tb_year.Location = new System.Drawing.Point(9, 120);
            this.tb_year.Name = "tb_year";
            this.tb_year.Size = new System.Drawing.Size(114, 20);
            this.tb_year.TabIndex = 5;
            this.tb_year.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // l_name
            // 
            this.l_name.AutoSize = true;
            this.l_name.Location = new System.Drawing.Point(6, 65);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(60, 13);
            this.l_name.TabIndex = 2;
            this.l_name.Text = "Название:";
            // 
            // l_year
            // 
            this.l_year.AutoSize = true;
            this.l_year.Location = new System.Drawing.Point(6, 104);
            this.l_year.Name = "l_year";
            this.l_year.Size = new System.Drawing.Size(74, 13);
            this.l_year.TabIndex = 4;
            this.l_year.Text = "Год выпуска:";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(9, 42);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(245, 20);
            this.tb_author.TabIndex = 1;
            this.tb_author.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(38, 168);
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
            this.b_abolition.Location = new System.Drawing.Point(169, 168);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(75, 23);
            this.b_abolition.TabIndex = 2;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l_status});
            this.status.Location = new System.Drawing.Point(0, 205);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(284, 22);
            this.status.TabIndex = 5;
            this.status.Text = "statusStrip1";
            // 
            // l_status
            // 
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(0, 17);
            // 
            // add_book
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(284, 227);
            this.Controls.Add(this.status);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.gb_book);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "add_book";
            this.Text = "Сведения о справочнике";
            this.gb_book.ResumeLayout(false);
            this.gb_book.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel l_status;
    }
}