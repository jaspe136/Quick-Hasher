namespace Quick_Hasher
{
    partial class CompareSet
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            inputHashTextbox = new TextBox();
            inputFolderTextbox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Hash = new DataGridViewTextBoxColumn();
            Match_found = new DataGridViewTextBoxColumn();
            button3 = new Button();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(200, 507);
            button1.Name = "button1";
            button1.Size = new Size(132, 56);
            button1.TabIndex = 0;
            button1.Text = "Browse files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(200, 594);
            button2.Name = "button2";
            button2.Size = new Size(132, 56);
            button2.TabIndex = 1;
            button2.Text = "Browser folders";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(12, 525);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(182, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "Choose input hashset:";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(12, 610);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(182, 23);
            textBox2.TabIndex = 3;
            textBox2.Text = "Choose input folder:";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(368, 530);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(125, 18);
            textBox3.TabIndex = 5;
            textBox3.Text = "Selected path:";
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Control;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(368, 615);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(125, 18);
            textBox4.TabIndex = 6;
            textBox4.Text = "Selected path:";
            // 
            // inputHashTextbox
            // 
            inputHashTextbox.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputHashTextbox.Location = new Point(487, 527);
            inputHashTextbox.Name = "inputHashTextbox";
            inputHashTextbox.ReadOnly = true;
            inputHashTextbox.Size = new Size(368, 25);
            inputHashTextbox.TabIndex = 7;
            // 
            // inputFolderTextbox
            // 
            inputFolderTextbox.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputFolderTextbox.Location = new Point(487, 615);
            inputFolderTextbox.Name = "inputFolderTextbox";
            inputFolderTextbox.ReadOnly = true;
            inputFolderTextbox.Size = new Size(368, 25);
            inputFolderTextbox.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Hash, Match_found });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1008, 452);
            dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            Column1.HeaderText = "filename";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Hash
            // 
            Hash.HeaderText = "Hash";
            Hash.MinimumWidth = 6;
            Hash.Name = "Hash";
            // 
            // Match_found
            // 
            Match_found.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Match_found.HeaderText = "Match Found";
            Match_found.MinimumWidth = 6;
            Match_found.Name = "Match_found";
            Match_found.Width = 124;
            // 
            // button3
            // 
            button3.BackColor = Color.Chartreuse;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(875, 551);
            button3.Name = "button3";
            button3.Size = new Size(145, 60);
            button3.TabIndex = 10;
            button3.Text = "Compare";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(405, 470);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(190, 20);
            textBox5.TabIndex = 11;
            // 
            // CompareSet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 676);
            Controls.Add(textBox5);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(inputFolderTextbox);
            Controls.Add(inputHashTextbox);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "CompareSet";
            Text = "Quick Hasher";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox inputHashTextbox;
        private TextBox inputFolderTextbox;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Hash;
        private DataGridViewTextBoxColumn Match_found;
        private Button button3;
        private TextBox textBox5;
    }
}