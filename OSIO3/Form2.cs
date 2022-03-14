using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OSIO3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

      

        private void GetFileInformation(string fileName)
        {
            FileInfo f = new FileInfo(fileName);

            label1.Text = "Creation Time - " + f.CreationTime.ToString();
            label2.Text = "Directory Name - " + f.DirectoryName;
            label3.Text = "File Extension - " + f.Extension;
            label4.Text = "Full Name - " + f.FullName;
            label5.Text = "Last Access Time - " + f.LastAccessTime.ToString();
            label6.Text = "Last Write Time - " + f.LastWriteTime.ToString();
            label7.Text = "File Size - " + (f.Length / 1024).ToString() + "KB";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetFileInformation(f.FileName);
            }
        }
    }
}

