using System;
using System.Drawing;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_ingr : Form
    {
        /// <summary>
        /// модуль, через который работать с базой
        /// </summary>
        private db_connect _data_module;
        /// <summary>
        ///  Состояние (new/old/mod)
        /// </summary>
        /// <param name="?"></param>
       
        private string _state;
        /// <summary>
        ///  ID ингридиента для загрузки данных (в режиме OLD)
        /// </summary>
       
        private string _id;
      
          private void enabled_b_save(object sender, EventArgs e)
          {
              if (this._state == "OLD") { this.set_state("MOD"); }
              // Включается кнопка "Сохранить" если текстбоксы не пустые
              if ((tb_name.Text != "") && (tb_uglevod.Text != "") && (tb_zhiri.Text != "") && (tb_belki.Text != "")) { this.b_save.Enabled = true; }
          }

          /// <summary>
          ///  Конструктор, вызываемый при нажатии "Добавить"
          /// </summary>
          /// <param name="data_module"></param>

           public add_ingr(db_connect data_module)
        {
            InitializeComponent();
            this.Size = new Size(225, 239);
            this.b_save.Location = new Point(10,172);
            this.b_abolition.Location = new Point(130,172);
            tb_calories.Enabled = false;
            tb_calories.Visible = false;
            label2.Enabled = false;
            label2.Visible = false;
            this._data_module = data_module;
            this.set_state("NEW");
        }
        
           //Конструктор, вызываемый
           //для редактирования существующего ингредиента
        public add_ingr(db_connect data_module, int ingr_id)
        {
            InitializeComponent();
            tb_calories.Enabled = false;
            this._id = ingr_id.ToString();
            this._data_module = data_module;
            this.fill_ingr_data();
            this.set_state("OLD");
        }

        /// <summary>
        /// заполняет форму данными о ингредиенте, полученными из базы данных при просмотре существующей в БД записи
        /// </summary>
        public void fill_ingr_data()
        {
            class_ingridients ingr;
            ingr = Program.add_read_module.get_ingr(Convert.ToInt32(this._id));
            if (ingr.result == "OK")
            {
                this.tb_name.Text = ingr.name;
                this.tb_uglevod.Text = ingr.uglevod;
                this.tb_zhiri.Text = ingr.zhiri;
                this.tb_belki.Text = ingr.protein;
                this.tb_calories.Text = ingr.calories;
                
            }
            else
            {
                //Не удалось получить сведений о текущем ингридиенте
                MessageBox.Show(ingr.result);
                this.Dispose();
            }
        }


           public void set_state(string state)
           {
               switch (state)
               {
                   case "OLD":
                       this._state = "OLD";
                       this.Text = "Просмотр";
                       this.b_save.Enabled = false;
                       break;

                   case "NEW":
                       this._state = "NEW";
                       this.Text = "Добавление";
                       this.b_save.Enabled = false;
                      
                       break;

                   case "MOD":
                       this._state = "MOD";
                       this.Text = "Редактирование";
                       this.b_save.Enabled = true;
                       break;
               }
           }

           private void b_save_Click(object sender, EventArgs e)
           {
             string result; //Результат попытки сохранения/добавления ингредиента
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":
                    result = Program.add_read_module.add_ingr(this.tb_name.Text,  (this.tb_calories.Text), (this.tb_uglevod.Text),(this.tb_zhiri.Text), (this.tb_belki.Text));
                    this.Close();
                    break;
                    

                //Если модифицируется существующая...
              case "MOD":
                 result = Program.add_read_module.upd_ingr(Convert.ToInt32(this._id), this.tb_name.Text,(this.tb_calories.Text), (this.tb_uglevod.Text), (this.tb_zhiri.Text), (this.tb_belki.Text));
                 tb_calories.Enabled = false;
                    break;

                default:
                    result = "NDF";
                    // не используется, однако mvs не позволяет 
                    // дальше работать переменной, которой в одной
                    // из веток кода не присваивается значение
                    break;
            }
            
            if (result == "OK")
            {
                if (this._state == "NEW")
                {
                    this.set_state("OLD");
                    this.Dispose();
                }
                else
                    if (this._state == "MOD")
                    {
                        this.set_state("OLD");
                    }
            }
            else
            {
               // MessageBox.Show(result);
                MessageBox.Show("Вы не можете в поля: Жиры,Белки,Углеводы,вводить текст");
            }

            this.Dispose();
           }
        /// <summary>
        /// Кнопка отмена 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
           private void b_abolition_Click(object sender, EventArgs e)
           {
               this.Close();
           }

          

    }
}
