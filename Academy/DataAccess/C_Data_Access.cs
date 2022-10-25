using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Academy.DataAcsess
{
    class C_Data_Access
    {
        SqlConnection con = new SqlConnection(@"Data Source=ERA-1\SQLSERVER;Initial Catalog=Academy;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        //Open Connection Data
        public void OpenCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        //Close Connection Data 
        public void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        //Edit Data in DB
        public void EditDB(string Store_proc, SqlParameter[] Param)
        {
            cmd = new SqlCommand(Store_proc, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (Param != null)
            {
                cmd.Parameters.AddRange(Param);
            }
            OpenCon();
            cmd.ExecuteNonQuery();
            CloseCon();
        }

        //Get Data from DB
        public DataTable Get_Data(string Store_proc, SqlParameter[] Param)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(Store_proc, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Param != null)
                {
                    cmd.Parameters.AddRange(Param);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}
