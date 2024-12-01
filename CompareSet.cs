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
        // alustetaan tarpeellisia muuttujia
        public static string[] fileList;
        public bool filesloaded = false;
        public string fileExtension;
        public bool hashfileSelected = false;
        public CompareSet()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e) //tämä aliohjelma käynnistyy kun "browse files" nappulaa painetaan
        {
            
            openFileDialog1.Filter = "Hash files (*.md5; *.sha)|*.md5;*.sha"; //annetaan käyttäjän valita vain .md5 tai .sha tiedostoja
            openFileDialog1.Title = "Select a Hash File"; //muutetaan tiedostovalintaikkunan otsikko sopivaksi
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputHashTextbox.Text = openFileDialog1.FileName; //asetetaan ohjelmassa olevaan tekstikenttään valitun hajautustiedoston tiedostopolku
                fileExtension = Path.GetExtension(openFileDialog1.FileName); //tallennetaan muuttujaan valitun tiedoston tiedostopääte
            }
            if (inputHashTextbox.Text != "")
            {
                hashfileSelected = true; //jos käyttäjä valitsi jonkun tiedoston muutetaan bool arvoksi true
            }
        }

        private void button2_Click(object sender, EventArgs e) // tämä aliohjelma käynnistyy kun "browse folders" nappulaa painetaan
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFolderTextbox.Text = folderBrowserDialog1.SelectedPath; //asetetaan ohjelmassa olevaan tekstikenttään valitun kansion polku
            }
            if (inputFolderTextbox.Text != "") 
            { 
                fileList = Directory.GetFiles(inputFolderTextbox.Text, "*.*", SearchOption.AllDirectories); //tallennetaan listaan valitun kansion kaikkien tiedostojen polku
                if (fileList.Length != 0)
                {
                    filesloaded = true; //jos valitussa polussa on tiedostoja muutetaan bool arvoksi true
                    textBox5.Text = $"0 / {fileList.Length} files checked"; //asetetaan löydettyjen tiedostojen lukumäärä sovelluksessa olevaan tekstikenttään joka seuraa tarkastettujen tiedostojen määrää
                }
            }
                
        }
        private void button3_Click(object sender, EventArgs e) //tämä aliohjelma käynnistyy kun "compare" nappulaa painetaan
        {
            if(filesloaded && hashfileSelected) //tarkastetaan että käyttäjä on valinnut hajautustiedoston, sekä kansion jossa on tiedostoja
            {
                CompareHashes();
            }
            else
            {
                MessageBox.Show("Fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); //jos kaikkia tietoja ei ole syötetty viesti laatikko kehottaa käyttäjää täyttämään ne jotta hän voi jatkaa
            }
        }

        private async void CompareHashes() 
        {
            int filesChecked = 0;
            HashSet<string> loadedHashset = new HashSet<string>();
            try
            {
                string[] lines = await Task.Run(() =>  File.ReadAllLines(inputHashTextbox.Text)); //luetaan hajautustiedoston rivit asynkroninisesti

                //poistetaan tyhjät rivit jos sellaisia on ja lisätään rivit yksitellen loadedHashset listaan
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

            dataGridView1.Rows.Clear(); //tyhjennetään tiedostotaulukko

            foreach (string filepath in fileList)//iteroidaan valitun kansion tiedostot
            {
                if (new FileInfo(filepath).Length == 0) //jos tiedosto on tyhjä, sen tarkastus ohitetaan
                {
                    dataGridView1.Rows.Add(filepath, "N/A", "Skipped (Empty File)");
                    filesChecked++; //nostetaan tarkastettujen tiedostojen lukumäärää
                    textBox5.Text = $"{filesChecked} / {fileList.Length} files checked"; //päivitetään tarkastettujen tiedostojen lukumäärä
                    continue;
                }
                try
                {
                    string hash;
                    if(fileExtension == ".md5") //jos valittu hajautustiedosto on .md5 tyyppinen käytetään siihen sopivaa aliohjelmaa
                    { 
                        hash = await Task.Run(() => CalculateMD5(filepath));  //suoritetaan aliohjelma asynkroninisesti
                    }
                    else //jos valittu hajautustiedosto on muu kuin .md5 tyyppinen (.sha) käytetään siihen sopivaa aliohjelmaa
                    {
                        hash = await Task.Run(() => CalculateSHA256(filepath)); //suoritetaan aliohjelma asynkroninisesti
                    }
                    bool hashFound = loadedHashset.Contains(hash); //tarkastetaan löytyyko laskettu hajautus hajautustiedostosta
                    filesChecked++; //nostetaan tarkastettujen tiedostojen lukumäärää
                    dataGridView1.Rows.Add(filepath, hash, hashFound ? "Match found" : "No match"); //lisätään tiedostotaulukkoon tieto siitä, että löytyikö hajautushajautustiedostosta, sekä muita tietoja.
                    textBox5.Text = $"{filesChecked} / {fileList.Length} files checked"; //päivitetään tarkastettujen tiedostojen lukumäärä
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

    }
}
