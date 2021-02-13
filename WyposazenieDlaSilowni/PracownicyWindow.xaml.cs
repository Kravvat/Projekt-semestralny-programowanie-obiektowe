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

namespace WyposazenieDlaSilowni
{
    /// <summary>
    /// Interaction logic for Pracownicy.xaml
    /// </summary>
    public partial class PracownicyWindow : Window
    {
        public PracownicyWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
            PracownicyWindow pracownicy = new PracownicyWindow();
            pracownicy.Close();
        }

        private void DodajPracownika_Button_Click(object sender, RoutedEventArgs e)
        {
            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            {
                Pracownicy nowyPracownik = new Pracownicy()
                {          
                    Imie = Imie_PracownikDodaj_Box.Text,
                    Nazwisko = Nazwisko_PracownikDodaj_Box.Text,
                    Wiek = int.Parse(Wiek_PracownikDodaj_Box.Text)
                };

                baza.Pracownicies.Add(nowyPracownik);
                baza.SaveChanges();
                MessageBox.Show("Pomyslnie dodano rekord do tabeli. Odswiez w celu podgladu");
            }
        }
        private void OdswiezPracownikow_Button_Click(object sender, RoutedEventArgs e)
        {
            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            this.pracownicyDataGrid.ItemsSource = baza.Pracownicies.ToList();
        }
        private void UsunPracownika_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET wyposazenie_dla_silowniDATASET = ((WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET)(this.FindResource("wyposazenie_dla_silowniDATASET")));
            // Load data into the table Pracownicy. You can modify this code as needed.
            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.PracownicyTableAdapter wyposazenie_dla_silowniDATASETPracownicyTableAdapter = new WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.PracownicyTableAdapter();
            wyposazenie_dla_silowniDATASETPracownicyTableAdapter.Fill(wyposazenie_dla_silowniDATASET.Pracownicy);
            System.Windows.Data.CollectionViewSource pracownicyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pracownicyViewSource")));
            pracownicyViewSource.View.MoveCurrentToFirst();
        }
    }
}
