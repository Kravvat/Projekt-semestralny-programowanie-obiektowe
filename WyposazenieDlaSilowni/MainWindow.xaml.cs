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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WyposazenieDlaSilowni.Wyposazenie_dla_silowni_DataSet wyposazenie_dla_silowni_DataSet = ((WyposazenieDlaSilowni.Wyposazenie_dla_silowni_DataSet)(this.FindResource("wyposazenie_dla_silowni_DataSet")));
            // Load data into the table Klienci. You can modify this code as needed.
            WyposazenieDlaSilowni.Wyposazenie_dla_silowni_DataSetTableAdapters.KlienciTableAdapter wyposazenie_dla_silowni_DataSetKlienciTableAdapter = new WyposazenieDlaSilowni.Wyposazenie_dla_silowni_DataSetTableAdapters.KlienciTableAdapter();
            wyposazenie_dla_silowni_DataSetKlienciTableAdapter.Fill(wyposazenie_dla_silowni_DataSet.Klienci);
            System.Windows.Data.CollectionViewSource klienciViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("klienciViewSource")));
            klienciViewSource.View.MoveCurrentToFirst();
        }

        private void klienciDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
