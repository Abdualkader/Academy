using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Academy.BL
{
    class Class_Open_Courses
    {
        DataAcsess.C_Data_Access AccessData = new DataAcsess.C_Data_Access();

        //Get open courses
        public DataTable Get_Open_Cources()
        {
            DataTable dt = new DataTable();
            dt = AccessData.Get_Data("Proc_Get_OpenCourse", null);
            return dt;
        }

        //Edit courses 
        public void Change_courses(int id, int cid, DateTime sdate, DateTime edate, string time, int state)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ocid", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@cid", SqlDbType.Int);
            param[1].Value = cid;
            param[2] = new SqlParameter("@csDate", SqlDbType.DateTime);
            param[2].Value = sdate;
            param[3] = new SqlParameter("@ceDate", SqlDbType.DateTime);
            param[3].Value = edate;
            param[4] = new SqlParameter("@cTime", SqlDbType.NVarChar,10);
            param[4].Value = time;
            param[5] = new SqlParameter("@cstate", SqlDbType.Int);
            param[5].Value = state;
           

            AccessData.EditDB("Proc_Add_OpenCourse", param);
        }

        //Edit courses 
        public void Change_course(int id, int cid, DateTime sdate, DateTime edate, string time, int state)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ocid", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@cid", SqlDbType.Int);
            param[1].Value = cid;
            param[2] = new SqlParameter("@csDate", SqlDbType.DateTime);
            param[2].Value = sdate;
            param[3] = new SqlParameter("@ceDate", SqlDbType.DateTime);
            param[3].Value = edate;
            param[4] = new SqlParameter("@cTime", SqlDbType.NVarChar,10);
            param[4].Value = time;
            param[5] = new SqlParameter("@cstate", SqlDbType.Int);
            param[5].Value = state;


            AccessData.EditDB("Proc_Edit_OpenCourse", param);
        }

        //Delete Courses
        public void Delete_Course(int cid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ocid", SqlDbType.Int);
            param[0].Value = cid;

            AccessData.EditDB("Proc_Delete_OpenCourse", param);
        }
    }
}
