using System;
using System.Windows.Forms;
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

        /// <summary>
    /// Принять изменения
    /// </summary>
    /// <param name="table_name"></param>
        public void apply_changes(string table_name)
        {
            Program.data_module._da.Update(Program.data_module._ds, table_name);
        }

        /// <summary>
        ///  удаляет запись из таблицы по указанному ИД ингридиента и блюда
        /// </summary>
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

    /// <summary>
    /// Удаляет блюдо из меню
    /// </summary>
    /// <param name="table_name"></param>
    /// <param name="id_name"></param>
    /// <param name="ingr_id"></param>
    /// <param name="food_id"></param>
    /// <returns></returns>
        public string del_food_menu(string table_name, int food, string serve)
        {
            string query = "delete from ";
            query += table_name;
            query += " where (ID_food = '" + food + "') and (Serve_time_of_food = '" + serve + "')";

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

        /// <summary>
    /// Удаляет блюдо из кулинарного справочника
    /// </summary>
    /// <param name="table_name"></param>
    /// <param name="id_name"></param>
    /// <param name="card_id"></param>
    /// <param name="food_id"></param>
    /// <param name="book_id"></param>
    /// <returns></returns>
        public string del_record_by_food_id(string table_name, string id_name, int card_id, int food_id, int book_id)
        {
            string query = "delete from ";
            query += table_name;
            query += " where (";
            query += id_name;
            query += " = '";
            query += book_id.ToString();
            query += "') and (ID_Cards = '" + card_id + "') and ( ID_Food = '" + food_id + "' )";

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

        /// <summary>
       ///  удаляет запись из таблицы в базе данных, по указанному имена таблицы и идентификатору записи
    /// </summary>
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

        /// <summary>
        /// добавляет карту
       /// </summary>
       /// <param name="food_name"></param>
       /// <param name="cost"></param>
       /// <param name="method"></param>
       /// <param name="card_numb"></param>
       /// <returns></returns>
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
                MessageBox.Show("Для данного блюда уже определена карточка - раскладка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "OK";
        }

        /// <summary>
        /// модифицирует запись о карте
        /// </summary>
        /// <param name="card_id"></param>
        /// <param name="food_id"></param>
        /// <param name="food_name"></param>
        /// <param name="cost"></param>
        /// <param name="method"></param>
        /// <param name="card_numb"></param>
        /// <returns></returns>
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
        public class_card get_card(string food_name)
        {
            class_card card = new class_card();
            string query = "Select C.Id_Cards, F.Name_food, C.Cost, C.Method_of_cooking, C.Number_Card "
                           + "From Cards C "
                           + "join Foods F on F.ID_food = C.ID_food ";
            query += "where F.Name_food = '" + food_name + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    card.result = "OK";
                    card.food_name = rd.GetString(1);

                    if (rd.IsDBNull(2))
                    {
                        card.cost = "";
                    }
                    else
                    {
                        card.cost = rd.GetSqlMoney(2).ToString();
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

        /// <summary>
        /// возвращает блюдо по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <returns></returns>
        public class_card[] get_list_food_name_in_card()
        {
            class_card[] food = new class_card[512];
            string query = "Select Name_food, ID_food from Foods "
                         + "where ID_food not in "
                        + "(select ID_food from Cards)";
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

        /// <summary>
        /// добавляет запись о блюде в базу данных
        /// </summary>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbo"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
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

        /// <summary>
        /// модифицирует запись (данные) о блюде в базе данных
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbo"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
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

            query += "where ID_food= '" + id.ToString() + "'";

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
        /// возвращает блюдо по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// добавляет запись о диете в базу данных
        /// </summary>
        /// <param name="numbDiet"></param>
        /// <param name="description"></param>
        /// <returns></returns>
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

        /// <summary>
        /// модифицирует запись (данные) о диете в базе данных
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numbDiet"></param>
        /// <param name="description"></param>
        /// <returns></returns>
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

        /// <summary>
        /// возвращает диету по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// добавляет запись о справочнике в базу данных
        /// </summary>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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
                MessageBox.Show("Поле:'Год выпуска' должно содержать только цифры","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            return "OK";
        }

        /// <summary>
        /// модифицирует запись (данные) о справочнике в базе данных
        /// </summary>
        /// <param name="id"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// возвращает справочник по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        book.year = rd.GetInt32(2).ToString();
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

        /// <summary>
        /// добавляет ингридиент в блюдо
        /// </summary>
        /// <param name="food_name"></param>
        /// <param name="gross"></param>
        /// <param name="net"></param>
        /// <param name="name_ingr"></param>
        /// <returns></returns>
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
                MessageBox.Show("Ингредиент уже содержится в блюде!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "OK";
        }

        /// <summary>
        /// модифицирует запись о ингридиенте в блюде
        /// </summary>
        /// <param name="ingr_id"></param>
        /// <param name="food_name"></param>
        /// <param name="gross"></param>
        /// <param name="net"></param>
        /// <param name="name_ingr"></param>
        /// <param name="ingr_old"></param>
        /// <returns></returns>
        public string upd_ingr_in_food(int ingr_id, string food_name, string gross, string net, string name_ingr, string ingr_old,string food_ID)
        {
                       
            string  query = "update Ingridients_in_food set ";
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


        public string upd_food_( string food_name, int food_ID)
        {

            string query = "update Foods set Name_food ='" + food_name + "'" + " from Foods where   ID_food ='" + food_ID + "'";
                        
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

        public string upd_login(string login, int ID)
        {

            string query = "update Users set Login ='" + login + "'" + " from Users  where  IDPost ='" + ID + "'";

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
        /// возвращает ингридиент в блюде по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="ingr_name"></param>
        /// <param name="food_name"></param>
        /// <returns></returns>
         public class_ingr_in_food get_ingr_in_food(string ingr_name,string food_name)
        {
            class_ingr_in_food ingr_in_food = new class_ingr_in_food();
            string query = "Select  F.Name_food, F.ID_food,I.ingridient_name, IIF.Gross_weight, IIF.Net_weight, IIF.Id_ingridients "
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
                    ingr_in_food.id_food = rd.GetInt32(1).ToString();

                    if (rd.IsDBNull(3))
                    {
                        ingr_in_food.gross = "";
                    }
                    else
                    {
                        ingr_in_food.gross = rd.GetDouble(3).ToString();
                    }
                    if (rd.IsDBNull(4))
                    {
                        ingr_in_food.net = "";
                    }
                    else
                    {
                        ingr_in_food.net = rd.GetDouble(4).ToString();
                    }
                    if (rd.IsDBNull(5))
                    {
                        ingr_in_food.ingr_id = "";
                    }
                    else
                    {
                        ingr_in_food.ingr_id = rd.GetInt32(5).ToString();
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

     
        /// <summary>
         ///  возвращает ингридиент по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <returns></returns>
        public class_ingr_in_food[] get_list_ingr_id(int _id_food)
        {
            class_ingr_in_food[] ingr = new class_ingr_in_food[512];
            string query = "select I.Id_ingridients, I.ingridient_name from Ingridients I "
                         + "where I.Id_ingridients not in "
                         + "(select Id_ingridients from Ingridients_in_food IIF "
                         + "join Foods F on IIF.ID_food = F.ID_food "
                         + "where F.ID_food = '" + _id_food +"')";
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
                    ingr[i].id_ingr = rd.GetInt32(0).ToString();
                    ingr[i].ingr_name = rd.GetString(1);
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
      
        /// <summary>
    /// возвращает блюдо по указанному в параметрах идентификатору (коду)
    /// </summary>
    /// <returns></returns>
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

        /// <summary>
        /// добавляет запись о очереди в базу данных
        /// </summary>
        /// <param name="season"></param>
        /// <param name="numb_men"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string add_queue(string numb_men, string numb_queue, string start, string end)
        {
            this._command_text = "insert into Queue";
            this._command_text += "(Number_of_mens, Number_queue, Starting_date, Ending_date) ";
            this._command_text += "values(";

            if (numb_men == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += numb_men;
                this._command_text += "',";
            }

            if (numb_queue == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += numb_queue;
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

        /// <summary>
        /// модифицирует запись (данные) о очереди в базе данных
        /// </summary>
        /// <param name="id"></param>
        /// <param name="season"></param>
        /// <param name="numb_men"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string upd_queue(int id, string numb_men, string numb_queue, string start, string end)
        {
            string query = "update Queue set ";
            query += "Number_of_mens=";
            if (numb_men == "") { query += "null, "; }
            else
            {
                query += "'";
                query += numb_men;
                query += "', ";
            }

              query += "Number_queue=";
            if (numb_queue == "") { query += "null, "; }
            else
            { 
                query += "'";
                query += numb_queue;
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

        /// <summary>
        /// возвращает очередь по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    if (rd.IsDBNull(1))
                    {
                        queue.numb_men = "";
                    }
                    else
                    {
                        queue.numb_men = rd.GetInt32(1).ToString();
                    }
                    if (rd.IsDBNull(2))
                    {
                        queue.start = "";
                    }
                    else
                    {
                        queue.start = rd.GetDateTime(2).ToString("dd.MM.yyyy");
                    }
                    if (rd.IsDBNull(3))
                    {
                        queue.end = "";
                    }
                    else
                    {
                        queue.end = rd.GetDateTime(3).ToString("dd.MM.yyyy");
                    }
                    if (rd.IsDBNull(4))
                    {
                        queue.length = "";
                    }
                    else
                    {
                        queue.length = rd.GetInt32(4).ToString();
                    }
                    if (rd.IsDBNull(5))
                    {
                        queue.numb_queue = "";
                    }
                    else
                    {
                        queue.numb_queue = rd.GetString(5);
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

        /// <summary>
        /// добавляет ингридиент в блюдо
        /// </summary>
        /// <param name="card_numb"></param>
        /// <param name="food_name"></param>
        /// <param name="diet_numb"></param>
        /// <returns></returns>
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
                //MessageBox.Show("Выберите блюдо!","Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "OK";
        }

    /// <summary>
    /// Возвращает помер диеты и id
    /// </summary>
    /// <returns></returns>
        public class_diet_in_food[] get_list_diet_id(int _id_food)
        {
            class_diet_in_food[] diet = new class_diet_in_food[512];
            string query = "select NumOfDiet, ID_Diets from Diets "
                         + "where ID_Diets not in "
                         + "(select ID_Diets from Food_In_Diets "
                         + "where ID_food = '" + _id_food + "')";
                         
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

        /// <summary>
        /// Возвращает номер диеты и id для редактировани диеты в блюде
        /// </summary>
        /// <returns></returns>
        public class_diet_in_food[] get_list_diet(int _id_card)
        {
            class_diet_in_food[] diet = new class_diet_in_food[512];
            string query = "select NumOfDiet, ID_Diets from Diets "
                         + "where ID_Diets not in "
                         + "(select ID_Diets from Food_In_Diets FID "
                         + "join Cards C on C.Id_Cards = FID.Id_Cards "
                         + "where C.Id_Cards = '" + _id_card + "')";

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

        /// <summary>
        /// возвращает блюдо по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <returns></returns>
        public class_diet_in_food[] get_list_food_name()
        {
            class_diet_in_food[] food = new class_diet_in_food[512];
            string query = "select distinct F.Name_food, F.ID_food from Foods F "
                         + "where F.ID_food in (select ID_food from Cards) "
                         + "and (select COUNT(ID_Diets) from Food_In_Diets FID where FID.ID_food = F.ID_food) < (select COUNT(ID_Diets) from Diets) "
                         + "group by F.Name_food, F.ID_food";
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

        /// <summary>
        /// возвращает карту по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <returns></returns>
        public class_diet_in_food get_list_card_id(int food_id)
        {
            class_diet_in_food card = new class_diet_in_food();
            string query = "select Number_Card, Id_Cards from Cards C "
                         + "join Foods F on F.ID_food = C.ID_food "
                         + "where F.ID_food = '" + food_id + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    card = new class_diet_in_food();
                    card.result = "OK";
                    card.card_id = rd.GetInt32(1).ToString();
                    card.card_numb = rd.GetString(0);
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

        //добавляет сотрудника
        public string add_person(string surname, string name, string secname, string post)
        {
            this._command_text = "insert into Person";
            this._command_text += "(Surname, Name, Secondname, Post) ";
            this._command_text += "values(";

            if (surname == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'" + surname + "', ";
            }

            if (name == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'" + name + "', ";
            }

            if (secname == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "'" + secname + "', ";
            }

            if (post == "")
            { this._command_text += "null"; this._command_text += ") "; }
            else
            {
                this._command_text += "'" + post + "') ";
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

        //модифицирует сотрудника
        public string upd_person(int post_id, string surname, string name, string secname, string post)
        {
            string query = "update Person set ";
            query += "Surname=";
            if (surname == "") { query += "null, "; }
            else
            {
                query += "'" + surname + "', ";
            }

            query += "Name =";
            if (name == "") { query += "null, "; }
            else
            {
                query += "'" + name + "', ";
            }

            query += "Secondname =";
            if (secname == "") { query += "null, "; }
            else
            {
                query += "'" + secname + "', ";
            }

            query += "Post =";
            if (post == "") { query += "null "; }
            else
            {
                query += "'" + post + "' ";
            }

            query += "where IDPost = '" + post_id + "'";
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

        // возвращает сотрудника по указанному в параметрах идентификатору (коду)
        public class_person get_person(int post_id)
        {
            class_person person = new class_person();
            string query = "select Surname, Name, Secondname, Post, IDPost "
                            + "from Person ";
            query += "where IDPost = '" + post_id + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    person.result = "OK";
                    person.post_id = post_id.ToString();
                    person.surname = rd.GetString(0);

                    if (rd.IsDBNull(1))
                    {
                        person.name = "";
                    }
                    else
                    {
                        person.name = rd.GetString(1);
                    }
                    if (rd.IsDBNull(2))
                    {
                        person.secondname = "";
                    }
                    else
                    {
                        person.secondname = rd.GetString(2);
                    }
                    if (rd.IsDBNull(3))
                    {
                        person.post = "";
                    }
                    else
                    {
                        person.post = rd.GetString(3);
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                person.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return person;
        }

        //добавляет блюдо в справочник
        public string add_food_in_book(string card_numb, string food, string book, string author, string year)
        {
            this._command_text = "insert into FoodInBook";
            this._command_text += "(Id_Cards, ID_food, IDBook) ";
            this._command_text += "values(";

            if (card_numb == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "(select Id_Cards from Cards where Number_Card ='" + card_numb;
                this._command_text += "'),";
            }

            if (food == "")
            { this._command_text += "null"; this._command_text += ", "; }
            else
            {
                this._command_text += "(select ID_Food from Foods where Name_Food ='" + food;
                this._command_text += "'),";
            }


            if (book == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += "(select IDBook from Book where Name ='" + book + "' and Author = '" + author + "' and Year = '" + year;
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
                MessageBox.Show("Блюдо уже содержится в этом справочнике!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            return "OK";
        }

        // возвращает рецепт для блюда по указанному в параметрах идентификатору (коду)
        public food_in_book get_food_in_book(string food)
        {
            food_in_book food_in_book = new food_in_book();
            string query = "select C.Number_Card, F.Name_food, B.Name, FIB.IDBook "
                         + "from FoodInBook FIB "
                         + "join Cards C on C.Id_Cards = FIB.Id_Cards "
                         + "join Foods F on F.ID_food = FIB.ID_food "
                         + "join Book B on B.IDBook = FIB.IDBook ";
            query += "where F.Name_food = '" + food.ToString() + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    food_in_book.result = "OK";
                    food_in_book.food = rd.GetString(1);

                    if (rd.IsDBNull(0))
                    {
                        food_in_book.card = "";
                    }
                    else
                    {
                        food_in_book.card = rd.GetString(0);
                    }
                    if (rd.IsDBNull(2))
                    {
                        food_in_book.book = "";
                    }
                    else
                    {
                        food_in_book.book = rd.GetString(2);
                    }
                    if (rd.IsDBNull(3))
                    {
                        food_in_book.book_id = "";
                    }
                    else
                    {
                        food_in_book.book_id = rd.GetInt32(3).ToString();
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                food_in_book.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return food_in_book;
        }

        //получаем список блюд
        public food_in_book[] get_list_food_in_book_id(int _id_book)
        {
            food_in_book[] card = new food_in_book[512];
            string query = "select C.ID_food, F.Name_food from Cards C "
                         + "join Foods F on F.ID_food = C.ID_food "
                         + "where C.ID_food not in "
                         + "(select ID_food from FoodInBook "
                         + "where IDBook = '" + _id_book + "')";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    card[i] = new food_in_book();
                    card[i].result = "OK";
                    card[i].food_id = rd.GetInt32(0).ToString();
                    card[i].food = rd.GetString(1);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                card[0].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return card;
        }

    /// <summary>
    /// Создает запись меню для очереди
    /// </summary>
    /// <param name="numb_men"></param>
    /// <param name="numb_queue"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
        public string add_menu(string numb_queue)
        {
            this._command_text = "insert into Menu";
            this._command_text += "(ID_queue) ";
            this._command_text += "values(";

            if (numb_queue == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += "(select ID_queue from Queue Q where Q.Number_queue ='" + numb_queue + "'))";
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
                MessageBox.Show("Меню для этой очереди уже было создано!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return "OK";
        }

        /// <summary>
        /// возвращает меню для очереди
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public class_menu get_menu(string numb_queue)
        {
            class_menu menu = new class_menu();
            string query = "select Q.Number_queue, M.ID_queue, M.ID_menu "
                           + "from Menu M "
                           + "join Queue Q on Q.ID_queue = M.ID_queue "
                           + "where Q.Number_queue = '" + numb_queue + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    menu.result = "OK";
                    menu.queue_id = rd.GetString(1);

                    if (rd.IsDBNull(1))
                    {
                        menu.menu_id = "";
                    }
                    else
                    {
                        menu.menu_id = rd.GetInt32(2).ToString();
                    }
                    if (rd.IsDBNull(3))
                    {
                        menu.numb_queue = "";
                    }
                    else
                    {
                        menu.numb_queue = rd.GetString(3);
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                menu.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return menu;
        }

        /// <summary>
        /// возвращает список очередей
        /// </summary>
        /// <returns></returns>
        public class_queue[] get_numb_queue()
        {
            class_queue[] menu = new class_queue[512];
            string query = "select ID_queue, Number_queue from Queue "
                         + "where ID_queue not in "
                         + "(select ID_queue from Menu)";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    menu[i] = new class_queue();
                    menu[i].result = "OK";
                    menu[i].queue_id = rd.GetInt32(0).ToString();
                    menu[i].numb_queue = rd.GetString(1);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                menu[0].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return menu;
        }

        /// <summary>
        /// Создает запись о меню на день
        /// </summary>
        /// <param name="numb_queue"></param>
        /// <returns></returns>
        public string add_menu_in_day(string day, int menu_id)
        {
            this._command_text = "insert into Menu_in_day";
            this._command_text += "(date_menu, ID_menu) ";
            this._command_text += "values(";

            if (day == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "'" + day + "',";
            }
            if (menu_id.ToString() == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += "'" + menu_id + "')";
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
                MessageBox.Show("Меню для этой очереди уже было создано!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return "OK";
        }

        /// <summary>
        /// возвращает список меню-дней для очереди
        /// </summary>
        /// <param name="numb_queue"></param>
        /// <returns></returns>
        public class_menu_in_day get_menu_in_day(int day_id, string day)
        {
            class_menu_in_day menu = new class_menu_in_day();
            string query = "select day_id, day "
                           + "from Menu_in_day "
                           + "where day_id = '" + day_id + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    menu.result = "OK";
                    menu.day_id = rd.GetString(0);

                    if (rd.IsDBNull(1))
                    {
                        menu.day = "";
                    }
                    else
                    {
                        menu.day = rd.GetString(1);
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                menu.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return menu;
        }


    /// <summary>
    /// Создаёт запись о блюде в меню
    /// </summary>
    /// <param name="serve_time"></param>
    /// <param name="food"></param>
    /// <returns></returns>
        public string add_food_in_menu(string serve_time, int menu_id, int day_id, string food, string serve)
        {
            this._command_text = "insert into Food_in_menu";
            this._command_text += "(Serve_time_of_food, ID_menu, ID_food, day_id, count_serve ) ";
            this._command_text += "values(";

            if (serve_time == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "'" + serve_time + "',";
            }
            if (menu_id.ToString() == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "'" + menu_id + "',";
            }
            if (food.ToString() == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "(select ID_food from Foods where Name_food ='" + food + "'),";
            }
            if (day_id.ToString() == "")
            { this._command_text += "null"; this._command_text += ","; }
            else
            {
                this._command_text += "'" + day_id + "',";
            }
            if (serve == "")
            { this._command_text += "null"; this._command_text += ")"; }
            else
            {
                this._command_text += "'" + serve + "')";
            }

            try
            {
                class_food_in_menu[] menu = new class_food_in_menu[512];
                string query = "Select F.ID_food, MID.day_id, F.Name_food "
                             + "from Food_in_menu FIM "
                             + "join Foods F on F.ID_food = FIM.ID_Food "
                             + "join Menu_in_day MID on MID.day_id = FIM.day_id "
                             + "where Serve_time_of_food = '" + serve_time + "' and MID.day_id = '" + day_id +"'";
                    SqlCommand com = Program.data_module._conn.CreateCommand();
                    com.CommandText = query;
                    SqlDataReader rd = com.ExecuteReader();
                    int i = 0;
                    while (rd.Read())
                    {
                        i++;
                        menu[i] = new class_food_in_menu();
                        menu[i].result = "OK";
                        menu[i].food_id = rd.GetInt32(0).ToString();
                        menu[i].day_id = rd.GetInt32(1).ToString();
                        menu[i].food = rd.GetString(2);
                        if ((menu[i].food == food) && (menu[i].day_id == Convert.ToString(day_id)))
                        {
                            rd.Close();
                            rd.Dispose();
                            com.Dispose();
                        }
                        
                    }
                    rd.Close();
                    rd.Dispose();
                    com.Dispose();
                
                    com = Program.data_module._conn.CreateCommand();
                    com.CommandText = this._command_text;
                    com.ExecuteNonQuery();
                    com.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Это блюдо уже есть в меню!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return "OK";
        }

        public class_food_in_menu get_food_in_menu(string food)
        {
            class_food_in_menu food_in_menu = new class_food_in_menu();
            string query = "select F.Name_food "
                         + "from Food_in_menu FIM "
                         + "join Foods F on F.ID_food = FIM.ID_food";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    food_in_menu.result = "OK";

                    if (rd.IsDBNull(0))
                    {
                        food_in_menu.food = "";
                    }
                    else
                    {
                        food_in_menu.food = rd.GetString(0);
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                food_in_menu.result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return food_in_menu;
        }
        //возвращает карту по указанному в параметрах идентификатору (коду)
        public class_food_in_menu[] get_foodMenu(string serve_time, int day)
        {
            class_food_in_menu[] food_in_menu = new class_food_in_menu[512];
            string query = "Select F.ID_food, F.Name_food "
                         + "from Foods F "
                         + "where F.ID_food not in (select ID_food from Food_in_menu where Serve_time_of_food = '" + serve_time +"'"+ "and day_id='"+day+"'"+ ")";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    food_in_menu[i] = new class_food_in_menu();
                    food_in_menu[i].result = "OK";
                    food_in_menu[i].food_id = rd.GetInt32(0).ToString();
                    food_in_menu[i].food = rd.GetString(1);
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception ex)
            {
                food_in_menu[0].result = "ERROR_" + ex.Data + " " + ex.Message;
            }

            return food_in_menu;
        }

        public string add_password(class_person  ID, string login, string password, string role)
        {
            this._command_text = "insert into Users";
            this._command_text += "(IDPost,login,password,role) ";
            this._command_text += "values(";

            if (ID.post_id == "")
            { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += ID.post_id;
                this._command_text += "',";
            }

            if (login == "null")
            {
                { this._command_text += "null"; this._command_text += ", "; }
            }
            else
            {
                this._command_text += " '";
                this._command_text += login;
                this._command_text += "',";
            }

           

            if (password == "")
            { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += password;
                this._command_text += "',";
            }

            if (role == "")
            { this._command_text += ""; this._command_text += ", "; }
            else
            {
                this._command_text += " '";
                this._command_text += role;
                this._command_text += "')";
            }

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch
            {
                MessageBox.Show(" Указанный вами логин уже занят", "Внимание !", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

            return "OK";

        }
        public string upd_password(int ID, string login, string password, string role)
        {
            this._command_text = "update Users set ";
            string query = "";
             _command_text += "Login= ";
            if (login == ""){ query += "null, "; }
            {
                
                this._command_text += " '";
                this._command_text += login;
                this._command_text += "',";
            }


            _command_text += "Password= ";
            if (password == "") { query += "null, "; }
            
            else
            {
                this._command_text += " '";
                this._command_text += password;
                this._command_text += "',";
            }

            _command_text += "role= ";
              if (role == "") { query += "null, ";  }

              else
              {
                  this._command_text += " '";
                  this._command_text += role;
                  this._command_text += "'";
              }
            _command_text += " where IDPost= " +  ID.ToString();

            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = this._command_text;
                com.ExecuteNonQuery();
                com.Dispose();
            }

            catch
            {
                MessageBox.Show(" Указанный вами логин уже занят", "Внимание !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "OK";

        }

    }
}
