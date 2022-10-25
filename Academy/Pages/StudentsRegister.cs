using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Academy.Pages
{
    public partial class StudentsRegister : Form
    {
        BL.Class_Students_Study studentStudy = new BL.Class_Students_Study();
        BL.Class_Students studentClass = new BL.Class_Students();
        BL.Class_Open_Courses openClass = new BL.Class_Open_Courses();
        BL.Class_Courses coursesClass = new BL.Class_Courses();
        BindingSource bs = new BindingSource();
        public StudentsRegister()
        {
            InitializeComponent();
        }

        private void StudentsRegister_Load(object sender, EventArgs e)
        {
            bs.DataSource = studentStudy.Get_Students_Study();
            DataGridStudy.DataSource = bs;

            txtId.DataBindings.Add("text", bs, "sacid");
            txtsid.DataBindings.Add("text", bs, "sid");
            txtocid.DataBindings.Add("text", bs, "ocid");
            txtquiz1.DataBindings.Add("text", bs, "dQuiz1");
            txtquiz2.DataBindings.Add("text", bs, "dQuiz2");
            txtfinal.DataBindings.Add("text", bs, "fDegree");

            DataGridStudy.Columns["sacid"].HeaderText = "الرقم التسلسلي";
            DataGridStudy.Columns["sName_ar"].HeaderText = "اسم الطالب";
            DataGridStudy.Columns["cName_ar"].HeaderText = "اسم الدورة";
            DataGridStudy.Columns["dQuiz1"].HeaderText = "درجة Quiz1";
            DataGridStudy.Columns["dQuiz2"].HeaderText = "درجة Quiz2";
            DataGridStudy.Columns["fDegree"].HeaderText = "الدرجة النهائية";
            DataGridStudy.Columns["sid"].Visible = false;
            DataGridStudy.Columns["ocid"].Visible = false;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtsid.Clear();
            txtocid.Clear();
            txtquiz1.Clear();
            txtquiz2.Clear();
            txtfinal.Clear();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty && txtsid.Text != string.Empty && txtocid.Text != string.Empty)
            {
                studentStudy.Add_Student_Study(int.Parse(txtId.Text), int.Parse(txtsid.Text), int.Parse(txtocid.Text), decimal.Parse(txtquiz1.Text),
                                                    decimal.Parse(txtquiz2.Text), decimal.Parse(txtfinal.Text));
                MessageBox.Show("تم الحفظ بنجاح");
            }
            else
            {
                MessageBox.Show("يرجى اكمال بقية المعلومات");
            }
            bs.DataSource = studentStudy.Get_Students_Study();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(txtId.Text != string.Empty && txtsid.Text != string.Empty && txtocid.Text != string.Empty)
            {
                if(MessageBox.Show("هل تريد الحفظ","سؤال",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                {
                    studentStudy.Edit_Student_Study(int.Parse(txtId.Text), int.Parse(txtsid.Text), int.Parse(txtocid.Text), decimal.Parse(txtquiz1.Text),
                                                    decimal.Parse(txtquiz2.Text), decimal.Parse(txtfinal.Text));
                }
            }
            else
            {
                MessageBox.Show("يرجى اكمال بقية المعلومات");
            }
            bs.DataSource = studentStudy.Get_Students_Study();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                if (MessageBox.Show("هل تريد الحذف", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    studentStudy.Delete_student_study(int.Parse(txtId.Text));
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال الرقم التسلسلي");
            }
            bs.DataSource = studentStudy.Get_Students_Study();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Home he = new Home();
            he.Show();
            this.Hide();
        }

        private void BtnDivison_Click(object sender, EventArgs e)
        {
            Divison de = new Divison();
            de.Show();
            this.Hide();
        }

        private void BtnCourses_Click(object sender, EventArgs e)
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

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openCourses oc = new openCourses();
            oc.Show();
            this.Hide();
        }

       
    }
}
