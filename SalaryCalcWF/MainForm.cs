using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using Model;

namespace SalaryCalcWF
{
    public partial class MainForm : Form
    {
        private LessonHelper lessonHelper;
        private Constants constants;
        public MainForm()
        {
            InitializeComponent();
            lessonHelper = LessonHelper.GetInstance();
            QueryConstants();
            tbxPriceA.DataBindings.Add("Text", constants, "Price_A");
            tbxPriceB.DataBindings.Add("Text", constants, "Price_B");
            tbxPriceC.DataBindings.Add("Text", constants, "Price_C");
            tbxPriceD.DataBindings.Add("Text", constants, "Price_D");
            tbxPriceEve.DataBindings.Add("Text", constants, "Price_Evening");
            tbxPriceMon1.DataBindings.Add("Text", constants, "Price_Mon1");
            tbxPriceMon2.DataBindings.Add("Text", constants, "Price_Mon2");
            tbxPriceMor.DataBindings.Add("Text", constants, "Price_Morning");
            tbxTerm.DataBindings.Add("Text", constants, "Term");
            tbxWeeks.DataBindings.Add("Text", constants, "TotalWeeks");
            tbxDuty1.DataBindings.Add("Text", constants, "Duty1");
            tbxDuty2.DataBindings.Add("Text", constants, "Duty2");
            tbxDuty3.DataBindings.Add("Text", constants, "Duty3");
        }

        private void QueryConstants()
        {
            var result = lessonHelper.GetConstants();
            constants = result.Object as Constants;
        }
        private void SaveConstants()
        {
            var result = lessonHelper.SaveConstants(constants);
            if(!result.Succeeded)
            {
                MessageBox.Show(string.Join(",", result.Info));
            }
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            var window = new TeacherManage();
            window.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void btnFindActivity_Click(object sender, EventArgs e)
        {
            var window = new TeacherActivity();
            window.Show();
               
        }

        private void btnInput_Click(object sender, EventArgs e)
        {

        }

        private void btnLessonA_Click(object sender, EventArgs e)
        {
            Lessons form = Lessons.GetInstance("A");
            form.Show();
        }

        private void btnLessonB_Click(object sender, EventArgs e)
        {
            Lessons form = Lessons.GetInstance("B");
            form.Show();
        }

        private void btnLessonC_Click(object sender, EventArgs e)
        {
            Lessons form = Lessons.GetInstance("C");
            form.Show();
        }

        private void btnLessonD_Click(object sender, EventArgs e)
        {
            Lessons form = Lessons.GetInstance("D");
            form.Show();
        }

        private void btnLessonMor_Click(object sender, EventArgs e)
        {
            Lessons form = Lessons.GetInstance("M");
            form.Show();
        }

        private void btnLessonEve_Click(object sender, EventArgs e)
        {
            Lessons form = Lessons.GetInstance("E");
            form.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //检查输入
            SaveConstants();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            var result = lessonHelper.RecoverDefaultConstants();
            constants = result.Object as Constants;
        }
    }
}
