namespace Quick_Hasher
{
    public partial class StartMenu : Form
    {


        public StartMenu()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateSet createSet = new CreateSet();
            createSet.Show();
            StartMenu startmenu = new StartMenu();
            startmenu.Hide();
        }

        private void StartMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0) { 
                Application.Exit();
            }
        }
    }
}
