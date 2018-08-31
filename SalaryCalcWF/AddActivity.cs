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
    public partial class AddActivity : Form
    {
        public AddActivity(string sort="")
        {
            InitializeComponent();
            switch (sort)
            {
                case "":
                    
                default:
                    break;
            }
        }

        private void cbxActType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
