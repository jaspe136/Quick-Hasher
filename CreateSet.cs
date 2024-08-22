using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Hasher
{
    public partial class CreateSet : Form
    {
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
            if (FolderSelect.ShowDialog() == DialogResult.OK) {
                inputFolderTextbox.Text = FolderSelect.SelectedPath;
            }
        }
    }
}
