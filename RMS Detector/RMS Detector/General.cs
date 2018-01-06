using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS_Detector
{
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
        }

        private void General_Load(object sender, EventArgs e)
        {

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {

            bool isRMS = false;
            Question qe = new Question();
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
                if (instance.ProcessName == "RMS")
                {
                    timer1.Enabled = false;
                    MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                    isRMS = true;
                    qe.Show();
                    break;
                }
                else if (instance.ProcessName == "rutserv")
                {
                    timer1.Enabled = false;
                    MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                    qe.Show();
                    isRMS = true;
                    break;
                }
                else if (instance.ProcessName == "rfusclient")
                {
                    timer1.Enabled = false;
                    MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                    qe.Show();
                    isRMS = true;
                    break;
                }
            }
            System.Threading.Thread.Sleep(500);
        }
    }
}
