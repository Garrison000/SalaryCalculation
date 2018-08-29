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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要删除该规则吗？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {

            }
        }
    }
}
