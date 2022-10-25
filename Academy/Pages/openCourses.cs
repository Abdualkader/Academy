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
    public partial class openCourses : Form
    {
        BL.Class_Open_Courses Class_open = new BL.Class_Open_Courses();
        BL.Class_Courses Class_Course = new BL.Class_Courses();
        BindingSource bs = new BindingSource();
        public openCourses()
        {
            InitializeComponent();
        }

        private void OpenCourses_Load(object sender, EventArgs e)
        {
            bs.DataSource = Class_open.Get_Open_Cources();
            DataGridCourseOpen.DataSource = bs;
            combo_course.DataSource = Class_Course.Get_Courses();
            combo_course.DisplayMember = "cName_ar";
            combo_course.ValueMember = "cid";

            txtId.DataBindings.Add("text", bs, "ocid");
            txtcid.DataBindings.Add("text", bs, "cid");
            txttime.DataBindings.Add("text", bs, "cTime");
            txtstate.DataBindings.Add("text", bs, "cstate");
            startDate.DataBindings.Add("Value", bs, "csDate");
            endDate.DataBindings.Add("Value", bs, "ceDate");
            combo_course.DataBindings.Add("SelectedValue", bs, "cid");

            DataGridCourseOpen.Columns["ocid"].HeaderText = "رقم الدورة المفتوحة";
            DataGridCourseOpen.Columns["csDate"].HeaderText = "تاريخ البدء";
            DataGridCourseOpen.Columns["ceDate"].HeaderText = "تاريخ الانتهاء";
            DataGridCourseOpen.Columns["cTime"].HeaderText = "وقت الدورة";
            DataGridCourseOpen.Columns["cstate"].HeaderText = "حالة الدورة";
            DataGridCourseOpen.Columns["cName_ar"].HeaderText = "اسم الدورة";
            DataGridCourseOpen.Columns["cid"].Visible = false;
            txtcid.Text = combo_course.SelectedValue.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtcid.Clear();
            txtId.Clear();
            txtstate.Clear();
            txttime.Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtcid.Text != string.Empty && txtId.Text != string.Empty && txtstate.Text != string.Empty && txttime.Text != string.Empty)
            {

                Class_open.Change_courses(int.Parse(txtId.Text), int.Parse(txtcid.Text), startDate.Value.Date, endDate.Value.Date, txttime.Text, int.Parse(txtstate.Text));
                MessageBox.Show("تم الحفظ بنجاح");
            }
            else
            {
                MessageBox.Show("يرجى ادخال البيانات كاملة");
            }
            bs.DataSource = Class_open.Get_Open_Cources();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("هل تريد الحفظ", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class_open.Change_course(int.Parse(txtId.Text), int.Parse(txtcid.Text), startDate.Value.Date, endDate.Value.Date, txttime.Text, int.Parse(txtstate.Text));

            }
            else
            {
                MessageBox.Show("يرجى ادخال البيانات كاملة");
            }
            bs.DataSource = Class_open.Get_Open_Cources();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                if (MessageBox.Show("هل تريد الحذف", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Class_open.Delete_Course(int.Parse(txtId.Text));
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال رقم القسم المراد حذفة");
            }
            bs.DataSource = Class_open.Get_Open_Cources();
        }

        private void Combo_course_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combo_course.SelectedValue != null)
            {
                txtcid.Text = combo_course.SelectedValue.ToString();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            Students st = new Students();
            st.Show();
            this.Hide();
        }

        private void BtnStudentStudy_Click(object sender, EventArgs e)
        {
            StudentsRegister sr = new StudentsRegister();
            sr.Show();
            this.Hide();
        }

         private void Gunapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAddStudents_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                AddStoCourse asc = new AddStoCourse();
                asc.num1 = int.Parse(txtId.Text);
                asc.nameCourse = combo_course.Text;
                asc.Show();
                asc.StartPosition = FormStartPosition.CenterParent;
            }
            else
            {
                MessageBox.Show("يرجى ادخال رقم الدورة");
            }
        }
    }
}
