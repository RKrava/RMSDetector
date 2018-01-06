using System;
using System.Threading;
using System.Windows.Forms;

namespace RMS_Detector
{
    public partial class General : Form
    {
        private readonly GeneralVm _vm;

        public General()
        {
            InitializeComponent();
            _vm = new GeneralVm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_vm.CheckProcess())
            {
                MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                new Question().Show();
                return;
            }
            MessageBox.Show("Програму RMS не знайдено!");
            Thread.Sleep(500);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_vm.CheckProcess())
            {
                timer1.Enabled = false;
                MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                new Question().Show();
                return;
            }
            Thread.Sleep(500);
        }
    }
}