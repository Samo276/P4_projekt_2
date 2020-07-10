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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    
    public partial class AddEmployeeWindow : Window
    {
        public int _liczbaZakladow { get; set; }
        public string _noweIdPracownika { get; set; }
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public AddEmployeeWindow()
        {
            InitializeComponent();

            _dtp04.SelectedDate = DateTime.Now.Date;
            _lab1.Visibility = Visibility.Collapsed;
            _tb01.Visibility = Visibility.Collapsed;

            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork_getNewIds;
            worker.RunWorkerAsync();
           
        }
        private void worker_DoWork_getNewIds(object sender, DoWorkEventArgs e)
        {
            List<int> _new_id = new List<int>();
            using (BazaPracownikow db = new BazaPracownikow())
            {
                /*var lp = db.Zaklad.Where(x => x.Id_zakladu != null).ToList<Zaklad>();
                foreach (var item in lp)
                {
                    _new_id.Add(Convert.ToInt32(item.Id_zakladu));
                }
                _liczbaZakladow = _new_id.Max();*/
                _liczbaZakladow = db.Zaklad.Where(x => x.Id_zakladu != null).Count();
            }
            List<int> _new_idp = new List<int>();
            using (BazaPracownikow db = new BazaPracownikow())
            {
                /*var lp2 = db.Pracownicy.Where(x => x.Id_pracownika != null).ToList<Pracownicy>();
                foreach (var item in lp2)
                {
                    _new_idp.Add(Convert.ToInt32(item.Id_pracownika));
                }
                _noweIdPracownika = Convert.ToString(_new_idp.Max() + 1);*/
                _noweIdPracownika = Convert.ToString(db.Pracownicy.Where(x => x.Id_pracownika != null).Count() +1 );
            }

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

            if (_tb11.Text != "" && _tb11.Text.All(Char.IsDigit) && Convert.ToInt32(_tb11.Text) <= _liczbaZakladow) { _tb11.Background = Brushes.LightGreen; _check++; }
            else _tb11.Background = Brushes.OrangeRed;

            if(_check == 10)
            {
                /*List<int> _new_id = new List<int>();
                using (BazaPracownikow db = new BazaPracownikow())
                {
                    var lp = db.Pracownicy.Where(x=> x.Id_pracownika != null ).ToList<Pracownicy>();
                    foreach (var item in lp)
                    {
                        _new_id.Add( Convert.ToInt32(item.Id_pracownika));
                    }
                    
                }*/
                Pracownicy _newEmployee = new Pracownicy(
                    _noweIdPracownika,
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

                
                using (BazaPracownikow db = new BazaPracownikow())
                {
                    db.Pracownicy.Add(_newEmployee);
                    db.SaveChanges();
                }
               
                if (worker.IsBusy) worker.CancelAsync();
                this.Close();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy) worker.CancelAsync();
            this.Close();
        }
    }
}
