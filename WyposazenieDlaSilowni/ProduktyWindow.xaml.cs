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
    /// Interaction logic for Produkty.xaml
    /// </summary>
    public partial class ProduktyWindow : Window
    {
        public ProduktyWindow()
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
            ProduktyWindow produkty = new ProduktyWindow();
            produkty.Close();
        }
        private void DodajProdukt_Button_Click(object sender, RoutedEventArgs e)
        {
            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            {
                Produkty nowyProdukt = new Produkty()
                {
                    Nazwa = Nazwa_ProduktDodaj_Box.Text,
                    Cena = int.Parse(Cena_ProduktDodaj_Box.Text),
                    WagaKG = int.Parse(Waga_ProduktDodaj_Box.Text)
                };

                baza.Produkties.Add(nowyProdukt);
                baza.SaveChanges();
                MessageBox.Show("Pomyslnie dodano rekord do tabeli. Odswiez w celu podgladu");
            }
        }

        private void OdswiezProdukty_Button_Click(object sender, RoutedEventArgs e)
        {

            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            this.produktyDataGrid.ItemsSource = baza.Produkties.ToList();
        }

        private void UsunProdukt_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET wyposazenie_dla_silowniDATASET = ((WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET)(this.FindResource("wyposazenie_dla_silowniDATASET")));
            // Load data into the table Produkty. You can modify this code as needed.
            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.ProduktyTableAdapter wyposazenie_dla_silowniDATASETProduktyTableAdapter = new WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.ProduktyTableAdapter();
            wyposazenie_dla_silowniDATASETProduktyTableAdapter.Fill(wyposazenie_dla_silowniDATASET.Produkty);
            System.Windows.Data.CollectionViewSource produktyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("produktyViewSource")));
            produktyViewSource.View.MoveCurrentToFirst();
        }
    }
}
