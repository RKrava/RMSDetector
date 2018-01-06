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
                    result = p.MainModule.FileName;
                    label1.Text = $"{result} - это путь к вирусу. Удалить?";
                    return;
                }
                catch (Win32Exception)
                {
                }

            MessageBox.Show("Not found");
        }

        private void DeleteFile(Process badProcess)
        {
            string s = badProcess.MainModule.FileName;
            badProcess.Kill();
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