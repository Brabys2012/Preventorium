﻿using System;
using System.Data;
using System.Data.SqlClient;


namespace Preventorium
{     class get_table
    {
        public DataSet _ds;
        public SqlDataAdapter _da;     
        public string _command_text;

        /// <summary>
        /// Метод содержит sql запрос на добавление значений в таблицу Ingridients
        /// </summary>
        public string add_ingr(string name, string callories, string carbohydrates, string fats, string proteins)
        {
            this._command_text = "insert into Ingridients";
            this._command_text += "(ingridient_name,calories,carbohydrates,fats,proteins ) ";
            this._command_text += "values(";

            if (name == "")
              { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += name;
                this._command_text += "',";
            }

            if (Convert.ToString(callories) == "null")
            {
                { this._command_text += "null"; this._command_text += ", "; }
            }
            else
            {
                this._command_text += " '";
                this._command_text += callories;
                this._command_text += "',";
            }

            if (Convert.ToString(carbohydrates) == "")
            { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += carbohydrates;
                this._command_text += "',";

            }

            if (Convert.ToString(fats) == "")
            { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += fats;
                this._command_text += "',";
            }

            if (Convert.ToString(proteins) == "")
            { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += proteins;
                this._command_text += "')";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";

        }
    /// <summary>
        /// Метод содержит sql запрос на обновление значений в таблицу Ingridients
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="calories"></param>
    /// <param name="uglevod"></param>
    /// <param name="fats"></param>
    /// <param name="proteins"></param>
    /// <returns>id ингридиента,имя,калории и т.д</returns>
        public string upd_ingr(int id, string name, string calories, string uglevod, string fats, string proteins)
        {
            string query = "update Ingridients set ";

            query += "ingridient_name=";
            if (name == "") { query += "null, "; }
            else
            {
                query += "'";
                query += name;
                query += "' ,";
            }

            query += "calories=";
            if (uglevod.ToString() == "") { query += "null, "; }
            else
            {
                query += "'";
                query += calories;
                query += "', ";
            }

            query += "carbohydrates=";
            if (uglevod.ToString() == "") { query += "null, "; }
            else
            {
                query += "'";
                query += uglevod;
                query += "', ";
            }

            query += "fats=";
            if (uglevod.ToString() == "") { query += "null, "; }
            else
            {
                query += "'";
                query += fats;
                query += "', ";
            }

            query += "proteins=";
            if (uglevod.ToString() == "") { query += "null, "; }
            else
            {
                query += "'";
                query += proteins;
                query += "' ";
            }

            query += "where ID_ingridients=";
            query += id.ToString();


            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }
    /// <summary>
    /// Метод ,возвращает значения о ингридиенте при редактировании на форму
    /// </summary>
    /// <param name="id"></param>
        /// <returns>id ингридиента,имя,калории и т.д</returns>
        public class_ingridients get_ingr(int id)
        {
            class_ingridients ingrid = new class_ingridients();
            string query = "select * from Ingridients where Id_ingridients=";
            query += id.ToString();
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    ingrid.result = "OK";
                    ingrid.ingr_id = id.ToString();
                    ingrid.name = rd.GetString(0);

                    if (rd.IsDBNull(2))
                    {
                        ingrid.uglevod = "";
                    }
                    else
                    {
                        ingrid.uglevod = rd.GetDouble(2).ToString();
                    }

                    if (rd.IsDBNull(1))
                    {
                        ingrid.calories = "";
                    }
                    else
                    {
                        ingrid.calories = rd.GetDouble(1).ToString();
                    }

                    if (rd.IsDBNull(3))
                    {
                        ingrid.zhiri = "";
                    }
                    else
                    {
                        ingrid.zhiri = rd.GetDouble(3).ToString();
                    }

                    if (rd.IsDBNull(4))
                    {
                        ingrid.protein = "";
                    }
                    else
                    {
                        ingrid.protein = rd.GetDouble(4).ToString();
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                ingrid.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return ingrid;
        }


        public void apply_changes(string table_name)
        {
            Program.data_module._da.Update(Program.data_module._ds, table_name);
        }

        //------------------------------------------------------------------------------------
        //удаляет запись из таблицы по указанному ИД ингридиента и блюда
        public string del_record_by_ingr_id(string table_name, string id_name, int ingr_id, int food_id)
        {
            string query = "delete from ";
            query += table_name;
            query += " where (";
            query += id_name;
            query += " = '";
            query += ingr_id.ToString();
            query += "') and (ID_food = '" + food_id + "')";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR" + " " + ex.Message + " " + ex.Data);
            }

            return "OK";
        }
        //------------------------------------------------------------------------------------

        public string del_record_by_diet_id(string table_name, string id_name, int food_id, int diet_id, int card_id)
        {
            string query = "delete from ";
            query += table_name;
            query += " where (";
            query += id_name;
            query += " = '";
            query += food_id.ToString();
            query += "') and (ID_Diets = '" + diet_id + "') and ( Id_Cards = '" + card_id + "' )";

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR" + " " + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //удаляет запись из таблицы в базе данных, по указанному имена таблицы и идентификатору записи
        public string del_record_by_id(string table_name, string id_name, int id)
        {
            string query = "";
            query += "delete from ";
            query += table_name;
            query += " where ";
            query += id_name;
            query += " = ";
            query += id.ToString();

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR" + " " + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //добавляет карту
        public string add_card(string food_name, string cost, string method, string card_numb)
        {
            this._command_text = "insert into Cards";
            this._command_text += "(ID_food, Cost, Method_of_cooking, Number_card) ";
            this._command_text += "values(";

            if (food_name == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "(select ID_food from Foods where Name_food ='" + food_name;
                this._command_text += "'),";
            }

            if (cost == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'";
                this._command_text += cost;
                this._command_text += "',";
            }


            if (method == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "'";
                this._command_text += method;
                this._command_text += "',";
            }

            if (card_numb == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "'";
                this._command_text += card_numb;
                this._command_text += "')";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись о карте
        public string upd_card(int card_id, int food_id, string food_name, string cost, string method, string card_numb)
        {
            string query = "update Cards set ";
            query += "ID_food=";
            if (food_id.ToString() == "") { query += "null,"; }
            else
            {
                query += "(select ID_food from Foods where Name_food = '" + food_name + "'),";
            }

            query += "Cost = ";
            if (cost == "") { query += "null, "; }
            else
            {
                query += "'";
                query += cost;
                query += "', ";
            }

            query += "Method_of_cooking=";
            if (method == "") { query += "null, "; }
            else
            {
                query += "'";
                query += method;
                query += "', ";
            }

            query += "Number_Card=";
            if (card_numb == "") { query += "null) "; }
            else
            {
                query += "'";
                query += card_numb;
                query += "' ";
            }

            query += "where Id_Cards = '" + card_id + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        // возвращает карту по указанному в параметрах идентификатору (коду)
        public class_card get_card(int card_id, string food_name)
        {
            class_card card = new class_card();
            string query = "Select C.Id_Cards, F.Name_food, C.Cost, C.Method_of_cooking, C.Number_Card "
                           + "From Cards C "
                           + "join Foods F on F.ID_food = C.ID_food ";
            query += "where C.Id_Cards = '" + card_id + "' and F.Name_food = '" + food_name.ToString() + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    card.result = "OK";
                    card.card_id = card_id.ToString();
                    card.food_name = rd.GetString(1);

                    if (rd.IsDBNull(2))
                    {
                        card.cost = "";
                    }
                    else
                    {
                        card.cost = rd.GetDecimal(2).ToString();
                    }
                    if (rd.IsDBNull(3))
                    {
                        card.method = "";
                    }
                    else
                    {
                        card.method = rd.GetString(3);
                    }
                    if (rd.IsDBNull(4))
                    {
                        card.card_numb = "";
                    }
                    else
                    {
                        card.card_numb = rd.GetString(4);
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                card.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return card;
        }

        //возвращает блюдо по указанному в параметрах идентификатору (коду)
        public class_card[] get_list_food_name_in_card()
        {
            class_card[] food = new class_card[512];
            string query = "Select Name_food, ID_food from Foods";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    food[i] = new class_card();
                    food[i].result = "OK";
                    food[i].food_id = rd.GetInt32(1).ToString();
                    food[i].food_name = rd.GetString(0);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                food[1].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return food;
        }

        //добавляет запись о блюде в базу данных
        public string add_food(string name, string calories, string proteins, string fats, string carbo, string weight)
        {
            this._command_text = "insert into Foods";
            this._command_text += "(Name_food, Full_calories, TotalProteins, TotalFats, TotalCarbohydrates, Finish_weight_of_food) ";
            this._command_text += "values(";

            //this._command_text += name == "" ? "null, " : "'" + name + "',";

            if (name == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'";
                this._command_text += name;
                this._command_text += "',";
            }

            if (calories == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += calories;
                this._command_text += "',";
            }

            if (proteins == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += proteins;
                this._command_text += "',";
            }

            if (fats == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += fats;
                this._command_text += "',";
            }

            if (carbo == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += carbo;
                this._command_text += "',";
            }

            if (weight == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += " '";
                this._command_text += weight;
                this._command_text += "')";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись (данные) о блюде в базе данных
        public string upd_food(int id, string name, string calories, string proteins, string fats, string carbo, string weight)
        {
            string query = "update Foods set ";
            query += "Name_food=";
            if (name == "") { query += "null, "; }
            else
            {
                query += "'";
                query += name;
                query += "', ";
            }

            query += "Full_calories=";
            if (calories == "") { query += "null, "; }
            else
            {
                query += "'";
                query += calories;
                query += "', ";
            }

            query += "TotalProteins=";
            if (proteins == "") { query += "null, "; }
            else
            {
                query += "'";
                query += proteins;
                query += "', ";
            }

            query += "TotalFats=";
            if (fats == "") { query += "null, "; }
            else
            {
                query += "'";
                query += fats;
                query += "', ";
            }

            query += "TotalCarbohydrates=";
            if (carbo == "") { query += "null, "; }
            else
            {
                query += "'";
                query += carbo;
                query += "', ";
            }

            query += "Finish_weight_of_food=";
            if (weight == "null") { query += "null,"; }
            else
            {
                query += "'";
                query += weight;
                query += "' ";
            }

            query += "where ID_food=";
            query += id.ToString();

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //возвращает блюдо по указанному в параметрах идентификатору (коду)
        public class_food get_food(int id)
        {
            class_food food = new class_food();
            string query = "select * from Foods where ID_food=";
            query += id.ToString();
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    food.result = "OK";
                    food.food_id = id.ToString();
                    food.name = rd.GetString(1);
                    if (rd.IsDBNull(2))
                    {
                        food.calories = "";
                    }
                    else
                    {
                        food.calories = rd.GetDouble(2).ToString();
                    }
                    if (rd.IsDBNull(3))
                    {
                        food.proteins = "";
                    }
                    else
                    {
                        food.proteins = rd.GetDouble(3).ToString();
                    }
                    if (rd.IsDBNull(4))
                    {
                        food.fats = "";
                    }
                    else
                    {
                        food.fats = rd.GetDouble(4).ToString();
                    }
                    if (rd.IsDBNull(5))
                    {
                        food.carbo = "";
                    }
                    else
                    {
                        food.carbo = rd.GetDouble(5).ToString();
                    }
                    if (rd.IsDBNull(6))
                    {
                        food.weight = "";
                    }
                    else
                    {
                        food.weight = rd.GetDouble(6).ToString();
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                food.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return food;
        }


        //добавляет запись о диете в базу данных
        public string add_diet(string numbDiet, string description)
        {
            this._command_text = "insert into Diets";
            this._command_text += "(NumOfDiet, Description) ";
            this._command_text += "values(";

            if (numbDiet == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += numbDiet;
                this._command_text += "',";
            }

            if (description == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += " '";
                this._command_text += description;
                this._command_text += "')";
            }


            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись (данные) о диете в базе данных
        public string upd_diet(int id, string numbDiet, string description)
        {
            string query = "update Diets set ";
            query += "NumOfDiet=";
            if (numbDiet == "") { query += "null, "; }
            else
            {
                query += "'";
                query += numbDiet;
                query += "', ";
            }

            query += "Description=";
            if (description.Length == 0) { query += "null "; }
            else
            {
                query += "'";
                query += description;
                query += "' ";
            }

            query += "where ID_Diets=";
            query += id.ToString();

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //возвращает диету по указанному в параметрах идентификатору (коду)
        public class_diet get_diet(int id)
        {
            class_diet diet = new class_diet();
            string query = "select * from Diets where ID_Diets=";
            query += id.ToString();
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    diet.result = "OK";
                    diet.diet_id = id.ToString();
                    diet.numbDiet = rd.GetString(1);
                    if (rd.IsDBNull(2))
                    {
                        diet.description = "";
                    }
                    else
                    {
                        diet.description = rd.GetString(2);
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                diet.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return diet;
        }

        //добавляет запись о справочнике в базу данных
        public string add_book(string author, string year, string name)
        {
            this._command_text = "insert into Book";
            this._command_text += "(Author, Year, Name) ";
            this._command_text += "values(";

            if (author == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'";
                this._command_text += author;
                this._command_text += "',";
            }

            if (year == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += year;
                this._command_text += "',";
            }

            if (name == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += " '";
                this._command_text += name;
                this._command_text += "')";
            }            

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись (данные) о справочнике в базе данных
        public string upd_book(int id, string author, string year, string name)
        {
            string query = "update Book set ";
            query += "Author=";
            if (author == "") { query += "null, "; }
            else
            {
                query += "'";
                query += author;
                query += "', ";
            }

            query += "Year=";
            if (year == "") { query += "null, "; }
            else
            {
                query += "'";
                query += year;
                query += "', ";
            }

            query += "Name=";
            if (name == "") { query += "null"; }
            else
            {
                query += "'";
                query += name;
                query += "'";
            }

            query += "where IDBook=";
            query += id.ToString();

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //возвращает справочник по указанному в параметрах идентификатору (коду)
        public class_book get_book(int id)
        {
            class_book book = new class_book();
            string query = "select * from Book where IDBook=";
            query += id.ToString();
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    book.result = "OK";
                    book.book_id = id.ToString();
                    book.author = rd.GetString(1);
                    if (rd.IsDBNull(2))
                    {
                        book.year = "";
                    }
                    else
                    {
                        book.year = rd.GetString(2);
                    }
                    if (rd.IsDBNull(3))
                    {
                        book.name = "";
                    }
                    else
                    {
                        book.name = rd.GetString(3);
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                book.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return book;
        }

        //добавляет ингридиент в блюдо
        public string add_ingr_in_food(string food_name, string gross, string net, string name_ingr)
        {
            this._command_text = "insert into Ingridients_in_food";
            this._command_text += "(ID_food, Gross_weight, Net_weight, Id_ingridients) ";
            this._command_text += "values(";

            if (food_name.ToString() == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "(select ID_food from Foods where Name_food ='" + food_name;
                this._command_text += "'), ";
            }
            
            if (gross == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += gross;
                this._command_text += "',";
            }

            if (net == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += net;
                this._command_text += "',";
            }

            if (name_ingr == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += "(select Id_ingridients from Ingridients where ingridient_name ='" + name_ingr;
                this._command_text += "'))";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись о ингридиенте в блюде
        public string upd_ingr_in_food(int ingr_id, string food_name, string gross, string net, string name_ingr, string ingr_old)
        {
            string query = "update Ingridients_in_food set ";
            query += "Gross_weight=";
            if (gross == "") { query += "null, "; }
            else
            {
                query += "'";
                query += gross;
                query += "', ";
            }

            query += "Net_weight=";
            if (net == "") { query += "null,"; }
            else
            {
                query += "'";
                query += net;
                query += "', ";
            }

            query += "Id_ingridients=";
            if (ingr_id.ToString() == "") { query += "null"; }
            else
            {
                query += "(select Id_ingridients from Ingridients where ingridient_name = '" + name_ingr + "')";
            }

            query += "where Id_ingridients = (select Id_ingridients from Ingridients where ingridient_name = '" + ingr_old + "') ";
            query += "and ID_food = (select ID_food from Foods where Name_food = '" + food_name + "')";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        // возвращает ингридиент в блюде по указанному в параметрах идентификатору (коду)
        public class_ingr_in_food get_ingr_in_food(string ingr_name,string food_name)
        {
            class_ingr_in_food ingr_in_food = new class_ingr_in_food();
            string query = "Select  F.Name_food, I.ingridient_name, IIF.Gross_weight, IIF.Net_weight, IIF.Id_ingridients "
                            + "From Ingridients_in_food IIF join Ingridients I on "
                            + "IIF.Id_ingridients = I.Id_ingridients "
                            + "join Foods F on  F.ID_food = IIF.ID_food ";
            query += "where I.ingridient_name = '" + ingr_name.ToString() +"'"+ "and F.Name_food='"+ food_name.ToString()+"'"; ;
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    ingr_in_food.result = "OK";
                    ingr_in_food.ingr_name = ingr_name.ToString();
                    ingr_in_food.food_name = rd.GetString(0);

                    if (rd.IsDBNull(2))
                    {
                        ingr_in_food.gross = "";
                    }
                    else
                    {
                        ingr_in_food.gross = rd.GetDouble(2).ToString();
                    }
                    if (rd.IsDBNull(3))
                    {
                        ingr_in_food.net = "";
                    }
                    else
                    {
                        ingr_in_food.net = rd.GetDouble(3).ToString();
                    }
                    if (rd.IsDBNull(4))
                    {
                        ingr_in_food.ingr_id = "";
                    }
                    else
                    {
                        ingr_in_food.ingr_id = rd.GetInt32(4).ToString();
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                ingr_in_food.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return ingr_in_food;
        }
        // возвращает ингридиент по указанному в параметрах идентификатору (коду)
        public class_ingr_in_food[] get_list_ingr_id()
        {
            class_ingr_in_food[] ingr = new class_ingr_in_food[512];
            string query = "Select ingridient_name, Id_ingridients from Ingridients";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    ingr[i] = new class_ingr_in_food();
                    ingr[i].result = "OK";
                    ingr[i].id_ingr = rd.GetInt32(1).ToString();
                    ingr[i].ingr_name = rd.GetString(0);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                ingr[1].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return ingr;
        }
        //возвращает блюдо по указанному в параметрах идентификатору (коду)
        public class_ingr_in_food[] get_list_food_id()
        {
            class_ingr_in_food[] id_food = new class_ingr_in_food[512];
            string query = "Select Name_food, ID_food from Foods";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    id_food[i] = new class_ingr_in_food();
                    id_food[i].result = "OK";
                    id_food[i].id_food = rd.GetInt32(1).ToString();
                    id_food[i].food_name = rd.GetString(0);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                id_food[1].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return id_food;
        }

        //добавляет запись о очереди в базу данных
        public string add_queue(string season, string numb_men, string start, string end)
        {
            this._command_text = "insert into Queue";
            this._command_text += "(Season, Number_of_mens, Starting_date, Ending_date) ";
            this._command_text += "values(";

            if (season == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'";
                this._command_text += season;
                this._command_text += "',";
            }

            if (numb_men == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += numb_men;
                this._command_text += "',";
            }

            if (start == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += start;
                this._command_text += "',";
            }

            if (end == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += " '";
                this._command_text += end;
                this._command_text += "')";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись (данные) о очереди в базе данных
        public string upd_queue(int id, string season, string numb_men, string start, string end)
        {
            string query = "update Queue set ";
            query += "Season=";
            if (season == "") { query += "null, "; }
            else
            {
                query += "'";
                query += season;
                query += "', ";
            }

            query += "Number_of_mens=";
            if (numb_men == "") { query += "null, "; }
            else
            {
                query += "'";
                query += numb_men;
                query += "', ";
            }

            query += "Starting_date=";
            if (start == "") { query += "null"; }
            else
            {
                query += "'";
                query += start;
                query += "',";
            }

            query += "Ending_date=";
            if (end == "") { query += "null"; }
            else
            {
                query += "'";
                query += end;
                query += "'";
            }

            query += "where ID_queue=";
            query += id.ToString();

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //возвращает очередь по указанному в параметрах идентификатору (коду)
        public class_queue get_queue(int id)
        {
            class_queue queue = new class_queue();
            string query = "select * from Queue where ID_queue=";
            query += id.ToString();
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    queue.result = "OK";
                    queue.queue_id = id.ToString();
                    queue.season = rd.GetString(1);
                    if (rd.IsDBNull(2))
                    {
                        queue.numb_men = "";
                    }
                    else
                    {
                        queue.numb_men = rd.GetInt32(2).ToString();
                    }
                    if (rd.IsDBNull(3))
                    {
                        queue.start = "";
                    }
                    else
                    {
                        queue.start = rd.GetDateTime(3).ToString("dd.MM.yyyy");
                    }
                    if (rd.IsDBNull(4))
                    {
                        queue.end = "";
                    }
                    else
                    {
                        queue.end = rd.GetDateTime(4).ToString("dd.MM.yyyy");
                    }
                    if (rd.IsDBNull(5))
                    {
                        queue.length = "";
                    }
                    else
                    {
                        queue.length = rd.GetInt32(5).ToString();
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                queue.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return queue;
        }

        //добавляет ингридиент в блюдо
        public string add_diet_in_food(string card_numb, string food_name, string diet_numb)
        {
            this._command_text = "insert into Food_In_Diets";
            this._command_text += "(Id_Cards, ID_food, ID_Diets) ";
            this._command_text += "values(";

            if (card_numb == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "(select Id_Cards from Cards where Number_Card ='" + card_numb;
                this._command_text += "'),";
            }

            if (food_name == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "(select ID_Food from Foods where Name_Food ='" + food_name;
                this._command_text += "'),";
            }


            if (diet_numb == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += "(select ID_Diets from Diets where NumOfDiet ='" + diet_numb;
                this._command_text += "'))";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return (ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        //модифицирует запись о диете в блюде
        public string upd_diet_in_food(int food_id, int diet_id, int card_id, string food_name, string diet_numb, string card_numb, string food_old, string diet_old, string card_old)
        {
            string query = "update Food_In_Diets set ";
            query += "Id_Cards=";
            if (card_id.ToString() == "") { query += "null,"; }
            else
            {
                query += "(select Id_Cards from Cards where Number_Card = '" + card_numb + "'),";
            }

            query += "ID_food=";
            if (food_id.ToString() == "") { query += "null,"; }
            else
            {
                query += "(select ID_food from Foods where Name_food = '" + food_name + "'),";
            }

            query += "ID_Diets =";
            if (diet_id.ToString() == "") { query += "null"; }
            else
            {
                query += "(select ID_Diets from Diets where NumOfDiet = '" + diet_numb + "')";
            }

            query += " where Id_Cards = (select Id_Cards from Cards where Number_Card = '" + card_old + "') ";
            query += "and ID_food = (select ID_food from Foods where Name_food = '" + food_old + "') ";
            query += "and ID_Diets = (select ID_DIets from Diets where NumOfDiet = '" + diet_old + "')";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch (Exception ex)
            {
                return ("ERROR_" + ex.Message + " " + ex.Data);
            }

            return "OK";
        }

        // возвращает диету в блюде по указанному в параметрах идентификатору (коду)
        public class_diet_in_food get_diet_in_food(string food_name, string diet_numb, string card_numb)
        {
            class_diet_in_food diet_in_food = new class_diet_in_food();
            string query = "Select F.Name_food, D.NumOfDiet, C.Number_Card, FID.ID_food "
                            + "From Food_In_Diets FID "
                            + "join Diets D on D.ID_Diets = FID.ID_Diets "
                            + "join Cards C on C.ID_food = FID.ID_food "
                            + "join Foods F on F.ID_food = FID.ID_food ";
            query += "where F.Name_food = '" + food_name.ToString() + "'" + "and D.NumOfDiet = '" + diet_numb.ToString() + "' and C.Number_Card = '" + card_numb.ToString() + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    diet_in_food.result = "OK";
                    diet_in_food.food_name = food_name.ToString();
                    diet_in_food.diet_numb = rd.GetString(1);

                    if (rd.IsDBNull(2))
                    {
                        diet_in_food.card_numb = "";
                    }
                    else
                    {
                        diet_in_food.card_numb = rd.GetString(2);
                    }
                    if (rd.IsDBNull(3))
                    {
                        diet_in_food.food_id = "";
                    }
                    else
                    {
                        diet_in_food.food_id = rd.GetInt32(3).ToString();
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                diet_in_food.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return diet_in_food;
        }

        public class_diet_in_food[] get_list_diet_id()
        {
            class_diet_in_food[] diet = new class_diet_in_food[512];
            string query = "Select NumOfDiet, ID_Diets from Diets";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    diet[i] = new class_diet_in_food();
                    diet[i].result = "OK";
                    diet[i].diet_id = rd.GetInt32(1).ToString();
                    diet[i].diet_numb = rd.GetString(0);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                diet[1].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return diet;
        }

        //возвращает блюдо по указанному в параметрах идентификатору (коду)
        public class_diet_in_food[] get_list_food_name()
        {
            class_diet_in_food[] food = new class_diet_in_food[512];
            string query = "Select Name_food, ID_food from Foods";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    food[i] = new class_diet_in_food();
                    food[i].result = "OK";
                    food[i].food_id = rd.GetInt32(1).ToString();
                    food[i].food_name = rd.GetString(0);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                food[1].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return food;
        }

        //возвращает карту по указанному в параметрах идентификатору (коду)
        public class_diet_in_food[] get_list_card_id()
        {
            class_diet_in_food[] card = new class_diet_in_food[512];
            string query = "Select Number_Card, Id_Cards from Cards";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    card[i] = new class_diet_in_food();
                    card[i].result = "OK";
                    card[i].card_id = rd.GetInt32(1).ToString();
                    card[i].card_numb = rd.GetString(0);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                card[1].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return card;
        }
    }
}
