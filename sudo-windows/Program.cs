using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sudo
{
    class Program
    {
        static void sudo_start(string file, string argument)
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            startInfo.CreateNoWindow = false;
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = ".";
            startInfo.FileName = @file;
            startInfo.Arguments = @argument;
            //@"/C computerdefaults.exe"
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        static int Main(string[] args)
        {
            int var;
            if (args.Length > 0)
            {
                string[] delFirst = args.Skip(1).ToArray();
                string argument = string.Join(" ", delFirst);
                sudo_start(args[0], argument);
                var = 0;
            }
            else
            {
                System.Console.WriteLine(@"Error: No arguments given! example: sudo cmd.exe");
                var = 1;
            }
            return var;
        }
    }
}