using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace DB_Anbindung_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string dbconnectstring =
            "SERVER=localhost;" +
                            "DATABASE=plz;" +
                            "UID=root;" +
                            "PASSWORD=;";
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection(dbconnectstring);
            MySqlConnection command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM orte";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FielCount; i++)
                { row += Reader.GetValue(i).ToString() + "\t"; }
                row += "\n";
                // Console.WriteLine(row);
                textBox.AppendText(row);
            }
            connection.Close();
        }

    }
}
