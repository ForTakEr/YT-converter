using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Free_Tärn_YouTube_converter
{
    public partial class Form1 : Form
    {
        public string formaat;

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
        }

        private void LinkBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tõmba_Click(object sender, EventArgs e)
        {

        }
    }
}
