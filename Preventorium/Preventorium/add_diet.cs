﻿using System;
using System.Windows.Forms;

namespace Preventorium
{
    public partial class add_diet : Form
    {
        /// <summary>
        /// конструктор формы
        /// </summary>
        public add_diet()
        {
            InitializeComponent();
        }

        //модуль, через который работать с базой
        private db_connect _data_module;
        //Состояние (new/old/mod)
        private string _state;
        //ID диеты для загрузки данных (в режиме OLD)
        public string _id;

        /// <summary>
        /// Конструктор, вызываемый при нажатии "Добавить" 
        /// </summary>
        /// <param name="data_module"></param>
        public add_diet(db_connect data_module)
        {
            InitializeComponent();
            this._data_module = data_module;
            this.set_state("NEW");      
        }

        /// <summary>
        /// метод активирует кнопку "Добавить", если немер диеты не пустой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enabled_b_save(object sender, EventArgs e)
        {
              if (this._state == "OLD") { this.set_state("MOD"); };
              if (tb_numbDiet.Text !="")
              {
                  this.b_save.Enabled = true;
              }
              else
                  this.b_save.Enabled = false;
        }

        /// <summary>
        /// Конструктор, вызываемый для редактирования существующей диеты
        /// </summary>
        /// <param name="data_module"></param>
        /// <param name="act_id"></param>
        public add_diet(db_connect data_module, int act_id)
        {
            InitializeComponent();
            this._id = act_id.ToString();
            this._data_module = data_module;
            this.fill_diet_data();
            this.set_state("OLD");
        }

        /// <summary>
        /// событие при сохранении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_save_Click(object sender, EventArgs e)
        {
            string result; //Результат попытки сохранения/добавления диеты
            switch (this._state)
            {
                //Если добавляется новая запись...
                case "NEW":
                    result = Program.add_read_module.add_diet(this.tb_numbDiet.Text,
         this.tb_description.Text);
                    this.Close();
                    break;

                //Если модифицируется существующая...
                case "MOD":
                    result = Program.add_read_module.upd_diet(Convert.ToInt32(this._id),
                    this.tb_numbDiet.Text,
         this.tb_description.Text);
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
                MessageBox.Show("Данная диета уже создана!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            this.Dispose();
        }


        /// <summary>
        /// устанавливает указанный в параметрах статус как состояние формы, в соответствии с 
        ///которым устанавливает параметры всех элементов формы, соответствующие указанному состоянию
        /// </summary>
        /// <param name="state"></param>
        public void set_state(string state)
        {
            switch (state)
            {
                case "OLD":
                    this._state = "OLD";
                    this.Text = "Диеты - Просмотр";
                    this.b_save.Enabled = false;
                    break;

                case "NEW":
                    this._state = "NEW";
                    this.Text = "Диеты - Добавление";
                    this.b_save.Enabled = false;
                    break;

                case "MOD":
                    this._state = "MOD";
                    this.Text = "Диеты - Редактирование";
                    this.b_save.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// заполняет форму данными о диете, полученными из базы данных при просмотре существующей в БД записи
        /// </summary>
        public void fill_diet_data()
        {
            class_diet diet;
            diet = Program.add_read_module.get_diet(Convert.ToInt32(this._id));
            if (diet.result == "OK")
            {
                this.tb_numbDiet.Text = diet.numbDiet;
                this.tb_description.Text = diet.description;
            }
            else
            {
                //Не удалось получить сведений о текущей диете
                MessageBox.Show(diet.result);
                this.Dispose();
            }
        }

        /// <summary>
        /// нажатие на кнопку отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_abolition_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
    }
}
