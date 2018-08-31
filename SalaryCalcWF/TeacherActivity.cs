using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Helper;

namespace SalaryCalcWF
{
    public partial class TeacherActivity : Form
    {
        private Teacher teacher;
        private Activity selectedActivity;
        private ActivityHelper activityHelper;
        public TeacherActivity(Teacher t = null)
        {
            InitializeComponent();
            teacher = t;
            if(teacher==null)
            {
                MessageBox.Show("没有找到该教师信息。");
                this.Close();
            }
            else
            {
                activityHelper = ActivityHelper.GetInstance();
                Init();
            }
        }
        private void Init()
        {
            lstTeacherActivity.DisplayMember = "Name";
            lstTeacherActivity.ValueMember = "ID";
            lstTeacherActivity.DataSource = teacher.Activities;
        }

        private void lstTeacherActivity_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedActivity = lstTeacherActivity.SelectedItems[0] as Activity;
            tbxName.Text = selectedActivity.Name;
            tbxValue.Text = selectedActivity.Value.ToString();
            tbxType.Text = selectedActivity.Type.Name;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show(string.Format("确定要将教师[%s]移出活动[%s]吗？",teacher.Name,selectedActivity.Name),"注意",MessageBoxButtons.YesNo);
            if(answer == DialogResult.Yes)
            {
                var result = activityHelper.RemoveFromActivity(selectedActivity, teacher);
                if (!result.Succeeded)
                {
                    MessageBox.Show(string.Join(",", result.Info));
                }
                else
                {
                    MessageBox.Show("移除成功。");
                }
            }
        }

        private void btnAddMon_Click(object sender, EventArgs e)
        {
            var window = new AddActivity();
            window.Show();
        }
    }
}
