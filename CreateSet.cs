using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows;
namespace Quick_Hasher
{
    public partial class CreateSet : Form
    {
        //List<string> fileList = new List<string>();
        public static string[] fileList;
        public bool filesLoaded = false;
        public bool outputSelected = false;

        public CreateSet()
        {
            InitializeComponent();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateSet_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("SHA256");
            //comboBox1.Items.Add("MD5");
        }

        private void CreateSet_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FolderSelect.ShowDialog() == DialogResult.OK)
            {
                inputFolderTextbox.Text = FolderSelect.SelectedPath;
            }
            fileList = Directory.GetFiles(inputFolderTextbox.Text, "*.*", SearchOption.AllDirectories);
            if (fileList.Length != 0)
            {
                filesLoaded = true;
            }
            textBox6.Text = $"{fileList.Length} file(s) loaded";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FolderSelect.ShowDialog() == DialogResult.OK)
            {
                outputFolderTextBox.Text = FolderSelect.SelectedPath;
            }
            if (outputFolderTextBox.Text != "")
            {
                outputSelected = true;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {      
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a hashing algorithm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            if (comboBox1.SelectedItem.ToString() == "MD5" && filesLoaded && outputSelected)
            {
                progressBar1.Maximum = fileList.Length;
                progressBar1.Value = 0;
                string combinedMD5path = Path.Combine(outputFolderTextBox.Text, "Hashes.md5");
                if (File.Exists(combinedMD5path))
                {
                   DialogResult result = MessageBox.Show("The selected output folder already contains a md5 hashfile that will be overwritten", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK) 
                    { 
                        WriteMD5(combinedMD5path); 
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    WriteMD5(combinedMD5path);
                }
                
            }
            else if (comboBox1.SelectedItem.ToString() == "SHA256" && filesLoaded && outputSelected)
            {
                progressBar1.Maximum = fileList.Length;
                progressBar1.Value = 0;
                string combinedSHA256path = Path.Combine(outputFolderTextBox.Text, "Hashes.sha");
                if (File.Exists(combinedSHA256path))
                {
                    DialogResult result = MessageBox.Show("The selected output folder already contains a sha hashfile that will be overwritten", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        WriteMD5(combinedSHA256path);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    WriteMD5(combinedSHA256path);
                }
            }
            else
            {
                MessageBox.Show("Fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        

        void WriteMD5(string combinedMD5path)
        {
            int errorCount = 0;
            int filesCalculated = 0;
            using (StreamWriter writer = new StreamWriter(combinedMD5path))
            {
                foreach (string filePath in fileList)
                {
                    try
                    {
                        
                        string md5Hash = CalculateMD5(filePath);
                        writer.WriteLine(md5Hash);
                        
                        System.Diagnostics.Debug.WriteLine($"Hash Calculated from {filePath}");
                        progressBar1.Value = ++filesCalculated;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                        errorCount++;
                    }
                }
               
            }
            MessageBox.Show($"Finished with {errorCount} error(s)", "Finished", MessageBoxButtons.OK);
            Process.Start("explorer.exe", outputFolderTextBox.Text);
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
        void WriteSHA256(string combinedSHA256path)
        {
            int errorCount = 0;
            int filesCalculated = 0;
            using (StreamWriter writer = new StreamWriter(combinedSHA256path))
            {
                foreach (string filePath in fileList)
                {
                    try
                    {

                        string Sha256Hash = CalculateSHA256(filePath);
                        writer.WriteLine(Sha256Hash);

                        System.Diagnostics.Debug.WriteLine($"Hash Calculated from {filePath}");
                        progressBar1.Value = ++filesCalculated;
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                        errorCount++;
                    }
                }
            }
            MessageBox.Show($"Finished with {errorCount} error(s)", "Finished", MessageBoxButtons.OK);
            Process.Start("explorer.exe", outputFolderTextBox.Text);
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
