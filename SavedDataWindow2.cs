using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Hasher
{
    public partial class SavedDataWindow2 : Form
    {
        public SavedDataWindow2()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "MyAppData", "DONTDELETE.db");


            int totalCount = 0;
            int errorCount = 0;

            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                string selectQuery = "SELECT TotalCount FROM FileCount WHERE Id = 1;";
                SQLiteCommand command = new SQLiteCommand(selectQuery, connection);
                object result = command.ExecuteScalar();
                totalCount = result != null ? Convert.ToInt32(result) : 0;

                string selectQuery2 = "SELECT ErrorCount FROM FileCount WHERE Id = 1;";
                SQLiteCommand command2 = new SQLiteCommand(selectQuery2, connection);
                object result2 = command2.ExecuteScalar();
                errorCount = result2 != null ? Convert.ToInt32(result2) : 0;
            }
            hashedfilesbox.Text = $"{totalCount}";
            errorcountbox.Text = $"{errorCount}";
        }
    }

}

