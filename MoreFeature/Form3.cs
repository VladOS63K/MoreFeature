using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoreFeature
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.TopMost = Properties.Program.Default.TopMost;
        }
        FeatureProgram[] progs;

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] pathes = Directory.GetFiles("json\\");
            foreach (string path in pathes)
            {
                var name = Path.GetFileName(path);
                comboBox1.Items.Add(name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            progs = JsonSerializer.Deserialize<FeaturePrograms>(File.ReadAllText("json\\" + comboBox1.SelectedItem)).Programs;
            dataGridView1.Rows.Clear();
            foreach (FeatureProgram prog in progs)
            {
                dataGridView1.Rows.Add(prog.Name, prog.Path, prog.Arguments, prog.Description);
            }
            dataGridView1.Enabled = true;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                List<FeatureProgram> list = new List<FeatureProgram>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    list.Add(new FeatureProgram((string)row.Cells[0].Value, (string)row.Cells[2].Value, (string)row.Cells[1].Value, (string)row.Cells[3].Value));
                }
                progs = list.ToArray<FeatureProgram>();
                File.WriteAllText("json\\" + comboBox1.SelectedItem, JsonSerializer.Serialize<FeaturePrograms>(new FeaturePrograms(progs)));
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dataGridView1.Enabled)
            {
                MessageBox.Show("Select file first!");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("cmd", "cmd.exe", "", "");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            InputBoxResult res = InputBox.Show("File list name to create", "", "Example");
            if (res.DialogResult == InputBoxDialogResult.OK && String.IsNullOrWhiteSpace(res.Text))
            {
                FileStream newFile = File.Create("json\\" + res.Text + ".json");
                newFile.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DialogResult res = MessageBox.Show("Do you want to delete " + comboBox1.SelectedItem + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    File.Delete("json\\" + comboBox1.SelectedItem);
                }
            }
        }
    }
}