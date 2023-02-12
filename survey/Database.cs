using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace survey
{
    public class Database
    {
        Connection con = new Connection();

        public int insert(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con.getConnection());
            con.openCon();
            var res = cmd.ExecuteNonQuery();
            con.closeCon();
            return res;
        }

        public int insertCmd(SqlCommand cmd)
        {
            cmd.Connection = con.getConnection();
            con.openCon();
            var res = cmd.ExecuteNonQuery();
            con.closeCon();
            return res;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con.getConnection());
            con.openCon();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.closeCon();
            return dt;
        }

        public DataTable getTableCmd(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            cmd.Connection = con.getConnection();
            con.openCon();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.closeCon();
            return dt;
        }
    }
}
