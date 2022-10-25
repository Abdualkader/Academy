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
    public partial class Students : Form
    {
        BL.Class_Students StudentClass = new BL.Class_Students();
        BindingSource bs = new BindingSource();
        public Students()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            bs.DataSource = StudentClass.Get_Students();
            DataGridStudents.DataSource = bs;
            txtId.DataBindings.Add("text", bs, "sid");
            txtNameAr.DataBindings.Add("text", bs, "sName_ar");
            txtNameEn.DataBindings.Add("text", bs, "sName_en");
            txtPhone.DataBindings.Add("text", bs, "sPhone");
            txtMobile.DataBindings.Add("text", bs, "sMobile");
            txtpMoile.DataBindings.Add("text", bs, "spMobile");
            txtaddress.DataBindings.Add("text", bs, "sAdress");

            DataGridStudents.Columns["sid"].HeaderText = "رقم الطالب";
            DataGridStudents.Columns["sName_ar"].HeaderText = "اسم الطالب_AR";
            DataGridStudents.Columns["sName_en"].HeaderText = "اسم الطالب_EN";
            DataGridStudents.Columns["sPhone"].HeaderText = "رقم الهاتف";
            DataGridStudents.Columns["sMobile"].HeaderText = "رقم الجوال";
            DataGridStudents.Columns["spMobile"].HeaderText = "رقم ولي الامر";
            DataGridStudents.Columns["sAdress"].HeaderText = "العنوان";
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtId.Clear();
            txtMobile.Clear();
            txtNameAr.Clear();
            txtNameEn.Clear();
            txtPhone.Clear();
            txtpMoile.Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string[] Splite_Name;
            char s = ' ';
            Splite_Name = txtNameAr.Text.Split(s);
            if (txtId.Text != string.Empty && txtMobile.Text != string.Empty && txtNameEn.Text != string.Empty && txtNameAr.Text != string.Empty)
            {


                if (Splite_Name.Length >= 5)
                {
                    StudentClass.Add_Student(0, txtNameAr.Text, txtNameEn.Text, txtPhone.Text, txtMobile.Text, txtpMoile.Text, txtaddress.Text);
                    MessageBox.Show("تم الحفظ بنجاح");
                }
                else
                {
                    MessageBox.Show("يجب ان يكون الاسم رباعي");
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال المعلومات كاملة");
            }
            bs.DataSource = StudentClass.Get_Students();

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string[] Splite_Name;
            char s = ' ';
            Splite_Name = txtNameAr.Text.Split(s);
            if (txtId.Text != string.Empty && txtMobile.Text != string.Empty && txtNameEn.Text != string.Empty && txtNameAr.Text != string.Empty)
            {
                if (Splite_Name.Length >= 4)
                {


                    if (MessageBox.Show("هل تريد الحفظ", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        StudentClass.Edit_Students(int.Parse(txtId.Text), txtNameAr.Text, txtNameEn.Text, txtPhone.Text, txtMobile.Text, txtpMoile.Text, txtaddress.Text);
                    }
                    else
                    {
                        MessageBox.Show("يجب ان يكون الاسم رباعي");
                    }
                }
                else
                {
                    MessageBox.Show("يرجى ادخال المعلومات كاملة");
                }
            }
            bs.DataSource = StudentClass.Get_Students();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                if (MessageBox.Show("هل تريد الحذف", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StudentClass.Delete_Students(int.Parse(txtId.Text));
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال رقم القسم المراد حذفة");
            }
            bs.DataSource = StudentClass.Get_Students();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Home he = new Home();
            he.Show();
            this.Hide();
        }

        private void BtnDivison_Click(object sender, EventArgs e)
        {
            Divison di = new Divison();
            di.Show();
            this.Hide();
        }

        private void BtnCourses_Click(object sender, EventArgs e)
        {
            Courses co = new Courses();
            co.Show();
            this.Hide();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openCourses op = new openCourses();
            op.Show();
            this.Hide();
        }

        private void BtnStudentStudy_Click(object sender, EventArgs e)
        {
            StudentsRegister st = new StudentsRegister();
            st.Show();
            this.Hide();
        }
    }
}
