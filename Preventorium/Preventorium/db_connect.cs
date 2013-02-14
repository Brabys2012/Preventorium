using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Preventorium
{
    public class db_connect
    {
        public SqlConnection _conn;
        public string _conn_status;
        public string _connection_string;
        public DataSet _ds;
        public SqlDataAdapter _da;
        public SqlCommandBuilder _cb;
        public string _active_table;
        public string _command_text;

        public db_connect()
        {
            this._conn = new SqlConnection();
            this._ds = new System.Data.DataSet();
            this._conn_status = "DISCONNECTED";
            if (!(this.set_connection_settings("Initial Catalog=preventorium;Server=XTREME-O1P7TPFI")))
                MessageBox.Show("Неверная строка подключения!");
        }

        public bool set_connection_settings(string conn_string)
        {
            this._connection_string = conn_string;
            try
            {
                this._conn.ConnectionString = this._connection_string;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // ------------------------------------------------------------------
        public DataSet get_data_table_diet_in_food(string table_name)
        {
            string query = "Select F.Name_food, D.NumOfDiet, C.Number_Card, FID.ID_food, FID.ID_Diets, FID.Id_Cards "
                            + "From Food_In_Diets FID "
                            + "join Diets D on D.ID_Diets = FID.ID_Diets "
                            + "join Cards C on C.ID_food = FID.ID_food "
                            + "join Foods F on F.ID_food = FID.ID_food ";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------       


// ------------------------------------------------------------------
        public DataSet get_data_table2(string table_name, int food_id)
        {
            string query = "Select  F.Name_food, I.ingridient_name, IIF.Gross_weight, IIF.Net_weight, IIF.Id_ingridients, F.ID_food "
                            + "From Ingridients_in_food IIF join Ingridients I on "
                            + "IIF.Id_ingridients = I.Id_ingridients "
                            + "join Foods F on  F.ID_food = IIF.ID_food "
                            + "where F.ID_food = '" + food_id + "'";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

// ------------------------------------------------------------------       

        public DataSet get_data_table(string table_name)
        {
            string query = "";
            query += "select";
            query += " *";
            query += " from ";
            query += table_name;
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------
        public DataSet get_data_table_cards(string table_name)
        {
            string query = "Select C.Id_Cards, F.Name_food, C.Cost, C.Method_of_cooking, C.Number_Card, C.ID_food "
                           + "From Cards C "
                           + "join Foods F on F.ID_food = C.ID_food";
            try
            {
                this._ds = new DataSet();
                this._da = new SqlDataAdapter(query, this._conn);
                this._cb = new SqlCommandBuilder(this._da);

                this._da.Fill(this._ds, table_name);
                this._active_table = table_name;
                return this._ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data + " " + ex.Message);
                return null;
            }
        }

        // ------------------------------------------------------------------  



        public string connect_to_db()
        {
            this._conn_status = "PROCESS_CONNECTING";
            try
            {
                this._conn.Open();
            }
            catch (Exception ex)
            {
                this._conn_status = "DISCONNECTED";
                return ex.Data + " " + ex.Message;
            }
            this._conn_status = "CONNECTED";
            return "OK";
        }

        public string disconnect_db()
        {
            this._conn_status = "PROCESS_DISCONNECTING";
            try
            {
                this._conn.Close();
            }
            catch (Exception ex)
            {
                this._conn_status = "CONNECTED";
                return ex.Data + " " + ex.Message;
            }
            this._conn_status = "DISCONNECTED";
            return "OK";
        }

     
        public string get_connect_status()
        {
            return this._conn_status;
        }
    }
}
