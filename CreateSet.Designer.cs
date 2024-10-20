namespace Quick_Hasher
{
    partial class CreateSet
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            FolderSelect = new FolderBrowserDialog();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            textBox5 = new TextBox();
            inputFolderTextbox = new TextBox();
            outputFolderTextBox = new TextBox();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            textBox6 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(59, 82);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(223, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Choose a hashing function:";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "SHA256", "MD5" });
            comboBox1.Location = new Point(288, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(59, 167);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(201, 23);
            textBox2.TabIndex = 2;
            textBox2.Text = "Choose the input folder:";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // FolderSelect
            // 
            FolderSelect.RootFolder = Environment.SpecialFolder.MyComputer;
            // 
            // button1
            // 
            button1.Location = new Point(288, 165);
            button1.Name = "button1";
            button1.Size = new Size(156, 29);
            button1.TabIndex = 3;
            button1.Text = "Browse folders";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(460, 172);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(125, 18);
            textBox3.TabIndex = 4;
            textBox3.Text = "Selected path:";
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Control;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(59, 246);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(224, 23);
            textBox4.TabIndex = 6;
            textBox4.Text = "Choose the output location:";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // button2
            // 
            button2.Location = new Point(288, 244);
            button2.Name = "button2";
            button2.Size = new Size(156, 29);
            button2.TabIndex = 7;
            button2.Text = "Browse folders";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Control;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(460, 250);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(125, 18);
            textBox5.TabIndex = 8;
            textBox5.Text = "Selected path:";
            // 
            // inputFolderTextbox
            // 
            inputFolderTextbox.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputFolderTextbox.Location = new Point(545, 168);
            inputFolderTextbox.Name = "inputFolderTextbox";
            inputFolderTextbox.ReadOnly = true;
            inputFolderTextbox.Size = new Size(368, 25);
            inputFolderTextbox.TabIndex = 5;
            // 
            // outputFolderTextBox
            // 
            outputFolderTextBox.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputFolderTextBox.Location = new Point(545, 246);
            outputFolderTextBox.Name = "outputFolderTextBox";
            outputFolderTextBox.ReadOnly = true;
            outputFolderTextBox.Size = new Size(368, 25);
            outputFolderTextBox.TabIndex = 9;
            // 
            // button3
            // 
            button3.BackColor = Color.Chartreuse;
            button3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(395, 396);
            button3.Name = "button3";
            button3.Size = new Size(190, 73);
            button3.TabIndex = 10;
            button3.Text = "Create File";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(120, 501);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(722, 29);
            progressBar1.TabIndex = 11;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Control;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(355, 544);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(255, 20);
            textBox6.TabIndex = 12;
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // CreateSet
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(961, 576);
            Controls.Add(textBox6);
            Controls.Add(progressBar1);
            Controls.Add(button3);
            Controls.Add(outputFolderTextBox);
            Controls.Add(textBox5);
            Controls.Add(button2);
            Controls.Add(textBox4);
            Controls.Add(inputFolderTextbox);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Name = "CreateSet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quick Hasher";
            FormClosed += CreateSet_FormClosed_1;
            Load += CreateSet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private FolderBrowserDialog FolderSelect;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button2;
        private TextBox textBox5;
        private TextBox inputFolderTextbox;
        private TextBox outputFolderTextBox;
        private Button button3;
        private ProgressBar progressBar1;
        private TextBox textBox6;
        private ContextMenuStrip contextMenuStrip1;
    }
}