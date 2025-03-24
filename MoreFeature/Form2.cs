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

namespace MoreFeature
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.TopMost = Properties.Program.Default.TopMost;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            programMost.Checked = Properties.Program.Default.TopMost;
            programAdmin.Checked = Properties.Program.Default.RunAsAdmin;
            foreach (string json in Directory.GetFiles("json\\"))
            {
                string name = Path.GetFileName(json);
                jsonList.Items.Add(name);
            }
            jsonList.SelectedItem = Properties.Program.Default.DefaultJson;

            startMost.Checked = Properties.Settings.Default.TopMost;
            startAdmin.Checked = Properties.Settings.Default.RunAsAdmin;
        }

        private void programAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (programAdmin.Checked)
            {
                startAdmin.Checked = true;
                startAdmin.Enabled = false;
            }
            else
            {
                startAdmin.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Program.Default.TopMost = programMost.Checked;
            Properties.Program.Default.RunAsAdmin = programAdmin.Checked;
            Properties.Program.Default.DefaultJson = jsonList.SelectedItem.ToString();

            Properties.Settings.Default.TopMost = startMost.Checked;
            Properties.Settings.Default.RunAsAdmin = startAdmin.Checked;

            Properties.Settings.Default.Save();
            Properties.Program.Default.Save();

            MessageBox.Show("Restarting program after clicking ОК");

            Application.Restart();
        }

        private void startAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
