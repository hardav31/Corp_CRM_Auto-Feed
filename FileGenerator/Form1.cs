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
using FileGenerator;
using FileGenerator.DataModel;
using FileGenerator.Convertors;

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

            button2.Enabled = false; //TODO with Task
            if (textBox1.Text=="")
            {
                MessageBox.Show("Please choose folder");
            }
            if (radioButton1.Checked)
            {
                CSVConvertor csvConvertor = new CSVConvertor(textBox1.Text + "\\text.csv");
                csvConvertor.WriteInCSV(csvConvertor.CreateObject(100000));
                button2.Enabled = true;
            }
            else
                if (radioButton2.Checked)
            {
                //call XML generator
            }
            
        }
    }
}
