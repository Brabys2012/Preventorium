namespace Preventorium
{
    partial class add_users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_users));
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.tb_new_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.cb_role = new System.Windows.Forms.ComboBox();
            this.tb_old_pass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(10, 72);
            this.tb_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(244, 22);
            this.tb_pass.TabIndex = 2;
            // 
            // tb_new_pass
            // 
            this.tb_new_pass.Location = new System.Drawing.Point(9, 162);
            this.tb_new_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_new_pass.Name = "tb_new_pass";
            this.tb_new_pass.Size = new System.Drawing.Size(244, 22);
            this.tb_new_pass.TabIndex = 4;
            this.tb_new_pass.TextChanged += new System.EventHandler(this.enabled);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите новый пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите логин (до 20 символов):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Укажите роль пользователя:";
            // 
            // b_save
            // 
            this.b_save.Enabled = false;
            this.b_save.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(8, 201);
            this.b_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(87, 28);
            this.b_save.TabIndex = 5;
            this.b_save.Text = "OK";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(166, 201);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(87, 28);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.close_Click);
            // 
            // cb_role
            // 
            this.cb_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_role.FormattingEnabled = true;
            this.cb_role.Location = new System.Drawing.Point(10, 24);
            this.cb_role.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_role.Name = "cb_role";
            this.cb_role.Size = new System.Drawing.Size(244, 24);
            this.cb_role.TabIndex = 1;
            this.cb_role.SelectedIndexChanged += new System.EventHandler(this.cb_role_SelectedIndexChanged);
            // 
            // tb_old_pass
            // 
            this.tb_old_pass.Location = new System.Drawing.Point(8, 117);
            this.tb_old_pass.Name = "tb_old_pass";
            this.tb_old_pass.Size = new System.Drawing.Size(245, 22);
            this.tb_old_pass.TabIndex = 3;
            this.tb_old_pass.UseSystemPasswordChar = true;
            this.tb_old_pass.TextChanged += new System.EventHandler(this.enabled);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Укажите старый пароль:";
            // 
            // add_users
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(257, 237);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_old_pass);
            this.Controls.Add(this.cb_role);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_new_pass);
            this.Controls.Add(this.tb_pass);
            this.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_users";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Назначить пароль";
            this.Load += new System.EventHandler(this.add_users_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_new_pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox cb_role;
        private System.Windows.Forms.TextBox tb_old_pass;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tb_pass;
    }
}