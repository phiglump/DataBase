using System.Data.OleDb;
using System.Windows;

namespace DatabaseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|ClassWorkDatabase.accdb");
            cn.Open();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string AssetID = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(AssetID, cn);
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "Employee ID: " + read[0].ToString() + " Asset ID: " + read[1].ToString() + " Description: "+ read[2].ToString() + "\n";
                TextLabel.Text = data;
            }
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "Employee ID: " + read[0].ToString() + " First Name: " + read[1].ToString() + " Last Name: " + read[2].ToString() + "\n";
            }
            TextLabelE.Text = data;
        }
    }
}
