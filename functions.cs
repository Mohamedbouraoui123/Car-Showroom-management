using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CarShowRoom
{
    class functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter Sda;
        private string Constr;

        public functions()
        {
            Constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\WAEL BOURAOUI\Documents\CarShowRoomDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(Constr);
            cmd = new SqlCommand();
            cmd.Connection =  Con;

        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            Sda = new SqlDataAdapter(Query, Constr);
            Sda.Fill(dt);
            return dt;

        }
        public int SetData(string Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }


        internal void SetDataWithParameters(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
