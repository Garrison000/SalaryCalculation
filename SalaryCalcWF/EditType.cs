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
    public partial class EditType : Form
    {
        public delegate void FinishEditEventHandler();
        public event FinishEditEventHandler FinishEditEvent;
        private LessonHelper lessonHelper;
        private LessonType original;
        public EditType(LessonType type = null)
        {
            InitializeComponent();
            lessonHelper = LessonHelper.GetInstance();
            if(type!=null)
            {
                tbxName.Text = type.LessonName;
                tbxGrade.Text = type.Grade.ToString();
                tbxPrice.Text = type.Price.ToString();
                tbxValue.Text = type.DefaultValue.ToString();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == "" || tbxGrade.Text == "" || tbxPrice.Text == "" || tbxValue.Text == "")
                MessageBox.Show("需要填写所有项目。");
            else
            {
                double defaultValue = 0;
                double price = 0;
                int grade = 0;
                string lessonName = "";
                try
                {
                    defaultValue = double.Parse(tbxValue.Text);
                    price = double.Parse(tbxPrice.Text);
                    grade = int.Parse(tbxGrade.Text);
                    lessonName = tbxName.Text;
                }
                catch(Exception)
                {
                    MessageBox.Show("输入有误，检查是否有圆角或者中文。");
                }
                if(original==null)
                {
                    var result = lessonHelper.AddLessonType(lessonName, price, defaultValue, grade);
                    if (!result.Succeeded)
                    {
                        MessageBox.Show(string.Join(",", result.Info));
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    var result = lessonHelper.EditLessonType(original, lessonName, price, defaultValue, grade);
                    if (!result.Succeeded)
                    {
                        MessageBox.Show(string.Join(",", result.Info));
                    }
                    else
                    {
                        this.Close();
                    }
                }             
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
