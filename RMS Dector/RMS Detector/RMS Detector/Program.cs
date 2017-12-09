using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;

namespace RMS_Detector
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new General());
        }
    }
    public partial class General : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Question qe = new Question();
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
                if (instance.ProcessName == "RMS") { qe.Show(); break; }
                else if (instance.ProcessName == "rutserv") { qe.Show(); break; }
                else if (instance.ProcessName == "rfusclient") { qe.Show(); break; }
            }
            System.Threading.Thread.Sleep(5000);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

    }
    public partial class Question : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
        }
    }
    public partial class Delete : Form
    {
        String result = ":(";

        private void Delete_Load(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcessesByName("rutserv");
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

      
    }
}
