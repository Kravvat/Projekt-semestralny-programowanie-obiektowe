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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WyposazenieDlaSilowni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor klasy MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pracownicy_Button_Click(object sender, RoutedEventArgs e)
        {
            PracownicyWindow pracownicy = new PracownicyWindow();
            pracownicy.Show();
            this.Close();
        }

        private void Klienci_Button_Click(object sender, RoutedEventArgs e)
        {
            KlienciWindow klienci = new KlienciWindow();
            klienci.Show();
            this.Close();
        }

        private void Produkty_Button_Click(object sender, RoutedEventArgs e)
        {
            ProduktyWindow produkty = new ProduktyWindow();
            produkty.Show();
            this.Close();
        }

        private void Zamowienia_Button_Click(object sender, RoutedEventArgs e)
        {
            ZamowieniaWindow zamowienia = new ZamowieniaWindow();
            zamowienia.Show();
            this.Close();
        }

        private void Wyloguj_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen wyloguj = new LoginScreen();
            wyloguj.Show();
            this.Close();
        }
    }
}
