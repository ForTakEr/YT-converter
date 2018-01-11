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
        public string YTdl;
        public string ffmpeg;

        public Form1()
        {
            InitializeComponent();
            FormatList.Items.Add("mp4");
            FormatList.Items.Add("m4a");
            FormatList.Items.Add("webm");
            FormatList.Items.Add("wav");
            FormatList.Items.Add("mp3");
        }

        private void FormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(FormatList.SelectedItem) == "mp3" || Convert.ToString(FormatList.SelectedItem) == "wav")
            {
                if (string.IsNullOrWhiteSpace(ffmpeg))
                {
                    MessageBox.Show("Selleks on vaja tõmmata ffmpeg ja ffprobe");
                    FormatList.Text = "";
                }
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
            int i = 1;
            formaat = Convert.ToString(FormatList.SelectedItem);
            if (formaat == "mp4")
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
            }
            if (formaat == "m4a")
            {
                index = 140;
            }
            if (formaat == "webm")
            {
                switch (i)
                {
                    case 1:
                        index = 251;
                        i++;
                        break;
                    case 2:
                        index = 171;
                        i++;
                        break;
                    case 3:
                        index = 250;
                        i++;
                        break;
                    case 4:
                        index = 249;
                        i++;
                        break;
                }
            }
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
                        convert.StartInfo.Arguments = "-f " + index + " -o " + "\u0022" + path + @"\" + failiNimi + "." + formaat + "\u0022" + " " + link; 
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
                        convert.StartInfo.Arguments = "-f " + index + " -o " + "\u0022" + path + @"\" + failiNimi.Replace("\n", "") + "\u0022" + " " + link;
                    }
                    if (!KonsooliNäha.Checked)
                    {
                        convert.StartInfo.UseShellExecute = false;
                        convert.StartInfo.CreateNoWindow = true; 
                    }
                    if (!string.IsNullOrWhiteSpace(YTdl))
                    {
                        convert.StartInfo.FileName = YTdl;
                    }
                    if (!string.IsNullOrWhiteSpace(ffmpeg) && !string.IsNullOrWhiteSpace(YTdl))
                    {
                        if (formaat == "wav" || formaat == "mp3" || formaat == "m4a")
                        {
                            convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " --output " + "\u0022" + path + @"\" + failiNimi.Replace("\n", "") + "." + formaat + "\u0022" + " " + link;
                        }
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ResourceDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (File.Exists(Path.Combine(folderName, "youtube-dl.exe")))
                {
                    YTdl = Path.Combine(folderName, "youtube-dl.exe");
                    MessageBox.Show("Youtube-dl leitud");
                }
                else
                {
                    MessageBox.Show("YouTube-dl ei leitud sealt pathist");
                }
                if (File.Exists(Path.Combine(folderName, "ffmpeg.exe")) && File.Exists(Path.Combine(folderName, "ffprobe.exe")))
                {
                    ffmpeg = Path.Combine(folderName, "ffmpeg.exe");
                    MessageBox.Show("ffmpeg ja ffprobe leitud");
                }
                else
                {
                    MessageBox.Show("ffmpeg ja ffprobe ei leitud");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("Palun valige faili allalaadimise asukoht.");
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("cant touch this");
        }
    }
}
