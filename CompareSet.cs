using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Hasher
{
    public partial class CompareSet : Form
    {

        public static string[] fileList;
        public bool filesloaded = false;
        public bool hashfileSelected = false;
        public CompareSet()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Hash files (*.md5; *.sha)|*.md5;*.sha";
            openFileDialog1.Title = "Select a Hash File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputHashTextbox.Text = openFileDialog1.FileName;
            }
            if (inputHashTextbox.Text != "")
            {
                hashfileSelected = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFolderTextbox.Text = folderBrowserDialog1.SelectedPath;
            }
            if (inputFolderTextbox.Text != "") 
            { 
                fileList = Directory.GetFiles(inputFolderTextbox.Text, "*.*", SearchOption.AllDirectories);
                if (fileList.Length != 0)
                {
                    filesloaded = true;
                    textBox5.Text = $"0 / {fileList.Length} files checked";
                }
            }
                
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(filesloaded && hashfileSelected)
            {
                CompareHashes();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void CompareHashes()
        {
            int filesChecked = 0;
            HashSet<string> loadedHashset = new HashSet<string>();
            try
            {
                string[] lines = await Task.Run(() =>  File.ReadAllLines(inputHashTextbox.Text));
                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    if (!string.IsNullOrEmpty(trimmedLine))
                    {
                        loadedHashset.Add(trimmedLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading hash file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView1.Rows.Clear();

            foreach (string filepath in fileList)
            {
                if (new FileInfo(filepath).Length == 0) 
                {
                    dataGridView1.Rows.Add(filepath, "N/A", "Skipped (Empty File)");
                    filesChecked++;
                    textBox5.Text = $"{filesChecked} / {fileList.Length} files checked";
                    continue;
                }
                try
                {

                    string hash = await Task.Run(() => CalculateMD5(filepath));
                    bool hashFound = loadedHashset.Contains(hash);
                    filesChecked++;
                    dataGridView1.Rows.Add(filepath, hash, hashFound ? "Match found" : "No match");
                    textBox5.Text = $"{filesChecked} / {fileList.Length} files checked";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {filepath}: {ex.Message}");
                    filesChecked++;
                    dataGridView1.Rows.Add(filepath, "Error", ex.Message);
                    textBox5.Text = $"{filesChecked} / {fileList.Length} files checked";
                    //errorCount++;
                }

            }
        }
        static string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }
        static string CalculateSHA256(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

    }
}
