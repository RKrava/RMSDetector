using System;
using System.Threading;
using System.Windows.Forms;
using System.ServiceProcess;
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
                timer1.Enabled = false;
                new Question().Show();
                return;
            }
            foreach (ServiceController service in ServiceController.GetServices())
            {
                if (service.DisplayName == "TektonIT - RMS Host")
                {
                    if (service.Status.Equals(ServiceControllerStatus.Stopped) ||
                        (service.Status.Equals(ServiceControllerStatus.StopPending))){}
                    else
                    {
                        MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                        timer1.Enabled = false;
                        new Question().Show();
                        return;
                    }
                }
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
            foreach (ServiceController service in ServiceController.GetServices())
            {
                if (service.DisplayName == "TektonIT - RMS Host")
                {
                    if (service.Status.Equals(ServiceControllerStatus.Stopped) ||
                        (service.Status.Equals(ServiceControllerStatus.StopPending))) { }
                    else
                    {
                        MessageBox.Show("На вашому комп'ютері знайдено програму вірус RMS!");
                        timer1.Enabled = false;
                        new Question().Show();
                        return;
                    }
                }
            }
            Thread.Sleep(500);
        }


        private void General_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void General_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
        "Хотите свернуть приложение в трей?";
            const string caption = "Закрытие Формы";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
            }
        }
    }
}