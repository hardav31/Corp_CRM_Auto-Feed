using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Models;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace FileGenerator

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDisable(Button button)
        {
            button.Enabled = false;
        }

        private void buttonEnable(Button button)
        {
            button.Enabled = true;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void generate_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                GenerateObject.generateObject.pCount = (int)projectsCount.Value;
                GenerateObject.generateObject.mCount = (int)membersCount.Value;

                loadLable.Visible = true;
                buttonDisable(generate);
                await Task.Run(() => GenerateObject.generateObject.Generate());
                List<Team> teams = await Task.Run(() => (GenerateObject.generateObject.GetTeamsList()));
                string fileName = $"{DateTime.Now.ToString("hhmmssfff")}";
                if (csvRadioButton.Checked)
                {
                    Save sv = new Save(textBox1.Text + $"\\{fileName}.csv");
                    await Task.Run(() => sv.ToCsv(teams));
                    buttonEnable(generate);
                    loadLable.Visible = false;
                    MessageBox.Show(fileName + ".csv Created in " + textBox1.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (xmlRadioButton.Checked)
                {
                    Save sv = new Save(textBox1.Text + $"\\{fileName}.xml");
                    Records rec = new Records();
                    rec.xTeams = TeamToSerializableTeam.Convert(GenerateObject.generateObject.GetTeamsList());
                    rec.Projects = GenerateObject.generateObject.GetProjectsList();
                    await Task.Run(() => sv.ToXml(rec));
                    buttonEnable(generate);
                    loadLable.Visible = false;
                    MessageBox.Show(fileName + ".xml Created in " + textBox1.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please choose a currect folder", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
