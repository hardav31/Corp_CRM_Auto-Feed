using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FileGenerator.Models;

namespace FileGenerator

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
          if (folderBrowserDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
             this.textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            GenerateObject gen = new GenerateObject();
            List<Team> teams = gen.GetTeams();
            Save sv;
               

            if (textBox1.Text=="")
            {
                MessageBox.Show("Please choose folder");
            }
            if (radioButton1.Checked)
            {
                button2.Enabled = false;
                sv = new Save(textBox1.Text + "\\CSV.csv");
                Save.ToCsv(teams);
                button2.Enabled = true;
                //CSVConvertor csvConvertor = new CSVConvertor(textBox1.Text + "\\text.csv");
                //csvConvertor.WriteInCSV(csvConvertor.CreateObject(100000));
                //button2.Enabled = true;
            }
            else
            if (radioButton2.Checked)
            {
                button2.Enabled = false;
                sv = new Save(textBox1.Text + "\\XML.txt");
                Save.ToXml(teams);
                button2.Enabled = true;
            }

        }
    }
}
