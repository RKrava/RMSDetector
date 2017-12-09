using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

namespace RMS_Detector
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
            String result = ":(";

            Process[] processlist = Process.GetProcessesByName("rfusclient");
            foreach (Process p in processlist)
            {
                try
                {
                    result = p.MainModule.FileName;
                    break;
                }
                catch (Win32Exception)
                {
                }
            }
            label1.Text = result;
            label1.Text += " - это путь к вирусу. Удалить?";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "rutserv";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
            name = "rfusclient";
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
            name = "RMS";
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
            System.IO.File.Delete(result);
        }
    }

       
    }

