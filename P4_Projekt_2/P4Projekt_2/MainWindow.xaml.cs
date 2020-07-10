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
using Microsoft.SqlServer;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace P4Projekt_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public List<Czas_Pracy> Lista_obecnosci { get; set; }
        public List<Pracownicy> Lista_pracownikow { get; set; }
        public List<Zaklad> Lista_Zakladow { get; set; }
        public DateTime _savedDate { get; set; } 
        public int _AddButton4Selection { get; set; } = 0;

        public string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BazaPracownikow;Trusted_Connection=True;";
        private readonly BackgroundWorker worker1 = new BackgroundWorker();
        

        public MainWindow()
        {         
            InitializeComponent();
            _Label_2.Content = "Kliknij dwukrotnie przycisk wyboru aby odswierzyc";
            _DatePicker.SelectedDate = Convert.ToDateTime("2020-05-03");
            
            worker1.WorkerSupportsCancellation = true;
            
            DisplaySelectionButton(0, 0, 0);
            SetDefaultButtonTextAndStatus();
            
            
        }

        private void _Button_1_Click(object sender, RoutedEventArgs e)
        {
            _savedDate = (DateTime)_DatePicker.SelectedDate;
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
            switch (_AddButton4Selection)
            {
                case 1: { break; }
                case 2: { new AddFacilitywindow().ShowDialog(); break; }
                case 3: { new AddEmployeeWindow().ShowDialog(); break; }
            }
        }

        private void _Button_5_Click(object sender, RoutedEventArgs e)
        {

        }
        //-----------------------------------------------------------------------------------
        //background workery
        private void worker_DoWork_loadFacilities(object sender, DoWorkEventArgs e)
        {
            
            List<Zaklad> _list = new List<Zaklad>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Zaklad", connect))
                {
                    connect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {

                            _list.Add(new Zaklad(
                                reader[0].ToString(),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString(),
                                reader[5].ToString(),
                                reader[6].ToString()
                                )); 
                        }
                    connect.Close();
                }
                Lista_Zakladow = _list;
            }
        }
    

        private void worker_DoWork_loadEmplyees(object sender, DoWorkEventArgs e)
        {
            
            List<Pracownicy> _list = new List<Pracownicy>();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Pracownicy", connect))
                {
                    connect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {

                            _list.Add(new Pracownicy(
                                reader[0].ToString(),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                Convert.ToDateTime(reader[3]).Date,
                                reader[4].ToString(),
                                reader[5].ToString(),
                                reader[6].ToString(),
                                reader[7].ToString(),
                                reader[8].ToString(),
                                reader[9].ToString(),
                                reader[10].ToString()
                                ));
                        }
                    connect.Close();
                }
                Lista_pracownikow = _list;
            }   
        }
        private void worker_DoWork_atendance(object sender, DoWorkEventArgs e)
        {
            

            if (_savedDate == null) _savedDate = DateTime.Now.Date; 
             

            using (var db = new BazaPracownikow())
            {
                Lista_obecnosci = db.Czas_Pracy.Where(x => x.Data_dnia == _savedDate).ToList<Czas_Pracy>();
            }

        }

        //-----------------------------------------------------------------------------------
        private void _Button_6_Click(object sender, RoutedEventArgs e)
        {
            this.Close();    
        }

        public void DisplaySelectionButton(int czas_pracy, int zaklady, int pracownicy)
        {
            if (!_Button_4.IsEnabled) _Button_4.IsEnabled = true;
            //if (!_Button_5.IsEnabled) _Button_5.IsEnabled = true;
            _Button_5.Visibility = Visibility.Collapsed;

            _DatePicker.Visibility = Visibility.Collapsed;
            
            _TabelaPracownikow.Visibility = Visibility.Collapsed;
            _TabelaZakladow.Visibility = Visibility.Collapsed;
            _TabelaObecnosci.Visibility = Visibility.Collapsed;

            if (czas_pracy == 1)
            {
                _AddButton4Selection = 1;
                //_DatePicker.SelectedDate = DateTime.Now;
                _DatePicker.Visibility = Visibility.Visible;
                _TabelaObecnosci.Visibility = Visibility.Visible;
                _DatePicker.IsEnabled = true;
                _Button_1.Background = Brushes.Cyan;
                _Image1.Source = new BitmapImage(new Uri("Pictures\\clock-512.png", UriKind.Relative));
                _Label_1.Content = "Czas Pracy";
                _Button_4.Content = "Dodaj Delegację/Urlop";

                if (worker1.IsBusy) worker1.CancelAsync();
                worker1.DoWork += worker_DoWork_atendance;
                if (!worker1.IsBusy) worker1.RunWorkerAsync();


                _TabelaObecnosci.ItemsSource = Lista_obecnosci;
            }
            else _Button_1.Background = Brushes.Transparent;

            if (zaklady == 1)
            {
                _AddButton4Selection = 2;
                _TabelaZakladow.Visibility = Visibility.Visible;
                _DatePicker.IsEnabled = false;
                _Button_2.Background = Brushes.Cyan;
                _Image1.Source = new BitmapImage(new Uri("Pictures\\factory_icon.png", UriKind.Relative));
                _Label_1.Content = "Placówki";
                _Button_4.Content = "Dodaj Placówki";

                
                if (worker1.IsBusy) worker1.CancelAsync();
                worker1.DoWork += worker_DoWork_loadFacilities;
                if (!worker1.IsBusy) worker1.RunWorkerAsync();
                

                _TabelaZakladow.ItemsSource = Lista_Zakladow;
            }
            else _Button_2.Background = Brushes.Transparent;

            if (pracownicy == 1)
            {
                _AddButton4Selection = 3;
                _TabelaPracownikow.Visibility = Visibility.Visible;
                _DatePicker.IsEnabled = false;
                _Button_3.Background = Brushes.Cyan;
                _Image1.Source = new BitmapImage(new Uri("Pictures\\people_icon.png", UriKind.Relative));
                _Label_1.Content = "Pracownicy";
                _Button_4.Content = "Dodaj Pracownika";

                
                if (worker1.IsBusy) worker1.CancelAsync();
                worker1.DoWork += worker_DoWork_loadEmplyees;
                if (!worker1.IsBusy) worker1.RunWorkerAsync();
                

                _TabelaPracownikow.ItemsSource = Lista_pracownikow;


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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
