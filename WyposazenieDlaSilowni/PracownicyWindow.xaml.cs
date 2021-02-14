using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
        public PracownicyWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            loadgrid();
        }

        private void loadgrid()
        {
            var data = from r in baza.Pracownicies select r;
            pracownicyDataGrid.ItemsSource = data.ToList();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MainMenu();
        }

        private void MainMenu()
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }

        private void DodajPracownika_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Imie_PracownikDodaj_Box.Text == String.Empty || Nazwisko_PracownikDodaj_Box.Text == String.Empty || Wiek_PracownikDodaj_Box.Text == String.Empty)
            {
                MessageBox.Show("Dodanie niepelnego rekordu jest niemozliwe", "UWAGA");
            }
            else
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
                Imie_PracownikDodaj_Box.Text = String.Empty;
                Nazwisko_PracownikDodaj_Box.Text = String.Empty;
                Wiek_PracownikDodaj_Box.Text = String.Empty;
            }
        }
        private void OdswiezPracownikow_Button_Click(object sender, RoutedEventArgs e)
        {           
            this.pracownicyDataGrid.ItemsSource = baza.Pracownicies.ToList();
        }
        private void UsunPracownika_Button_Click(object sender, RoutedEventArgs e)
        {
            int PracownikID = (pracownicyDataGrid.SelectedItem as Pracownicy).ID;
            Pracownicy Pracownik = (from r in baza.Pracownicies where r.ID == PracownikID select r).SingleOrDefault();
            baza.Pracownicies.Remove(Pracownik);
            baza.SaveChanges();
            MessageBox.Show("Pomyslnie usunieto rekord z tabeli. Odswiez w celu podgladu");
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
