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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Use_Notify(); // Setting up all Property of Notifyicon
        }
        private void Use_Notify()
        {
            MyNotify.ContextMenuStrip = contextMenuStrip1;
            MyNotify.BalloonTipText = "This is A Sample Application";
            MyNotify.BalloonTipTitle = "Your Application Name";
            MyNotify.ShowBalloonTip(1);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            // Hide The Form when it's minimized
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }
        private void MyNotify_DoubleClick(object sender, System.EventArgs e)
        {
            // Show the form when Dblclicked on Notifyicon
            Show();
            WindowState = FormWindowState.Normal;
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Will Close Your Application 
            MyNotify.Dispose();
            Application.Exit();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Will Restore Your Application 
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Settings 1
            MessageBox.Show("Your Application Settings 1");
        }

        private void settings2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Settings 2
            MessageBox.Show("Your Application Settings 2");
        }

        private void MyNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void fileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FileLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void fileLocationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Myform = new Settings();
            Myform.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit????", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Myform = new DicomMonitor();
            Myform.Show();
        }
    }
}