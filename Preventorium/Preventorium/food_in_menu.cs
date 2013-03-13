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

           public class_menu_in_food[] _food_list_breakfast;
           public class_menu_in_food[] _menu_in_day;
           public class_menu_in_food[] _food_list_dinner;
           public class_menu_in_food[] _food_list_support;
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
           public class_food[] _food_list_support1;
           public class_food[] _food_list_support2;
           public class_food[] _food_list_support3;
           public class_food[] _food_list_support4;
           public class_food[] _food_list_support5;
           public class_food[] _food_list_support6;
           public class_food[] _food_list_support7;
           public class_food[] _food_list_support8;

           private readonly string File = @"\1.docx";
        

           public food_in_menu(int id, int day_id)
        
           {
            AddDayID = day_id;
            menu_id = id;
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
               this.load_data_table2("Food_in_menu");
               gw_dinner.Columns[3].HeaderText = "Блюдо";
               this.load_data_table3("Food_in_menu");
               gw_supper.Columns[3].HeaderText = "Блюдо";
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
                           del = new del_food_from_menu(Program.data_module, Convert.ToInt32(gw_breakfast.Rows[gw_breakfast.CurrentRow.Index].Cells[0].Value.ToString()), gw_breakfast.Rows[gw_breakfast.CurrentRow.Index].Cells[2].Value.ToString());
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
                           del = new del_food_from_menu(Program.data_module, Convert.ToInt32(gw_breakfast.Rows[gw_breakfast.CurrentRow.Index].Cells[0].Value.ToString()), gw_breakfast.Rows[gw_breakfast.CurrentRow.Index].Cells[2].Value.ToString());
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
               this._food_list_support = this.food_support();
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
               this._food_list_support1 = this.food_support1();
               this._food_list_support2 = this.food_support2();
               this._food_list_support3 = this.food_support3();
               this._food_list_support4 = this.food_support4();
               this._food_list_support5 = this.food_support5();
               this._food_list_support6 = this.food_support6();
               this._food_list_support7 = this.food_support7();
               this._food_list_support8 = this.food_support8();

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
                   if (_food_list_support1 == null)
                   {
                       var name2 = "";
                       word1("[в]", name2, word);
                       word1("[1]", name2, word);
                       word1("[уБлюдо1]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support1[1] != null)
                       {
                           var name2 = _food_list_support1[1].name;
                           var ves = _food_list_support1[1].weight;
                           var vess = "Вес:";
                           word1("[в]", vess, word);
                           word1("[1]", ves, word);
                           word1("[уБлюдо1]", name2, word);
                       }
                   }
                   if (_food_list_support2 == null)
                   {
                       var name2 = "";
                       word1("[в1]", name2, word);
                       word1("[2]", name2, word);

                       word1("[уБлюдо2]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support2[1] != null)
                       {
                           var name2 = _food_list_support2[1].name;
                           var ves = _food_list_support2[1].weight;
                           var vess = "Вес:";
                           word1("[в1]", vess, word);
                           word1("[2]", ves, word);

                           word1("[уБлюдо2]", name2, word);
                       }
                   }
                   if (_food_list_support3 == null)
                   {
                       var name2 = "";

                       word1("[уБлюдо3]", name2, word);
                       word1("[в2]", name2, word);
                       word1("[3]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support3[1] != null)
                       {
                           var name2 = _food_list_support3[1].name;
                           var ves = _food_list_support3[1].weight;
                           var vess = "Вес:";
                           word1("[в2]", vess, word);
                           word1("[3]", ves, word);
                           word1("[уБлюдо3]", name2, word);
                       }
                   }
                   if (_food_list_support4 == null)
                   {
                       var name2 = "";
                       word1("[в3]", name2, word);
                       word1("[4]", name2, word);

                       word1("[уБлюдо4]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support4[1] != null)
                       {
                           var name2 = _food_list_support4[1].name;
                           var ves = _food_list_support4[1].weight;
                           var vess = "Вес:";
                           word1("[в3]", vess, word);
                           word1("[4]", ves, word);


                           word1("[уБлюдо4]", name2, word);
                       }
                   }
                   if (_food_list_support5 == null)
                   {
                       var name2 = "";
                       word1("[в4]", name2, word);
                       word1("[5]", name2, word);

                       word1("[уБлюдо5]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support5[1] != null)
                       {
                           var name2 = _food_list_support5[1].name;
                           var ves = _food_list_support5[1].weight;
                           var vess = "Вес:";
                           word1("[в4]", vess, word);
                           word1("[5]", ves, word);

                           word1("[уБлюдо5]", name2, word);
                       }
                   }
                   if (_food_list_support6 == null)
                   {
                       var name2 = "";
                       word1("[в5]", name2, word);
                       word1("[6]", name2, word);

                       word1("[уБлюдо6]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support6[1] != null)
                       {
                           var name2 = _food_list_support6[1].name;
                           var ves = _food_list_support6[1].weight;
                           var vess = "Вес:";
                           word1("[в5]", vess, word);
                           word1("[6]", ves, word);
                           word1("[уБлюдо6]", name2, word);
                       }
                   }
                   if (_food_list_support7 == null)
                   {
                       var name2 = "";
                       word1("[в6]", name2, word);
                       word1("[7]", name2, word);

                       word1("[уБлюдо7]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support7[1] != null)
                       {
                           var name2 = _food_list_support7[1].name;
                           var ves = _food_list_support7[1].weight;
                           var vess = "Вес:";
                           word1("[в6]", vess, word);
                           word1("[7]", ves, word);

                           word1("[уБлюдо7]", name2, word);
                       }
                   }
                   if (_food_list_support8 == null)
                   {
                       var name2 = "";
                       word1("[в7]", name2, word);
                       word1("[8]", name2, word);

                       word1("[уБлюдо8]", name2, word);
                   }
                   else
                   {

                       if (this._food_list_support8[1] != null)
                       {
                           var name2 = _food_list_support8[1].name;
                           var ves = _food_list_support8[1].weight;
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

           public class_menu_in_food[] food_support()
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
           public class_food[] food_support1()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";


               if (_food_list_support[1] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_support[1].food_id + "'";

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
           public class_food[] food_support2()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_support[2] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_support[2].food_id + "'";

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
           public class_food[] food_support3()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_support[3] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_support[3].food_id + "'";

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
           public class_food[] food_support4()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_support[4] == null) { foods_list = null; }
               else
               {
                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_support[4].food_id + "'";

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
           public class_food[] food_support5()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_support[5] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_support[5].food_id + "'";

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
           public class_food[] food_support6()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_support[6] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_support[6].food_id + "'";

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
           public class_food[] food_support7()
           {
               class_food[] foods_list = new class_food[512];

               string query = "select *  from Foods Where ID_food ='";

               if (_food_list_support[7] == null) { foods_list = null; }
               else
               {
                   string g1 = this._food_list_support[7].food_id + "'";

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
           public class_food[] food_support8()
           {
               class_food[] foods_list = new class_food[512];
               if (_food_list_support[8] == null) { foods_list = null; }
               else
               {

                   string query = "select *  from Foods Where ID_food ='";


                   string g1 = this._food_list_support[8].food_id + "'";

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


           public class_food[] food1()
           {
               class_food[] foods_list1 = new class_food[512];

               string query = "select *  from Foods where Name_food='" + _food_list_breakfast1[1].name;
               string query3 = query;
               try
               {
                   SqlCommand com = Program.data_module._conn.CreateCommand();
                   com.CommandText = query3;
                   int i = 0;

                   SqlDataReader rd = com.ExecuteReader();

                   while (rd.Read())
                   {
                       i = i + 1;
                       foods_list1[i] = new class_food();
                       foods_list1[i].result = "OK";
                       foods_list1[i].food_id = rd.GetInt32(0).ToString();
                       foods_list1[i].name = rd.GetString(1).ToString();
                       foods_list1[i].calories = rd.GetDouble(2).ToString();
                       foods_list1[i].proteins = rd.GetDouble(3).ToString();
                       foods_list1[i].fats = rd.GetDouble(4).ToString();
                       foods_list1[i].carbo = rd.GetDouble(5).ToString();
                       foods_list1[i].weight = rd.GetDouble(6).ToString();


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

               return foods_list1;

           }



           private void word1(string stubToReplace, string text, word.Document word)
           {
               var range = word.Content;

               range.Find.ClearFormatting();

               range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);

           }
              
    }
}
