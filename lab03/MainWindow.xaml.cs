using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = "Data Source=LAB1504-28\\SQLEXPRESS;Initial Catalog=lab03;User Id=reynoso;Password=123456";
        private DataTable dataTable = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
        }
        //Data READER
        private void Button_Alumnos2(object sender, RoutedEventArgs e)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);

                connection.Close();

                dataGridAlumnos2.ItemsSource = dataTable.DefaultView;
                dataGridAlumnos2.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //DataTable
        private void Button_Alumnos(object sender, RoutedEventArgs e)
        {
            List<Student> students = new List<Student>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudenId = reader.GetInt32(reader.GetOrdinal("StudenId"));
                    string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    string LastName = reader.GetString(reader.GetOrdinal("LastName"));

                    students.Add(new Student { StudenId = StudenId, FirstName = FirstName, LastName = LastName });
                }

                connection.Close();

                dataGridAlumnos.ItemsSource = students;
                dataGridAlumnos.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}