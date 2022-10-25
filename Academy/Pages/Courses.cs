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
    public partial class Courses : Form
    {
        BL.Class_Courses Class_Course = new BL.Class_Courses();
        BindingSource bs = new BindingSource();
        BL.Class_Division Class_Divison = new BL.Class_Division();
        public Courses()
        {
            InitializeComponent();
        }

        private void Courses_Load(object sender, EventArgs e)
        {

            bs.DataSource = Class_Course.Get_Courses();
            DataGridCourses.DataSource = bs;
            combo_div.DataSource = Class_Divison.Get_Division();
            combo_div.DisplayMember = "dName_ar";
            combo_div.ValueMember = "did";

            txtId.DataBindings.Add("text", bs, "cid");
            txtNameAr.DataBindings.Add("text", bs, "cName_ar");
            txtNameEn.DataBindings.Add("text", bs, "cName_en");
            txtTime.DataBindings.Add("text", bs, "cPeriod");
            txtSal.DataBindings.Add("text", bs, "cPrice");
            txtDetail.DataBindings.Add("text", bs, "cDetail");
            txtDivID.DataBindings.Add("text", bs, "did");
            txtCode.DataBindings.Add("text", bs, "cCode");
            txtNote.DataBindings.Add("text", bs, "cNote");
            combo_div.DataBindings.Add("SelectedValue", bs, "did");

            DataGridCourses.Columns["cid"].HeaderText = "رقم الكورس";
            DataGridCourses.Columns["cName_ar"].HeaderText = "اسم الدورة_AR";
            DataGridCourses.Columns["cName_en"].HeaderText = "اسم الدورة_EN";
            DataGridCourses.Columns["cDetail"].HeaderText = "تفاصيل الدورة";
            DataGridCourses.Columns["cPeriod"].HeaderText = "زمن الدورة";
            DataGridCourses.Columns["cPrice"].HeaderText = "سعر الدورة";
            DataGridCourses.Columns["cCode"].HeaderText = "كود الدورة";
            DataGridCourses.Columns["cNote"].HeaderText = "ملاحظات الدورة";
            DataGridCourses.Columns["dName_ar"].HeaderText = "القسم";
            DataGridCourses.Columns["did"].Visible = false;
            txtDivID.Text = combo_div.SelectedValue.ToString();
        }

    

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtDetail.Clear();
            txtId.Clear();
            txtNameAr.Clear();
            txtNameEn.Clear();
            txtNote.Clear();
            txtSal.Clear();
            txtTime.Clear();
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtNameAr.Text != string.Empty && txtNameEn.Text != string.Empty && txtDivID.Text != string.Empty &&
                txtSal.Text != string.Empty && txtTime.Text != string.Empty)
            {
               
                Class_Course.Add_Courses(0, txtNameAr.Text, txtNameEn.Text, int.Parse(txtTime.Text),
                    decimal.Parse(txtSal.Text), txtCode.Text, txtDetail.Text,txtNote.Text, int.Parse(txtDivID.Text));
                MessageBox.Show("تم الحفظ بنجاح");
            }
            else
            {
                MessageBox.Show("يرجى ادخال البيانات كاملة");
            }
            bs.DataSource = Class_Course.Get_Courses();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحفظ", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class_Course.Edit_Course(int.Parse(txtId.Text), txtNameAr.Text, txtNameEn.Text, int.Parse(txtTime.Text),
                    decimal.Parse(txtSal.Text), txtCode.Text, txtDetail.Text, txtNote.Text, int.Parse(txtDivID.Text));
            }
            else
            {
                MessageBox.Show("يرجى ادخال البيانات كاملة");
            }
            bs.DataSource = Class_Course.Get_Courses();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                if (MessageBox.Show("هل تريد الحذف", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Class_Course.Delete_Course(int.Parse(txtId.Text));
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال رقم القسم المراد حذفة");
            }
            bs.DataSource = Class_Course.Get_Courses();
        }

        private void Combo_div_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combo_div.SelectedValue != null)
            {
                txtDivID.Text = combo_div.SelectedValue.ToString();
            }
        }

        private void BtnDivison_Click(object sender, EventArgs e)
        {
            Divison di = new Divison();
            di.Show();
            this.Hide();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Home he = new Home();
            he.Show();
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
    }
}
