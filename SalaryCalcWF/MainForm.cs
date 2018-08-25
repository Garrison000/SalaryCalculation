using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryCalcWF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            var window = new TeacherManage();
            window.Show();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void btnFindActivity_Click(object sender, EventArgs e)
        {
            var window = new TeacherActivity();
            window.Show();
               
        }
    }
}
