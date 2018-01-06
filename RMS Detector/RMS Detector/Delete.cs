using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RMS_Detector
{
    public partial class Delete : Form
    {
        private string result = "";

        public Delete()
        {
            InitializeComponent();
            FindProcess();
        }

        private void FindProcess()
        {
            var processlist = Process.GetProcessesByName("rfusclient");
            foreach (var p in processlist)
                try
                {
                    DeleteFile(p);
                    return;
                }
                catch (Win32Exception)
                {
                }

        }

        private void DeleteFile(Process badProcess)
        {
            string s = badProcess.MainModule.FileName;
            badProcess.Kill();
            MessageBox.Show("Not found");//Вот здесь 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var etc = Process.GetProcesses();

            foreach (var anti in etc)
            {
                string name1 = "rutserv";
                string name2 = "rfusclient";
                string name3 = "RMS";
                string processName = anti.ProcessName.ToLower();

                if (processName.Contains(name1) || processName.Contains(name2)
                    || processName.Contains(name3))
                {
                    anti.Kill();
                }
            }
            File.Delete(result);
        }
    }
}