using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS_Detector
{
    public class GeneralVm
    {
        public bool CheckProcess()
        {
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
                if (instance.ProcessName == "RMS" || instance.ProcessName == "rutserv" || instance.ProcessName == "rfusclient")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
