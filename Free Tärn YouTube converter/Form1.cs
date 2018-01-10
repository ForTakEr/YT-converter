using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Free_Tärn_YouTube_converter
{
    public partial class Form1 : Form
    {
        public string formaat;
        public string link;
        public int index;
        public string kõik;

        public Form1()
        {
            InitializeComponent();
            FormatList.Items.Add("Mp4");
            FormatList.Items.Add("m4a");
            FormatList.Items.Add("webm");
        }

        private void FormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            formaat = Convert.ToString(FormatList.SelectedItem);
            //Video
            if (formaat == "Mp4")
            {
                index = 137;
            }
            //Audio
            if (formaat == "m4a")
            {
                index = 140;
            }
            //Audio
            if (formaat == "webm")
            {
                index = 248;
            }
        }

        private void LinkBox_TextChanged(object sender, EventArgs e)
        {
            link = LinkBox.Text;
            //var proc = new Process
            //{
            //    StartInfo = new ProcessStartInfo
            //    {
            //        FileName = "youtube-dl.exe",
            //        Arguments = "-F " + link,
            //        UseShellExecute = false,
            //        RedirectStandardOutput = true,
            //        CreateNoWindow = true
            //    }
            //};
            //try
            //{
            //    proc.Start();
            //    kõik = proc.StandardOutput.ReadToEnd();
            //    proc.WaitForExit();
            //    FormatList.Text = kõik;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Youtube-dl ei leitud");
            //    throw;
            //}
        }

        private void Tõmba_Click(object sender, EventArgs e)
        {
            //If statementiga Tõmba ei tööta, kui ei ole kõik väljad täidetud
            if (!string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(formaat))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;
                    startInfo.FileName = "youtube-dl.exe";
                    startInfo.Arguments = "-f " + index + " " + link;
                    Process.Start(startInfo);
                }
                catch (Exception)
                {
                    MessageBox.Show("Youtube-dl ei leitud");
                    throw;
                }
                MessageBox.Show("Video on convertitud"); 
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LinkBox.Text = "";
            FormatList.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
