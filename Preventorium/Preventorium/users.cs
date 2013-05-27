using System;
using System.Drawing;
using System.Windows.Forms;


namespace Preventorium
{
    public partial class users : Form
    {

        /// <summary>
        /// Имя текущей таблицы.
        /// </summary>
        private const string _current_state = "Users";

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        private string login;
        /// <summary>
        /// Логин пользователя после смены логина.
        /// </summary>
        private class_person logins;
        /// <summary>
        /// Роль пользлвателя.
        /// </summary>
        class_person professia;

        /// <summary>
        /// Инициализирует экземпляр формы users.
        /// </summary>
        /// <param name="prof">Экземпляр класса, представляющий текущего пользователя.</param>
        /// <param name="login">Логин пользователя.</param>
        public users(class_person prof, string login)
        {
            InitializeComponent();
            professia = prof;
            this.login = login;
        }

        /// <summary>
        /// Происходит при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void users_Load(object sender, EventArgs e)
        {    
            // Если роль пользователя:Пользователь-диет_сестра,то форму преобразуем следующем образом:
            if (professia.role.Equals("Пользователь-диет_сестра"))
            {
                this.Size = new Size(222, 115);
                load_data_table();
                gw.Columns[1].HeaderText = "Логин";
                gw.Columns[2].Visible = false;
                gw.Columns[0].Visible = false;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.cancel_password.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator4.Visible = false;
                b_add_menu_strip.Visible = false;
                this.toolStripSeparator5.Visible = false;
                this.toolStripSeparator6.Visible = false;
                delete_menu_strip.Visible = false;
                this.b_add.Image = global::Preventorium.Properties.Resources.kwrite;
                this.b_add.Text = "Изменить пароль";
                this.b_read.Visible = false;
                read_menu_strip.Click += new System.EventHandler(this.b_add_Click);
            }

            // Если роль пользователя:Администратор-глав_врач,то форму преобразуем следующем образом:
            if (professia.role.Equals("Администратор-глав_врач"))
            {
                this.Text = "Пароли пользователей";
                load_data_table_head();
                gw.Columns[0].Visible = false;
                gw.Columns[1].HeaderText = "Пользователь";
                gw.Columns[1].Width = 100;
                gw.Columns[2].HeaderText = "Логин";
                gw.Columns[2].Width = 90;
                gw.Columns[3].Visible = false;
                //gw.Columns[3].Width = 100;
                gw.Columns[4].HeaderText = "Роль пользователя";
                gw.Columns[4].Width = 150;
            }
        }

        /// <summary>
        /// Метод который загружает форму сменить логин или пароль пользователю, с ролью пользователя: Пользователь-диет_сестра.
        /// </summary>
        /// <param name="profess"></param>
        /// <param name="id"></param>
        private void add_new_users(class_person profess, int id)
        {
            add_users ingr = new add_users(Program.data_module, profess, id);
            login = ingr.tb_pass.Text;
            ingr.ShowDialog();
        }

        /// <summary>
        /// Назначает права пользователям.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_add_Click(object sender, EventArgs e)
        {
            try
            {   //Если роль пользователя:Администратор-глав_врач,то грузим форму назначения прав пользователей(add_user)
                if (professia.role == "Администратор-глав_врач")
                {
                    // Cчитываем с дата грида значение Login
                    string post1 = Convert.ToString(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString());
                    // Если логин не пуст,то выводим сообщение,что права уже назначены:
                    if (post1 != "")
                        MessageBox.Show("Права пользователю уже назначены", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    { //если нет,то назначем права пользователю
                        string post = Convert.ToString(gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString());
                        int ID = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                        //Передаем в форму должность пользователя
                        add_users ingr = new add_users(Program.data_module, professia, post, ID);
                        ingr.ShowDialog();
                    }
                    load_data_table_head();
                }

                //Если роль пользователя: Пользователь-диет_сестра,то грузим форму назначения прав пользователей(add_user)
                if (professia.role == "Пользователь-диет_сестра")
                {
                    // Cчитываем с дата грида значение id пользователя и пераем его в консруктор формы add_user
                    int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                    this.add_new_users(professia, id);
                    logins = Program.add_read_module.get_login(id);
                    load_data_table();
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Загружает данные пользователя.
        /// </summary>
        private void load_data_table()
        {
            bs.DataSource = Program.data_module.get_data_table_password(_current_state, professia.role, logins.login).Tables[_current_state];
            gw.DataSource = bs;
            gw.Update();
            gw.Show();
        }

        /// <summary>
        /// Загружает данные администратора.
        /// </summary>
        private void load_data_table_head()
        {
            bs.DataSource = Program.data_module.get_data_table_password_head_vrach(_current_state).Tables[_current_state];
            gw.DataSource = bs;
            gw.Update();
            gw.Show();
        }

        /// <summary>
        /// Редактирвоание пароля пользователям, доступна только Администратору.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_read_Click(object sender, EventArgs e)
        {
            try
            {
                if ((professia.role == "Администратор-глав_врач"))
                {
                    string post = Convert.ToString(gw.Rows[gw.CurrentRow.Index].Cells[2].Value.ToString());
                    if (post == "")
                        MessageBox.Show("Вы не назначили права пользователю", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
                        add_users user_settings = new add_users(Program.data_module, professia, id, "MOD");
                        user_settings.ShowDialog();
                    }

                    load_data_table_head();
                }
            }
            catch { }
        }

        /// <summary>
        /// Выделение правой кнопкой мыши строку дата грида.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_MouseDown(object sender, MouseEventArgs e)
        {
            int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex == -1) return;
            gw.ClearSelection();
            gw.Rows[rowIndex].Selected = true;
            gw.CurrentCell = gw[1, rowIndex];// 3  - это номер столбца
        }

        /// <summary>
        /// Событие двойного клика на дата грид
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (professia.role == "Пользователь-диет_сестра")
            {
                b_add_Click(sender, e);
            }
            else
            {
                b_read_Click(sender, e);
            }
        }

        /// <summary>
        /// С кнопок клавиатуры открываем форму добавления,редактирвоания пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (professia.role == "Пользователь-диет_сестра")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        int rowIndex = (gw.CurrentRow.Index - 1);
                        if (rowIndex < 0)
                            rowIndex = 0;
                        b_add_Click(sender, e);
                        gw.CurrentCell = gw[0, rowIndex];
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        int rowIndex = (gw.CurrentRow.Index - 1);
                        if (rowIndex < 0)
                            rowIndex = 0;
                        b_read_Click(sender, e);
                        gw.CurrentCell = gw[0, rowIndex];
                    }
                    if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                        b_add_Click(sender, e);
                    if (e.KeyCode == Keys.Delete)
                        cancel_password_Click(sender, e);
                }
            }
            catch
            { }

        }

        /// <summary>
        /// Сброс логина и пароя пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_password_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сбросить логин и пароль?", "Сброс данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                string result = Program.add_read_module.del_record_by_password(_current_state, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите пользователя!");
            }
            this.load_data_table_head();
        }

    }
}
