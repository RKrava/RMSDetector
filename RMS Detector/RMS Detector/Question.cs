using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RMS_Detector
{
    public partial class Question : Form
    {
        public Question()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FindProcess();
        }

        private void FindProcess()
        {
            int flag = 0;
            var processlist = Process.GetProcessesByName("rutserv");
            foreach (var p in processlist)
                try
                {
                    DeleteFile(p);
                    flag = 1;
                    return;
                }
                catch (Win32Exception)
                {
                }
            if (flag == 0)
            {
                processlist = Process.GetProcessesByName("rfusclient");
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
        }

        private void DeleteFile(Process badProcess)
        {
            string s = "";
            s = badProcess.MainModule.FileName;
            const string message = "Ви бажаєте видалити шкідливе программне забезпечення RMS";
            const string caption = "Видалення";
            var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                this.Hide();
                Application.Exit();
            }
            else
            {
                badProcess.Kill();
                Thread.Sleep(500);
                if (s != "") File.Delete(s);
                this.Hide();
                Application.Exit();
            }
        }

        private void Question_Load(object sender, EventArgs e)
        {

        }
    }
}
