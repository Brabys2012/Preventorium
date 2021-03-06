﻿namespace Preventorium
{
    partial class add_diet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_diet));
            this.l_diet = new System.Windows.Forms.Label();
            this.tb_numbDiet = new System.Windows.Forms.TextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.l_description = new System.Windows.Forms.Label();
            this.b_abolition = new System.Windows.Forms.Button();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // l_diet
            // 
            this.l_diet.AutoSize = true;
            this.l_diet.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_diet.Location = new System.Drawing.Point(13, 9);
            this.l_diet.Name = "l_diet";
            this.l_diet.Size = new System.Drawing.Size(98, 18);
            this.l_diet.TabIndex = 0;
            this.l_diet.Text = "Номер диеты:";
            // 
            // tb_numbDiet
            // 
            this.tb_numbDiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_numbDiet.Location = new System.Drawing.Point(16, 30);
            this.tb_numbDiet.Name = "tb_numbDiet";
            this.tb_numbDiet.Size = new System.Drawing.Size(100, 21);
            this.tb_numbDiet.TabIndex = 1;
            this.tb_numbDiet.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // b_save
            // 
            this.b_save.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(16, 226);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 4;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // l_description
            // 
            this.l_description.AutoSize = true;
            this.l_description.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_description.Location = new System.Drawing.Point(13, 53);
            this.l_description.Name = "l_description";
            this.l_description.Size = new System.Drawing.Size(118, 18);
            this.l_description.TabIndex = 2;
            this.l_description.Text = "Описание диеты:";
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_abolition.Location = new System.Drawing.Point(166, 226);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(75, 23);
            this.b_abolition.TabIndex = 5;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // tb_description
            // 
            this.tb_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_description.Location = new System.Drawing.Point(16, 74);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(225, 146);
            this.tb_description.TabIndex = 3;
            this.tb_description.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // add_diet
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(257, 255);
            this.Controls.Add(this.tb_description);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.l_description);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.tb_numbDiet);
            this.Controls.Add(this.l_diet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_diet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сведения о диете";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_diet;
        private System.Windows.Forms.TextBox tb_numbDiet;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label l_description;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.TextBox tb_description;
    }
}