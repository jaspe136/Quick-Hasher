using System.Data.SQLite;

namespace Quick_Hasher
{
    public partial class StartMenu : Form
    {

        public StartMenu()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompareSet compareSet = new CompareSet();
            compareSet.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateSet createSet = new CreateSet();
            createSet.ShowDialog();
            
        }

        private void StartMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
        public void InitializeDatabase()
        {
            string dbDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "MyAppData");
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            string dbPath = Path.Combine(dbDirectory, "DONTDELETE.db");

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS FileCount (
                Id INTEGER PRIMARY KEY,
                TotalCount INTEGER NOT NULL,
                ErrorCount INTEGER NOT NULL
            );";
                SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();

                string insertInitialCountQuery = "INSERT OR IGNORE INTO FileCount (Id, TotalCount, ErrorCount) VALUES (1, 0, 0);";
                command = new SQLiteCommand(insertInitialCountQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SavedDataWindow2 savedDataWindow2 = new SavedDataWindow2();
            savedDataWindow2.ShowDialog();
        }
    }
}
