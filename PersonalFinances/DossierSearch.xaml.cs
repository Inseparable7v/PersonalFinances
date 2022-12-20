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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    var searchText = searchTextBox.Text;
        //    List<Client> clients = context.Clients.Where(c => c.ClientName == searchText || c.ClientEgn == searchText || c.ClientEmail == searchText || c.ClientPhone == searchText).ToList();
        //    dataGridView.ItemsSource = clients;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var searchText = searchTextBox.Text;
            var Number = 0m;
            var ClientData = searchTextBox.Text == null ? "" : searchTextBox.Text;
            var Year = 0m;
            var Status = searchTextBox.Text == null ? "" : searchTextBox.Text;
            Client Client = context.Clients.Where(c => c.ClientEgn == ClientData).FirstOrDefault();
            if (Decimal.TryParse(searchTextBox.Text, out Number) || Decimal.TryParse(searchTextBox.Text, out Year))
            {
                if (Client == null)
                {
                    dataGridView.ItemsSource = context.Dossiers.Where(d => d.DossierNo == Number || d.DossierYear == Year || d.DossierStatus == Status).ToList();
                }
                else
                {
                    dataGridView.ItemsSource = context.Dossiers.Where(d => d.DossierNo == Number || d.ClientId == Client.ClientId || d.DossierYear == Year || d.DossierStatus == Status).ToList();
                }
            }

        }

        private void dataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridView.SelectedItems.Count > 0)
            {
                editButton.Visibility = Visibility.Visible;
                Dossier dossier = dataGridView.SelectedItem as Dossier;
                dossierNumber.Text = dossier.DossierNo.ToString();
                year.Text = dossier.DossierYear.ToString();
                status.Text = dossier.DossierStatus;
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Dossier dossier = dataGridView.SelectedItem as Dossier;

           if(dossierNumber.Text.Length == 0)
            {
                MessageBox.Show("Enter a dossier number.");
                dossierNumber.Focus();
            }

            if (year.Text.Length == 0)
            {
                MessageBox.Show("Enter an year.");
                year.Focus();
            }

            if (status.Text.Length == 0)
            {
                MessageBox.Show("Enter a status number.");
                status.Focus();
            }

            var Number = 0m;
            var Year = 0m;

            if (Decimal.TryParse(dossierNumber.Text, out Number) && Decimal.TryParse(year.Text, out Year))
            {
                dossier.DossierNo = Number;
                dossier.DossierYear = Year;
                dossier.DossierStatus = status.Text;
                context.Entry(dossier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                MessageBox.Show("Update dossier information successfully.");
                dataGridView.ItemsSource = new List<Dossier> { dossier };

                dossierNumber.Text = "";
                year.Text = "";
                status.Text = "";
                client.Text = "";
            }
            else
            {
                MessageBox.Show("Error while updating dossier information!");

            }
        }
    }
}
