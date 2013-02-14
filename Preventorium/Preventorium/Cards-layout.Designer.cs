namespace Preventorium
{
    partial class Cards_layout
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
            this.bt_ok = new System.Windows.Forms.Button();
            this.gbfood = new System.Windows.Forms.GroupBox();
            this.cb_food = new System.Windows.Forms.ComboBox();
            this.cb_ok = new System.Windows.Forms.ComboBox();
            this.gbdiets = new System.Windows.Forms.GroupBox();
            this.Cb_diet_vrach2 = new System.Windows.Forms.ComboBox();
            this.cb_diets_vrach = new System.Windows.Forms.ComboBox();
            this.gbcards = new System.Windows.Forms.GroupBox();
            this.gbfood.SuspendLayout();
            this.gbdiets.SuspendLayout();
            this.gbcards.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Enabled = false;
            this.bt_ok.Location = new System.Drawing.Point(257, 37);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(156, 53);
            this.bt_ok.TabIndex = 3;
            this.bt_ok.Text = "Создать карточку-раскладку";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // gbfood
            // 
            this.gbfood.Controls.Add(this.cb_food);
            this.gbfood.Location = new System.Drawing.Point(12, 21);
            this.gbfood.Name = "gbfood";
            this.gbfood.Size = new System.Drawing.Size(218, 84);
            this.gbfood.TabIndex = 0;
            this.gbfood.TabStop = false;
            this.gbfood.Text = "Выберите блюдо:";
            // 
            // cb_food
            // 
            this.cb_food.FormattingEnabled = true;
            this.cb_food.Location = new System.Drawing.Point(6, 33);
            this.cb_food.Name = "cb_food";
            this.cb_food.Size = new System.Drawing.Size(196, 21);
            this.cb_food.TabIndex = 0;
            this.cb_food.SelectedIndexChanged += new System.EventHandler(this.cb_food_SelectedIndexChanged);
            // 
            // cb_ok
            // 
            this.cb_ok.FormattingEnabled = true;
            this.cb_ok.Location = new System.Drawing.Point(6, 19);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(196, 21);
            this.cb_ok.TabIndex = 0;
            this.cb_ok.Visible = false;
            // 
            // gbdiets
            // 
            this.gbdiets.Controls.Add(this.Cb_diet_vrach2);
            this.gbdiets.Controls.Add(this.cb_diets_vrach);
            this.gbdiets.Location = new System.Drawing.Point(12, 181);
            this.gbdiets.Name = "gbdiets";
            this.gbdiets.Size = new System.Drawing.Size(407, 58);
            this.gbdiets.TabIndex = 2;
            this.gbdiets.TabStop = false;
            this.gbdiets.Text = "Ответственные за диеты:";
            this.gbdiets.Visible = false;
            // 
            // Cb_diet_vrach2
            // 
            this.Cb_diet_vrach2.FormattingEnabled = true;
            this.Cb_diet_vrach2.Location = new System.Drawing.Point(208, 19);
            this.Cb_diet_vrach2.Name = "Cb_diet_vrach2";
            this.Cb_diet_vrach2.Size = new System.Drawing.Size(193, 21);
            this.Cb_diet_vrach2.TabIndex = 1;
            this.Cb_diet_vrach2.Visible = false;
            // 
            // cb_diets_vrach
            // 
            this.cb_diets_vrach.FormattingEnabled = true;
            this.cb_diets_vrach.Location = new System.Drawing.Point(6, 19);
            this.cb_diets_vrach.Name = "cb_diets_vrach";
            this.cb_diets_vrach.Size = new System.Drawing.Size(196, 21);
            this.cb_diets_vrach.TabIndex = 0;
            this.cb_diets_vrach.Visible = false;
            // 
            // gbcards
            // 
            this.gbcards.Controls.Add(this.cb_ok);
            this.gbcards.Location = new System.Drawing.Point(12, 121);
            this.gbcards.Name = "gbcards";
            this.gbcards.Size = new System.Drawing.Size(218, 54);
            this.gbcards.TabIndex = 1;
            this.gbcards.TabStop = false;
            this.gbcards.Text = "Кем утверждена карточка-раскладка:";
            this.gbcards.Visible = false;
            // 
            // Cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 256);
            this.Controls.Add(this.gbcards);
            this.Controls.Add(this.gbdiets);
            this.Controls.Add(this.gbfood);
            this.Controls.Add(this.bt_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Cards";
            this.Text = "Карточка - раскладка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbfood.ResumeLayout(false);
            this.gbdiets.ResumeLayout(false);
            this.gbcards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.GroupBox gbfood;
        private System.Windows.Forms.ComboBox cb_ok;
        private System.Windows.Forms.GroupBox gbdiets;
        private System.Windows.Forms.ComboBox Cb_diet_vrach2;
        private System.Windows.Forms.ComboBox cb_diets_vrach;
        private System.Windows.Forms.GroupBox gbcards;
        private System.Windows.Forms.ComboBox cb_food;
    }
}
