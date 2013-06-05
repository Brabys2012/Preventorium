using System;
using System.Windows.Forms;

namespace Preventorium
{
    /// <summary>
    /// данный класс содержит данные о очереди для которой создается меню
    /// </summary>
    public partial class menu : Form
    {
           private string _current_state;//переменная содержит название текущей таблицы
           /// <summary>
           /// Конструктор формы
           /// </summary>
           public menu()
           {
               InitializeComponent();
           }

           /// <summary>
           /// Метод загрузки данных из БД
           /// </summary>
           /// <param name="state"></param>
           public void load_data_table(string state)
           {
               bs.DataSource = Program.data_module.get_menu("Menu").Tables[state];//вызываем метод который производит запрос в БД
               gw.DataSource = bs;//заполняем дата грид полученными данными
               gw.Columns[0].Visible = false;//скрываем столбец
               gw.Columns[1].Visible = false;//скрываем столбец
               gw.Update();//обновляем дата грид
               gw.Show();
               this._current_state = state;
           }
           /// <summary>
           /// Метод переименовывает столбцы в дата гриде
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void menu_Load(object sender, EventArgs e)
           {
               this.load_data_table("Menu");
               gw.Columns[2].HeaderText = "Номер очереди";
               gw.Columns[3].HeaderText = "Количество человек";
               gw.Columns[4].HeaderText = "Дата начала";
               gw.Columns[5].HeaderText = "Дата окончания";
           }

           /// <summary>
           /// Удаление меню
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void b_delete_Click(object sender, EventArgs e)
           {
               if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                   return;
                try
                {   
                     //вызываем форму удаления записи
                    string result = Program.add_read_module.del_record_by_id(_current_state, "ID_menu", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                }
                catch (Exception)
                {
                     MessageBox.Show("Выберите очередь!");
                }
               this.load_data_table(this._current_state);//обновдяем дата грид
           }

           /// <summary>
           /// Добавление нового меню
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void b_add_Click(object sender, EventArgs e)
           {
               add_menu menu = new add_menu(Program.data_module);
               menu.ShowDialog();
               //обновляем дата грид
               this.load_data_table(this._current_state);
           }

           /// <summary>
           /// метод вызывает контекстное меню для нужной(выбранной) строки
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void gw_MouseDown(object sender, MouseEventArgs e)
           {
               int rowIndex = gw.HitTest(e.X, e.Y).RowIndex;
               if (rowIndex == -1) return;

               gw.ClearSelection();
               gw.Rows[rowIndex].Selected = true;
               gw.CurrentCell = gw[3, rowIndex];
           }

           /// <summary>
           /// при редактировании вызываем форму меню созданного на день и передаем параметры: ид очереди и меню
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void b_edit_Click(object sender, EventArgs e)
           {
               int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
               int queue = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString());
               menu_in_day form = new menu_in_day(id, queue);
               form.ShowDialog();
           }

           /// <summary>
           /// при редактировании по двойному клику вызываем форму меню созданного на день и передаем параметры: ид очереди и меню
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               int id = Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString());
               int queue=Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString());
               menu_in_day form = new menu_in_day(id,queue);
               form.ShowDialog();
           }
           
        /// <summary>
        /// метод обрабатывает события нажатия на клавиши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
           private void gw_KeyDown(object sender, KeyEventArgs e)
           {
               try
               {
                   //если нажата 'Enter', вызываем форму редактирования
                   if (e.KeyCode == Keys.Enter)
                   {
                       int rowIndex = (gw.CurrentRow.Index - 1);

                       if (rowIndex < 0)
                       {
                           rowIndex = 0;
                       }

                       b_edit_Click(sender, e);

                       gw.CurrentCell = gw[0, rowIndex];
                   }
                   //если нажата '+' вызываем форму добавления новой записи
                   if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                   {
                       b_add_Click(sender, e);
                   }
                   //если нажата 'Del' то вызываем метод удаления записи
                   if (e.KeyCode == Keys.Delete)
                   {
                       b_delete_Click(sender, e);
                   }
               }
               catch
               { }
           }
        
       }
}
