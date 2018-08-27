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
                LessonType type;
                try
                {
                    type = new LessonType
                    {
                        DefaultValue = double.Parse(tbxValue.Text),
                        Price = double.Parse(tbxPrice.Text),
                        Grade = int.Parse(tbxGrade.Text),
                        LessonName = tbxName.Text
                    };
                }
                catch(Exception)
                {
                    MessageBox.Show("输入有误，检查是否有圆角或者中文。");
                }
            }
        }
    }
}
