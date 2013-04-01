namespace Preventorium
{
    partial class add_ingr
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
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.tb_zhiri = new System.Windows.Forms.TextBox();
            this.tb_uglevod = new System.Windows.Forms.TextBox();
            this.tb_belki = new System.Windows.Forms.TextBox();
            this.tb_calories = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(14, 268);
            this.b_save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(100, 32);
            this.b_save.TabIndex = 10;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Location = new System.Drawing.Point(171, 268);
            this.b_abolition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(100, 32);
            this.b_abolition.TabIndex = 11;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // tb_zhiri
            // 
            this.tb_zhiri.Location = new System.Drawing.Point(14, 133);
            this.tb_zhiri.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_zhiri.Name = "tb_zhiri";
            this.tb_zhiri.Size = new System.Drawing.Size(257, 25);
            this.tb_zhiri.TabIndex = 5;
            this.tb_zhiri.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_uglevod
            // 
            this.tb_uglevod.Location = new System.Drawing.Point(14, 82);
            this.tb_uglevod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_uglevod.Name = "tb_uglevod";
            this.tb_uglevod.Size = new System.Drawing.Size(257, 25);
            this.tb_uglevod.TabIndex = 3;
            this.tb_uglevod.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_belki
            // 
            this.tb_belki.Location = new System.Drawing.Point(14, 184);
            this.tb_belki.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_belki.Name = "tb_belki";
            this.tb_belki.Size = new System.Drawing.Size(257, 25);
            this.tb_belki.TabIndex = 7;
            this.tb_belki.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_calories
            // 
            this.tb_calories.Location = new System.Drawing.Point(14, 235);
            this.tb_calories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_calories.Name = "tb_calories";
            this.tb_calories.Size = new System.Drawing.Size(257, 25);
            this.tb_calories.TabIndex = 9;
            this.tb_calories.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название ингредиента:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(14, 31);
            this.tb_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(257, 25);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Калории:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Углеводы:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Жиры";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Белки";
            // 
            // add_ingr
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(287, 309);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_zhiri);
            this.Controls.Add(this.tb_uglevod);
            this.Controls.Add(this.tb_calories);
            this.Controls.Add(this.tb_belki);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_ingr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сведения о ингредиенте";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.TextBox tb_zhiri;
        private System.Windows.Forms.TextBox tb_uglevod;
        private System.Windows.Forms.TextBox tb_belki;
        private System.Windows.Forms.TextBox tb_calories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}