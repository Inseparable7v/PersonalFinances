using PersonalFinances.Models;
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

namespace PersonalFinances
{
    /// <summary>
    /// Interaction logic for DossierSearch.xaml
    /// </summary>
    public partial class DossierSearch : Window
    {
        public DossierSearch()
        {
            InitializeComponent();
        }
        PersonalFinancesDBContext context = new();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Number = 0m;
            var ClientData = clientTextBox.Text == null ? "" : clientTextBox.Text;
            var Year = 0m;
            var Status = statusTextBox.Text == null ? "" : statusTextBox.Text;
            Client Client = context.Clients.Where(c => c.ClientEgn == ClientData).FirstOrDefault();
            if (Decimal.TryParse(numberTextBox.Text, out Number) || Decimal.TryParse(yearTextBox.Text, out Year))
            {
                if (Client == null)
                {
                    dataGridView.ItemsSource = context.Dossiers.Where(d => d.DossierNo == Number || d.DossierYear == Year || d.DossierStatus == Status).ToList();
                } else
                {
                    dataGridView.ItemsSource = context.Dossiers.Where(d => d.DossierNo == Number || d.ClientId == Client.ClientId || d.DossierYear == Year || d.DossierStatus == Status).ToList();
                }
            } 
      
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
