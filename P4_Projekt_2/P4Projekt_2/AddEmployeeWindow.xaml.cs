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

namespace P4Projekt_2.Baza
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();

            _dtp04.SelectedDate = DateTime.Now.Date;
            _lab1.Visibility = Visibility.Collapsed;
            _tb01.Visibility = Visibility.Collapsed;

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCorrect();
        }

        public void CheckIfCorrect()
        {
            int _check = 0;

            if (_tb02.Text != "") { _tb02.Background = Brushes.LightGreen; _check++; }
            else _tb02.Background = Brushes.OrangeRed;

            if (_tb03.Text != "") { _tb03.Background = Brushes.LightGreen; _check++; }
            else _tb03.Background = Brushes.OrangeRed;

            if (_dtp04.SelectedDate != DateTime.Now.Date) { _dtp04.Background = Brushes.LightGreen; _check++; }
            else _dtp04.Background = Brushes.OrangeRed;

            if (_tb05.Text != "") { _tb05.Background = Brushes.LightGreen; _check++; }
            else _tb05.Background = Brushes.OrangeRed;

            if (_tb06.Text != "") { _tb06.Background = Brushes.LightGreen; _check++; }
            else _tb06.Background = Brushes.OrangeRed;

            if (_tb07.Text != "") { _tb07.Background = Brushes.LightGreen; _check++; }
            else _tb07.Background = Brushes.OrangeRed;

            if (_tb08.Text != "") { _tb08.Background = Brushes.LightGreen; _check++; }
            else _tb08.Background = Brushes.OrangeRed;

            if (_tb09.Text != "") { _tb09.Background = Brushes.LightGreen; _check++; }
            else _tb09.Background = Brushes.OrangeRed;

            if (_tb10.Text != "") { _tb10.Background = Brushes.LightGreen; _check++; }
            else _tb10.Background = Brushes.OrangeRed;

            if (_tb11.Text != "") { _tb11.Background = Brushes.LightGreen; _check++; }
            else _tb11.Background = Brushes.OrangeRed;

            if(_check == 10)
            {
                Pracownicy _newEmployee = new Pracownicy(
                    _tb02.Text,
                    _tb03.Text,
                    (DateTime)_dtp04.SelectedDate,
                    _tb05.Text,
                    _tb06.Text,
                    _tb07.Text,
                    _tb08.Text,
                    _tb09.Text,
                    _tb10.Text,
                    _tb11.Text
                        );

                _lab1.Visibility = Visibility.Visible;
                using (BazaPracownikow db = new BazaPracownikow())
                {
                    db.Pracownicy.Add(_newEmployee);
                    db.SaveChanges();
                }
                _tb01.Visibility = Visibility.Visible;
                this.Close();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
