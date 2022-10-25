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

namespace Academy.Pages
{
    public partial class Divison : Form
    {
        BL.Class_Division Division_cls = new BL.Class_Division();
        BindingSource bs = new BindingSource();
        public Divison()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Divison_Load(object sender, EventArgs e)
        {
            bs.DataSource = Division_cls.Get_Division();
            DataGridDivison.DataSource = bs;
            

            txtId.DataBindings.Add("text", bs, "did");
            txtNameAr.DataBindings.Add("text", bs, "dName_ar");
            txtNameEn.DataBindings.Add("text", bs, "dName_en");
            txtDetail.DataBindings.Add("text", bs, "detail");
            DataGridDivison.Columns["did"].HeaderText= "رقم القسم";
            DataGridDivison.Columns["dName_ar"].HeaderText = "اسم القسم_AR";
            DataGridDivison.Columns["dName_en"].HeaderText = "اسم القسم_EN";
            DataGridDivison.Columns["detail"].HeaderText = "تفاصيل القسم";

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNameAr.Text = "";
            txtNameEn.Text = "";
            txtDetail.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtNameAr.Text != "" && txtNameEn.Text != "")
            {
                try
                {
                     Division_cls.Add_Division(0, txtNameAr.Text, txtNameEn.Text, txtDetail.Text);
                    MessageBox.Show("تم الحفظ بنجاح");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال اسم القسم بالانجليزية و العربية");
            }
            bs.DataSource = Division_cls.Get_Division();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text != string.Empty)
            {
                if(MessageBox.Show("هل تريد الحذف", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Division_cls.Del_Divion(int.Parse(txtId.Text));
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال رقم القسم المراد حذفة");
            }
            bs.DataSource = Division_cls.Get_Division();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (txtNameAr.Text != "" && txtNameEn.Text != "")
            {
                try
                {
                    if (MessageBox.Show("هل تريد الحفظ", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Division_cls.Edit_Division(int.Parse(txtId.Text), txtNameAr.Text, txtNameEn.Text, txtDetail.Text);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("يرجى ادخال اسم القسم بالانجليزية و العربية");
            }
            bs.DataSource = Division_cls.Get_Division();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Home ho = new Home();
            ho.Show();
            this.Hide();
        }

        private void BtnCourse_Click(object sender, EventArgs e)
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
