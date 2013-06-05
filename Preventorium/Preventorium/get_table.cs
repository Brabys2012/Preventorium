using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Preventorium
{
    class get_table
    {
        public DataSet _ds;
        public SqlDataAdapter _da;
        public string _command_text;
        /// <summary>
        /// Выполняет SQL запрос, который не возвращает никаких данных.
        /// </summary>
        /// <param name="sql_query">SQL запрос для выполнения.</param>
        /// <returns>Признак успешного выполнения запроса.</returns>
        public string SQL_Exec(string sql_query)
        {
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = sql_query;
                com.ExecuteNonQuery();
                com.Dispose();
            }
            catch (Exception ex)
            {
                return (string.Format("Error:'{0}'", ex.Message));
            }
            return "OK";
        }

        /// <summary>
        /// Метод содержит sql запрос на добавление значений в таблицу Ingridients
        /// </summary>
        public string add_ingr(string name, string callories, string carbohydrates, string fats, string proteins)
        {
            return SQL_Exec(string.Format("insert into Ingridients (ingridient_name, carbohydrates, fats, proteins) values ('{0}', {1}, {2}, {3})", name, carbohydrates, fats, proteins));
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
        public string upd_ingr(int id, string name, string calories, string carbohydrates, string fats, string proteins)
        {
            return SQL_Exec(string.Format("update Ingridients set ingridient_name = '{1}', calories = {2}, carbohydrates = {3}, fats = {4}, proteins = {5} where ID_ingridients = {0}", id, ((name.Length == 0) ? "NULL" : name), calories, carbohydrates, fats, proteins));
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
            return SQL_Exec(string.Format("delete from  {0} where ({1}= '{2}') and (ID_food = '{3}')", table_name, id_name, ingr_id, food_id));
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
            return SQL_Exec(string.Format("delete from  {0} where (ID_food= '{1}') and (Serve_time_of_food = '{2}')", table_name, food, serve));
        }
        /// <summary>
        /// Удаляет диету из блюда
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="id_name"></param>
        /// <param name="food_id"></param>
        /// <param name="diet_id"></param>
        /// <param name="card_id"></param>
        /// <returns></returns>
        public string del_record_by_diet_id(string table_name, string id_name, int food_id, int diet_id, int card_id)
        {
            return SQL_Exec(string.Format("delete from  {0} where ( {1}= '{2}') and (ID_Diets = '{3}')  and ( Id_Cards = '{4}')", table_name, id_name, food_id, diet_id, card_id));
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
            return SQL_Exec(string.Format("delete from  {0} where ( {1}= '{4}') and (ID_Cards = '{2}')  and ( ID_Food = '{3}')", table_name, id_name, card_id, food_id, book_id));
        }

        /// <summary>
        ///  удаляет запись из таблицы в базе данных, по указанному имена таблицы и идентификатору записи
        /// </summary>
        public string del_record_by_id(string table_name, string id_name, int id)
        {
            return SQL_Exec(string.Format("delete from  {0} where ( {1}= {2}) ", table_name, id_name, id));
        }
        /// <summary>
        ///  сбрасывает пароль и логин пользователя(логину и паролю в резельтате запроса присваевается значение null)
        /// </summary>
        public string del_record_by_password(string table_name, int id)
        {
            return SQL_Exec(string.Format("update Users set Login='', Password=null from  {0} where IDUsers= {1} ", table_name, id));
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
            return SQL_Exec(string.Format("insert into Cards (ID_food, Cost, Method_of_cooking, Number_card ) values ((select ID_food from Foods where Name_food ='{0}'),'{1}','{2}','{3}')", ((food_name.Length == 0) ? "NULL" : food_name), ((cost.Length == 0) ? "0" : cost), ((method.Length == 0) ? "" : method), ((card_numb.Length == 0) ? "NULL" : card_numb)));
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
            return SQL_Exec(string.Format("update Cards set ID_food=(select ID_food from Foods where Name_food = '{0}'), Cost='{1}', Method_of_cooking='{2}', Number_card='{3}' where Id_Cards= {4} ", ((food_name.Length == 0) ? "NULL" : food_name), ((cost.Length == 0) ? "0" : cost), ((method.Length == 0) ? "" : method), ((card_numb.Length == 0) ? "NULL" : card_numb), card_id));
        }
        /// <summary>
        ///  возвращает карту по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="food_name"></param>
        /// <returns></returns>

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
            return SQL_Exec(string.Format("insert into Foods (Name_food, Full_calories, TotalProteins, TotalFats, TotalCarbohydrates, Finish_weight_of_food ) values ('{0}',{1},{2},{3},{4},{5})", ((name.Length == 0) ? "NULL" : name), ((calories.Length == 0) ? "NULL" : calories), ((proteins.Length == 0) ? "NULL" : proteins), ((fats.Length == 0) ? "NULL" : fats), ((carbo.Length == 0) ? "NULL" : carbo), ((weight.Length == 0) ? "NULL" : weight)));
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
            return SQL_Exec(string.Format("update  Foods set Name_food='{0}', Full_calories={1}, TotalProteins={2}, TotalFats={3}, TotalCarbohydrates={4}, Finish_weight_of_food= {5} where ID_food='{6}'", ((name.Length == 0) ? "NULL" : name), ((calories.Length == 0) ? "NULL" : calories), ((proteins.Length == 0) ? "NULL" : proteins), ((fats.Length == 0) ? "NULL" : fats), ((carbo.Length == 0) ? "NULL" : carbo), ((weight.Length == 0) ? "NULL" : weight), id));
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
            return SQL_Exec(string.Format("insert into Diets (NumOfDiet, Description ) values ('{0}','{1}')", ((numbDiet.Length == 0) ? "NULL" : numbDiet), ((description.Length == 0) ? "" : description)));
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
            return SQL_Exec(string.Format("update Diets set NumOfDiet='{0}',Description='{1}' where ID_Diets='{2}' ", ((numbDiet.Length == 0) ? "NULL" : numbDiet), ((description.Length == 0) ? "" : description), id));
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
            try
            {
                class_book[] book = new class_book[512];
                string query = "select * From Book where Author ='" + author + "'" + " and Name= '" + name + "'";
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    book[i] = new class_book();
                    book[i].result = "OK";
                    book[i].author = rd.GetString(1);
                    book[i].name = rd.GetString(3);
                    book[i].year = rd.GetInt32(2).ToString();

                    if ((book[i].author == author) && (book[i].year == year) && (book[i].name == name))
                    {
                        rd.Close();
                        rd.Dispose();
                        com.Dispose();
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }
            catch (Exception)
            {
                return null;
            }

            return SQL_Exec(string.Format("insert into Book (Author, Year,Name ) values ('{0}',{1},'{2}')", ((author.Length == 0) ? "NULL" : author), ((year.Length == 0) ? "NULL" : year), ((name.Length == 0) ? "NULL" : name)));
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
            return SQL_Exec(string.Format("update  Book set Author='{0}', Year='{1}',Name='{2}' where IDBook={3}", ((author.Length == 0) ? "NULL" : author), ((year.Length == 0) ? "NULL" : year), ((name.Length == 0) ? "NULL" : name), id));
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
            return SQL_Exec(string.Format("insert into Ingridients_in_food  (ID_food, Gross_weight, Net_weight, Id_ingridients) values( (select ID_food from Foods where Name_food ='{0}'),{1},{2},(select Id_ingridients from Ingridients where ingridient_name='{3}') ) ", ((food_name.Length == 0) ? "NULL" : food_name), ((gross.Length == 0) ? "NULL" : gross), ((net.Length == 0) ? "NULL" : net), ((name_ingr.Length == 0) ? "NULL" : name_ingr)));
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
        public string upd_ingr_in_food(int ingr_id, string food_name, string gross, string net, string name_ingr, string ingr_old, string food_ID)
        {
            return SQL_Exec(string.Format("update Ingridients_in_food  set Gross_weight={2},Net_weight={3},Id_ingridients=(select Id_ingridients from Ingridients where ingridient_name ='{4}') where Id_ingridients = (select Id_ingridients from Ingridients where ingridient_name ='{5}' and ID_food = (select ID_food from Foods where Name_food = '{1}'))", ((ingr_id.ToString().Length == 0) ? "NULL" : ingr_id.ToString()), ((food_name.Length == 0) ? "NULL" : food_name), ((gross.Length == 0) ? "NULL" : gross), ((net.Length == 0) ? "NULL" : net), ((name_ingr.Length == 0) ? "NULL" : name_ingr), ((ingr_old.Length == 0) ? "NULL" : ingr_old), ((food_ID.Length == 0) ? "NULL" : food_ID)));
        }
        /// <summary>
        /// обновляет таблицу Foods при редактировании блюда в текст боксе
        /// </summary>
        /// <param name="food_name"></param>
        /// <param name="food_ID"></param>
        /// <returns></returns>
        public string upd_food_(string food_name, int food_ID)
        {
            return SQL_Exec(string.Format("update Foods set Name_food ='{0}' from Foods where  ID_food ={1}", food_name, food_ID));
        }

        /// <summary>
        /// обновление роли ,когда пользователь изменяет его в комбо боксе
        /// </summary>
        /// <param name="login"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string upd_login(string role, int ID)
        {
            return SQL_Exec(string.Format("update  Users set role='{0}'where IDUsers={1}", role, ID));
        }

        /// <summary>
        /// возвращает ингридиент в блюде по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="ingr_name"></param>
        /// <param name="food_name"></param>
        /// <returns></returns>
        public class_ingr_in_food get_ingr_in_food(string ingr_name, string food_name)
        {
            class_ingr_in_food ingr_in_food = new class_ingr_in_food();
            string query = "Select  F.Name_food, F.ID_food,I.ingridient_name, IIF.Gross_weight, IIF.Net_weight, IIF.Id_ingridients "
                            + "From Ingridients_in_food IIF join Ingridients I on "
                            + "IIF.Id_ingridients = I.Id_ingridients "
                            + "join Foods F on  F.ID_food = IIF.ID_food ";
            query += "where I.ingridient_name = '" + ingr_name.ToString() + "'" + "and F.Name_food='" + food_name.ToString() + "'"; ;
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
        public class_ingr_in_food[] get_list_ingr_id(int _id_food, int _id_ingr)
        {
            class_ingr_in_food[] ingr = new class_ingr_in_food[512];
            string query = "select I.Id_ingridients, I.ingridient_name "
                           + "from Ingridients I "
                           + "join Ingridients_in_food IIF on IIF.Id_ingridients = I.Id_ingridients "
                           + "join Foods F on IIF.ID_food = F.ID_food "
                           + "where I.Id_ingridients = " + _id_ingr + " and F.ID_food = " + _id_food + " ";
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
                    ingr[i].ingr_id = rd.GetInt32(0).ToString();
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
        ///  возвращает ингридиент по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <returns></returns>
        public class_ingr_in_food[] get_list_ingr_name(int _id_food)
        {
            class_ingr_in_food[] ingr = new class_ingr_in_food[512];
            string query = "select I.Id_ingridients, I.ingridient_name "
                         + "from Ingridients I where I.Id_ingridients "
                         + "not in (select Id_ingridients from Ingridients_in_food IIF join Foods F on IIF.ID_food = F.ID_food where F.ID_food = '" + _id_food +"')";
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
                    ingr[i].ingr_id = rd.GetInt32(0).ToString();
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
            return SQL_Exec(string.Format("insert into Queue (Number_of_mens, Number_queue, Starting_date, Ending_date ) values ({0},'{1}','{2}','{3}')", ((numb_men.Length == 0) ? "NULL" : numb_men), ((numb_queue.Length == 0) ? "NULL" : numb_queue), ((start.Length == 0) ? "NULL" : start), ((end.Length == 0) ? "NULL" : end)));
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
            return SQL_Exec(string.Format("update  Queue set  Number_of_mens={0}, Number_queue='{1}', Starting_date='{2}', Ending_date='{3}' where ID_queue={4} ", ((numb_men.Length == 0) ? "NULL" : numb_men), ((numb_queue.Length == 0) ? "NULL" : numb_queue), ((start.Length == 0) ? "NULL" : start), ((end.Length == 0) ? "NULL" : end), id));

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
        /// добавляет  диету  в блюдо
        /// </summary>
        /// <param name="card_numb"></param>
        /// <param name="food_name"></param>
        /// <param name="diet_numb"></param>
        /// <returns></returns>
        public string add_diet_in_food(string card_numb, string food_name, string diet_numb)
        {
            return SQL_Exec(string.Format("insert into Food_In_Diets (Id_Cards, ID_food, ID_Diets ) values ((select Id_Cards from Cards where Number_Card='{0}'),(select ID_Food from Foods where Name_Food ='{1}'),(select ID_Diets from Diets where NumOfDiet='{2}' ))", ((card_numb.Length == 0) ? "NULL" : card_numb), ((food_name.Length == 0) ? "NULL" : food_name), ((diet_numb.Length == 0) ? "NULL" : diet_numb)));
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

        /// <summary>
        /// добавляет сотрудника
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="secname"></param>
        /// <param name="post"></param>
        /// <returns></returns>

        public string add_person(string surname, string name, string secname, string post)
        {
            return SQL_Exec(string.Format("insert into Users (Surname, Name, Secondname, Post) values ('{0}','{1}','{2}','{3}') ", ((surname.Length == 0) ? "NULL" : surname), ((name.Length == 0) ? "NULL" : name), ((secname.Length == 0) ? "NULL" : secname), ((post.Length == 0) ? "NULL" : post)));
        }
        /// <summary>
        /// модифицирует сотрудника
        /// </summary>
        /// <param name="post_id"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="secname"></param>
        /// <param name="post"></param>
        /// <returns></returns>

        public string upd_person(int post_id, string surname, string name, string secname, string post)
        {
            return SQL_Exec(string.Format("update Users set Surname='{1}', Name='{2}', Secondname='{3}', Post='{4}' where IDUsers={0} ", post_id, ((surname.Length == 0) ? "NULL" : surname), ((name.Length == 0) ? "NULL" : name), ((secname.Length == 0) ? "NULL" : secname), ((post.Length == 0) ? "NULL" : post)));
        }

        /// <summary>
        ///  возвращает сотрудника по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="post_id"></param>
        /// <returns></returns>
        public class_person get_person(int post_id)
        {
            class_person person = new class_person();
            string query = "select Surname, Name, Secondname, Post, IDUsers "
                            + "from Users ";
            query += "where IDUsers = '" + post_id + "'";
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

        /// <summary>
        /// добавляет блюдо в справочник
        /// </summary>
        /// <param name="card_numb"></param>
        /// <param name="food"></param>
        /// <param name="book"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public string add_food_in_book(string card_numb, string food, string book, string author, string year)
        {
            return SQL_Exec(string.Format("insert into FoodInBook (Id_Cards, ID_food, IDBook) values ((select Id_Cards from Cards where Number_Card='{0}'),(select ID_Food from Foods where Name_Food ='{1}'), (select IDBook from Book where Name ='{2}' and Author = '{3}' and Year ='{4}')) ", ((card_numb.Length == 0) ? "NULL" : card_numb), ((food.Length == 0) ? "NULL" : food), ((book.Length == 0) ? "NULL" : book), ((author.Length == 0) ? "NULL" : author), ((year.Length == 0) ? "NULL" : year)));
        }

        /// <summary>
        /// возвращает рецепт для блюда по указанному в параметрах идентификатору (коду)
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>

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

        /// <summary>
        /// получаем список блюд
        /// </summary>
        /// <param name="_id_book"></param>
        /// <returns></returns>

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
            return SQL_Exec(string.Format(" insert into Menu (ID_queue) values((select ID_queue from Queue Q where Q.Number_queue ='{0}')) ", ((numb_queue.Length == 0) ? "NULL" : numb_queue)));
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
            try
            {
                class_menu_in_day[] menu = new class_menu_in_day[512];
                string query = "select date_menu From Menu_in_day where ID_menu ='" + menu_id + "'";
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    menu[i] = new class_menu_in_day();
                    menu[i].result = "OK";
                    menu[i].day = rd.GetDateTime(0).ToShortDateString();
                    if (menu[i].day == Convert.ToString(day))
                    {
                        rd.Close();
                        rd.Dispose();
                        com.Dispose();
                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }
            catch (Exception)
            {
                return null;
            }

            return SQL_Exec(string.Format("insert into Menu_in_day (date_menu, ID_menu) values('{0}',{1})", ((day.Length == 0) ? "NULL" : day), ((menu_id.ToString().Length == 0) ? "NULL" : menu_id.ToString())));
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
            try
            {
                class_food_in_menu[] menu = new class_food_in_menu[512];
                string query = "Select F.ID_food, MID.day_id, F.Name_food "
                             + "from Food_in_menu FIM "
                             + "join Foods F on F.ID_food = FIM.ID_Food "
                             + "join Menu_in_day MID on MID.day_id = FIM.day_id "
                             + "where Serve_time_of_food = '" + serve_time + "' and MID.day_id = '" + day_id + "'";
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
            }

            catch (Exception)
            {
                MessageBox.Show("Это блюдо уже есть в меню!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return SQL_Exec(string.Format("insert into Food_in_menu (Serve_time_of_food, ID_menu, ID_food, day_id, count_serve) values('{0}',{1},(select ID_food from Foods where Name_food ='{3}'),{2},'{4}')", ((serve_time.Length == 0) ? "NULL" : serve_time), menu_id, day_id, ((food.Length == 0) ? "NULL" : food), ((serve.Length == 0) ? "NULL" : serve)));
        }
        /// <summary>
        /// возвращает названия блюд
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
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
        /// <summary>
        /// возвращает блюдо которое еще не добавлено в таблицу Food_in_menu
        /// </summary>
        /// <param name="serve_time"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public class_food_in_menu[] get_foodMenu(string serve_time, int day)
        {
            class_food_in_menu[] food_in_menu = new class_food_in_menu[512];
            string query = "Select F.ID_food, F.Name_food "
                         + "from Foods F "
                         + "where F.ID_food not in (select ID_food from Food_in_menu where Serve_time_of_food = '" + serve_time + "'" + "and day_id='" + day + "'" + ")";
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
        /// <summary>
        /// назначение прав пользователям (логин,пароль и т.д)
        /// </summary>
        /// <param name="prof"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public string add_password(string prof, string login, string password, string role, int ID)
        {
            try
            {
                class_person[] menu = new class_person[512];
                string query = "select login from Users where role='Администратор-глав_врач' or role='Пользователь-диет_сестра'";
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    menu[i] = new class_person();
                    menu[i].result = "OK";
                    if (rd.IsDBNull(0))
                    { }
                    else
                    {
                        menu[i].login = rd.GetString(0);

                        if ((menu[i].login == login))
                        {
                            rd.Close();
                            rd.Dispose();
                            com.Dispose();
                        }
                    }

                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception)
            {
                return null;
            }

            return SQL_Exec(string.Format("update  Users set login='{0}',password='{1}',role='{2}' where Post='{3}' and IDUsers={4}", login, password, role, prof, ID));
        }



        /// <summary>
        /// смена логина пароля,  ролей пользователя
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public string add_password_user(int ID, string login, string password, string role)
        {
            return SQL_Exec(string.Format("update  Users set Login='{0}',Password='{1}',role='{2}' where IDUsers='{3}'", login, password, role, ID));
        }


        /// <summary>
        /// смена логина пароля,  ролей пользователя
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public string upd_password(int ID, string login, string password, string role)
        {
            try
            {
                class_person[] menu = new class_person[512];
                string query = "select login from Users where role='Администратор-глав_врач' or role='Пользователь-диет_сестра'";
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                SqlDataReader rd = com.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                    menu[i] = new class_person();
                    menu[i].result = "OK";
                    if (rd.IsDBNull(0))
                    { }
                    else
                    {
                        menu[i].login = rd.GetString(0);
                        if ((menu[i].login == login))
                        {
                            rd.Close();
                            rd.Dispose();
                            com.Dispose();
                        }

                    }
                }
                rd.Close();
                rd.Dispose();
                com.Dispose();
            }

            catch (Exception)
            {
                return null;
            }

            return SQL_Exec(string.Format("update  Users set Login='{0}',Password='{1}',role='{2}' where IDUsers='{3}'", login, password, role, ID));
        }
        
        /// <summary>
        /// Обновляется логин,если пол-ль изменил логин ,но не менял пароль
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public string upd_passwords(int ID, string login)
        {
            return SQL_Exec(string.Format("update  Users set Login='{0}' where IDUsers='{1}'", login,  ID));
        }
        /// <summary>
        /// Обновляется логин и пароль,если польз-ль поменял огин и пароль
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <returns></returns>        
        public string upd_passwordss(int ID, string login,string pass )
        {
            return SQL_Exec(string.Format("update  Users set Login='{0}', Password='{2}' where IDUsers='{1}'", login, ID,pass));
        }
        
        /// <summary>
        /// Возвращает  логин пользователя
        /// </summary>
        public class_person get_login(int ID)
        {
            class_person user = new class_person();
            string query = "select login  from Users where IDUsers='" + ID + "'";
            try
            {
                SqlCommand com = Program.data_module._conn.CreateCommand();
                com.CommandText = query;
                int i = 0;
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    i = i + 1;
                    user = new class_person();
                    user.result = "OK";
                    user.login = rd.GetString(0);
                }

                if (user == null)
                {
                    i = i + 1;
                    user = new class_person();
                    user.pass = "";
                    string password = (user.pass);
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
            return user;
        }

    }
}
