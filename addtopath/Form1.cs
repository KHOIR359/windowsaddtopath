using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addtopath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow= false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput= true;
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
            output = string.Join("\n", output.Split('\n')[4].Split(';'));
                
            
            list.Text = output;
            p.WaitForExit();


            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void list_Click(object sender, EventArgs e)
        {

        }

        private void vs_scroll(object sender, ScrollEventArgs e)
        {
            panel1.VerticalScroll.Value = e.NewValue;
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
