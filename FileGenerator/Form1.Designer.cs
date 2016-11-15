namespace FileGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.generate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xmlRadioButton = new System.Windows.Forms.RadioButton();
            this.csvRadioButton = new System.Windows.Forms.RadioButton();
            this.browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.loadLable = new System.Windows.Forms.Label();
            this.membersCount = new System.Windows.Forms.NumericUpDown();
            this.projectsCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.membersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(148, 123);
            this.generate.Margin = new System.Windows.Forms.Padding(2);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(217, 30);
            this.generate.TabIndex = 6;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 23);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose file type";
            // 
            // xmlRadioButton
            // 
            this.xmlRadioButton.AutoSize = true;
            this.xmlRadioButton.Location = new System.Drawing.Point(193, 102);
            this.xmlRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.xmlRadioButton.Name = "xmlRadioButton";
            this.xmlRadioButton.Size = new System.Drawing.Size(47, 17);
            this.xmlRadioButton.TabIndex = 4;
            this.xmlRadioButton.Text = "XML";
            this.xmlRadioButton.UseVisualStyleBackColor = true;
            // 
            // csvRadioButton
            // 
            this.csvRadioButton.AutoSize = true;
            this.csvRadioButton.Checked = true;
            this.csvRadioButton.Location = new System.Drawing.Point(102, 102);
            this.csvRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.csvRadioButton.Name = "csvRadioButton";
            this.csvRadioButton.Size = new System.Drawing.Size(46, 17);
            this.csvRadioButton.TabIndex = 3;
            this.csvRadioButton.TabStop = true;
            this.csvRadioButton.Text = "CSV";
            this.csvRadioButton.UseVisualStyleBackColor = true;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(442, 23);
            this.browse.Margin = new System.Windows.Forms.Padding(2);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(61, 20);
            this.browse.TabIndex = 2;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose folder";
            // 
            // loadLable
            // 
            this.loadLable.AutoSize = true;
            this.loadLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadLable.Location = new System.Drawing.Point(218, 168);
            this.loadLable.Name = "loadLable";
            this.loadLable.Size = new System.Drawing.Size(75, 16);
            this.loadLable.TabIndex = 7;
            this.loadLable.Text = "Loading......";
            this.loadLable.Visible = false;
            // 
            // membersCount
            // 
            this.membersCount.Location = new System.Drawing.Point(105, 66);
            this.membersCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.membersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.membersCount.Name = "membersCount";
            this.membersCount.Size = new System.Drawing.Size(46, 20);
            this.membersCount.TabIndex = 8;
            this.membersCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // projectsCount
            // 
            this.projectsCount.Location = new System.Drawing.Point(210, 66);
            this.projectsCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.projectsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.projectsCount.Name = "projectsCount";
            this.projectsCount.Size = new System.Drawing.Size(46, 20);
            this.projectsCount.TabIndex = 8;
            this.projectsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Members";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Projects";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 202);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.projectsCount);
            this.Controls.Add(this.membersCount);
            this.Controls.Add(this.loadLable);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xmlRadioButton);
            this.Controls.Add(this.csvRadioButton);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.membersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton xmlRadioButton;
        private System.Windows.Forms.RadioButton csvRadioButton;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label loadLable;
        private System.Windows.Forms.NumericUpDown membersCount;
        private System.Windows.Forms.NumericUpDown projectsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

