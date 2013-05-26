namespace Preventorium
{
    partial class add_ingr_in_food
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_ingr_in_food));
            this.l_ingr = new System.Windows.Forms.Label();
            this.l_gross = new System.Windows.Forms.Label();
            this.tb_gross = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_net = new System.Windows.Forms.TextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abolition = new System.Windows.Forms.Button();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.lb_ingr = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // l_ingr
            // 
            this.l_ingr.AutoSize = true;
            this.l_ingr.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_ingr.Location = new System.Drawing.Point(13, 9);
            this.l_ingr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_ingr.Name = "l_ingr";
            this.l_ingr.Size = new System.Drawing.Size(90, 18);
            this.l_ingr.TabIndex = 0;
            this.l_ingr.Text = "Ингредиент:";
            // 
            // l_gross
            // 
            this.l_gross.AutoSize = true;
            this.l_gross.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_gross.Location = new System.Drawing.Point(309, 9);
            this.l_gross.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_gross.Name = "l_gross";
            this.l_gross.Size = new System.Drawing.Size(82, 18);
            this.l_gross.TabIndex = 2;
            this.l_gross.Text = "Вес брутто:";
            // 
            // tb_gross
            // 
            this.tb_gross.Location = new System.Drawing.Point(312, 31);
            this.tb_gross.Margin = new System.Windows.Forms.Padding(4);
            this.tb_gross.Name = "tb_gross";
            this.tb_gross.Size = new System.Drawing.Size(201, 25);
            this.tb_gross.TabIndex = 3;
            this.tb_gross.TextChanged += new System.EventHandler(this.enabled_b_save);
            this.tb_gross.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_gross_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(309, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вес нетто:";
            // 
            // tb_net
            // 
            this.tb_net.Location = new System.Drawing.Point(312, 82);
            this.tb_net.Margin = new System.Windows.Forms.Padding(4);
            this.tb_net.Name = "tb_net";
            this.tb_net.Size = new System.Drawing.Size(201, 25);
            this.tb_net.TabIndex = 5;
            this.tb_net.TextChanged += new System.EventHandler(this.enabled_b_save);
            this.tb_net.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_net_KeyPress);
            // 
            // b_save
            // 
            this.b_save.Enabled = false;
            this.b_save.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_save.Location = new System.Drawing.Point(312, 417);
            this.b_save.Margin = new System.Windows.Forms.Padding(4);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(100, 32);
            this.b_save.TabIndex = 6;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abolition
            // 
            this.b_abolition.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_abolition.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_abolition.Location = new System.Drawing.Point(420, 417);
            this.b_abolition.Margin = new System.Windows.Forms.Padding(4);
            this.b_abolition.Name = "b_abolition";
            this.b_abolition.Size = new System.Drawing.Size(100, 32);
            this.b_abolition.TabIndex = 7;
            this.b_abolition.Text = "Отмена";
            this.b_abolition.UseVisualStyleBackColor = true;
            this.b_abolition.Click += new System.EventHandler(this.b_abolition_Click);
            // 
            // lb_ingr
            // 
            this.lb_ingr.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_ingr.FormattingEnabled = true;
            this.lb_ingr.HorizontalScrollbar = true;
            this.lb_ingr.ItemHeight = 18;
            this.lb_ingr.Location = new System.Drawing.Point(16, 31);
            this.lb_ingr.Margin = new System.Windows.Forms.Padding(4);
            this.lb_ingr.Name = "lb_ingr";
            this.lb_ingr.Size = new System.Drawing.Size(288, 418);
            this.lb_ingr.TabIndex = 8;
            // 
            // add_ingr_in_food
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_abolition;
            this.ClientSize = new System.Drawing.Size(526, 456);
            this.Controls.Add(this.lb_ingr);
            this.Controls.Add(this.b_abolition);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.tb_net);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_gross);
            this.Controls.Add(this.l_gross);
            this.Controls.Add(this.l_ingr);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "add_ingr_in_food";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить ингредиенты в блюдо";
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_ingr;
        private System.Windows.Forms.Label l_gross;
        private System.Windows.Forms.TextBox tb_gross;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_net;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abolition;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ListBox lb_ingr;
    }
}