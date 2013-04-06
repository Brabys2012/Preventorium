using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;

namespace Preventorium
{
    public partial class food_in_menu : Form
    {
       
           private string _current_state;
           private string _id;
           private int menu_id;
           private int AddDayID;
           private int queue_id;
        #region
           /* public class_ingr_in_food[] _ves;
        public class_ingr_in_food[] _ves2;
        public class_ingr_in_food[] _ves3;
        public class_ingr_in_food[] _ves4;
        public class_ingr_in_food[] _ves5;
        public class_ingr_in_food[] _ves6;
        public class_ingr_in_food[] _ves7;
        public class_ingr_in_food[] _ves8;
        public class_ingr_in_food[] _obshves;
          

        public class_food[] _food;
        public class_queue _count_serv;*/

        #endregion
           public class_menu_in_food[] _food_list_breakfast;
           public class_menu_in_food[] _menu_in_day;
           public class_menu_in_food[] _food_list_dinner;
           public class_menu_in_food[] _food_list_supper;
           public class_ingridients[] _ingr_list;
           public class_ingridients[] _ingr_list1;
           public class_food[] _food_list_breakfast1;
           public class_food[] _food_list_breakfast2;
           public class_food[] _food_list_breakfast3;
           public class_food[] _food_list_breakfast4;
           public class_food[] _food_list_breakfast5;
           public class_food[] _food_list_breakfast6;
           public class_food[] _food_list_breakfast7;
           public class_food[] _food_list_breakfast8;
           public class_food[] _food_list_dinner1;
           public class_food[] _food_list_dinner2;
           public class_food[] _food_list_dinner3;
           public class_food[] _food_list_dinner4;
           public class_food[] _food_list_dinner5;
           public class_food[] _food_list_dinner6;
           public class_food[] _food_list_dinner7;
           public class_food[] _food_list_dinner8;
           public class_food[] _food_list_supper1;
           public class_food[] _food_list_supper2;
           public class_food[] _food_list_supper3;
           public class_food[] _food_list_supper4;
           public class_food[] _food_list_supper5;
           public class_food[] _food_list_supper6;
           public class_food[] _food_list_supper7;
           public class_food[] _food_list_supper8;

           private readonly string File = @"\Reports\Меню на день.docx";
          
        

           public food_in_menu(int id, int day_id,int queue)
        
           {
            AddDayID = day_id;
            menu_id = id;
            queue_id = queue;
            InitializeComponent();
           }

           public void load_data_table1(string state)
           {
               bs.DataSource = Program.data_module.get_data_table_breakfast(state, AddDayID).Tables[state];
               gw_breakfast.DataSource = bs;
               gw_breakfast.Columns[0].Visible = false;
               gw_breakfast.Columns[1].Visible = false;
               gw_breakfast.Columns[2].Visible = false;
               this.gw_breakfast.Update();
               this.gw_breakfast.Show();
               this._current_state = state;
           }

           public void load_data_table2(string state)
           {
               bs_dinner.DataSource = Program.data_module.get_data_table_dinner("Food_in_menu", AddDayID).Tables[state];
               gw_dinner.DataSource = this.bs_dinner;
               gw_dinner.Columns[0].Visible = false;
               gw_dinner.Columns[1].Visible = false;
               gw_dinner.Columns[2].Visible = false;
               gw_dinner.Update();
               gw_dinner.Show();
               this._current_state = state;
           }

           public void load_data_table3(string state)
           {
               bs_supper.DataSource = Program.data_module.get_data_table_supper("Food_in_menu", AddDayID).Tables[state];
               gw_supper.DataSource = bs_supper;
               gw_supper.Columns[0].Visible = false;
               gw_supper.Columns[1].Visible = false;
               gw_supper.Columns[2].Visible = false;
               gw_supper.Update();
               gw_supper.Show();
               this._current_state = state;
           }

           private void food_in_menu_Load(object sender, EventArgs e)
           {
               this.load_data_table1("Food_in_menu");
               gw_breakfast.Columns[3].HeaderText = "Блюдо";
               gw_breakfast.Columns[4].HeaderText = "Количество порций";
               gw_breakfast.Columns[4].Width = 80;
               this.load_data_table2("Food_in_menu");
               gw_dinner.Columns[3].HeaderText = "Блюдо";
               gw_dinner.Columns[4].HeaderText = "Количество порций";
               gw_dinner.Columns[4].Width = 80;
               this.load_data_table3("Food_in_menu");
               gw_supper.Columns[3].HeaderText = "Блюдо";
               gw_supper.Columns[4].HeaderText = "Количество порций";
               gw_supper.Columns[4].Width = 110;
           }

           //Удаление блюда
           private void del_breakfast_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Food_in_menu":
                       del_food_from_menu del = null;
                       try
                       {
                           del = new del_food_from_menu(Program.data_module, Convert.ToInt32(gw_breakfast.Rows[gw_breakfast.CurrentRow.Index].Cells[0].Value.ToString()), gw_breakfast.Rows[gw_breakfast.CurrentRow.Index].Cells[2].Value.ToString());
                           del.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;
               }
               this.load_data_table1(this._current_state);
           }

           /// <summary>
           /// Добавление блюда
           /// </summary>
           private void add_new_food_in_menu(string serve_time, int menu_id, int day_id)
           {
               add_food_in_menu food = new add_food_in_menu(Program.data_module, serve_time, menu_id, day_id);
               food.ShowDialog();
           }

           private void add_breakfast_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Food_in_menu":
                       string serve_time = "завтрак";
                       this.add_new_food_in_menu(serve_time, menu_id, AddDayID);

