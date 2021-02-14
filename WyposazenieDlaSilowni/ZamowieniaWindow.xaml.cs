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
    /// Interaction logic for Zamowienia.xaml
    /// </summary>
    public partial class ZamowieniaWindow : Window
    {
        Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
        public ZamowieniaWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            loadgrid();
        }
        private void loadgrid()
        {
            var data = from r in baza.Zamowienias select r;
            zamowieniaDataGrid.ItemsSource = data.ToList();
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
        private void DodajZamowienie_Button_Click(object sender, RoutedEventArgs e)
        {
            {
                Zamowienia noweZamowienie = new Zamowienia()
                {
                    Produkt = int.Parse(Produkt_ZamowienieDodaj_Box.Text),
                    DataZlozeniaZamowienia = DateTime.Parse(Data_ZamowienieDodaj_Box.Text),
                    Klient = int.Parse(Klient_ZamowienieDodaj_Box.Text)
                };

                baza.Zamowienias.Add(noweZamowienie);
                baza.SaveChanges();
                MessageBox.Show("Pomyslnie dodano rekord do tabeli. Odswiez w celu podgladu");
                Produkt_ZamowienieDodaj_Box.Text = String.Empty;
                Data_ZamowienieDodaj_Box.Text = String.Empty;
                Klient_ZamowienieDodaj_Box.Text = String.Empty;

            }
        }

        private void OdswiezZamowienia_Button_Click(object sender, RoutedEventArgs e)
        {
            this.zamowieniaDataGrid.ItemsSource = baza.Zamowienias.ToList();
        }

        private void UsunZamowienie_Button_Click(object sender, RoutedEventArgs e)
        {
            int ZamowienieID = (zamowieniaDataGrid.SelectedItem as Zamowienia).ID;
            Zamowienia Zamowienie = (from r in baza.Zamowienias where r.ID == ZamowienieID select r).SingleOrDefault();
            baza.Zamowienias.Remove(Zamowienie);
            baza.SaveChanges();
            MessageBox.Show("Pomyslnie usunieto rekord z tabeli. Odswiez w celu podgladu");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET wyposazenie_dla_silowniDATASET = ((WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET)(this.FindResource("wyposazenie_dla_silowniDATASET")));
            // Load data into the table Zamowienia. You can modify this code as needed.
            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.ZamowieniaTableAdapter wyposazenie_dla_silowniDATASETZamowieniaTableAdapter = new WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.ZamowieniaTableAdapter();
            wyposazenie_dla_silowniDATASETZamowieniaTableAdapter.Fill(wyposazenie_dla_silowniDATASET.Zamowienia);
            System.Windows.Data.CollectionViewSource zamowieniaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("zamowieniaViewSource")));
            zamowieniaViewSource.View.MoveCurrentToFirst();
        }
    }
}
