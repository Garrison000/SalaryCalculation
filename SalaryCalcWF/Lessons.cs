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
        private LessonHelper lhelper;
        public Lessons GetInstance(string sort)
        {
            if (window == null)
            {
                window = new Lessons(sort);
            }
            return window;
        }
        public Lessons(string sort)
        {
            InitializeComponent();
            lblSort.Text = sort + "类";
            var en = lhelper.LetterToEnum(sort);
            var result = lhelper.GetTypeByEnum(en);
            if(!result.Succeeded)
            {
                MessageBox.Show(string.Join(",",result.Info));
            }
            List<LessonType> lessonTypes = result.Object as List<LessonType>;
            dgvLesson.DataSource = lessonTypes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
