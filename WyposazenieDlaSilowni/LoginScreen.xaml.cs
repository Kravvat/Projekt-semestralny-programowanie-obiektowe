using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WyposazenieDlaSilowni
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Zaloguj_Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Wyposazenie dla silowni; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM DaneLogin WHERE NazwaUzytkownika=@NazwaUzytkownika AND Haslo=@Haslo";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@NazwaUzytkownika",NazwaUzytkownika_Box.Text);
                    sqlCmd.Parameters.AddWithValue("@Haslo", Haslo_PasswordBox.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        MainWindow dasboard = new MainWindow();
                        dasboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Podane dane sa bledne");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
