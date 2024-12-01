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
using System.Data.SQLite;
namespace Quick_Hasher
{
    public partial class CreateSet : Form
    {
        //alustetaan tarpeelliset muuttujat
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

        private void button1_Click(object sender, EventArgs e) //tämä aliohjelma käynnistyy kun painaa "browse folder" nappulaa
        {
            if (FolderSelect.ShowDialog() == DialogResult.OK)
            {
                inputFolderTextbox.Text = FolderSelect.SelectedPath; //asetetaan ohjelmassa olevaan tekstikenttään valitun kansion polku
            }
            if (inputFolderTextbox.Text != "")
            {
                fileList = Directory.GetFiles(inputFolderTextbox.Text, "*.*", SearchOption.AllDirectories); //tallennetaan listaan valitun kansion kaikkien tiedostojen polku
                if (fileList.Length != 0)
                {
                    filesLoaded = true; //jos valitussa polussa on tiedostoja muutetaan bool arvoksi true
                }
                textBox6.Text = $"{fileList.Length} file(s) loaded"; //asetetaan löydettyjen tiedostojen määrä tekstilaatikkoon
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (FolderSelect.ShowDialog() == DialogResult.OK)
            {
                outputFolderTextBox.Text = FolderSelect.SelectedPath; //asetetaan ohjelmassa olevaan tekstikenttään valitun kansion polku
            }
            if (outputFolderTextBox.Text != "")
            {
                outputSelected = true; //jos käyttäjä valitsi jonkun kansion muutetaan bool arvoksi true
            }
            
        }

        private void button3_Click(object sender, EventArgs e) //tämä aliohjelma käynnistyy kun "create file" nappulaa painetaan
        {      
            if (comboBox1.SelectedItem == null) //tarkastetaan että algoritmi on valittu
            {
                MessageBox.Show("Please select a hashing algorithm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            if (comboBox1.SelectedItem.ToString() == "MD5" && filesLoaded && outputSelected) //jos kaikki kohdat on täytetty ja algoritmina on md5 tämä palikka koodia käynnistyy
            {
                progressBar1.Maximum = fileList.Length; //asetetaan latausviivan maksimi luvuksi tiedostojen määrä
                progressBar1.Value = 0; 
                string combinedMD5path = Path.Combine(outputFolderTextBox.Text, "Hashes.md5"); //muodostetaan hajautustiedoston polku johon se kirjoitetaan
                if (File.Exists(combinedMD5path)) //ohjelma varoittaa jos valitussa polussa on jo hajautustiedosto ja siitä, että se tulee ylikirjoitetuksi
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
            else if (comboBox1.SelectedItem.ToString() == "SHA256" && filesLoaded && outputSelected) //jos kaikki kohdat on täytetty ja algoritmina on sha256 tämä palikka koodia käynnistyy
            {
                progressBar1.Maximum = fileList.Length; //asetetaan latausviivan maksimi luvuksi tiedostojen määrä
                progressBar1.Value = 0;
                string combinedSHA256path = Path.Combine(outputFolderTextBox.Text, "Hashes.sha"); //muodostetaan hajautustiedoston polku johon se kirjoitetaan
                if (File.Exists(combinedSHA256path)) //ohjelma varoittaa jos valitussa polussa on jo hajautustiedosto ja siitä, että se tulee ylikirjoitetuksi
                {
                    DialogResult result = MessageBox.Show("The selected output folder already contains a sha hashfile that will be overwritten", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        WriteSHA256(combinedSHA256path);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    WriteSHA256(combinedSHA256path);
                }
            }
            else
            {
                MessageBox.Show("Fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // jos kaikkia kohtia ei ollut täytetty, hajautus ei käynnisty.
            }
            
        }

        

        void WriteMD5(string combinedMD5path)
        {
            int errorCount = 0; 
            int filesCalculated = 0;
            using (StreamWriter writer = new StreamWriter(combinedMD5path)) //alustetaan tiedostokirjoittaja ja asetetaan sille tiedostopolku
            {
                foreach (string filePath in fileList) //iteroidaan tiedostot valitussa kansiossa
                {
                    try
                    {

                        string md5Hash = CalculateMD5(filePath); //lasketaan hajautus
                        writer.WriteLine(md5Hash); //kirjoitetaan hajautus omalle rivilleen
                        
                        System.Diagnostics.Debug.WriteLine($"md5 Hash Calculated from {filePath}"); 
                        progressBar1.Value = ++filesCalculated; //lisätään latausviivaan edistystä yhdellä tiedostolla
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                        errorCount++;
                    }
                }
               
            }
            MessageBox.Show($"Finished with {errorCount} error(s)", "Finished", MessageBoxButtons.OK); //ilmoitetaan lopuksi käyttäjälle että tapahtuiko hajautuksessa virheitä
            UpdateDatabase(filesCalculated, errorCount);
            Process.Start("explorer.exe", outputFolderTextBox.Text); //avataan hajautustiedoston kansio käyttäjälle
        }

        static string CalculateMD5(string filePath) //md5 hajautuksen laskemiseen tarkoitettu aliohjelma
        {
            using (var md5 = MD5.Create()) //alustetaan md5 muuttujan
            {
                using (var stream = File.OpenRead(filePath)) //avataan tiedosto lukua varten ja tallenetaan sen tiedot muuttujaan
                {
                    byte[] hashBytes = md5.ComputeHash(stream); //tallennetaan lasketut hajautustavut muuttajaan
                    StringBuilder sb = new StringBuilder(); //alustetaan kirjoitusohjelma
                    foreach (byte b in hashBytes) //iteroidaan lasketut tavut
                    {
                        sb.Append(b.ToString("x2")); //lisätään yksittäiset tavut kirjoitusohjelmaan
                    }
                    return sb.ToString(); //palautetaan tekstinä kirjoitusohjelmaan tallennetut hajautustavut
                }
            }
        }
        void WriteSHA256(string combinedSHA256path) 
        {
            int errorCount = 0;
            int filesCalculated = 0;
            using (StreamWriter writer = new StreamWriter(combinedSHA256path)) //alustetaan tiedostokirjoittaja ja asetetaan sille tiedostopolku
            {
                foreach (string filePath in fileList) //iteroidaan tiedostot valitussa kansiossa
                {
                    try
                    {

                        string Sha256Hash = CalculateSHA256(filePath); //lasketaan hajautus
                        writer.WriteLine(Sha256Hash); //kirjoitetaan hajautus omalle rivilleen

                        System.Diagnostics.Debug.WriteLine($"sha256 Hash Calculated from {filePath}");
                        progressBar1.Value = ++filesCalculated; //lisätään latausviivaan edistystä yhdellä tiedostolla

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing file {filePath}: {ex.Message}"); 
                        errorCount++;
                    }
                }
            }
            MessageBox.Show($"Finished with {errorCount} error(s)", "Finished", MessageBoxButtons.OK); //ilmoitetaan lopuksi käyttäjälle että tapahtuiko hajautuksessa virheitä
            UpdateDatabase(filesCalculated, errorCount);
            Process.Start("explorer.exe", outputFolderTextBox.Text); //avataan hajautustiedoston kansio käyttäjälle
        }
        static string CalculateSHA256(string filePath) //sha hajautuksen laskemiseen tarkoitettu aliohjelma. Ohjelma toimii samalla tavalla kuin vastaava md5 ohjelma
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
        public void UpdateDatabase(int hashedFileCount, int errorCount)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "MyAppData", "DONTDELETE.db");

            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string updateQuery = @"
            UPDATE FileCount 
            SET TotalCount = TotalCount + @hashedFileCount,
                ErrorCount = ErrorCount + @errorCount
            WHERE Id = 1;";
                SQLiteCommand command = new SQLiteCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@hashedFileCount", hashedFileCount);
                command.Parameters.AddWithValue("@errorCount", errorCount);
                command.ExecuteNonQuery();
            }
        }
    }
}
