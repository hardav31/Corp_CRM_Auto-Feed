using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FileGenerator.Models;
using System.Threading.Tasks;

namespace FileGenerator

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                GenerateObject gen = new GenerateObject();
                List<Team> teams = await Task.Run(() => (gen.GetTeams()));

                if (radioButton1.Checked)
                {
                    button2.Enabled = false;
                    Save.Filepath = textBox1.Text + "\\CSV.csv";
                    await Task.Run(() => Save.ToCsv(teams));
                    button2.Enabled = true;
                }
                if (radioButton2.Checked)
                {
                    button2.Enabled = false;
                    Save.Filepath = textBox1.Text + "\\CSV.csv";
                    await Task.Run(() => Save.ToXml(teams));
                    button2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please choose a folder","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
