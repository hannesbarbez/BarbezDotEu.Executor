using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;

namespace BarbezDotEu.Executor.Wpf.Logic
{
    public static class Generic
    {
        public static void RunExternalProcess(string appPath, string args, bool useShellExecute, bool waitForExit)
        {
            ProcessStartInfo info = new(appPath, @args)
            {
                UseShellExecute = useShellExecute
            };

            Process p = new()
            {
                StartInfo = info
            };
            p.Start();
            if (waitForExit) p.WaitForExit();
        }

        public static void RunExternalProcess(string appPath, string args)
        {
            ProcessStartInfo info = new(appPath, @args)
            {
                UseShellExecute = false
            };

            Process p = new()
            {
                StartInfo = info
            };
            p.Start();
        }

        public static void OpenWebsite(string url)
        {
            Process myProcess = new();
            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = url;
                myProcess.Start();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
    }
}
