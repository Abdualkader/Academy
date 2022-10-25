using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Academy.BL
{
    class Class_Students_Study
    {
        DataAcsess.C_Data_Access AccessData = new DataAcsess.C_Data_Access();
        //Get Students study 
        public DataTable Get_Students_Study()
        {
            DataTable dt = new DataTable();
            dt = AccessData.Get_Data("Proc_Get_CourseStudy", null);
            return dt;
        }

        //Add Student to course  
        public void Add_Student_Study(int sacid, int sid, int ocid, decimal Quiz1,decimal Quiz2,decimal final)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@sacid", SqlDbType.Int);
            param[0].Value = sacid;
            param[1] = new SqlParameter("@sid", SqlDbType.Int);
            param[1].Value = sid;
            param[2] = new SqlParameter("@ocid", SqlDbType.Int);
            param[2].Value = ocid;
            param[3] = new SqlParameter("@dQuiz1", SqlDbType.Decimal,18);
            param[3].Value = Quiz1;
            param[4] = new SqlParameter("@dQuiz2", SqlDbType.Decimal,18);
            param[4].Value = Quiz2;
            param[5] = new SqlParameter("@fDegree", SqlDbType.Decimal,18);
            param[5].Value = final;

            AccessData.EditDB("Proc_Add_CourseStudy", param);
        }

        //Edit Student Study  
        public void Edit_Student_Study(int sacid, int sid, int ocid, decimal Quiz1, decimal Quiz2, decimal final)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@sacid", SqlDbType.Int);
            param[0].Value = sacid;
            param[1] = new SqlParameter("@sid", SqlDbType.Int);
            param[1].Value = sid;
            param[2] = new SqlParameter("@ocid", SqlDbType.Int);
            param[2].Value = ocid;
            param[3] = new SqlParameter("@dQuiz1", SqlDbType.Decimal, 18);
            param[3].Value = Quiz1;
            param[4] = new SqlParameter("@dQuiz2", SqlDbType.Decimal, 18);
            param[4].Value = Quiz2;
            param[5] = new SqlParameter("@fDegree", SqlDbType.Decimal, 18);
            param[5].Value = final;

            AccessData.EditDB("Proc_Edit_CourseStudy", param);
        }

        //Delete Student Study
        public void Delete_student_study(int sid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@sacid", SqlDbType.Int);
            param[0].Value = sid;

            AccessData.EditDB("Proc_Delete_CourseStudy", param);
        }
    }
}
