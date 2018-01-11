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
using System.Text.RegularExpressions;

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
        public string TXTFail;
        public string Protsenttekst;
        public int protsent;

        public Form1()
        {
            InitializeComponent();
            FormatList.Items.Add("mp4");
            FormatList.Items.Add("m4a");
            FormatList.Items.Add("wav");
            FormatList.Items.Add("mp3");
            if (File.Exists("ffmpeg.exe"))
            {
                ffmpeg = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe");
            }
        }

        private void FormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(FormatList.SelectedItem) == "mp3" || Convert.ToString(FormatList.SelectedItem) == "wav")
            {
                if (string.IsNullOrWhiteSpace(ffmpeg) || !File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe")))
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
            kõik = string.Empty;
            Protsenttekst = string.Empty;
            protsent = 0;

            progressBar1.Visible = true;
            int i = 1;
            formaat = Convert.ToString(FormatList.SelectedItem);
            if (formaat != "wav" && formaat != "mp3" || !string.IsNullOrWhiteSpace(ffmpeg) || File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe")))
            {
                if (formaat == "mp4")
                {
                    switch (i)
                    {
                        case 1: //720p
                            index = 22;
                            i++;
                            break;
                        case 2: //360p
                            index = 18;
                            i++;
                            break;
                    }
                }
                if (formaat == "m4a")
                {
                    index = 140;
                }
                if (File.Exists("ffprobe.exe") && File.Exists("ffmpeg.exe"))
                {
                    ffmpeg = "olemas";
                    YTdl = Path.Combine(Directory.GetCurrentDirectory(), "youtube-dl.exe");
                }

                if (!string.IsNullOrWhiteSpace(link) || !string.IsNullOrWhiteSpace(TXTFail) && !string.IsNullOrWhiteSpace(formaat))
                {
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        path = Directory.GetCurrentDirectory();
                    }
                    while (true)
                    {
                        var convert = new Process();
                        convert.StartInfo.FileName = "youtube-dl.exe";
                        while (true)
                        {
                            if (!string.IsNullOrWhiteSpace(NimeBox.Text))
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
                                failiNimi = failiNimi.Replace("\n", "");
                                int indexNumber = failiNimi.IndexOf(".");
                                if (indexNumber > 0)
                                {
                                    failiNimi = failiNimi.Substring(0, indexNumber);
                                }
                                failiNimi = failiNimi + "." + formaat;
                                convert.StartInfo.Arguments = "-f " + index + " -o " + "\u0022" + path + @"\" + failiNimi + "\u0022" + " " + link;
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
                                    if (!string.IsNullOrWhiteSpace(NimeBox.Text))
                                    {
                                        convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " --output " + "\u0022" + path + @"\" + failiNimi.Replace("\n", "") + "." + formaat + "\u0022" + " " + link;
                                    }
                                    else
                                    {
                                        convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " " + link;
                                        failiNimi = failiNimi.Replace(".mp4", "." + formaat);
                                    }
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(TXTFail))
                            {
                                if (formaat == "wav" || formaat == "mp3" || formaat == "m4a")
                                {
                                    convert.StartInfo.Arguments = "--extract-audio --audio-format " + formaat + " -a " + TXTFail;
                                }
                                else
                                {
                                    convert.StartInfo.Arguments = "-f " + index + " -a " + TXTFail;
                                }
                            }
                            if (!File.Exists(path + @"\" + failiNimi))
                            {
                                if (!KonsooliNäha.Checked)
                                {
                                    convert.StartInfo.RedirectStandardOutput = true;
                                    convert.Start();
                                    for (int a = 0; a < 6; a++)
                                    {
                                        kõik = convert.StandardOutput.ReadLine();
                                    }
                                    while (protsent != 100)
                                    {
                                        kõik = convert.StandardOutput.ReadLine();
                                        if (kõik != null)
                                        {
                                            Protsenttekst = kõik.Substring(11, 6);
                                            //Protsenttekst = Regex.Replace(Protsenttekst, "[^0-9.]", "");
                                            Protsenttekst = Regex.Match(Protsenttekst, @"\d+").Value;
                                            if (Protsenttekst == "")
                                            {
                                                break;
                                            }
                                            protsent = Int32.Parse(Protsenttekst);
                                            progressBar1.Value = protsent;
                                        }
                                        else
                                        {
                                            if (formaat == "mp4")
                                            {
                                                switch (i)
                                                {
                                                    case 1: //720p
                                                        index = 22;
                                                        i++;
                                                        break;
                                                    case 2: //360p
                                                        index = 18;
                                                        i++;
                                                        break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    convert.WaitForExit();
                                }
                                else
                                {
                                    convert.Start();
                                    convert.WaitForExit();
                                    if (File.Exists(path + @"\" + failiNimi + "." + formaat))
                                    {
                                        break;
                                    }
                                }

                                if (string.IsNullOrWhiteSpace(TXTFail))
                                {
                                    if (!string.IsNullOrWhiteSpace(NimeBox.Text))
                                    {
                                        if (File.Exists(path + @"\" + failiNimi + "." + formaat))
                                        {
                                            MessageBox.Show("Teie video on alla laetud");
                                            LinkBox.Text = "";
                                            FormatList.ResetText();
                                            NimeBox.Text = "";
                                            progressBar1.Value = 0;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (File.Exists(path + @"\" + failiNimi))
                                        {
                                            MessageBox.Show("Teie video on alla laetud");
                                            LinkBox.Text = "";
                                            FormatList.ResetText();
                                            NimeBox.Text = "";
                                            progressBar1.Value = 0;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Teie videod on alla laetud");
                                    LinkBox.Text = "";
                                    FormatList.ResetText();
                                    NimeBox.Text = "";
                                    progressBar1.Value = 0;
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("See video/audio on teil juba seal olemas");
                                break;
                            }
                        }
                        break;
                    }

                }
                else
                {
                    MessageBox.Show("Palun täida kõik väljad");
                } 
            }
            else
            {
                MessageBox.Show("Palun lisage ffmpeg ja ffprobe directory või pange see samasse folderisse, kus on see programm");
            }
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
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Palun valige faili allalaadimise asukoht.");
            }
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in files)
            {
                TXTFail = filePath;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
