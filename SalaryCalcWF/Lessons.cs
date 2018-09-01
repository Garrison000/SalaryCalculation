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
    public partial class Lessons : Form//有必要单例。
    {
        private static Lessons window;
        private static string savedSort;
        private LessonHelper lhelper;
        List<LessonType> lessonTypes;

        /*
        public static Lessons GetInstance(string sort)
        {
            if (window == null)
            {
                window = new Lessons(sort);
            }
            if (sort==savedSort)
            {
                return window;
            }
            else
            {
                window.Close();
                window = new Lessons(sort);
            }
            return window;
            
        }*/

        public static Lessons GetInstance(string sort)
        {
            return new Lessons(sort);
        }

        public Lessons(string sort)
        {
            InitializeComponent();
            savedSort = sort;
            lblSort.Text = sort + "类";
            lhelper = LessonHelper.GetInstance();
            var en = lhelper.LetterToEnum(sort);
            var result = lhelper.GetTypeByEnum(en);
            if(!result.Succeeded)
            {
                MessageBox.Show(string.Join(",",result.Info));
            }
            lessonTypes = result.Object as List<LessonType>;
            dgvLesson.DataSource = lessonTypes;
        }

        private void Flush()
        {
            var en = lhelper.LetterToEnum(savedSort);
            var result = lhelper.GetTypeByEnum(en);
            if (!result.Succeeded)
            {
                MessageBox.Show(string.Join(",", result.Info));
            }
            lessonTypes = result.Object as List<LessonType>;
            dgvLesson.DataSource = lessonTypes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var window = new AddRule(savedSort);
            window.Text = savedSort + "类规则";
            window.FinishAddRuleEvent += FinishAddRule;
            window.Show();
        }

        private void FinishAddRule(string name, double price, double value, int grade)
        {
            var result = lhelper.AddLessonType(name, price, value, grade,savedSort);
            if(!result.Succeeded)
            {
                MessageBox.Show(string.Join(",", result.Info));
            }
            else
            {
                Flush();
            }
        }

        private void FinishEditRule(long id,string name, double price, double value, int grade)
        {            
            var result = lhelper.EditLessonType(id ,name, price, value, grade);
            if (!result.Succeeded)
            {
                MessageBox.Show(string.Join(",", result.Info));
            }
            else
            {
                Flush();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要删除该规则吗？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                var lessonResult = lhelper.DeleteLessonType(dgvLesson.SelectedRows[0].DataBoundItem as LessonType);
                if(!lessonResult.Succeeded)
                {
                    MessageBox.Show(string.Join(",", lessonResult.Info));
                }
                else
                {
                    MessageBox.Show("删除成功");
                }
                Flush();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if(dgvLesson.SelectedRows.Count>0)
            {
                var window = new EditType(dgvLesson.SelectedRows[0].DataBoundItem as LessonType, savedSort);
                window.FinishEditEvent += FinishEditRule;
                window.Show();
            }
        }
    }
}
