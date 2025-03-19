using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAboutCapitals
{
    public partial class Rules_Form5 : Form
    {
        public Rules_Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initialize form1 = new Initialize();            
            form1.Show();
            Program.closeRules = false;
            this.Close();
            
        }

        private void Rules_Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.closeRules == true)
            {
                Environment.Exit(1);
            }

            else
            {
                Program.closeRules = true;
            }
            
        }
    }
}
