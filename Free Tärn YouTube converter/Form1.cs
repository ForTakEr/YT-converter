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
using System.IO;
using System.Threading;

namespace Free_Tärn_YouTube_converter
{
    public partial class Form1 : Form
    {
        public string formaat;
        public string link;
        public int index;
        public string kõik;
        public string failiNimi;
        public string path;

        public Form1()
        {
            InitializeComponent();
            FormatList.Items.Add("mp4");
            FormatList.Items.Add("m4a");
            FormatList.Items.Add("webm");
        }

        private void FormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            formaat = Convert.ToString(FormatList.SelectedItem);
            if (!string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(formaat))
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = Directory.GetCurrentDirectory();
                }
                while (true)
                {
                    var convert = new Process();
                    convert.StartInfo.FileName = "youtube-dl.exe";
                    if (!string.IsNullOrWhiteSpace(failiNimi))
                    {
                        convert.StartInfo.Arguments = "-o " + "\u0022" + path + @"\" + failiNimi + "." + formaat + "\u0022" + " " + link; 
                    }
                    else
                    {
                        var fileName = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "youtube-dl.exe",
                                Arguments = "--get-filename " + link,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true
                            }
                        };
                        fileName.Start();
                        failiNimi = fileName.StandardOutput.ReadToEnd();
                        fileName.WaitForExit();
                        failiNimi.Replace("\n", "");
                        convert.StartInfo.Arguments = "-o " + "\u0022" + path + @"\" + failiNimi.Replace("\n", "") + "\u0022" + " " + link;
                    }
                    if (!KonsooliNäha.Checked)
                    {
                        convert.StartInfo.UseShellExecute = false;
                        convert.StartInfo.CreateNoWindow = true; 
                    }

                    try
                    {
                        convert.Start();
                        convert.WaitForExit();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Youtube-dl ei leitud");
                        throw;
                    }

                    if (!string.IsNullOrWhiteSpace(NimeBox.Text))
                    {
                        if (File.Exists(path + @"\" + failiNimi + "." + formaat))
                        {
                            MessageBox.Show("Teie video on convertitud");
                            LinkBox.Text = "";
                            FormatList.ResetText();
                            NimeBox.Text = "";
                            break;
                        }  
                    }
                    else
                    {
                        if (File.Exists(path + @"\" + failiNimi))
                        {
                            MessageBox.Show("Teie video on convertitud");
                            LinkBox.Text = "";
                            FormatList.ResetText();
                            NimeBox.Text = "";
                            break;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad");
            }
            ////If statementiga Tõmba ei tööta, kui ei ole kõik väljad täidetud
            //if (!string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(formaat))
            //{
            //    try
            //    {
            //        ProcessStartInfo startInfo = new ProcessStartInfo();
            //        startInfo.UseShellExecute = false;
            //        startInfo.CreateNoWindow = true;
            //        startInfo.FileName = "youtube-dl.exe";
            //        startInfo.Arguments = "-f " + index + " " + link;
            //        Process.Start(startInfo);
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Youtube-dl ei leitud");
            //        throw;
            //    }
            //    MessageBox.Show("Video on convertitud"); 
            //}
            //else
            //{
            //    MessageBox.Show("Palun täida kõik väljad");
            //}
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LinkBox.Text = "";
            FormatList.ResetText();
            NimeBox.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
        }

        private void NimeBox_TextChanged(object sender, EventArgs e)
        {
            failiNimi = NimeBox.Text;
        }

        private void KonsooliNäha_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
