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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        bool backupExists = false;
        bool replaced = false;

        private void Form4_Load(object sender, EventArgs e)
        {
            backupExists = File.Exists(Environment.GetEnvironmentVariable("windir")+"\\system32\\Utilman.backup");
            replaced = Properties.Program.Default.UtilmanReplaced;
            label1.Text = "Utilman backup:" + (backupExists ? "Found" : "Not Found");
        }
    }
}
