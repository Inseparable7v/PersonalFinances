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
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Data.Sql;
using System.Data;
using PersonalFinances.Models;
using System.Windows.Interop;
using System.Text.RegularExpressions;

namespace PersonalFinances
{
    /// <summary>
    /// Interaction logic for SearchClient.xaml
    /// </summary>
    public partial class SearchClient : Window
    {
        public SearchClient()
        {
            InitializeComponent();
        }
        private PersonalFinancesDBContext context = new();


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var searchText = searchTextBox.Text;
            List<Client> clients = context.Clients.Where(c => c.ClientName == searchText || c.ClientEgn == searchText || c.ClientEmail == searchText || c.ClientPhone == searchText).ToList();
            dataGridView.ItemsSource = clients;
        }

        private void dataGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridView.SelectedItems.Count > 0)
            {
                editButton.Visibility = Visibility.Visible;
                Client client = dataGridView.SelectedItem as Client;
                Console.WriteLine(client.ClientName);
                clientEGN.Text = client.ClientEgn;
                clientEmail.Text = client.ClientEmail;
                clientLastName.Text = client.ClientLastname;
                clientName.Text = client.ClientName;
                clientPhone.Text = client.ClientPhone;
                clientSurname.Text = client.ClientSurname;
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

            Client client = dataGridView.SelectedItem as Client;
            if (clientEmail.Text.Length == 0)
            {
                MessageBox.Show("Enter an email.");
                clientEmail.Focus();
            }
            if (clientEGN.Text.Length < 10 || clientEGN.Text.Length > 10)
            {
                MessageBox.Show("EGN must be exact 10 numbers.");
                clientEGN.Focus();
            }
            if (clientPhone.Text.Length < 10 || clientPhone.Text.Length > 10)
            {
                MessageBox.Show("Phone must be exact 10 numbers.");
                clientPhone.Focus();
            }
            else if (!Regex.IsMatch(clientEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email.");
                clientEmail.Select(0, clientEmail.Text.Length);
                clientEmail.Focus();
            }
            else
            {
                {
                    client.ClientEgn = clientEGN.Text;
                    client.ClientEmail = clientEmail.Text;
                    client.ClientLastname = clientLastName.Text;
                    client.ClientPhone = clientPhone.Text;
                    client.ClientName = clientName.Text;
                    client.ClientSurname = clientSurname.Text;
                    context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                    MessageBox.Show("Update Client information successfully.");
                    dataGridView.ItemsSource = new List<Client> { client };
                    clientEGN.Text = "";
                    clientEmail.Text = "";
                    clientLastName.Text = "";
                    clientPhone.Text = "";
                    clientName.Text = "";
                    clientSurname.Text = "";
                }
            }
        }

    }
}
