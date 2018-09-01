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

namespace SalaryCalcWF
{
    public partial class AddActivity : Form
    {
        private List<string> category;
        public AddActivity(ActivityTypeEnum e = ActivityTypeEnum.None)
        {
            InitializeComponent();
            switch(e)
            {
                case ActivityTypeEnum.Monitoring:
                    cbxActType.SelectedIndex = 0;
                    break;
                case ActivityTypeEnum.Affairs:
                    cbxActType.SelectedIndex = 1;
                    break;
                case ActivityTypeEnum.ClassAdviser:
                    cbxActType.SelectedIndex = 2;
                    break;
                case ActivityTypeEnum.Library:
                    cbxActType.SelectedIndex = 3;
                    break;
                case ActivityTypeEnum.News:
                    cbxActType.SelectedIndex = 4;
                    break;
                case ActivityTypeEnum.Cross:
                    cbxActType.SelectedIndex = 5;
                    break;
                case ActivityTypeEnum.Other:
                    cbxActType.SelectedIndex = 6;
                    break;
            }
        }

        private void InitCategory()
        {
            category = new List<string>();
            category.Add("监考");
            category.Add("兼任图书管理、实验室、机房管理");
            category.Add("担任班主任");
            category.Add("负责小学图书借阅工作");
            category.Add("新闻组或宣传组成员");
            category.Add("跨头跨科");
            category.Add("其他");
            cbxActType.DataSource = category;
        }

        private void cbxActType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
