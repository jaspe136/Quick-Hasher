namespace Quick_Hasher
{
    partial class SavedDataWindow2
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
            textBox1 = new TextBox();
            hashedfilesbox = new TextBox();
            textBox3 = new TextBox();
            errorcountbox = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(105, 36);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(196, 32);
            textBox1.TabIndex = 1;
            textBox1.Text = "Total hashed files";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // hashedfilesbox
            // 
            hashedfilesbox.Font = new Font("Trebuchet MS", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            hashedfilesbox.ForeColor = Color.DarkGoldenrod;
            hashedfilesbox.Location = new Point(31, 95);
            hashedfilesbox.Name = "hashedfilesbox";
            hashedfilesbox.ReadOnly = true;
            hashedfilesbox.Size = new Size(325, 27);
            hashedfilesbox.TabIndex = 2;
            hashedfilesbox.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(105, 151);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(196, 32);
            textBox3.TabIndex = 3;
            textBox3.Text = "Total errors";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // errorcountbox
            // 
            errorcountbox.Font = new Font("Trebuchet MS", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            errorcountbox.ForeColor = Color.Crimson;
            errorcountbox.Location = new Point(31, 211);
            errorcountbox.Name = "errorcountbox";
            errorcountbox.ReadOnly = true;
            errorcountbox.Size = new Size(325, 27);
            errorcountbox.TabIndex = 4;
            errorcountbox.TextAlign = HorizontalAlignment.Center;
            // 
            // SavedDataWindow2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 346);
            Controls.Add(errorcountbox);
            Controls.Add(textBox3);
            Controls.Add(hashedfilesbox);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SavedDataWindow2";
            Text = "SavedDataWindow2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox hashedfilesbox;
        private TextBox textBox3;
        private TextBox errorcountbox;
    }
}