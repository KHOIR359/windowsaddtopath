using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process p = new();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.Start();
            p.StandardInput.WriteLine("echo %path%");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            string[] outputArray = output.Split('\n')[4].Split(';');
            List<string> outputList=  outputArray.ToList();
            outputList.Add(args[0]);
            outputArray = outputList.Distinct().ToArray();
            output = string.Join(';', outputArray);



            Process q = new();
            q.StartInfo.UseShellExecute = false;
            q.StartInfo.CreateNoWindow = false;
            q.StartInfo.RedirectStandardOutput = true;
            q.StartInfo.RedirectStandardInput = true;
            q.StartInfo.FileName = "cmd.exe";
            q.Start();
            q.StandardInput.WriteLine("setx path \"" + output+";\"");
            q.StandardInput.Flush();
            q.StandardInput.Close();
            Console.WriteLine("Success");

            
            Console.ReadLine();
              
            

        }

        public static string[] RemoveDuplicates(string[] s)
        {
            HashSet<string> set = new(s);
            string[] result = new string[set.Count];
            set.CopyTo(result);
            return result;
        }
    }
}
