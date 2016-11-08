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
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void generate_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(textBox1.Text))
            {
                
                int count;
                if (!int.TryParse((ConfigurationManager.AppSettings["membersCount"]), out count) || count <= 0 || count > 100000)
                {
                    MessageBox.Show("ENTER FROM 1 TO 100", "Invalid Count For Member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!int.TryParse((ConfigurationManager.AppSettings["projectsCount"]), out count) || count <= 0 || count > 10000)
                {
                    MessageBox.Show("ENTER FROM 1 TO 10", "Invalid Count For Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                    loadLable.Visible = true;
                    buttonDisable(generate);
                    GenerateObject gen = new GenerateObject();
                    List<Team> teams = await Task.Run(() => (gen.GetTeamList()));

                    if (csvRadioButton.Checked)
                    {
                        Save sv = new Save(textBox1.Text + "\\CSV.csv");
                        await Task.Run(() => sv.ToCsv(teams));
                        buttonEnable(generate);
                        loadLable.Visible = false;
                    }
                    if (xmlRadioButton.Checked)
                    {
                        Save sv = new Save(textBox1.Text + "\\XML.xml");
                        await Task.Run(() => sv.ToXml(teams));
                        buttonEnable(generate);
                        loadLable.Visible = false;
                    }
                    textBox1.Text= "";

                }
            }
            else

            {
                MessageBox.Show("Please choose a currect folder", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
