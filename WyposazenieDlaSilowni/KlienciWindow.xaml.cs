﻿using System;
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
    /// Interaction logic for Klienci.xaml
    /// </summary>
    public partial class KlienciWindow : Window
    {
        public KlienciWindow()
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
            KlienciWindow klienci = new KlienciWindow();
            klienci.Close();
        }
        private void DodajKlienta_Button_Click(object sender, RoutedEventArgs e)
        {
            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            {
                Klienci nowyKlient = new Klienci()
                {
                    Imie = Imie_KlientDodaj_Box.Text,
                    Nazwisko = Nazwisko_KlientDodaj_Box.Text,
                    Miasto = Miasto_KlientDodaj_Box.Text,
                    ObslugujacyPracownik = int.Parse(ObslugujacyPracownik_KlientDodaj_Box.Text)
                };

                baza.Kliencis.Add(nowyKlient);
                baza.SaveChanges();
                MessageBox.Show("Pomyslnie dodano rekord do tabeli. Odswiez w celu podgladu");
            }
        }
        private void OdswiezKlientow_Button_Click(object sender, RoutedEventArgs e)
        {
            Wyposazenie_dla_silowniBAZA baza = new Wyposazenie_dla_silowniBAZA();
            this.klienciDataGrid.ItemsSource = baza.Kliencis.ToList();
        }
        private void UsunKlienta_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET wyposazenie_dla_silowniDATASET = ((WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASET)(this.FindResource("wyposazenie_dla_silowniDATASET")));
            // Load data into the table Klienci. You can modify this code as needed.
            WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.KlienciTableAdapter wyposazenie_dla_silowniDATASETKlienciTableAdapter = new WyposazenieDlaSilowni.Wyposazenie_dla_silowniDATASETTableAdapters.KlienciTableAdapter();
            wyposazenie_dla_silowniDATASETKlienciTableAdapter.Fill(wyposazenie_dla_silowniDATASET.Klienci);
            System.Windows.Data.CollectionViewSource klienciViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("klienciViewSource")));
            klienciViewSource.View.MoveCurrentToFirst();
        }
    }
}