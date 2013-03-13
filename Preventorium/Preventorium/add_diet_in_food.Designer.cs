namespace Preventorium
{
    partial class add_diet_in_food
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_food_name = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_diet_numb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_card_numb = new System.Windows.Forms.ComboBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название блюда:";
            // 
            // cb_food_name
            // 
            this.cb_food_name.FormattingEnabled = true;
            this.cb_food_name.Location = new System.Drawing.Point(12, 26);
            this.cb_food_name.Name = "cb_food_name";
            this.cb_food_name.Size = new System.Drawing.Size(171, 21);
            this.cb_food_name.TabIndex = 1;
            this.cb_food_name.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Номер диеты:";
            // 
            // cb_diet_numb
            // 
            this.cb_diet_numb.FormattingEnabled = true;
            this.cb_diet_numb.Location = new System.Drawing.Point(12, 66);
            this.cb_diet_numb.Name = "cb_diet_numb";
            this.cb_diet_numb.Size = new System.Drawing.Size(171, 21);
            this.cb_diet_numb.TabIndex = 3;
            this.cb_diet_numb.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номер карты:";
            // 
            // cb_card_numb
            // 
            this.cb_card_numb.FormattingEnabled = true;
            this.cb_card_numb.Location = new System.Drawing.Point(12, 106);
            this.cb_card_numb.Name = "cb_card_numb";
            this.cb_card_numb.Size = new System.Drawing.Size(171, 21);
            this.cb_card_numb.TabIndex = 5;
            this.cb_card_numb.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(12, 133);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 6;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(108, 133);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 7;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // add_diet_in_food
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(190, 164);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.cb_card_numb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_diet_numb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_food_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_diet_in_food";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диеты для блюда";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_food_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_diet_numb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_card_numb;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_cancel;
    }
}