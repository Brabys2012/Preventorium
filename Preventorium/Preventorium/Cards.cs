using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;


namespace Preventorium
{
    /// <summary>
    /// данный класс содержит карты 0 раскладки назначенные блюдам, диеты, способы приготовления
    /// </summary>
    public partial class Cards : Form
    {
        private string _current_state;//содержит название таблицы

        /// <summary>
        /// Содержит номера диет
        /// </summary>
        public class_card[] _card_list;
        /// <summary>
        /// Содержит метод приготовления
        /// </summary>
        public class_card[] _card_method;

        /// <summary>
        /// конструктор формы
        /// </summary>
        public Cards()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод скрывает ненужные столбцы, заполняет дата грид данными и вызывает метод который создает запрос к БД
        /// </summary>
        /// <param name="state"></param>
        public void load_data_table(string state)
        {
            bs.DataSource = Program.data_module.get_data_table_cards("Cards").Tables[state];
            gw.DataSource = bs;
            gw.Columns[0].Visible = false;
            gw.Columns[3].Visible = false;
            gw.Columns[5].Visible = false;
            gw.Update();//обновляем дата грид
            gw.Show();
            this._current_state = state;
        }

        /// <summary>
        /// добавление карты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_add_Click(object sender, EventArgs e)
        {
            add_cards card = new add_cards(Program.data_module);
            card.ShowDialog();
            this.load_data_table(this._current_state);
        }

        /// <summary>
        /// редактирование карты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_edit_Click(object sender, EventArgs e)
        {
            add_cards card = null;
            try
            {
                 card = new add_cards(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()),
                                            gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                            Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                 card.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите карту!");
            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }

        /// <summary>
        /// метод форматирует, переименовывает столбцы и вызывает метод заполнения дата грида
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void card_Load(object sender, EventArgs e)
        {
            this.load_data_table("Cards");
            gw.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gw.Columns[1].HeaderText = "Блюдо";
            gw.Columns[2].DefaultCellStyle.Format = "0.00 руб.";
            gw.Columns[2].HeaderText = "Ориентировочная стоимость";
            gw.Columns[4].HeaderText = "Номер карты";
        }

        /// <summary>
        /// редактирование по двойному клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_cards card = null;
            try
            {
                card = new add_cards(Program.data_module, Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()),
                                            gw.Rows[gw.CurrentRow.Index].Cells[1].Value.ToString(),
                                            Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[5].Value.ToString()));
                card.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите карту!");
            }
            this.load_data_table(this._current_state);//обновляем дата грид
        }
        
        /// <summary>
        /// Удаление карты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_delete_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
             try
             {
                 string result = Program.add_read_module.del_record_by_id(_current_state, "Id_Cards", Convert.ToInt32(gw.Rows[gw.CurrentRow.Index].Cells[0].Value.ToString()));    
             }
             catch (Exception)
             {
                 MessageBox.Show("Выберите карту!");
             }
            this.load_data_table(this._current_state);//обновление дата грид
        }

        /// <summary>
        /// получаем способ приготовления и номер диеты по номеру карты
        /// </summary>
        /// <returns></returns>
        public class_card[] get_card_list()
        {
            class_card[] card = new class_card[512];
            string cell = gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString();
            string query = "select C.Id_Cards, C.Number_Card,  D.NumOfDiet from Cards C ";
            query += "join Food_In_Diets FIN on C.Id_Cards = FIN.Id_Cards ";
            query += "join Diets D on D.ID_Diets = FIN.ID_Diets ";
            query += "where Number_Card = '" + cell + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                
                  int i = 0;
                  while (rd.Read())
                {
                        i = i + 1;
                        card[i] = new class_card();
                        card[i].result = "OK";                       
                       


                        if (rd.IsDBNull(2))
                        {
                            card[i].diet_numb = "";
                        }
                        else
                        {
                            card[i].diet_numb = rd.GetString(2);
                        }                        

                    }
                            
                rd.Close();
                rd.Dispose();
                com.Dispose();
            
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;

            }  return card;

         }
        /// <summary>
        /// Возвращает метод приготовления
        /// </summary>
        /// <returns></returns>
        public class_card[] get_method_list()
        {
            class_card[] card = new class_card[512];
            string cell = gw.Rows[gw.CurrentRow.Index].Cells[4].Value.ToString();
            string query = "select Method_of_cooking from Cards ";
             query += "where Number_Card = '" + cell + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();

                int i = 0;
                while (rd.Read())
                {
                    i = i + 1;
                    card[i] = new class_card();
                    card[i].result = "OK";



                    if (rd.IsDBNull(0))
                    {
                        card[i].method = "";
                    }
                    else
                    {
                        card[i].method = rd.GetString(0);
                    }

                }

                rd.Close();
                rd.Dispose();
                com.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Data);
                return null;

            } return card;

        }

        /// <summary>
        /// при выборе карты заполняем текст боксы методом приготовления и номерами диет содержащихся в карте - раскладке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void gw_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          this._card_list = this.get_card_list();//вызываем метод получения метода приготовления и номеров диет
          this._card_method = this.get_method_list();
          tb_desc.Text = "";

          tb_method.Text = _card_method[1].method;
          
            if (this._card_list != null)//если метод вернул не пустое значение, то очищаем лист бокс
          {
              this.lb_diet.Items.Clear();
          }
                      
         
         
            for (int i = 1; i < this._card_list.Count(); i++)//заполняем текст боксы данными полученными в запросе
            {
                if (this._card_list[i] != null)
                {

                    lb_diet.Items.Add(_card_list[i].diet_numb);                  
                }
                else
                {                   
                    
                    break;
                }
            }
        }

        /// <summary>
        /// редактирование по двойному клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_DoubleClick(object sender, EventArgs e)
        {
            this.b_edit_Click(sender, e);
        }

        /// <summary>
        /// метод вызывает контекстное меню для выбранной строки
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
        /// из выбранной в лист боксе диеты передаем в текст бокс расшифровку диеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_diet_SelectedIndexChanged(object sender, EventArgs e)
        {
            class_diet diet = new class_diet();
            string query = "select Description from Diets "
                         + "where NumOfDiet = '" + lb_diet.Text + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    if (rd.IsDBNull(0))
                    {
                        diet.description = "";
                        tb_desc.Text = diet.description;
                    }
                    else
                    {
                        diet.description = rd.GetString(0);
                        tb_desc.Text = diet.description;
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR_" + ex.Data + " " + ex.Message);
            }
        }

        /// <summary>
        /// метод обрабатывает нажатия на клавиши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gw_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //если нажата 'Enter', то редактирование
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
                //Если нажатие '+', то добавление новой записи
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    b_add_Click(sender, e);
                }
                //если нажатие 'Del', то удаление записи
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

