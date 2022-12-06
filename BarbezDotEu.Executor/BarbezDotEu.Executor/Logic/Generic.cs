using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;

namespace HanTools.Logic
{
    public static class Generic
    {
        public static void RunExternalProcess(string appPath, string args, bool useShellExecute, bool waitForExit)
        {
            ProcessStartInfo info = new ProcessStartInfo(appPath, @args);
            info.UseShellExecute = useShellExecute;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            if (waitForExit) p.WaitForExit();
        }

        public static void RunExternalProcess(string appPath, string args)
        {
            ProcessStartInfo info = new ProcessStartInfo(appPath, @args);
            info.UseShellExecute = false;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();
        }

        public static void OpenWebsite(string url, bool anonymous)
        {
            Process myProcess = new Process();

            try
            {
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = GetDefaultBrowserPath();

                //if (anonymous) myProcess.StartInfo.Arguments += "-private-window";
                if (anonymous) myProcess.StartInfo.Arguments += "-private";
                myProcess.StartInfo.Arguments += " " + url;

                myProcess.Start();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private static string GetDefaultBrowserPath()
        {
            string key = @"http\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }
    }
}