                       break;
               }

               this.load_data_table1(this._current_state);
           }

           private void b_del_break_Click(object sender, EventArgs e)
           {
               this.del_breakfast_Click(sender, e);
           }

           private void gw_MouseDown_breakfast(object sender, MouseEventArgs e)
           {
               int rowIndex = gw_breakfast.HitTest(e.X, e.Y).RowIndex;
               if (rowIndex == -1) return;

               gw_breakfast.ClearSelection();
               gw_breakfast.Rows[rowIndex].Selected = true;
               gw_breakfast.CurrentCell = gw_breakfast[1, rowIndex];
           }

           private void add_dinner_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Food_in_menu":
                       string serve_time = "обед";
                       this.add_new_food_in_menu(serve_time, menu_id, AddDayID);

                       break;
               }
               this.load_data_table2(this._current_state);
           }

           private void add_supper_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Food_in_menu":
                       string serve_time = "ужин";
                       this.add_new_food_in_menu(serve_time, menu_id, AddDayID);

                       break;
               }
               this.load_data_table3(this._current_state);

           }

           private void del_dinner_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Food_in_menu":
                       del_food_from_menu del = null;
                       try
                       {
                           this.load_data_table2(this._current_state);
                           del = new del_food_from_menu(Program.data_module, Convert.ToInt32(gw_dinner.Rows[gw_dinner.CurrentRow.Index].Cells[0].Value.ToString()), gw_dinner.Rows[gw_dinner.CurrentRow.Index].Cells[2].Value.ToString());
                           del.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;
               }
               this.load_data_table2(this._current_state);
           }

           private void del_supper_Click(object sender, EventArgs e)
           {
               switch (this._current_state)
               {
                   case "Food_in_menu":
                       del_food_from_menu del = null;
                       try
                       {
                           this.load_data_table3(this._current_state);
                           del = new del_food_from_menu(Program.data_module, Convert.ToInt32(gw_supper.Rows[gw_supper.CurrentRow.Index].Cells[0].Value.ToString()), gw_supper.Rows[gw_supper.CurrentRow.Index].Cells[2].Value.ToString());
                           del.ShowDialog();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show("Выберите блюдо!");
                       }
                       break;
               }
               this.load_data_table3(this._current_state);
           }

           private void Menu_in_day_Click(object sender, EventArgs e)
           {

               this._food_list_breakfast = this.food_breakfast();
               this._menu_in_day = this.menu_in_day();
               this._food_list_dinner = this.food_dinner();
               this._food_list_supper = this.food_supper();
               this._food_list_breakfast1 = this.food_breakfast1();
               this._food_list_breakfast2 = this.food_breakfast2();
               this._food_list_breakfast3 = this.food_breakfast3();
               this._food_list_breakfast4 = this.food_breakfast4();
               this._food_list_breakfast5 = this.food_breakfast5();
               this._food_list_breakfast6 = this.food_breakfast6();
               this._food_list_breakfast7 = this.food_breakfast7();
               this._food_list_breakfast8 = this.food_breakfast8();
               this._food_list_dinner1 = this.food_dinner1();
               this._food_list_dinner2 = this.food_dinner2();
               this._food_list_dinner3 = this.food_dinner3();
               this._food_list_dinner4 = this.food_dinner4();
               this._food_list_dinner5 = this.food_dinner5();
               this._food_list_dinner6 = this.food_dinner6();
               this._food_list_dinner7 = this.food_dinner7();
               this._food_list_dinner8 = this.food_dinner8();
               this._food_list_supper1 = this.food_supper1();
               this._food_list_supper2 = this.food_supper2();
               this._food_list_supper3 = this.food_supper3();
               this._food_list_supper4 = this.food_supper4();
               this._food_list_supper5 = this.food_supper5();
               this._food_list_supper6 = this.food_supper6();
               this._food_list_supper7 = this.food_supper7();
               this._food_list_supper8 = this.food_supper8();

               report();
           
           }
         
        public void report()
           {

               var App = new word.Application();


               var word = App.Documents.Add(Application.StartupPath + File);


               if (_menu_in_day == null)
               {

                   var name2 = "";

                   word1("[Date]", name2, word);
               }
               else
               {

                   if (this._menu_in_day[1] != null)
                   {
                       var name2 = _menu_in_day[1].service;

                       word1("[Date]", name2, word);

                   }

                   if (_food_list_breakfast1 == null)
                   {

                       var name2 = "";
                       word1("[Блюдо1]", name2, word);
                       word1("[Вес1]", name2, word);
                       word1("[Вес]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_breakfast1[1] != null)
                       {
                           var name2 = _food_list_breakfast1[1].name;
                           var ves = _food_list_breakfast1[1].weight;
                           var vess = "Вес:";
                           word1("[Блюдо1]", name2, word);
                           word1("[Вес1]", ves, word);
                           word1("[Вес]", vess, word);

                       }
                   }
                        if (_food_list_breakfast2 == null)
                       {
                           var name2 = "";
                          
                           word1("[Блюдо2]", name2, word);
                           word1("[Вес2]", name2, word);
                           word1("[Весc1]", name2, word);
                          
                       }
                       else
                       {

                           if (this._food_list_breakfast1[1] != null)
                           {
                               var name2 = _food_list_breakfast2[1].name;
                               var ves = _food_list_breakfast2[1].weight;
                               word1("[Блюдо2]", name2, word);
                               word1("[Вес2]", ves, word);
                               var vess = "Вес:";
                               word1("[Весc1]", vess, word);
                           }

                       }

                       if (_food_list_breakfast3 == null)
                       {
                           var name2 = "";
                          word1("[Блюдо3]", name2, word);
                          word1("[Вес3]", name2, word);
                          word1("[Весc2]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_breakfast3[1] != null)
                           {
                               var name2 = _food_list_breakfast3[1].name;
                               var ves = _food_list_breakfast3[1].weight;
                               word1("[Вес3]", ves, word);
                               word1("[Блюдо3]", name2, word);
                               var vess = "Вес:";
                               word1("[Весc2]", vess, word);
                           }

                       }
                       if (_food_list_breakfast4 == null)
                       {

                           var name2 = "";
                           word1("[Вес4]", name2, word);
                           word1("[Блюдо4]", name2, word);
                           word1("[Весc3]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_breakfast4[1] != null)
                           {
                               var name2 = _food_list_breakfast4[1].name;
                               var ves = _food_list_breakfast4[1].weight;
                               word1("[Блюдо4]", name2, word);
                               word1("[Вес4]", ves, word);
                               var vess = "Вес:";
                               word1("[Весc3]", vess, word);
                           }

                       }
                       if (_food_list_breakfast5 == null)
                       {

                           var name2 = "";

                           word1("[Блюдо5]", name2, word);
                           word1("[Вес5]", name2, word);
                           word1("[Весc4]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_breakfast5[1] != null)
                           {
                               var name2 = _food_list_breakfast5[1].name;
                               var ves = _food_list_breakfast5[1].weight;

                               word1("[Блюдо5]", name2, word);
                               var vess = "Вес:";
                               word1("[Вес5]", ves, word);
                               word1("[Весc4]", vess, word);
                           }

                       }
                       if (_food_list_breakfast6 == null)
                       {
                           var name2 = "";
                           word1("[Вес6]", name2, word);
                           word1("[Весc5]", name2, word);
                           word1("[Блюдо6]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_breakfast6[1] != null)
                           {
                               var name2 = _food_list_breakfast6[1].name;
                               var ves = _food_list_breakfast6[1].weight;
                               var vess = "Вес:";
                               word1("[Блюдо6]", name2, word);
                               word1("[Весc5]", vess, word);
                               word1("[Вес6]", ves, word);
                           }
                       }
                       if (_food_list_breakfast7 == null)
                       {
                           var name2 = "";
                           word1("[Вес7]", name2, word);
                           word1("[Блюдо7]", name2, word);
                           word1("[Весc6]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_breakfast7[1] != null)
                           {
                               var name2 = _food_list_breakfast7[1].name;
                               var ves = _food_list_breakfast7[1].weight;
                               var vess = "Вес:";
                               word1("[Блюдо7]", name2, word);
                               word1("[Весc6]", vess, word);
                               word1("[Вес7]", ves, word);
                           }
                       }
                       if (_food_list_breakfast8 == null)
                       {
                           var name2 = "";
                           word1("[Вес8]", name2, word);
                           word1("[Весc7]", name2, word);
                           word1("[Блюдо8]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_breakfast8[1] != null)
                           {
                               var name2 = _food_list_breakfast8[1].name;

                               var ves = _food_list_breakfast8[1].weight;
                               var vess = "Вес:";
                               word1("[Весc7]", vess, word);
                               word1("[Вес8]", ves, word);

                               word1("[Блюдо8]", name2, word);
                           }
                       }


                       if (_food_list_dinner1 == null)
                       {
                           var name2 = "";

                           word1("[оБлюдо1]", name2, word);
                           word1("[Ves]", name2, word);
                           word1("[Ves1]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_dinner1[1] != null)
                           {
                               var name2 = _food_list_dinner1[1].name;
                               var ves = _food_list_dinner1[1].weight;
                               var vess = "Вес:";

                               word1("[оБлюдо1]", name2, word);
                               word1("[Ves1]", ves, word);
                               word1("[Ves]", vess, word);
                               
                           }
                       }

                       if (_food_list_dinner2 == null)
                       {
                           var name2 = "";

                           word1("[оБлюдо2]", name2, word);
                           word1("[Vess1]", name2, word);
                           word1("[Ves2]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_dinner2[1] != null)
                           {
                               var name2 = _food_list_dinner2[1].name;
                               var ves = _food_list_dinner2[1].weight;
                               var vess = "Вес:";
                               word1("[оБлюдо2]", name2, word);
                               word1("[Ves2]", ves, word);
                               word1("[Vess1]", vess, word);
                           }
                       }

                       if (_food_list_dinner3 == null)
                       {
                           var name2 = "";
                           word1("[Vess2]", name2, word);
                           word1("[Ves3]", name2, word);
                           word1("[оБлюдо3]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_dinner3[1] != null)
                           {
                               var name2 = _food_list_dinner3[1].name;
                               var ves = _food_list_dinner3[1].weight;
                               var vess = "Вес:";
                               word1("[оБлюдо3]", name2, word);
                               word1("[Ves3]", ves, word);
                               word1("[Vess2]", vess, word);
                           }
                       }
                       if (_food_list_dinner4 == null)
                       {
                           var name2 = "";
                           word1("[Vess3]", name2, word);
                           word1("[Ves4]", name2, word);
                           word1("[оБлюдо4]", name2, word);
                       }
                       else
                       {

                           if (this._food_list_dinner4[1] != null)
                           {
                               var name2 = _food_list_dinner4[1].name;
                               var ves = _food_list_dinner4[1].weight;
                               var vess = "Вес:";
                               word1("[Vess3]", vess, word);
                               word1("[Ves4]", ves, word);
                               word1("[оБлюдо4]", name2, word);
                           }

                       }

                   

                   if (_food_list_dinner5 == null)
                   {
                       var name2 = "";
                       word1("[Vess4]", name2, word);
                       word1("[Ves5]", name2, word);
                       word1("[оБлюдо5]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_dinner5[1] != null)
                       {
                           var name2 = _food_list_dinner5[1].name;
                           var ves = _food_list_dinner5[1].weight;
                           var vess = "Вес:";
                           word1("[Vess4]", vess, word);
                           word1("[Ves5]", ves, word);
                           word1("[оБлюдо5]", name2, word);
                       }
                   }

                   if (_food_list_dinner6 == null)
                   {
                       var name2 = "";
                       word1("[Vess5]", name2, word);
                       word1("[Ves6]", name2, word);
                       word1("[оБлюдо6]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_dinner6[1] != null)
                       {
                           var name2 = _food_list_dinner6[1].name;
                           var ves = _food_list_dinner6[1].weight;
                           var vess = "Вес:";
                           word1("[Vess5]", vess, word);
                           word1("[Ves6]", ves, word);
                           word1("[оБлюдо6]", name2, word);
                       }
                   }


                   if (_food_list_dinner7 == null)
                   {
                       var name2 = "";
                      
                       word1("[Vess6]", name2, word);
                       word1("[Ves7]", name2, word);
                       word1("[оБлюдо7]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_dinner3[1] != null)
                       {
                           var name2 = _food_list_dinner7[1].name;
                           var ves = _food_list_dinner7[1].weight;
                           var vess = "Вес:";

                           word1("[Vess6]", vess, word);
                           word1("[Ves7]", ves, word);
                           word1("[оБлюдо7]", name2, word);
                       }
                   }

                   if (_food_list_dinner8 == null)
                   {
                       var name2 = "";
                       word1("[Vess7]", name2, word);
                       word1("[Ves8]", name2, word);
                       word1("[оБлюдо8]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_dinner8[1] != null)
                       {
                           var name2 = _food_list_dinner8[1].name;
                           var ves = _food_list_dinner7[1].weight;
                           var vess = "Вес:";
                           
                           word1("[Vess7]", vess, word);
                           word1("[Ves8]", ves, word);
                           word1("[оБлюдо8]", name2, word);
                       }
                   }
                   if (_food_list_supper1 == null)
                   {
                       var name2 = "";
                       word1("[в]", name2, word);
                       word1("[1]", name2, word);
                       word1("[уБлюдо1]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper1[1] != null)
                       {
                           var name2 = _food_list_supper1[1].name;
                           var ves = _food_list_supper1[1].weight;
                           var vess = "Вес:";
                           word1("[в]", vess, word);
                           word1("[1]", ves, word);
                           word1("[уБлюдо1]", name2, word);
                       }
                   }
                   if (_food_list_supper2 == null)
                   {
                       var name2 = "";
                       word1("[в1]", name2, word);
                       word1("[2]", name2, word);

                       word1("[уБлюдо2]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper2[1] != null)
                       {
                           var name2 = _food_list_supper2[1].name;
                           var ves = _food_list_supper2[1].weight;
                           var vess = "Вес:";
                           word1("[в1]", vess, word);
                           word1("[2]", ves, word);

                           word1("[уБлюдо2]", name2, word);
                       }
                   }
                   if (_food_list_supper3 == null)
                   {
                       var name2 = "";

                       word1("[уБлюдо3]", name2, word);
                       word1("[в2]", name2, word);
                       word1("[3]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper3[1] != null)
                       {
                           var name2 = _food_list_supper3[1].name;
                           var ves = _food_list_supper3[1].weight;
                           var vess = "Вес:";
                           word1("[в2]", vess, word);
                           word1("[3]", ves, word);
                           word1("[уБлюдо3]", name2, word);
                       }
                   }
                   if (_food_list_supper4 == null)
                   {
                       var name2 = "";
                       word1("[в3]", name2, word);
                       word1("[4]", name2, word);

                       word1("[уБлюдо4]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper4[1] != null)
                       {
                           var name2 = _food_list_supper4[1].name;
                           var ves = _food_list_supper4[1].weight;
                           var vess = "Вес:";
                           word1("[в3]", vess, word);
                           word1("[4]", ves, word);


                           word1("[уБлюдо4]", name2, word);
                       }
                   }
                   if (_food_list_supper5 == null)
                   {
                       var name2 = "";
                       word1("[в4]", name2, word);
                       word1("[5]", name2, word);

                       word1("[уБлюдо5]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper5[1] != null)
                       {
                           var name2 = _food_list_supper5[1].name;
                           var ves = _food_list_supper5[1].weight;
                           var vess = "Вес:";
                           word1("[в4]", vess, word);
                           word1("[5]", ves, word);

                           word1("[уБлюдо5]", name2, word);
                       }
                   }
                   if (_food_list_supper6 == null)
                   {
                       var name2 = "";
                       word1("[в5]", name2, word);
                       word1("[6]", name2, word);

                       word1("[уБлюдо6]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper6[1] != null)
                       {
                           var name2 = _food_list_supper6[1].name;
                           var ves = _food_list_supper6[1].weight;
                           var vess = "Вес:";
                           word1("[в5]", vess, word);
                           word1("[6]", ves, word);
                           word1("[уБлюдо6]", name2, word);
                       }
                   }
                   if (_food_list_supper7 == null)
                   {
                       var name2 = "";
                       word1("[в6]", name2, word);
                       word1("[7]", name2, word);

                       word1("[уБлюдо7]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper7[1] != null)
                       {
                           var name2 = _food_list_supper7[1].name;
                           var ves = _food_list_supper7[1].weight;
                           var vess = "Вес:";
                           word1("[в6]", vess, word);
                           word1("[7]", ves, word);

                           word1("[уБлюдо7]", name2, word);
                       }
                   }
                   if (_food_list_supper8 == null)
                   {
                       var name2 = "";
                       word1("[в7]", name2, word);
                       word1("[8]", name2, word);

                       word1("[уБлюдо8]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_supper8[1] != null)
                       {
                           var name2 = _food_list_supper8[1].name;
                           var ves = _food_list_supper8[1].weight;
                           var vess = "Вес:";
                           word1("[в7]", vess, word);
                           word1("[8]", ves, word);

                           word1("[уБлюдо8]", name2, word);
                       }
                   }

                   App.Visible = true;
                   GC.Collect();
               }
           }

        #region
        public class_menu_in_food[] menu_in_day()
           {
               class_menu_in_food[] menu_in_day = new class_menu_in_food[512];

               string query = "select *  from Menu_in_day  where day_id ='" + AddDayID + "'";

               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query;
                   int i = 0;

                   SqlDataReader rd = com.ExecuteReader();

                   while (rd.Read())
                   {
                       i = i + 1;
                       menu_in_day[i] = new class_menu_in_food();
                       menu_in_day[i].result = "OK";
                       menu_in_day[i].service = rd.GetDateTime(1).ToShortDateString();
                       

                   }
                   rd.Close();
                   rd.Dispose();
                   com.Dispose();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + " " + ex.Data);
                   return null;
               }


               return menu_in_day;


           }

           public class_menu_in_food[] food_breakfast()
           {

               class_menu_in_food[] foods_list = new class_menu_in_food[512];

               string query = "select *  from Food_in_menu  where Serve_time_of_food ='Завтрак' and day_id='" + AddDayID + "'";

               string query2 = query;
               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query2;


                   SqlDataReader rd = com.ExecuteReader();
                   int i = 0;
                   while (rd.Read())
                   {
                       i = i + 1;
                       foods_list[i] = new class_menu_in_food();
                       foods_list[i].result = "OK";
                       foods_list[i].food_id = rd.GetInt32(2).ToString();
                       foods_list[i].service = rd.GetInt32(3).ToString();
                       
                       

                   }
                   rd.Close();
                   rd.Dispose();
                   com.Dispose();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + " " + ex.Data);
                   return null;
               }

               return foods_list;

           }

           public class_food[] food_breakfast1()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_breakfast[1] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_breakfast[1].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }

           public class_food[] food_breakfast2()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";
               if (_food_list_breakfast[2] == null) { foods_list = null; }
               else
               {

                   string g1 = this._food_list_breakfast[2].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }

           public class_food[] food_breakfast3()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";
               if (_food_list_breakfast[3] == null) { foods_list = null; }
               else
               {

                   string g1 = this._food_list_breakfast[3].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString(); ;

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }

           public class_food[] food_breakfast4()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_breakfast[4] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_breakfast[4].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_breakfast5()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_breakfast[5] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_breakfast[5].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_breakfast6()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";
               if (_food_list_breakfast[6] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_breakfast[6].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_breakfast7()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_breakfast[7] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_breakfast[7].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_breakfast8()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_breakfast[8] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_breakfast[8].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }

           public class_menu_in_food[] food_dinner()
           {

               class_menu_in_food[] foods_list = new class_menu_in_food[512];

               string query = "select *  from Food_in_menu  where Serve_time_of_food ='Обед' and day_id='" + AddDayID +"'";

               string query2 = query;
               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query2;


                   SqlDataReader rd = com.ExecuteReader();
                   int i = 0;
                   while (rd.Read())
                   {
                       i = i + 1;
                       foods_list[i] = new class_menu_in_food();
                       foods_list[i].result = "OK";
                       foods_list[i].food_id = rd.GetInt32(2).ToString();

                   }
                   rd.Close();
                   rd.Dispose();
                   com.Dispose();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + " " + ex.Data);
                   return null;
               }

               return foods_list;

           }
           public class_food[] food_dinner1()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_dinner[1] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_dinner[1].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_dinner2()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_dinner[2] == null) { foods_list = null; }
               else
               {

                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_dinner[2].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_dinner3()
           {
               class_food[] foods_list = new class_food[512];

               if (_food_list_dinner[3] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_dinner[3].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_dinner4()
           {
               class_food[] foods_list = new class_food[512];

               if (_food_list_dinner[4] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";
                   string g1 = this._food_list_dinner[4].food_id + "'";
                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_dinner5()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_dinner[5] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_dinner[5].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_dinner6()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_dinner[6] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_dinner[6].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_dinner7()
           {

               class_food[] foods_list = new class_food[512];
               if (_food_list_dinner[7] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_dinner[7].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_dinner8()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_dinner[8] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_dinner[8].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }

           public class_menu_in_food[] food_supper()
           {

               class_menu_in_food[] foods_list = new class_menu_in_food[512];


               string query = "select *  from Food_in_menu  where Serve_time_of_food ='Ужин' and day_id='"+ AddDayID +"'";

               string query2 = query;
               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query2;


                   SqlDataReader rd = com.ExecuteReader();
                   int i = 0;
                   while (rd.Read())
                   {
                       i = i + 1;
                       foods_list[i] = new class_menu_in_food();
                       foods_list[i].result = "OK";
                       foods_list[i].food_id = rd.GetInt32(2).ToString();
                     

                   }
                   rd.Close();
                   rd.Dispose();
                   com.Dispose();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + " " + ex.Data);
                   return null;
               }


               return foods_list;

           }
           public class_food[] food_supper1()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";


               if (_food_list_supper[1] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_supper[1].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_supper2()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_supper[2] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_supper[2].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_supper3()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_supper[3] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_supper[3].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_supper4()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_supper[4] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_supper[4].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_supper5()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_supper[5] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_supper[5].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();
                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_supper6()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_supper[6] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_supper[6].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
           public class_food[] food_supper7()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_supper[7] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_supper[7].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }
               return foods_list;

           }
           public class_food[] food_supper8()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_supper[8] == null) { foods_list = null; }
               else
               {

                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_supper[8].food_id + "'";

                   string query2 = query + g1;
                   try
                   {
                       SqlCommand com = Program.data_module._conn.CreateCommand();
                       com.CommandText = query2;
                       int i = 0;

                       SqlDataReader rd = com.ExecuteReader();

                       while (rd.Read())
                       {
                           i = i + 1;
                           foods_list[i] = new class_food();
                           foods_list[i].result = "OK";
                           foods_list[i].name = rd.GetString(1);
                           foods_list[i].weight = rd.GetDouble(6).ToString();

                       }
                       rd.Close();
                       rd.Dispose();
                       com.Dispose();
                   }

                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message + " " + ex.Data);
                       return null;
                   }
               }

               return foods_list;

           }
        #endregion
        
           private void word1(string stubToReplace, string text, word.Document word)
           {
               var range = word.Content;

               range.Find.ClearFormatting();

               range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);

           }
           private void gw_breakfast_KeyDown(object sender, KeyEventArgs e)
           {
               if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
               {
                   this.add_breakfast_Click(sender, e);
               }

               if (e.KeyCode == Keys.Delete)
               {

                   this.del_breakfast_Click(sender, e);
               }

           }
           private void gw_dinner_KeyDown(object sender, KeyEventArgs e)
           {
               if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
               {
                   this.add_dinner_Click(sender, e);
               }

               if (e.KeyCode == Keys.Delete)
               {

                   this.del_dinner_Click(sender, e);
               }

           }
           private void gw_supper_KeyDown(object sender, KeyEventArgs e)
           {
               
                   if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                   {
                       this.add_supper_Click(sender, e);
                   }

                   if (e.KeyCode == Keys.Delete)
                   {

                       this.del_supper_Click(sender, e);
                   }
               
               
           }
           #region

           /* public class_food[] get_food_breakfast(int date)
           {

               class_food[] food = new class_food[512];

               string query = "select distinct F.ID_food,Fim.count_serve,Name_food, F.Finish_weight_of_food from Food_in_menu FIM" +
                        " join Foods F on F.ID_food = FIM.ID_food " +
                    " where FIM.Serve_time_of_food = 'завтрак'  and day_id='" + date + "'";

               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query;
                   int i = 0;

                   SqlDataReader rd = com.ExecuteReader();

                   while (rd.Read())
                   {
                       i = i + 1;
                       food[i] = new class_food();
                       food[i].result = "OK";
                       food[i].food_id = rd.GetInt32(0).ToString();
                       food[i].name = rd.GetString(2);
                       if (rd.IsDBNull(1))
                       { food[i].count_portc = ""; }
                       else
                           food[i].count_portc = rd.GetInt32(1).ToString();
                       
                       if (rd.IsDBNull(2))
                       { food[i].weight = ""; }
                       else
                           food[i].weight = rd.GetDouble(3).ToString();
                                             
                       }

                   
                       
                   rd.Close();
                   rd.Dispose();
                   com.Dispose();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + " " + ex.Data);
                   return null;
               }

              
                   return food;
           }
           public class_ingridients[] get_ingr_list(int date)
           {

               class_ingridients[] ingr_list = new class_ingridients[512];

               string query = "select distinct I.Id_ingridients,I.ingridient_name from Food_in_menu FIM " +
                " join Foods F on F.ID_food = FIM.ID_food" +
                " join Ingridients_in_food IIF on IIF.ID_food = F.ID_food" +
                " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
                " where FIM.Serve_time_of_food = 'завтрак' and day_id = '" + date + "'";

               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query;
                   int i = 0;

                   SqlDataReader rd = com.ExecuteReader();

                   while (rd.Read())
                   {
                       i = i + 1;
                       ingr_list[i] = new class_ingridients();
                       ingr_list[i].result = "OK";
                       ingr_list[i].name = rd.GetString(1).ToString();
                       ingr_list[i].ingr_id = rd.GetInt32(0).ToString();
                   }
                   rd.Close();
                   rd.Dispose();
                   com.Dispose();
               }

               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + " " + ex.Data);
                   return null;
               }

               return ingr_list;
           }
           public class_ingr_in_food[] get_ves_breakfast()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];
            
               if (_food[1] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1'";

                   
                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'" +"and IIF.ID_food='"+ _food[1].food_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {
                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       if (rd.IsDBNull(0))
                                       {

                                           food[i].net = "";
                                           
                                       }
                                       else
                                       {
                                           food[i].net = rd.GetDouble(0).ToString();
                                          
                                       }
                                     
                                   }
                                   if (food[i] == null)
                                   {
                                       food[i] = new class_ingr_in_food();
                                       food[i].net = "0";
                                       int g = Convert.ToInt32(food[i].net);
                                       g = 0;
                                   }
                                   
                             
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                                  
                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }
                           



                           }

                       }


                   }
                                     
               }
           
                return food;
                         
           }

           public class_ingr_in_food[] get_sum_breakfast(int day)
           {
               class_food[] food = new class_food[512];
               class_ingr_in_food[] foods = new class_ingr_in_food[512];


               string query = "select Sum( count_serve * Net_weight /1000 ) from Ingridients_in_food join Food_in_menu on Ingridients_in_food.ID_food = Food_in_menu.ID_food "+ "  where Food_in_menu.day_id='" + day+ "'" +"and Food_in_menu.Serve_time_of_food='завтрак'" +" group by Ingridients_in_food.Id_ingridients";
                                       try
                                       {
                                           SqlCommand com = Program.data_module._conn.CreateCommand();
                                           com.CommandText = query ;
                                           SqlDataReader rd = com.ExecuteReader();
                                           int i=0;
                                           while (rd.Read())
                                           {i++;
                                               foods[i] = new class_ingr_in_food();
                                               foods[i].result = "OK";
                                               if (rd.IsDBNull(0))
                                               {

                                                   foods[i].net = "";

                                               }
                                               else
                                               {
                                                   foods[i].net = rd.GetDouble(0).ToString();

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
                                       }

                                                                            
               return foods;
           }
           
           public class_ingr_in_food[] get_ves_breakfast2()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];
               if (_food[2] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[2].food_id + "'"; ;

                   
                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();
                                  
                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }
                                   if (food[i] ==null)
                                   {
                                       food[i] = new class_ingr_in_food();
                                       food[i].net = "0";
                                     
                                       int g = Convert.ToInt32(food[i].net);
                                       g = 0;
                                   }

                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }


                           }

                       }
                   }

               }

               return food;
           }
           public  class_ingr_in_food[] get_ves_breakfast3()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];

               if (_food[3] != null)
               {

                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[3].food_id + "'"; ;



                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }

                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }

                           }


                       }
                   }
               }
                return food;
           }
           public class_ingr_in_food[] get_ves_breakfast4()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];
               if (_food[4] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[4].food_id + "'"; ;



                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }


                           }

                       }
                   }
               }


               return food;
           }
           public class_ingr_in_food[] get_ves_breakfast5()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];
               if (_food[5] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[5].food_id + "'"; ;

                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }



                           }


                       }
                   }
               }


               return food;
           }
           public class_ingr_in_food[] get_ves_breakfast6()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];

               if (_food[6] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[6].food_id + "'"; ;



                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }

                           }
                       }
                   }
               }

               return food;
           }
           public class_ingr_in_food[] get_ves_breakfast7()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];
               if (_food[7] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[7].food_id + "'"; ;



                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }

                           }
                       }
                   }
               }
               return food;
           }
           public class_ingr_in_food[] get_ves_breakfast8()
           {
               class_ingr_in_food[] food = new class_ingr_in_food[512];

               if (_food[8] != null)
               {
                   string query = "select IIF.Net_weight from Foods F " +
         " join Ingridients_in_food IIF on F.ID_food = IIF.ID_food" +
         " join Ingridients I on I.Id_ingridients = IIF.Id_ingridients" +
         " join Food_in_menu FIM on FIM.ID_food = F.ID_food where FIM.Serve_time_of_food = 'завтрак' and day_id = '1' and IIF.ID_food='" + _food[8].food_id + "'"; ;



                   if (_ingr_list == null) { _ingr_list = null; }
                   else
                   {
                       for (int i = 1; i < _ingr_list.Count(); i++)
                       {

                           if (_ingr_list[i] != null)
                           {
                               string g1 = "and IIF.Id_ingridients='" + this._ingr_list[i].ingr_id + "'";
                               try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query + g1;
                                   SqlDataReader rd = com.ExecuteReader();

                                   while (rd.Read())
                                   {

                                       food[i] = new class_ingr_in_food();
                                       food[i].result = "OK";
                                       food[i].net = rd.GetDouble(0).ToString();

                                   }
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }

                           }
                       }
                   }
               }

               return food;
           }

           public class_queue get_count_serv(int id_queue)
           {
               class_queue queue = new class_queue();
                string query = "select Number_of_mens from Queue where ID_queue='" + id_queue+"'";

                         try
                               {
                                   SqlCommand com = Program.data_module._conn.CreateCommand();
                                   com.CommandText = query ;
                                   SqlDataReader rd = com.ExecuteReader();
                                 
                                   while (rd.Read())
                                   {
                                       
                                       queue = new class_queue();
                                       queue.result = "OK";
                                       queue.numb_men = rd.GetInt32(0).ToString();

                                   }
                                   rd.Close();
                                   rd.Dispose();
                                   com.Dispose();
                               }

                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message + " " + ex.Data);
                                   return null;
                               }
                         return queue;

                           }
           
           
           /*public void Report_MEnu_Layout()
           {

               var App = new word.Application(Visible = false);

               if (_ingr_list[24] != null)
               {
                   var word = App.Documents.Add(Application.StartupPath + File3);

                   for (int i = 1; i <= 8; i++)
                   {
                       if (_food[i] == null)
                       {
                           var name = "";

                           word1("[блюдо" + i + "]", name, word);
                           word1("[Вес" + i + ":]", name, word);

                       }

                       if (this._food[i] != null)
                       {

                           var name = _food[i].name;

                           var name1 = "Вес:" + " " + _food[i].weight;

                           word1("[Вес" + i + ":]", name1, word);

                           word1("[блюдо" + i + "]", name, word);

                       }
                   }




                   for (int i = 1; i < 51; i++)
                   {
                       if (_ingr_list[i] == null)
                       {
                           var name = "";


                           word1("[" + i + "]", name, word);
                       }

                       if (this._ingr_list[i] != null)
                       {

                           var name = _ingr_list[i].name;


                           word1("[" + i + "]", name, word);
                       }

                       if (_ves[i] == null)
                       {
                           var name6 = "";
                           word1("[v" + i + "]", name6, word);
                       }
                       else
                       {

                           if (this._ves[i] != null)
                           {
                               var name5 = Convert.ToDouble(_ves[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc));
                               word1("[v" + i + "]", nsme6.ToString(), word);
                           }
                           else
                           {
                               var name6 = "";
                               word1("[v" + i + "]", name6, word);
                           }
                       }
                       if (_ves2[i] == null)
                       {

                           var name6 = "";
                           word1("[k" + i + "]", name6, word);
                       }

                       else
                       {

                           if (this._ves2[i] != null)
                           {
                               var name5 = _ves2[i].net;
                               word1("[k" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[k" + i + "]", name6, word);
                           }
                       }

                       if (_ves3[i] == null)
                       {

                           var name6 = "";
                           word1("[i" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves3[i] != null)
                           {
                               var name5 = _ves3[i].net;
                               word1("[i" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[k" + i + "]", name6, word);
                           }
                       }
                       if (_ves4[i] == null)
                       {

                           var name6 = "";
                           word1("[z" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves4[i] != null)
                           {
                               var name5 = _ves4[i].net;
                               word1("[z" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[z" + i + "]", name6, word);
                           }
                       }
                       if (_ves5[i] == null)
                       {

                           var name6 = "";
                           word1("[x" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves5[i] != null)
                           {
                               var name5 = _ves5[i].net;
                               word1("[x" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[x" + i + "]", name6, word);
                           }
                       }

                       if (_ves5[i] == null)
                       {

                           var name6 = "";
                           word1("[x" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves5[i] != null)
                           {
                               var name5 = _ves5[i].net;
                               word1("[x" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[x" + i + "]", name6, word);
                           }
                       }

                       if (_ves6[i] == null)
                       {

                           var name6 = "";
                           word1("[y" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves6[i] != null)
                           {
                               var name5 = _ves6[i].net;
                               word1("[y" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[y" + i + "]", name6, word);
                           }
                       }

                       if (_ves7[i] == null)
                       {

                           var name6 = "";
                           word1("[q" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves7[i] != null)
                           {
                               var name5 = _ves7[i].net;
                               word1("[q" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[q" + i + "]", name6, word);
                           }
                       }

                       if (_ves8[i] == null)
                       {

                           var name6 = "";
                           word1("[n" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves8[i] != null)
                           {
                               var name5 = _ves8[i].net;
                               word1("[n" + i + "]", name5, word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[n" + i + "]", name6, word);
                           }
                       }

                   }

                   App.Visible = true;
                   GC.Collect();
               }
               else
               {
                   var word = App.Documents.Add(Application.StartupPath + File1);
                   for (int i = 1; i <= 8; i++)
                   {
                       if (_food[i] == null)
                       {
                           var name = "";

                           word1("[блюдо" + i + "]", name, word);
                           word1("[Вес" + i + ":]", name, word);
                           word1("[kol" + i + "]", name, word);

                       }

                       if (this._food[i] != null)
                       {

                           var name = _food[i].name;
                           var name2 = _food[i].count_portc;
                           var name1 = "Вес:" + " " + _food[i].weight;

                           word1("[Вес" + i + ":]", name1, word);

                           word1("[блюдо" + i + "]", name, word);

                           word1("[kol" + i + "]", name2, word);

                       }
                   }

                   for (int i = 1; i <= 50; i++)
                   {

                       if (_ingr_list[i] == null)
                       {
                           var name = "";

                           word1("[" + i + "]", name, word);
                       }

                       if (this._ingr_list[i] != null)
                       {

                           var name = _ingr_list[i].name;


                           word1("[" + i + "]", name, word);
                       }


                       if (_ves[i] == null)
                       {

                           var name6 = "";
                           word1("[v" + i + "]", name6, word);
                       }
                       else
                       {

                           if (this._ves[i] != null)
                           {
                               var name5 = Convert.ToDouble(_ves[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[1].count_portc) / 1000);
                               word1("[v" + i + "]", nsme6.ToString(), word);


                           }
                           else
                           {
                               var name6 = "";
                               word1("[v" + i + "]", name6, word);
                           }
                       }
                       if (_ves2[i] == null)
                       {

                           var name6 = "";
                           word1("[k" + i + "]", name6, word);
                       }

                       else
                       {

                           if (this._ves2[i] != null)
                           {
                               var name5 = Convert.ToDouble(_ves2[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[2].count_portc) / 1000);
                               word1("[k" + i + "]", nsme6.ToString(), word);


                           }
                           else
                           {
                               var name6 = "";
                               word1("[k" + i + "]", name6, word);
                           }
                       }

                       if (_ves3[i] == null)
                       {

                           var name6 = "";
                           word1("[i" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves3[i] != null)
                           {

                               var name5 = Convert.ToDouble(_ves3[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[3].count_portc) / 1000);

                               word1("[i" + i + "]", nsme6.ToString(), word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[k" + i + "]", name6, word);
                           }
                       }
                       if (_ves4[i] == null)
                       {

                           var name6 = "";
                           word1("[z" + i + "]", name6, word);

                       }

                       else
                       {
                           if (this._ves4[i] != null)
                           {

                               var name5 = Convert.ToDouble(_ves4[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[4].count_portc) / 1000);

                               word1("[z" + i + "]", nsme6.ToString(), word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[z" + i + "]", name6, word);
                           }
                       }
                       if (_ves5[i] == null)
                       {

                           var name6 = "";
                           word1("[x" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves5[i] != null)
                           {
                               var name5 = Convert.ToDouble(_ves5[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[5].count_portc) / 1000);
                               word1("[x" + i + "]", nsme6.ToString(), word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[x" + i + "]", name6, word);
                           }
                       }


                       if (_ves6[i] == null)
                       {

                           var name6 = "";
                           word1("[y" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves6[i] != null)
                           {

                               var name5 = Convert.ToDouble(_ves6[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[6].count_portc) / 1000);
                               word1("[y" + i + "]", nsme6.ToString(), word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[y" + i + "]", name6, word);
                           }
                       }

                       if (_ves7[i] == null)
                       {

                           var name6 = "";
                           word1("[q" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves7[i] != null)
                           {

                               var name5 = Convert.ToDouble(_ves7[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[7].count_portc) / 1000);
                               word1("[q" + i + "]", nsme6.ToString(), word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[q" + i + "]", name6, word);
                           }
                       }

                       if (_ves8[i] == null)
                       {

                           var name6 = "";
                           word1("[n" + i + "]", name6, word);
                       }

                       else
                       {
                           if (this._ves8[i] != null)
                           {

                               var name5 = Convert.ToDouble(_ves8[i].net);
                               var nsme6 = (name5 * Convert.ToDouble(_food[8].count_portc) / 1000);

                               word1("[n" + i + "]", nsme6.ToString(), word);

                           }
                           else
                           {
                               var name6 = "";
                               word1("[n" + i + "]", name6, word);
                           }

                       }


                       if (_obshves[i] != null)
                       {
                           var name5 = _obshves[i].net;
                           word1("[b" + i + "]", name5.ToString(), word);

                       }
                       else
                       {
                           var name5 = "";
                           word1("[b" + i + "]", name5, word);
                       }

                       if (_menu_in_day == null)
                       {

                           var name2 = "";

                           word1("[date]", name2, word);
                       }
                       else
                       {

                           if (this._menu_in_day[1] != null)
                           {
                               var name2 = _menu_in_day[1].service;

                               word1("[date]", name2, word);
                           }
                       }
                       if (_count_serv == null)
                       {

                           var name2 = "";

                           word1("[kol]", name2, word);
                       }
                       else
                       {

                           if (this._count_serv != null)
                           {
                               var name2 = _count_serv.numb_men;

                               word1("[kol]", name2, word);

                           }

                       }
                   }
                       App.Visible = true;
                       GC.Collect();
                   }
               }*/
           #endregion;

           private void Menu_layout_break_Click(object sender, EventArgs e)
           {
               Menu_Strip_breakfast_Click(sender,e);
           }

           private void Menu_Strip_breakfast_Click(object sender, EventArgs e)
             { 
               # region
                 /* _food = get_food_breakfast(AddDayID);
                 _ingr_list = get_ingr_list(AddDayID);
                 _ves = get_ves_breakfast();
                 _ves2 = get_ves_breakfast2();
                 _ves3 = get_ves_breakfast3();
                 _ves4 = get_ves_breakfast4();
                 _ves5 = get_ves_breakfast5();
                 _ves6 = get_ves_breakfast6();
                 _ves7 = get_ves_breakfast7();
                 _ves8 = get_ves_breakfast8();
                 _obshves = get_sum_breakfast(AddDayID); 
                 _menu_in_day = this.menu_in_day();
                 _count_serv = this.get_count_serv(queue_id);*/
                 // Report_MEnu_Layout();
               #endregion

                 Menu_layout Menu_layout = new Menu_layout("завтрак",AddDayID, queue_id);
                 Menu_layout.ShowDialog();
             
             }

           private void gw_breakfast_MouseDown(object sender, MouseEventArgs e)
             {
                 int rowIndex = gw_breakfast.HitTest(e.X, e.Y).RowIndex;
                 if (rowIndex == -1) return;
                 gw_breakfast.ClearSelection();
                 gw_breakfast.Rows[rowIndex].Selected = true;
                 gw_breakfast.CurrentCell = gw_breakfast[3, rowIndex];// 3  - это номер столбца
             }

           private void gw_dinner_MouseDown(object sender, MouseEventArgs e)
             {
                 int rowIndex = gw_dinner.HitTest(e.X, e.Y).RowIndex;
                 if (rowIndex == -1) return;
                 gw_dinner.ClearSelection();
                 gw_dinner.Rows[rowIndex].Selected = true;
                 gw_dinner.CurrentCell = gw_dinner[3, rowIndex];// 3  - это номер столбца

             }

           private void gw_supper_MouseDown(object sender, MouseEventArgs e)
             {
                 int rowIndex = gw_supper.HitTest(e.X, e.Y).RowIndex;
                 if (rowIndex == -1) return;
                 gw_supper.ClearSelection();
                 gw_supper.Rows[rowIndex].Selected = true;
                 gw_supper.CurrentCell = gw_supper[3, rowIndex];// 3  - это номер столбца
                 
             }

           private void del_context_dinner_Click(object sender, EventArgs e)
             {
                 del_dinner_Click(sender,e);
             }

             private void del_context_supper_Click(object sender, EventArgs e)
             {
                 del_supper_Click(sender,e);
             }

             private void Menu_layout_dinner_Click(object sender, EventArgs e)
             {
                 Menu_Strip_din_Click(sender,e);
             }

             private void Menu_Strip_din_Click(object sender, EventArgs e)
             {
                 Menu_layout Menu_layout = new Menu_layout("обед",AddDayID, queue_id);
                 Menu_layout.ShowDialog();
             }

             private void Menu_supper_Click(object sender, EventArgs e)
             {
                 supper_Click(sender, e);
             }

             private void supper_Click(object sender, EventArgs e)
             {
                 Menu_layout Menu_layout = new Menu_layout("ужин", AddDayID, queue_id);
                 Menu_layout.ShowDialog();
             }

             private void Menu_all_day_Click(object sender, EventArgs e)
             {
                 Menu_layout Menu_layout = new Menu_layout("весь день",AddDayID, queue_id);
                 Menu_layout.ShowDialog();

             }

         }
    }


    


