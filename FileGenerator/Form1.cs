using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FileGenerator.Models;
using System.Threading.Tasks;
using System.Configuration;

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
                int count;
                if (!int.TryParse((ConfigurationManager.AppSettings["membersCount"]), out count) || count <= 0 || count > 1000000)
                {
                    MessageBox.Show("ENTER FROM 1 TO 1000000", "Invalid Count For Member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!int.TryParse((ConfigurationManager.AppSettings["projectsCount"]), out count) || count <= 0 || count > 10000)
                {
                    MessageBox.Show("ENTER FROM 1 TO 10000", "Invalid Count For Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else 
                {
                    loadLable.Visible = true;
                    GenerateObject gen = new GenerateObject();
                    List<Team> teams = await Task.Run(() => (gen.GetTeams()));
                    
                    if (radioButton1.Checked)
                    {
                        Save.Filepath = textBox1.Text + "\\CSV.csv";
                        await Task.Run(() => Save.ToCsv(teams));
                        loadLable.Visible = false;
                    }
                    if (radioButton2.Checked)
                    {

                        Save.Filepath = textBox1.Text + "\\XML.csv";
                        await Task.Run(() => Save.ToXml(teams));
                        loadLable.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a folder", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     
    }
}
