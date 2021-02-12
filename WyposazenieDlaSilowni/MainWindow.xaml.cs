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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pracownicy_Button_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy pracownicy = new Pracownicy();
            pracownicy.Show();
            this.Close();
        }

        private void Klienci_Button_Click(object sender, RoutedEventArgs e)
        {
            Klienci klienci = new Klienci();
            klienci.Show();
            this.Close();
        }

        private void Produkty_Button_Click(object sender, RoutedEventArgs e)
        {
            Produkty produkty = new Produkty();
            produkty.Show();
            this.Close();
        }

        private void Zamowienia_Button_Click(object sender, RoutedEventArgs e)
        {
            Zamowienia zamowienia = new Zamowienia();
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
