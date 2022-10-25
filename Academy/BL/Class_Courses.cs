using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Academy.BL
{
    class Class_Courses
    {
        DataAcsess.C_Data_Access AccessData = new DataAcsess.C_Data_Access();

        //Get Data for Courses 
        public DataTable Get_Courses()
        {
            DataTable dt = new DataTable();
            dt = AccessData.Get_Data("Proc_Get_Courses", null);
            return dt;
        }

        //Add Data to Courses
        public void Add_Courses(int id, string name_ar,string name_en,int period,decimal price,string code,string detail,string note,int divid)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@cid", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@cName_ar", SqlDbType.NVarChar,50);
            param[1].Value = name_ar;
            param[2] = new SqlParameter("@cName_en", SqlDbType.NVarChar,50);
            param[2].Value = name_en;
            param[3] = new SqlParameter("@cPeriod", SqlDbType.Int);
            param[3].Value = period;
            param[4] = new SqlParameter("@cPrice", SqlDbType.Decimal);
            param[4].Value = price;
            param[5] = new SqlParameter("@cCode", SqlDbType.NVarChar,50);
            param[5].Value = code;
            param[6] = new SqlParameter("@cDetail", SqlDbType.NVarChar,200);
            param[6].Value = detail;
            param[7] = new SqlParameter("@cNote", SqlDbType.NVarChar,50);
            param[7].Value = note;
            param[8] = new SqlParameter("@did", SqlDbType.Int);
            param[8].Value = divid;

            AccessData.EditDB("Proc_Add_Course", param);
        }

        //Delete Data from Courses
        public void Delete_Course(int cid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@cid", SqlDbType.Int);
            param[0].Value = cid;

            AccessData.EditDB("Proc_Delete_Course", param);
        }

        //Update Course 
        public void Edit_Course(int id, string name_ar, string name_en, int period, decimal price, string code, string detail, string note, int divid)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@cid", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@cName_ar", SqlDbType.NVarChar, 50);
            param[1].Value = name_ar;
            param[2] = new SqlParameter("@cName_en", SqlDbType.NVarChar, 50);
            param[2].Value = name_en;
            param[3] = new SqlParameter("@cPeriod", SqlDbType.Int);
            param[3].Value = period;
            param[4] = new SqlParameter("@cPrice", SqlDbType.Decimal);
            param[4].Value = price;
            param[5] = new SqlParameter("@cCode", SqlDbType.NVarChar, 50);
            param[5].Value = code;
            param[6] = new SqlParameter("@cDetail", SqlDbType.NVarChar, 200);
            param[6].Value = detail;
            param[7] = new SqlParameter("@cNote", SqlDbType.NVarChar, 50);
            param[7].Value = note;
            param[8] = new SqlParameter("@did", SqlDbType.Int);
            param[8].Value = divid;

            AccessData.EditDB("Proc_Edit_Course", param);

        }
    }
}
