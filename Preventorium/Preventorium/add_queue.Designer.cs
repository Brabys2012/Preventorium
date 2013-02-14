namespace Preventorium
{
    partial class add_queue
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_end = new System.Windows.Forms.DateTimePicker();
            this.tb_start = new System.Windows.Forms.DateTimePicker();
            this.tb_mens = new System.Windows.Forms.TextBox();
            this.tb_season = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.p_status = new System.Windows.Forms.StatusStrip();
            this.l_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.p_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_end);
            this.groupBox1.Controls.Add(this.tb_start);
            this.groupBox1.Controls.Add(this.tb_mens);
            this.groupBox1.Controls.Add(this.tb_season);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сведения о очереди:";
            // 
            // tb_end
            // 
            this.tb_end.Location = new System.Drawing.Point(130, 83);
            this.tb_end.Name = "tb_end";
            this.tb_end.Size = new System.Drawing.Size(138, 20);
            this.tb_end.TabIndex = 7;
            this.tb_end.ValueChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(130, 44);
            this.tb_start.Name = "tb_start";
            this.tb_start.Size = new System.Drawing.Size(138, 20);
            this.tb_start.TabIndex = 5;
            this.tb_start.ValueChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_mens
            // 
            this.tb_mens.Location = new System.Drawing.Point(9, 83);
            this.tb_mens.Name = "tb_mens";
            this.tb_mens.Size = new System.Drawing.Size(113, 20);
            this.tb_mens.TabIndex = 3;
            this.tb_mens.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // tb_season
            // 
            this.tb_season.Location = new System.Drawing.Point(9, 44);
            this.tb_season.Name = "tb_season";
            this.tb_season.Size = new System.Drawing.Size(113, 20);
            this.tb_season.TabIndex = 1;
            this.tb_season.TextChanged += new System.EventHandler(this.enabled_b_save);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата окончания:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата начала:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество человек:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сезон:";
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(28, 136);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 1;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Location = new System.Drawing.Point(162, 136);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(75, 23);
            this.b_abolition.TabIndex = 2;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // p_status
            // 
            this.p_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l_status});
            this.p_status.Location = new System.Drawing.Point(0, 165);
            this.p_status.Name = "p_status";
            this.p_status.Size = new System.Drawing.Size(301, 22);
            this.p_status.TabIndex = 4;
            this.p_status.Text = "statusStrip1";
            // 
            // l_status
            // 
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(0, 17);
            // 
            // add_queue
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(301, 187);
            this.Controls.Add(this.p_status);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "add_queue";
            this.Text = "Добавить очередь";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.p_status.ResumeLayout(false);
            this.p_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker tb_end;
        private System.Windows.Forms.DateTimePicker tb_start;
        private System.Windows.Forms.TextBox tb_mens;
        private System.Windows.Forms.TextBox tb_season;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.StatusStrip p_status;
        private System.Windows.Forms.ToolStripStatusLabel l_status;
    }
}