namespace Preventorium
{
    partial class Menu_layout
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
            this.button1 = new System.Windows.Forms.Button();
            this.cb_ok = new System.Windows.Forms.ComboBox();
            this.Cb_diet_vrach2 = new System.Windows.Forms.ComboBox();
            this.cb_diets_vrach = new System.Windows.Forms.ComboBox();
            this.lb_head_vrach = new System.Windows.Forms.Label();
            this.lb_diet = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(11, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_ok
            // 
            this.cb_ok.FormattingEnabled = true;
            this.cb_ok.Location = new System.Drawing.Point(11, 26);
            this.cb_ok.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(260, 21);
            this.cb_ok.TabIndex = 0;
            // 
            // Cb_diet_vrach2
            // 
            this.Cb_diet_vrach2.FormattingEnabled = true;
            this.Cb_diet_vrach2.Location = new System.Drawing.Point(329, 73);
            this.Cb_diet_vrach2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Cb_diet_vrach2.Name = "Cb_diet_vrach2";
            this.Cb_diet_vrach2.Size = new System.Drawing.Size(260, 21);
            this.Cb_diet_vrach2.TabIndex = 4;
            // 
            // cb_diets_vrach
            // 
            this.cb_diets_vrach.FormattingEnabled = true;
            this.cb_diets_vrach.Location = new System.Drawing.Point(11, 68);
            this.cb_diets_vrach.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_diets_vrach.Name = "cb_diets_vrach";
            this.cb_diets_vrach.Size = new System.Drawing.Size(260, 21);
            this.cb_diets_vrach.TabIndex = 1;
            // 
            // lb_head_vrach
            // 
            this.lb_head_vrach.AutoSize = true;
            this.lb_head_vrach.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_head_vrach.Location = new System.Drawing.Point(9, 9);
            this.lb_head_vrach.Name = "lb_head_vrach";
            this.lb_head_vrach.Size = new System.Drawing.Size(186, 16);
            this.lb_head_vrach.TabIndex = 4;
            this.lb_head_vrach.Text = "Кем утверждена меню-раскладка:";
            // 
            // lb_diet
            // 
            this.lb_diet.AutoSize = true;
            this.lb_diet.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_diet.Location = new System.Drawing.Point(9, 51);
            this.lb_diet.Name = "lb_diet";
            this.lb_diet.Size = new System.Drawing.Size(166, 16);
            this.lb_diet.TabIndex = 5;
            this.lb_diet.Text = "Составитель меню-раскладки:";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(182, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu_layout
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(281, 134);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lb_diet);
            this.Controls.Add(this.lb_head_vrach);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.Cb_diet_vrach2);
            this.Controls.Add(this.cb_diets_vrach);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu_layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование меню-раскладки ";
            this.Load += new System.EventHandler(this.Menu_layout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_ok;
        private System.Windows.Forms.ComboBox Cb_diet_vrach2;
        private System.Windows.Forms.ComboBox cb_diets_vrach;
        private System.Windows.Forms.Label lb_head_vrach;
        private System.Windows.Forms.Label lb_diet;
        private System.Windows.Forms.Button button2;
    }
}