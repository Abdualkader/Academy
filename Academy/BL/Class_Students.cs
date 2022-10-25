using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Academy.BL
{
    class Class_Students
    {
        DataAcsess.C_Data_Access AccessData = new DataAcsess.C_Data_Access();
        //Get Students Data
        public DataTable Get_Students()
        {
            DataTable dt = new DataTable();
            dt = AccessData.Get_Data("Proc_Get_Students", null);
            return dt;
        }

        //Add Students 
        public void Add_Student(int sid , string name_ar,string name_en,string phone, string mobile,string Pmobile,string address)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@sid", SqlDbType.Int);
            param[0].Value = sid;
            param[1] = new SqlParameter("@sName_ar",SqlDbType.NVarChar,50);
            param[1].Value = name_ar;
            param[2] = new SqlParameter("@sName_en", SqlDbType.NVarChar,50);
            param[2].Value = name_en;
            param[3] = new SqlParameter("@sPhone", SqlDbType.NVarChar,50);
            param[3].Value = phone;
            param[4] = new SqlParameter("@sMobile", SqlDbType.NVarChar,50);
            param[4].Value = mobile;
            param[5] = new SqlParameter("@spMobile", SqlDbType.NVarChar,50);
            param[5].Value = Pmobile;
            param[6] = new SqlParameter("@sAdress", SqlDbType.NVarChar,50);
            param[6].Value = address;

            AccessData.EditDB("Proc_Add_Students", param);
        }
        //Edit Students 
        public void Edit_Students(int sid, string name_ar, string name_en, string phone, string mobile, string Pmobile, string address)
        {

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@sid", SqlDbType.Int);
            param[0].Value = sid;
            param[1] = new SqlParameter("@sName_ar", SqlDbType.NVarChar, 50);
            param[1].Value = name_ar;
            param[2] = new SqlParameter("@sName_en", SqlDbType.NVarChar, 50);
            param[2].Value = name_en;
            param[3] = new SqlParameter("@sPhone", SqlDbType.NVarChar, 50);
            param[3].Value = phone;
            param[4] = new SqlParameter("@sMobile", SqlDbType.NVarChar, 50);
            param[4].Value = mobile;
            param[5] = new SqlParameter("@spMobile", SqlDbType.NVarChar, 50);
            param[5].Value = Pmobile;
            param[6] = new SqlParameter("@sAdress", SqlDbType.NVarChar, 50);
            param[6].Value = address;

            AccessData.EditDB("Proc_Edit_Students", param);
        }
        //Delete Students
        public void Delete_Students(int sid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@sid", SqlDbType.Int);
            param[0].Value = sid;

            AccessData.EditDB("Proc_Delete_Students", param);
        }
    }
}
