namespace Preventorium
{
    partial class add_menu
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
            this.cb_numb_queue = new System.Windows.Forms.ComboBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите очередь:";
            // 
            // cb_numb_queue
            // 
            this.cb_numb_queue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_numb_queue.FormattingEnabled = true;
            this.cb_numb_queue.Location = new System.Drawing.Point(16, 31);
            this.cb_numb_queue.Margin = new System.Windows.Forms.Padding(4);
            this.cb_numb_queue.Name = "cb_numb_queue";
            this.cb_numb_queue.Size = new System.Drawing.Size(207, 26);
            this.cb_numb_queue.TabIndex = 1;
            this.cb_numb_queue.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // b_save
            // 
            this.b_save.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(16, 65);
            this.b_save.Margin = new System.Windows.Forms.Padding(4);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(100, 32);
            this.b_save.TabIndex = 2;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_abolition.Location = new System.Drawing.Point(123, 65);
            this.b_abolition.Margin = new System.Windows.Forms.Padding(4);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(100, 32);
            this.b_abolition.TabIndex = 3;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // add_menu
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(232, 104);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.cb_numb_queue);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_menu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_numb_queue;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
    }
}