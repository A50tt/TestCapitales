using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace TestAboutCapitals
{
    public partial class GettingStarted_Form4 : Form
    {
        public GettingStarted_Form4()
        {
            InitializeComponent();
            this.Show();
        }

        public void CountDown(int num)
        {
            if (num == 0)
            {
                this.label1.Visible = true;
            }

            else if (num == 1)
            {
                this.label2.Visible = true;
            }

            else if (num == 2)
            {
                this.label3.Visible = true;
            }

            else if (num == 3)
            {
                this.label4.Visible = true;
            }
        }
        private void GettingStarted_Form4_Shown(object sender, EventArgs e)
        {
            if (Program.GameMode == 10)
            {
            Application.DoEvents();
            CountDown(0);
            Program.WaitSomeTimeAndUpdate(200);
            CountDown(1);
            }
            else if (Program.GameMode == 20)
            {
                Application.DoEvents();
                CountDown(0);
                Program.WaitSomeTimeAndUpdate(175);
                CountDown(1);
            }
            else if (Program.GameMode == 30)
            {
                Application.DoEvents();
                CountDown(0);
                Program.WaitSomeTimeAndUpdate(100);
                CountDown(1);
            }

        }

        private void label2_VisibleChanged(object sender, EventArgs e)
        {
            //STARTING THE COUNTER
            if (Program.GameMode == 10)
            {
                Program.WaitSomeTimeAndUpdate(1000);
                CountDown(2);
            }
            else if (Program.GameMode == 20)
            {
                Program.WaitSomeTimeAndUpdate(1600);
                CountDown(2);
            }
            else if (Program.GameMode == 30)
            {
                Program.WaitSomeTimeAndUpdate(1600);
                CountDown(2);
            }

        }

        private void label3_VisibleChanged(object sender, EventArgs e)
        {
            //"3..." NOW VISIBLE!
            if (Program.GameMode == 10)
            {
                Program.WaitSomeTimeAndUpdate(1100);
                CountDown(3);
            }
            else if (Program.GameMode == 20)
            {
                Program.WaitSomeTimeAndUpdate(1500);
                CountDown(3);
            }
            else if (Program.GameMode == 30)
            {
                Program.WaitSomeTimeAndUpdate(800);
                CountDown(3);
            }

        }

        private void label4_VisibleChanged(object sender, EventArgs e)
        {
            //"2..." NOW VISIBLE!
            if (Program.GameMode == 10)
            {
                Program.WaitSomeTimeAndUpdate(1600);
                Test_Form2 form2 = new Test_Form2();
                Program.WaitSomeTimeAndUpdate(450);
                this.Hide();
                form2.Show();
            }
            else if (Program.GameMode == 20)
            {
                Program.WaitSomeTimeAndUpdate(1500);
                Test_Form2 form2 = new Test_Form2();
                Program.WaitSomeTimeAndUpdate(1550);
                this.Hide();
                form2.Show();
            }
            else if (Program.GameMode == 30)
            {
                Program.WaitSomeTimeAndUpdate(350);
                Test_Form2 form2 = new Test_Form2();
                Program.WaitSomeTimeAndUpdate(350);
                this.Hide();
                form2.Show();
            }
        }

        private void GettingStarted_Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
