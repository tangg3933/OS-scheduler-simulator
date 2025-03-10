﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

// Author: Nivin Jose Kovukunnel and Phuc Hoang Nguyen

namespace RunPythonScriptFromCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Execute python process...");
            Option1_ExecProcess();

            Console.WriteLine();
            Console.ReadKey();
        }

        static void Option1_ExecProcess()
        {
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            
            // It is important to set the path to your environment, where packages such as Numpy is installed.
            psi.FileName = @"C:\Users\nivin\PycharmProjects\pythonProject\venv\Scripts\python.exe";

            // 2) Provide script and arguments
            var script = @"C:\Users\nivin\PycharmProjects\pythonProject\main.py";  //PART A Code implementation
            
            // var script = @"C:\Users\nivin\PycharmProjects\pythonProject\testing.py"; // Matplot lib example!
            
            // var script = @"C:\Users\nivin\Desktop\testcode.py"; // Python Numpy example!

            // Arguments if they are needed, this section can be omitted or ignored.
            var a = "2";
            var b = "100";

            psi.Arguments = $"\"{script}\" \"{a}\" \"{b}\"";

            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // 4) Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);

        }

    }

}
