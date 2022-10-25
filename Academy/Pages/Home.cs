using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.Pages
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void DivisionIcon_Click(object sender, EventArgs e)
        {
            Divison di = new Divison();
            this.Hide();
            di.Show();
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            Divison di = new Divison();
            di.Show();
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCourse_Click(object sender, EventArgs e)
        {
            Courses co = new Courses();
            co.Show();
            this.Hide();
        }

        private void CoursesIcon_Click(object sender, EventArgs e)
        {
            Courses co = new Courses();
            co.Show();
            this.Hide();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            Students st = new Students();
            st.Show();
            this.Hide();
        }

        private void StudentsIcon_Click(object sender, EventArgs e)
        {
            Students st = new Students();
            st.Show();
            this.Hide();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openCourses op = new openCourses();
            op.Show();
            this.Hide();
        }

        private void OpenIcon_Click(object sender, EventArgs e)
        {
            openCourses op = new openCourses();
            op.Show();
            this.Hide();
        }

        private void BtnStudentStudy_Click(object sender, EventArgs e)
        {
            StudentsRegister sr = new StudentsRegister();
            sr.Show();
            this.Hide();
        }

        private void StudentStudyIcon_Click(object sender, EventArgs e)
        {
            StudentsRegister sr = new StudentsRegister();
            sr.Show();
            this.Hide();
        }
    }
}
