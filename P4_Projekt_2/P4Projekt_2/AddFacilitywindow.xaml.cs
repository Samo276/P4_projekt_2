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
    /// Interaction logic for AddFacilitywindow.xaml
    /// </summary>
    public partial class AddFacilitywindow : Window
    {
        public int _liczbaZakladow { get; set; }
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public AddFacilitywindow()
        {

            InitializeComponent();

            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork_getNewIds;
            worker.RunWorkerAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCorrect();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy) worker.CancelAsync();
            this.Close();
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
                _liczbaZakladow = db.Zaklad.Where(x=> x.Id_zakladu !=null).Count();
            }
        }
        public void CheckIfCorrect()
        {
            int _check = 0;

            if (_tb1.Text != "") { _tb1.Background = Brushes.LightGreen; _check++; }
            else _tb1.Background = Brushes.OrangeRed;

            if (_tb2.Text != "") { _tb2.Background = Brushes.LightGreen; _check++; }
            else _tb2.Background = Brushes.OrangeRed;

            if (_tb3.Text != "") { _tb3.Background = Brushes.LightGreen; _check++; }
            else _tb3.Background = Brushes.OrangeRed;

            if (_tb4.Text != "") { _tb4.Background = Brushes.LightGreen; _check++; }
            else _tb4.Background = Brushes.OrangeRed;

            if (_tb5.Text != "") { _tb5.Background = Brushes.LightGreen; _check++; }
            else _tb5.Background = Brushes.OrangeRed;

            if (_tb6.Text != "") { _tb6.Background = Brushes.LightGreen; _check++; }
            else _tb6.Background = Brushes.OrangeRed;

            if (_check == 6)
            {
                Zaklad _newFacility = new Zaklad(
                    Convert.ToString(_liczbaZakladow+1),
                    _tb1.Text,
                    _tb2.Text,
                    _tb3.Text,
                    _tb4.Text,
                    _tb5.Text,
                    _tb6.Text
                    );


                using (BazaPracownikow db = new BazaPracownikow())
                {
                    db.Zaklad.Add(_newFacility);
                    db.SaveChanges();
                }

                if (worker.IsBusy) worker.CancelAsync();
                this.Close();
            }
        }
    }
}
