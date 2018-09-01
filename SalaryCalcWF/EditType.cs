﻿using System;
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
        public delegate void FinishEditEventHandler(long id, string name, double price, double value, int grade);
        public event FinishEditEventHandler FinishEditEvent;
        private LessonHelper lessonHelper;
        private LessonType original;
        private string enString;

        public EditType(LessonType type = null,string enstring="")
        {
            InitializeComponent();
            lessonHelper = LessonHelper.GetInstance();
            if(type!=null)
            {
                original = type;
                tbxName.Text = type.LessonName;
                tbxGrade.Text = type.Grade.ToString();
                tbxPrice.Text = type.Price.ToString();
                tbxValue.Text = type.DefaultValue.ToString();
                enString = enstring;
            }
            else
            {
                MessageBox.Show("没有传入type实例。");
                this.Close();
            }
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

            FinishEditEvent?.Invoke(original.ID,tbxName.Text, price, value, grade);
            this.Close();
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
