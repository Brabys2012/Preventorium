using System;
using System.Windows.Forms;

namespace Preventorium
{
    /// <summary>
    /// данный класс содержит информацию о блюде
    /// </summary>
    public partial class food : Form
    {
        private string _current_state;//содержит название текущей таблицы
        /// <summary>
        /// конструктор формы
        /// </summary>
        public food()   
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод загрузки данных из БД и отображение её в дата грид
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table(state).Tables[state];//вызываем метод создаваемый запрос к БД
            gw.DataSource = bs;
            gw.Columns[0].Visible= false;//скрываем ненужный столбец

            gw.Update();//обновляем дата грид
            gw.Show();
            this._current_state = state;
        }

         /// <summary>
        /// Добавление блюда
         /// </summary>
        private void add_new_food()
        {
            add_food food = new add_food(Program.data_module);
            food.ShowDialog();
        }
        
        /// <summary>
        /// вызов формы добавления нового блюда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAddFood_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Foods":
                       this.add_new_food();
                       break;
               }

               this.load_data_table(this._current_state);//обновляем дата грид
           }

           /// <summary>
           /// Редактирование блюд
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void bEditFood_Click(object sender, EventArgs e)
           {
                switch (this._current_state)
            {
                case "Foods":
                   add_food food = null;
                    try
                    {   
                        //вызываем форму редактирования
                        food = new add_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                        food.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выберите блюдо!");
                        }
                    break;
       
            }
                 this.load_data_table(this._current_state);//обновляем дата грид
        }
        
        /// <summary>
        /// метод переименовывает и форматирует столбцы, а так же вызывает метод загрузки данных из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void food_Load(object sender, EventArgs e)
           {
               this.load_data_table("Foods");
               gw.Columns[1].HeaderText = "Название блюда";
               gw.Columns[2].DefaultCellStyle.Format = "##.000";
               gw.Columns[2].Width = 50;
               gw.Columns[2].HeaderText = "Калории";
               gw.Columns[3].DefaultCellStyle.Format = "##.00";
               gw.Columns[3].Width = 40;
               gw.Columns[3].HeaderText = "Белки";
               gw.Columns[4].DefaultCellStyle.Format = "##.00";
               gw.Columns[4].Width = 40;
               gw.Columns[4].HeaderText = "Жиры";
               gw.Columns[5].DefaultCellStyle.Format = "##.00";
               gw.Columns[5].Width = 40;
               gw.Columns[5].HeaderText = "Углеводы";
               gw.Columns[6].DefaultCellStyle.Format = "##.00 г.";
               gw.Columns[6].Width = 90;
               gw.Columns[6].HeaderText = "Вес готового блюда";
              
           }
           
           /// <summary>
           /// редактирование по двойному клику
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {
               switch (this._current_state)
               {
                   case "Foods":
                       add_food food = null;
                       try
                       {
                           food = new add_food(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));
                           food.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;

               }
               this.load_data_table(this._current_state);//обновляем дата грид
           }

           /// <summary>
           /// удаление записи
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void bDelete_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Foods":
                       delete del = null;
                       try
                       {
                           del = new delete(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()), _current_state);
                           del.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;
               }
               this.load_data_table(this._current_state);//обновляем дата грид
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
               gw.CurrentCell = gw[1, rowIndex];
           }
           
           /// <summary>
           /// удаление с помощью контекста
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void delete_memu_strip_Click(object sender, EventArgs e)
           {
               this.bDelete_Click(sender, e);
           }

           /// <summary>
           /// редактирование с помощью контекста
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
           private void menu_strip_food_read_Click(object sender, EventArgs e)
           {
               this.bEditFood_Click(sender, e);
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
                   //если наждата 'Enter', выхываем метод редактирования
                   if (e.KeyCode == Keys.Enter)
                   {
                       int rowIndex = (gw.CurrentRow.Index - 1);

                       if (rowIndex < 0)
                       {
                           rowIndex = 0;
                       }

                       bEditFood_Click(sender,e);

                       gw.CurrentCell = gw[0, rowIndex];
                   }
                    //если нажата '+' вызываем метод добавления новой записи
                   if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                   {
                       bAddFood_Click(sender, e);
                   }
                    //если нажата 'Del' вызываем метод удаления записи
                   if (e.KeyCode == Keys.Delete)
                   {
                       bDelete_Click(sender, e);
                   }
               }
               catch
               { }

           }

       }
}
