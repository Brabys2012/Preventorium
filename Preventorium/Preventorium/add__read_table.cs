using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Preventorium
{
    class add__read_table
    {
       

          public DataSet get_data_table(string table_name)
      {
          string query = "";
          query += "select";
          query += " *";
          query += " from ";
          query += table_name;
          try
          {
              Program.data_module._ds = new DataSet();
              Program.data_module._da = new SqlDataAdapter(query,Program.data_module._conn);
              Program.data_module._cb = new SqlCommandBuilder(Program.data_module._da);

              Program.data_module._da.Fill(Program.data_module._ds, table_name);
              Program.data_module._active_table = table_name;
              return Program.data_module._ds;
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Data + " " + ex.Message);
              return null;
          }
      }
      



    }
}
