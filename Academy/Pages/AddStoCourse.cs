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
    public partial class AddStoCourse : Form
    {
        BL.Class_Students StudentClass = new BL.Class_Students();
        BL.Class_Students_Study Addstudent = new BL.Class_Students_Study();
        BindingSource bs = new BindingSource();
        public int num1;
        public string nameCourse;
        public AddStoCourse()
        {
            InitializeComponent();
        }

        private void AddStoCourse_Load(object sender, EventArgs e)
        {
            bs.DataSource = StudentClass.Get_Students();
            DataGridStudents.DataSource = bs;
            txtcourseName.Text = nameCourse;
            txtIdOpen.Text = num1.ToString();
            txtIdStudent.DataBindings.Add("text", bs, "sid");
            txtStudentName.DataBindings.Add("text", bs, "sName_ar");
            DataGridStudents.Columns["sid"].HeaderText = "رقم الطالب";
            DataGridStudents.Columns["sName_ar"].HeaderText = "اسم الطالب_AR";
            DataGridStudents.Columns["sName_en"].HeaderText = "اسم الطالب_EN";
            DataGridStudents.Columns["sPhone"].HeaderText = "رقم الهاتف";
            DataGridStudents.Columns["sMobile"].HeaderText = "رقم الجوال";
            DataGridStudents.Columns["spMobile"].HeaderText = "رقم ولي الامر";
            DataGridStudents.Columns["sAdress"].HeaderText = "العنوان";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Addstudent.Add_Student_Study(0, int.Parse(txtIdStudent.Text), int.Parse(txtIdOpen.Text), 0, 0, 0);
            MessageBox.Show("تم الحفظ بنجاح");
        }
    }
}
