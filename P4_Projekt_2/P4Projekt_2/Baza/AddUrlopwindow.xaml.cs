using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace P4Projekt_2.Baza
{
    /// <summary>
    /// Interaction logic for AddUrlopwindow.xaml
    /// </summary>
    public partial class AddUrlopwindow : Window
    {
        public AddUrlopwindow()
        {
            InitializeComponent();
            _dtp.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int _check = 0;

            if (!(_cb.Text == "" || _cb.Text == null)) { _cb.Background = Brushes.LightGreen; _check++; }
            else _cb.Background = Brushes.OrangeRed;

            if (_tb.Text != "") { _tb.Background = Brushes.LightGreen; _check++; }
            else _tb.Background = Brushes.OrangeRed;

            if (_check == 2)
            {
                using (BazaPracownikow db = new BazaPracownikow())
                {

                    string stan;
                    if (_cb.Text == "Urlop") stan = "3";
                    else if (_cb.Text == "Delegacja") stan = "4";
                    else if (_cb.Text == "Zwolnienie Lekarskie") stan = "2";
                    else stan = null;

                    if (stan != null)
                    {
                        var fate = new Czas_Pracy(
                        _tb.Text,
                        (DateTime)_dtp.SelectedDate,
                        stan
                        );

                        db.Czas_Pracy.Add(fate);
                        db.SaveChanges();
                    }
                }
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}

