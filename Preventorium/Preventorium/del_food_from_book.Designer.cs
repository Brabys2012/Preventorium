namespace Preventorium
{
    partial class del_food_from_book
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
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(122, 59);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_apply
            // 
            this.b_apply.Location = new System.Drawing.Point(15, 59);
            this.b_apply.Name = "b_apply";
            this.b_apply.Size = new System.Drawing.Size(75, 23);
            this.b_apply.TabIndex = 1;
            this.b_apply.Text = "ОК";
            this.b_apply.UseVisualStyleBackColor = true;
            this.b_apply.Click += new System.EventHandler(this.b_apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "    Вы действительно\r\nхотите удалить запись ?";
            // 
            // del_food_from_book
            // 
            this.AcceptButton = this.b_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(211, 95);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_apply);
            this.Controls.Add(this.label1);
            this.Name = "del_food_from_book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_apply;
        private System.Windows.Forms.Label label1;
    }
}