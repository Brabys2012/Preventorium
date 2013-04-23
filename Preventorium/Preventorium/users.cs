using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class users : Form
    {
        private string _current_state;
        class_person professia;

        public users(class_person prof)
        {
            InitializeComponent();
            professia = prof;
        }

        private void users_Load(object sender, EventArgs e)
        {
            if (professia.post == "Пользователь-диет_сестра")
            {
                this.Size = new Size(222, 115);
                load_data_table("Users", professia.post);
                gw.Columns[1].HeaderText = "Логин";
                gw.Columns[2].HeaderText = "Пароль";
                gw.Columns[0].Visible = false;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.b_delete.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator4.Visible = false;
                this.b_add.Image = global::Preventorium.Properties.Resources._50px_Exquisite_kwrite;
                this.b_add.Text = "Изменить пароль";
                this.b_read.Visible = false;
            }
            if (professia.post == "Администратор-глав_врач")
            {
                this.Text = "Пароли пользователей";
                load_data_table_head("Users");
                gw.Columns[0].Visible = false;
                gw.Columns[1].HeaderText = "Пользователь";
                gw.Columns[1].Width = 100;
                gw.Columns[2].HeaderText = "Логин";
               gw.Columns[2].Width = 90;
                gw.Columns[3].HeaderText = "Пароль";
                gw.Columns[3].Width = 100;
                gw.Columns[4].HeaderText = "Роль пользователя";
                gw.Columns[4].Width = 150;
            }
       }
        public void load_data_table(string state, string prof)
        {
            bs.DataSource = Program.data_module.get_data_table_password(state, prof).Tables[state];
            gw.DataSource = bs;
            gw.Update();
            gw.Show();
            this._current_state = state;
        }
        public void load_data_table_head(string state)
        {
            bs.DataSource = Program.data_module.get_data_table_password_head_vrach(state).Tables[state];
            gw.DataSource = bs;
            gw.Update();
            gw.Show();
            this._current_state = state;
        }
      
        private void add_new_users(class_person profess,int id)
        {
            add_users ingr = new add_users(Program.data_module, profess,id);
            ingr.ShowDialog();
        }
        private void b_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (professia.post == "Администратор-глав_врач")
                {
                    switch (this._current_state)
                    {
                        case "Users":
                          add_users ingr = new add_users(Program.data_module, professia);
                          ingr.ShowDialog();
                            break;
                    }

                    load_data_table_head("Users");
                }

                if (professia.post == "Пользователь-диет_сестра")
                {
                    switch (this._current_state)
                    {
                        case "Users":
                            int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                            this.add_new_users(professia, id);
                            break;
                    }
                    load_data_table("Users", professia.post);

                }
            }
            catch
            { }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            switch (this._current_state)
            {
                case "Users":
                    delete del = null;
                    try
                    {
                        del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
                        del.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите пользователя");
                    }
                    break;
            }
            if (professia.post == "Администратор-глав_врач")
            {
                switch (this._current_state)
                {
                    case "Users":
                        load_data_table_head("Users");
                        break;
                }
            }
                if (professia.post == "Пользователь-диет_сестра")
                {
                    switch (this._current_state)
                    {
                        case "Users":
                            load_data_table("Users", professia.post);
                            break;
                    }
                }

            }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((professia.post == "Администратор-глав_врач"))
                {
                    switch (this._current_state)
                    {
                        case "Users":
                            int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                            add_users user_settings = new add_users(Program.data_module, professia, id, "MOD");
                            user_settings.ShowDialog();
                            break;
                    }
                    load_data_table_head("Users");
                }
            }
            catch { }
        }

       
       
    }
}
