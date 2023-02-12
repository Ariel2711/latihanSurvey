using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace survey
{
    public class Connection
    {
        public SqlConnection con;

        public Connection()
        {
            con = new SqlConnection("Data Source=DESKTOP-5VS88JF;Initial Catalog=kuisioner;Integrated Security=True");
        }

        public SqlConnection getConnection() { return con; }

        public void openCon()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeCon()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
