namespace Quick_Hasher
{
    partial class StartMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Bisque;
            button1.Location = new Point(519, 176);
            button1.Name = "button1";
            button1.Size = new Size(94, 65);
            button1.TabIndex = 0;
            button1.Text = "Compare";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Bisque;
            button2.Location = new Point(189, 176);
            button2.Name = "button2";
            button2.Size = new Size(94, 65);
            button2.TabIndex = 1;
            button2.Text = "Create";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(286, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 45);
            textBox1.TabIndex = 2;
            textBox1.Text = "Quick Hasher";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(471, 155);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(191, 27);
            textBox2.TabIndex = 3;
            textBox2.Text = "Compare files/folders";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(175, 155);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 4;
            textBox3.Text = "Create Hash Set";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "StartMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quick Hasher";
            FormClosed += StartMenu_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
