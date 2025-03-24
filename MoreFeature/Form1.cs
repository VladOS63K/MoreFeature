using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;


namespace MoreFeature
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            try
            {
                runAsAdmin = Properties.Program.Default.RunAsAdmin;
                bool runningAsAdmin = (args.Length != 0 && args[0] == "-admin" ? true : false);
                if (!runningAsAdmin && runAsAdmin)
                {
                    ProcessStartInfo inf = new ProcessStartInfo();
                    inf.FileName = Application.ExecutablePath;
                    inf.Arguments = "-admin";
                    inf.Verb = "runas";
                    Process.Start(inf);
                    Process.GetCurrentProcess().Kill(); // Application.Exit() not working //
                }
                else
                {
                    InitializeComponent();
                    this.TopMost = Properties.Program.Default.TopMost;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error while running program:\n\n{ex.Message}\n\nProgram need to shutdown.","MoreFeature Starter",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        Process runningProcess;
        bool run = false;
        bool runAsAdmin = false;

        public delegate bool EnumWindowsProc(int hWnd, int lParam);

        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        [DllImport("user32.dll")]
        static extern bool BringWindowToTop(IntPtr hWnd);

        void RunProcess(string fileName, bool runAsAdmin, bool bringToTop)
        {
            if (run == true) { return; }
            runningProcess = new Process();
            runningProcess.StartInfo = new ProcessStartInfo(fileName);
            if (runAsAdmin) { runningProcess.StartInfo.Verb = "runas"; }
            runningProcess.Start();
            if (bringToTop) { BringWindowToTop(runningProcess.MainWindowHandle); }
            run = true;
            while (!runningProcess.HasExited)
            {
                run = true;
            }
            run = false;
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            FeatureProgram[] progs = JsonSerializer.Deserialize<FeaturePrograms>(File.ReadAllText("json\\" + Properties.Program.Default.DefaultJson)).Programs;

            foreach (FeatureProgram prog in progs)
            {
                Button b = new Button();
                b.Size = new Size(150, 100);
                b.Text = prog.Name;
                toolTip1.SetToolTip(b, prog.Description);
                b.MouseEnter += (s, p) =>
                {
                    toolStripStatusLabel1.Text = prog.Description;
                };
                b.Click += (s, p) =>
                {
                    try
                    {
                        RunProcess(prog.Path, Properties.Settings.Default.RunAsAdmin, Properties.Settings.Default.TopMost);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void fileListEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }
    }
}
