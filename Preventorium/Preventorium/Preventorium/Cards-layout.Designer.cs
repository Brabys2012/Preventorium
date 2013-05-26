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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cards_layout));
            this.bt_ok = new System.Windows.Forms.Button();
            this.gbfood = new System.Windows.Forms.GroupBox();
            this.cb_food = new System.Windows.Forms.ComboBox();
            this.cb_ok = new System.Windows.Forms.ComboBox();
            this.gbdiets = new System.Windows.Forms.GroupBox();
            this.Cb_diet_vrach2 = new System.Windows.Forms.ComboBox();
            this.cb_diets_vrach = new System.Windows.Forms.ComboBox();
            this.gbcards = new System.Windows.Forms.GroupBox();
            this.b_cancel = new System.Windows.Forms.Button();
            this.gbfood.SuspendLayout();
            this.gbdiets.SuspendLayout();
            this.gbcards.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Enabled = false;
            this.bt_ok.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_ok.Location = new System.Drawing.Point(80, 155);
            this.bt_ok.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(139, 39);
            this.bt_ok.TabIndex = 3;
            this.bt_ok.Text = "Создать";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // gbfood
            // 
            this.gbfood.Controls.Add(this.cb_food);
            this.gbfood.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbfood.Location = new System.Drawing.Point(14, 5);
            this.gbfood.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbfood.Name = "gbfood";
            this.gbfood.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbfood.Size = new System.Drawing.Size(291, 65);
            this.gbfood.TabIndex = 0;
            this.gbfood.TabStop = false;
            this.gbfood.Text = "Выберите блюдо:";
            // 
            // cb_food
            // 
            this.cb_food.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_food.FormattingEnabled = true;
            this.cb_food.Location = new System.Drawing.Point(8, 27);
            this.cb_food.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_food.Name = "cb_food";
            this.cb_food.Size = new System.Drawing.Size(260, 26);
            this.cb_food.TabIndex = 0;
            this.cb_food.SelectedIndexChanged += new System.EventHandler(this.cb_food_SelectedIndexChanged);
            // 
            // cb_ok
            // 
            this.cb_ok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ok.FormattingEnabled = true;
            this.cb_ok.Location = new System.Drawing.Point(8, 27);
            this.cb_ok.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(260, 26);
            this.cb_ok.TabIndex = 0;
            this.cb_ok.SelectedIndexChanged += new System.EventHandler(this.cb_ok_SelectedIndexChanged);
            // 
            // gbdiets
            // 
            this.gbdiets.Controls.Add(this.Cb_diet_vrach2);
            this.gbdiets.Controls.Add(this.cb_diets_vrach);
            this.gbdiets.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbdiets.Location = new System.Drawing.Point(14, 78);
            this.gbdiets.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbdiets.Name = "gbdiets";
            this.gbdiets.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbdiets.Size = new System.Drawing.Size(589, 69);
            this.gbdiets.TabIndex = 2;
            this.gbdiets.TabStop = false;
            this.gbdiets.Text = "Ответственные за диеты:";
            // 
            // Cb_diet_vrach2
            // 
            this.Cb_diet_vrach2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_diet_vrach2.FormattingEnabled = true;
            this.Cb_diet_vrach2.Location = new System.Drawing.Point(307, 27);
            this.Cb_diet_vrach2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Cb_diet_vrach2.Name = "Cb_diet_vrach2";
            this.Cb_diet_vrach2.Size = new System.Drawing.Size(260, 26);
            this.Cb_diet_vrach2.TabIndex = 1;
            this.Cb_diet_vrach2.SelectedIndexChanged += new System.EventHandler(this.Cb_diet_vrach2_SelectedIndexChanged);
            // 
            // cb_diets_vrach
            // 
            this.cb_diets_vrach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diets_vrach.FormattingEnabled = true;
            this.cb_diets_vrach.Location = new System.Drawing.Point(8, 27);
            this.cb_diets_vrach.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_diets_vrach.Name = "cb_diets_vrach";
            this.cb_diets_vrach.Size = new System.Drawing.Size(260, 26);
            this.cb_diets_vrach.TabIndex = 0;
            this.cb_diets_vrach.SelectedIndexChanged += new System.EventHandler(this.cb_diets_vrach_SelectedIndexChanged);
            // 
            // gbcards
            // 
            this.gbcards.Controls.Add(this.cb_ok);
            this.gbcards.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbcards.Location = new System.Drawing.Point(315, 5);
            this.gbcards.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbcards.Name = "gbcards";
            this.gbcards.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbcards.Size = new System.Drawing.Size(291, 65);
            this.gbcards.TabIndex = 1;
            this.gbcards.TabStop = false;
            this.gbcards.Text = "Кем утверждена карточка-раскладка:";
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_cancel.Location = new System.Drawing.Point(389, 155);
            this.b_cancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(139, 39);
            this.b_cancel.TabIndex = 4;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // Cards_layout
            // 
            this.AcceptButton = this.bt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(616, 200);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.gbcards);
            this.Controls.Add(this.gbdiets);
            this.Controls.Add(this.gbfood);
            this.Controls.Add(this.bt_ok);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "Cards_layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование карточки - раскладки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbfood.ResumeLayout(false);
            this.gbdiets.ResumeLayout(false);
            this.gbcards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbfood;
        private System.Windows.Forms.ComboBox cb_ok;
        private System.Windows.Forms.GroupBox gbdiets;
        private System.Windows.Forms.ComboBox Cb_diet_vrach2;
        private System.Windows.Forms.ComboBox cb_diets_vrach;
        private System.Windows.Forms.GroupBox gbcards;
        private System.Windows.Forms.ComboBox cb_food;
        public System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button b_cancel;
    }
}
