using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class DicomMonitor : Form
    {

        BackgroundWorker m_oWorker;

        public DicomMonitor()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
        }
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If it was cancelled midway
            if (e.Cancelled)
            {
                //lblStatus.Text = "Task Cancelled.";
            }
            else if (e.Error != null)
            {
               // lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                // lblStatus.Text = "Task Completed...";

            }
            //btnStartAsyncOperation.Enabled = true;
            //btnCancel.Enabled = false;
        }
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            //progressBar1.Value = e.ProgressPercentage;
            //lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
        }

        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //NOTE : Never play with the UI thread here...

            //time consuming operation
            for (int i = 0; i < 100; i++)
            {
                string filepath = (@"C:\MyDir");
                string[] files = Directory.GetFiles(filepath, "*.*", SearchOption.AllDirectories);
                for (int index = 0; index < files.Length; index++)
                    foreach (string s in files)
                    {
                        string fileToProcess = filepath;
                        m_oWorker.ReportProgress(100 * index / files.Length, fileToProcess);

                        string port;
                        port = "106";
                        string Host;
                        Host = "192.168.99.13";
                        //string dicompath = @"C:\MyDir";
                        string finalpath = Host + " " + port + " " + s;
                        //textBox1.Text = finalpath;
                        System.Diagnostics.Process pr = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            FileName = @"C:\dcmtk\bin\storescu-tls.exe",
                            Arguments = finalpath

                        });

                        pr.Start();
                        pr.WaitForExit();
                        Thread.Sleep(500);
                        //File.Move(s, @"C:\MyDels");
                        //Provider Source Folder Path
                        string SourceFolder = @"c:\MyDir\";
                        //Provide Destination Folder path
                        //string DestinationFolder = @"C:\MyDels\";

                        var filess = new DirectoryInfo(SourceFolder).GetFiles("*.*");

                        //Loop throught files and Move to destination folder
                        foreach (FileInfo file in filess)
                        {
                            //delete file if already exists
                            //Process.Start("cmd.exe", string.Format("/c del \"{0}", SourceFolder + file.Name));

                            //Move the file to destination folder
                            //file.MoveTo(DestinationFolder + file.Name);

                            System.IO.File.Delete(s);
                            //File.Delete(s);

                        }

                        //pr.WaitForExit();
                        //Thread.Sleep(50);
                        m_oWorker.ReportProgress(i);

                        //If cancel button was pressed while the execution is in progress
                        //Change the state from cancellation ---> cancel'ed
                        if (m_oWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            m_oWorker.ReportProgress(0);
                            return;
                        }

                    }

                //Report 100% completion on operation completed
                m_oWorker.ReportProgress(100);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            /// if (m_oWorker.IsBusy)
            {
                //Stop/Cancel the async operation here
                m_oWorker.CancelAsync();
            }
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            String WatchFolder = @"C:\MyDir";
            FileSystemWatcher fsw = new FileSystemWatcher(WatchFolder);
            fsw.EnableRaisingEvents = true;
            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
        }
        void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            while (m_oWorker.IsBusy)
                m_oWorker.CancelAsync();
            m_oWorker.RunWorkerAsync();

            //listBox1.Text = (e.FullPath + "Has been added. Sending file now....");

        }

        private void btnStartAsyncOperation_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        
    }
}
