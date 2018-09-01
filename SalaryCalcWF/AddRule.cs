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
    public partial class AddRule : Form
    {
        public delegate void FinishAddRuleDelegate(string name, double price, double value, int grade);
        public event FinishAddRuleDelegate FinishAddRuleEvent;
        private LessonHelper lessonHelper;
        public AddRule(string sort)
        {
            InitializeComponent();
            tbxValue.Text = "1";
            if (sort == "")
                this.Close();
            lessonHelper = LessonHelper.GetInstance();
            tbxPrice.Text = lessonHelper.GetPrice(lessonHelper.LetterToEnum(sort)).ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == "" || tbxGrade.Text == "" || tbxPrice.Text == "" || tbxValue.Text == "")
            {
                MessageBox.Show("请完整填写所有项目");
                return;
            }   
            double price, value;
            int grade;
            var result = double.TryParse(tbxPrice.Text, out price);
            if (!result)
            {
                MessageBox.Show("请输入数字。");
                return;
            }
            result = double.TryParse(tbxValue.Text, out value);
            if (!result)
            {
                MessageBox.Show("请输入数字。");
                return;
            }
            result = int.TryParse(tbxGrade.Text, out grade);
            if (!result)
            {
                MessageBox.Show("请输入数字。");
                return;
            }

            FinishAddRuleEvent?.Invoke(tbxName.Text,price,value,grade);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
