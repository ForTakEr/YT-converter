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

            if (formaat == "Mp4")
            {
                index = 137;
            }
            if (formaat == "m4a")
            {
                index = 140;
            }
            if (formaat == "webm")
            {
                index = 248;
            }
        }

        private void LinkBox_TextChanged(object sender, EventArgs e)
        {
            link = LinkBox.Text;
        }

        private void Tõmba_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Users\opilane\Documents\visual studio 2017\Projects\Free Tärn YouTube converter\YT-converter\Free Tärn YouTube converter\youtube-dl.exe";
            startInfo.Arguments = "-f " + index + " " + link;
            Process.Start(startInfo);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LinkBox.Text = "";
            FormatList.Text = "";
        }
    }
}
