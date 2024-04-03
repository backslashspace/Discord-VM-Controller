﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Link_Slave
{
    internal partial class Program
    {

        internal static void Start(String[] args)
        {
            Task.Delay(10000).Wait();

            TryCreateNewLine();     //create new line in log for better readability

            Log.FastLog("Win32", $"Service [v{version}] start initiated", xLogSeverity.Info);

            Control.Start.Initiate();
        }

        internal static void Stop()
        {
            Control.Shutdown.ServiceComponents(false);
        }

        // # # # # # # # # # # # # # # # # # #

        private static void TryCreateNewLine()
        {
            try
            {
                using (StreamWriter streamWriter = new($"{Program.assemblyPath}\\logs\\{DateTime.Now:dd.MM.yyyy}.txt", true, Encoding.UTF8))
                {
                    streamWriter.WriteLine();
                }
            }
            catch { }
        }
    }
}