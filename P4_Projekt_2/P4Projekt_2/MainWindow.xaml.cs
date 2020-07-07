using Microsoft.EntityFrameworkCore.Storage;
using P4Projekt_2.Baza;
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
using System.ComponentModel;

namespace P4Projekt_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public MainWindow()
        {         
            InitializeComponent();
            
            DisplaySelectionButton(0, 0, 0);
            SetDefaultButtonTextAndStatus();

            //--------bw
            worker.DoWork += worker_DoWork_loadEmplyees;
            worker.DoWork += worker_DoWork_loadFacilities;
            //--------bw


        }

        private void _Button_1_Click(object sender, RoutedEventArgs e)
        {
            DisplaySelectionButton(1, 0, 0);
        }

        private void _Button_2_Click(object sender, RoutedEventArgs e)
        {
            DisplaySelectionButton(0, 1, 0);
        }

        private void _Button_3_Click(object sender, RoutedEventArgs e)
        {
            DisplaySelectionButton(0, 0, 1);
        }

        private void _Button_4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _Button_5_Click(object sender, RoutedEventArgs e)
        {

        }
        //-----------------------------------------------------------------------------------
        //background workery
        private void worker_DoWork_loadFacilities(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void worker_DoWork_loadEmplyees(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }


        //-----------------------------------------------------------------------------------
        private void _Button_6_Click(object sender, RoutedEventArgs e)
        {
            this.Close();    
        }

        public void DisplaySelectionButton(int czas_pracy, int zaklady, int pracownicy)
        {
            if (!_Button_4.IsEnabled) _Button_4.IsEnabled = true;
            if (!_Button_5.IsEnabled) _Button_5.IsEnabled = true;

            if (czas_pracy == 1)
            {
                _DatePicker.IsEnabled = true;
                _Button_1.Background = Brushes.Cyan;
                _Image1.Source = new BitmapImage(new Uri("Pictures\\clock-512.png", UriKind.Relative));
                _Label_1.Content = "Czas Pracy";
                _Button_4.Content = "Dodaj Delegację/Urlop";
            }
            else _Button_1.Background = Brushes.Transparent;

            if (zaklady == 1)
            {
                _DatePicker.IsEnabled = false;
                _Button_2.Background = Brushes.Cyan;
                _Image1.Source = new BitmapImage(new Uri("Pictures\\factory_icon.png", UriKind.Relative));
                _Label_1.Content = _zaklady;
                _Button_4.Content = "Dodaj Placówki";
            }
            else _Button_2.Background = Brushes.Transparent;

            if (pracownicy == 1)
            {
                _DatePicker.IsEnabled = false;
                _Button_3.Background = Brushes.Cyan;
                _Image1.Source = new BitmapImage(new Uri("Pictures\\people_icon.png", UriKind.Relative));
                _Label_1.Content = "Pracownicy";
                _Button_4.Content = "Dodaj Pracownika";
            }
            else _Button_3.Background = Brushes.Transparent;
        }
        public void SetDefaultButtonTextAndStatus()
        {
            _Button_1.Content = "Czas Pracy";
            _Button_2.Content = "Placówki";
            _Button_3.Content = "Pracownicy";
            //------------------------------------
            _Button_4.Content = "Dodaj";
            _Button_5.Content = "Edytuj";
            _Button_6.Content = "Zamknij";
            //------------------------------------
            _Label_1.Content = "";
            //------------------------------------
            _DatePicker.IsEnabled = false;
            _Button_4.IsEnabled = false;
            _Button_5.IsEnabled = false;
        }
    }
}
