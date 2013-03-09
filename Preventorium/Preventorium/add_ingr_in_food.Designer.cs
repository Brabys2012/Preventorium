namespace Preventorium
{
    partial class add_ingr_in_food
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
            this.l_ingr = new System.Windows.Forms.Label();
            this.cb_ingr = new System.Windows.Forms.ComboBox();
            this.l_gross = new System.Windows.Forms.Label();
            this.tb_gross = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_net = new System.Windows.Forms.TextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // l_ingr
            // 
            this.l_ingr.AutoSize = true;
            this.l_ingr.Location = new System.Drawing.Point(12, 9);
            this.l_ingr.Name = "l_ingr";
            this.l_ingr.Size = new System.Drawing.Size(70, 13);
            this.l_ingr.TabIndex = 0;
            this.l_ingr.Text = "Ингридиент:";
            // 
            // cb_ingr
            // 
            this.cb_ingr.FormattingEnabled = true;
            this.cb_ingr.Location = new System.Drawing.Point(15, 26);
            this.cb_ingr.Name = "cb_ingr";
            this.cb_ingr.Size = new System.Drawing.Size(280, 21);
            this.cb_ingr.TabIndex = 1;
            this.cb_ingr.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // l_gross
            // 
            this.l_gross.AutoSize = true;
            this.l_gross.Location = new System.Drawing.Point(12, 56);
            this.l_gross.Name = "l_gross";
            this.l_gross.Size = new System.Drawing.Size(65, 13);
            this.l_gross.TabIndex = 2;
            this.l_gross.Text = "Вес брутто:";
            // 
            // tb_gross
            // 
            this.tb_gross.Location = new System.Drawing.Point(15, 72);
            this.tb_gross.Name = "tb_gross";
            this.tb_gross.Size = new System.Drawing.Size(138, 20);
            this.tb_gross.TabIndex = 3;
            this.tb_gross.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вес нетто:";
            // 
            // tb_net
            // 
            this.tb_net.Location = new System.Drawing.Point(159, 72);
            this.tb_net.Name = "tb_net";
            this.tb_net.Size = new System.Drawing.Size(138, 20);
            this.tb_net.TabIndex = 5;
            this.tb_net.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(39, 98);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 6;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Location = new System.Drawing.Point(191, 98);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(75, 23);
            this.b_abolition.TabIndex = 7;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // add_ingr_in_food
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(307, 128);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.tb_net);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_gross);
            this.Controls.Add(this.l_gross);
            this.Controls.Add(this.cb_ingr);
            this.Controls.Add(this.l_ingr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_ingr_in_food";
            this.Text = "Добавить ингридиенты в блюдо";
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_ingr;
        private System.Windows.Forms.ComboBox cb_ingr;
        private System.Windows.Forms.Label l_gross;
        private System.Windows.Forms.TextBox tb_gross;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_net;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.BindingSource bs;
    }
}