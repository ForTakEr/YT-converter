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
            int i = 1;
            formaat = Convert.ToString(FormatList.SelectedItem);
            //Video
            if (formaat == "Mp4")
            {
                while (!File.Exists("*.mp4"))
                {
                    switch (i)
                    {
                        case 1: //1080p
                            index = 137;
                            i++;
                            break;
                        case 2: //720p
                            index = 22;
                            i++;
                            break;
                        case 3: //480p
                            index = 135;
                            i++;
                            break;
                        case 4: //360p
                            index = 18;
                            i++;
                            break;
                    }
                    if (!string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(formaat))
                    {
                        var convert = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "youtube-dl.exe",
                                Arguments = "-f " + index + " " + link,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true
                            }
                        };
                        try
                        {
                            convert.Start();
                            convert.WaitForExit();

                            if (File.Exists("*.mp4"))
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Youtube-dl ei leitud");
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Palun täida kõik väljad");
                        break;
                    }
                }
                MessageBox.Show("Video on convertitud");
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
            FormatList.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("okei");
        }
    }
}
