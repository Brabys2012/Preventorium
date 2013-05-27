namespace Preventorium
{
    partial class db_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(db_settings));
            this.b_abolition = new System.Windows.Forms.Button();
            this.b_apply = new System.Windows.Forms.Button();
            this.cb_win_auth = new System.Windows.Forms.CheckBox();
            this.t_pass = new System.Windows.Forms.TextBox();
            this.t_user = new System.Windows.Forms.TextBox();
            this.t_server = new System.Windows.Forms.TextBox();
            this.lPass = new System.Windows.Forms.Label();
            this.tSchema = new System.Windows.Forms.Label();
            this.lUser = new System.Windows.Forms.Label();
            this.lServer = new System.Windows.Forms.Label();
            this.t_schema = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_abolition.Location = new System.Drawing.Point(176, 141);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(80, 23);
            this.b_abolition.TabIndex = 10;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // b_apply
            // 
            this.b_apply.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_apply.Location = new System.Drawing.Point(12, 141);
            this.b_apply.Name = "b_apply";
            this.b_apply.Size = new System.Drawing.Size(80, 23);
            this.b_apply.TabIndex = 9;
            this.b_apply.Text = "Применить";
            this.b_apply.UseVisualStyleBackColor = true;
            this.b_apply.Click += new System.EventHandler(this.b_apply_Click);
            // 
            // cb_win_auth
            // 
            this.cb_win_auth.AutoSize = true;
            this.cb_win_auth.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_win_auth.Location = new System.Drawing.Point(15, 58);
            this.cb_win_auth.Name = "cb_win_auth";
            this.cb_win_auth.Size = new System.Drawing.Size(204, 20);
            this.cb_win_auth.TabIndex = 4;
            this.cb_win_auth.Text = "Проверка подлинности Windows";
            this.cb_win_auth.UseVisualStyleBackColor = true;
            this.cb_win_auth.CheckedChanged += new System.EventHandler(this.cb_win_auth_CheckedChanged);
            // 
            // t_pass
            // 
            this.t_pass.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_pass.Location = new System.Drawing.Point(123, 107);
            this.t_pass.Multiline = true;
            this.t_pass.Name = "t_pass";
            this.t_pass.Size = new System.Drawing.Size(133, 20);
            this.t_pass.TabIndex = 1;
            this.t_pass.TextChanged += new System.EventHandler(this.off_connect);
            // 
            // t_user
            // 
            this.t_user.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_user.Location = new System.Drawing.Point(123, 79);
            this.t_user.Name = "t_user";
            this.t_user.Size = new System.Drawing.Size(133, 22);
            this.t_user.TabIndex = 1;
            this.t_user.TextChanged += new System.EventHandler(this.off_connect);
            // 
            // t_server
            // 
            this.t_server.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_server.Location = new System.Drawing.Point(123, 6);
            this.t_server.Multiline = true;
            this.t_server.Name = "t_server";
            this.t_server.Size = new System.Drawing.Size(133, 20);
            this.t_server.TabIndex = 2;
            this.t_server.TextChanged += new System.EventHandler(this.off_connect);
            // 
            // lPass
            // 
            this.lPass.AutoSize = true;
            this.lPass.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPass.Location = new System.Drawing.Point(12, 110);
            this.lPass.Name = "lPass";
            this.lPass.Size = new System.Drawing.Size(52, 16);
            this.lPass.TabIndex = 7;
            this.lPass.Text = "Пароль:";
            // 
            // tSchema
            // 
            this.tSchema.AutoSize = true;
            this.tSchema.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tSchema.Location = new System.Drawing.Point(12, 35);
            this.tSchema.Name = "tSchema";
            this.tSchema.Size = new System.Drawing.Size(108, 16);
            this.tSchema.TabIndex = 2;
            this.tSchema.Text = "Имя базы данных:";
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lUser.Location = new System.Drawing.Point(12, 84);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(87, 16);
            this.lUser.TabIndex = 5;
            this.lUser.Text = "Пользователь:";
            // 
            // lServer
            // 
            this.lServer.AutoSize = true;
            this.lServer.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lServer.Location = new System.Drawing.Point(12, 9);
            this.lServer.Name = "lServer";
            this.lServer.Size = new System.Drawing.Size(51, 16);
            this.lServer.TabIndex = 0;
            this.lServer.Text = "Cервер:";
            // 
            // t_schema
            // 
            this.t_schema.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_schema.Location = new System.Drawing.Point(123, 32);
            this.t_schema.Multiline = true;
            this.t_schema.Name = "t_schema";
            this.t_schema.Size = new System.Drawing.Size(133, 20);
            this.t_schema.TabIndex = 1;
            this.t_schema.TextChanged += new System.EventHandler(this.off_connect);
            // 
            // db_settings
            // 
            this.AcceptButton = this.b_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(270, 173);
            this.Controls.Add(this.t_schema);
            this.Controls.Add(this.t_pass);
            this.Controls.Add(this.t_user);
            this.Controls.Add(this.t_server);
            this.Controls.Add(this.lPass);
            this.Controls.Add(this.tSchema);
            this.Controls.Add(this.lUser);
            this.Controls.Add(this.lServer);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.b_apply);
            this.Controls.Add(this.cb_win_auth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "db_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры подключения";
            this.Load += new System.EventHandler(this.db_settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.Button b_apply;
        private System.Windows.Forms.CheckBox cb_win_auth;
        private System.Windows.Forms.TextBox t_pass;
        private System.Windows.Forms.TextBox t_user;
        private System.Windows.Forms.TextBox t_server;
        private System.Windows.Forms.Label lPass;
        private System.Windows.Forms.Label tSchema;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.Label lServer;
        private System.Windows.Forms.TextBox t_schema;
    }
}