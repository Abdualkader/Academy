using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Academy.BL
{
    class Class_Division
    {
        DataAcsess.C_Data_Access Accessdata = new DataAcsess.C_Data_Access();
        //Get Division Table Data from DB
        public DataTable Get_Division()
        {
            DataTable dt = new DataTable();
            dt = Accessdata.Get_Data("Proc_Get_Division", null);
            return dt;
        }

        //Add Data to Division Table
        public void Add_Division(int did, string name_ar, string name_en, string detail)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@did", SqlDbType.Int);
            param[0].Value = did;
            param[1] = new SqlParameter("@dName_ar", SqlDbType.NVarChar, 50);
            param[1].Value = name_ar;
            param[2] = new SqlParameter("dName_en", SqlDbType.NVarChar, 50);
            param[2].Value = name_en;
            param[3] = new SqlParameter("detail", SqlDbType.NVarChar, 200);
            param[3].Value = detail;

            Accessdata.EditDB("Proc_add_Division", param);
        }

        //Delete Division 
        public void Del_Divion(int did)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@did", SqlDbType.Int);
            param[0].Value = did;

            Accessdata.EditDB("Proc_Delete_Division", param);
        }
        //Update Division 
        public void Edit_Division(int did, string name_ar, string name_en, string detail)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@did", SqlDbType.Int);
            param[0].Value = did;
            param[1] = new SqlParameter("@dName_ar", SqlDbType.NVarChar, 50);
            param[1].Value = name_ar;
            param[2] = new SqlParameter("dName_en", SqlDbType.NVarChar, 50);
            param[2].Value = name_en;
            param[3] = new SqlParameter("detail", SqlDbType.NVarChar, 200);
            param[3].Value = detail;

            Accessdata.EditDB("Proc_edit_Division", param);
        }
    }
}
