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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_layout));
            this.ok = new System.Windows.Forms.Button();
            this.cb_ok = new System.Windows.Forms.ComboBox();
            this.cb_diets_vrach = new System.Windows.Forms.ComboBox();
            this.lb_head_vrach = new System.Windows.Forms.Label();
            this.lb_diet = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ok.Location = new System.Drawing.Point(11, 99);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(88, 26);
            this.ok.TabIndex = 2;
            this.ok.Text = "Создать";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cb_ok
            // 
            this.cb_ok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ok.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ok.FormattingEnabled = true;
            this.cb_ok.Location = new System.Drawing.Point(12, 24);
            this.cb_ok.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(260, 24);
            this.cb_ok.TabIndex = 0;
            this.cb_ok.SelectedIndexChanged += new System.EventHandler(this.cb_ok_SelectedIndexChanged);
            // 
            // cb_diets_vrach
            // 
            this.cb_diets_vrach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_diets_vrach.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_diets_vrach.FormattingEnabled = true;
            this.cb_diets_vrach.Location = new System.Drawing.Point(12, 71);
            this.cb_diets_vrach.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cb_diets_vrach.Name = "cb_diets_vrach";
            this.cb_diets_vrach.Size = new System.Drawing.Size(260, 24);
            this.cb_diets_vrach.TabIndex = 1;
            this.cb_diets_vrach.SelectedIndexChanged += new System.EventHandler(this.cb_diets_vrach_SelectedIndexChanged);
            // 
            // lb_head_vrach
            // 
            this.lb_head_vrach.AutoSize = true;
            this.lb_head_vrach.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_head_vrach.Location = new System.Drawing.Point(9, 2);
            this.lb_head_vrach.Name = "lb_head_vrach";
            this.lb_head_vrach.Size = new System.Drawing.Size(226, 18);
            this.lb_head_vrach.TabIndex = 5;
            this.lb_head_vrach.Text = "Кем утверждена меню-раскладка:";
            // 
            // lb_diet
            // 
            this.lb_diet.AutoSize = true;
            this.lb_diet.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_diet.Location = new System.Drawing.Point(8, 49);
            this.lb_diet.Name = "lb_diet";
            this.lb_diet.Size = new System.Drawing.Size(203, 18);
            this.lb_diet.TabIndex = 6;
            this.lb_diet.Text = "Составитель меню-раскладки:";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(183, 99);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(89, 26);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(11, 149);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(260, 26);
            this.pb.Step = 1;
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Прогресс расчета 0 %";
            // 
            // Menu_layout
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(283, 184);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.lb_diet);
            this.Controls.Add(this.lb_head_vrach);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_diets_vrach);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ComboBox cb_ok;
        private System.Windows.Forms.ComboBox cb_diets_vrach;
        private System.Windows.Forms.Label lb_head_vrach;
        private System.Windows.Forms.Label lb_diet;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label label1;
    }
}