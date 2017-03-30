using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Enter Path for Key location...";
            if (fbd.ShowDialog() == DialogResult.OK)
                MessageBox.Show(fbd.SelectedPath);
            KeyBox.Text = fbd.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Enter Path for Cert location...";
            if (fbd.ShowDialog() == DialogResult.OK)
                MessageBox.Show(fbd.SelectedPath);
            CertBox.Text = fbd.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            
            if (fbd.ShowDialog() == DialogResult.OK)
                MessageBox.Show(fbd.FileName);
            FileBox.Text = fbd.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Enter Path for images...";
            if (fbd.ShowDialog() == DialogResult.OK)
                MessageBox.Show(fbd.SelectedPath);
            FileLocation.Text = fbd.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
