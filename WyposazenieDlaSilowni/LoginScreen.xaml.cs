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
        /// <summary>
        /// Konstruktor klasy LoginScreen
        /// </summary>
        public LoginScreen()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEnter);
        }
        private void HandleEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TryLogin();
            }          
        }
        private void Zaloguj_Button_Click(object sender, RoutedEventArgs e)
        {
            TryLogin();
        }

        private void TryLogin()
        {
            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            string login = NazwaUzytkownika_Box.Text;
            string haslo = Haslo_PasswordBox.Password;

            var uzytkownik = baza.DaneLogins.SingleOrDefault(x => x.NazwaUzytkownika == login && x.Haslo == haslo);
            if (uzytkownik != null)
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wprowadzone dane sa bledne. Sprobuj ponownie");
            }
        }       
    }
}
