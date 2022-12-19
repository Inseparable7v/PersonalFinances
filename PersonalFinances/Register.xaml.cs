using PersonalFinances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private Address address;
        private Dossier dossier;
        private Client client;
        private PersonalFinancesDBContext context;
        private static Login Login = new();
        public Register()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login.Show();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxSurrName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddressHMunicipality.Text = "";
            textBoxAddressHPlace.Text = "";
            textBoxAddressHRegion.Text = "";
            textBoxAddressHPostCode.Text = "";
            textBoxAddressHText.Text = "";
            textBoxAddressPPlace.Text = "";
            textBoxAddressPRegion.Text = "";
            textBoxAddressPPostCode.Text = "";
            textBoxAddressPText.Text = "";
            textBoxAddressPMunicipality.Text = "";
            textBoxEGN.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login.Show();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            var randomIntDossierNumber = r.Next(0, 1000);


            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                context = new PersonalFinancesDBContext();
                client = new Client();
                var homeAddress = new Address();
                var privateAddress = new Address();
                dossier = new Dossier();


                var firstName = textBoxFirstName.Text;
                var lastName = textBoxLastName.Text;
                var surrName = textBoxSurrName.Text;
                var email = textBoxEmail.Text;
                var egn = textBoxEGN.Text;
                var phone = textBoxPhone.Text;

                dossier.DossierNo = randomIntDossierNumber;
                var randomIntDossierBalance = r.Next(0, 5000);
                dossier.DossierMinBalance = randomIntDossierBalance;
                dossier.DossierYear = new DateTime().Year;

                SetClient(firstName, lastName, surrName, email, egn, phone);
                SetAddress(ref privateAddress, ref homeAddress);
                SetAddress(ref privateAddress, ref homeAddress);
                client.Addresses.Add(homeAddress);
                client.Addresses.Add(privateAddress);

                errormessage.Text = "";
                context.Add(client);
                context.SaveChanges();

                var clientId = context.Clients.FirstOrDefault(c => c.ClientEgn == egn).ClientId;
                privateAddress.ClientId = clientId;
                homeAddress.ClientId = clientId;
                dossier.ClientId = clientId;
                context.Add(address);
                context.Add(dossier);
                context.SaveChangesAsync();
                errormessage.Text = "You have Registered successfully.";
                Login_Click(sender, e);
                Close_Click(sender, e);
                Reset();
            }
        }

        private void SetClient(string firstName, string lastName, string surrName,
            string email, string egn, string phone)
        {
            client.ClientEmail = email;
            client.ClientName = firstName;
            client.ClientLastname = lastName;
            client.ClientEgn = egn;
            client.ClientPhone = phone;
            client.ClientSurname = surrName;
        }

        private void SetAddress(ref Address privateAddress, ref Address homeAddress)
        {
            //Home address fields
            homeAddress.AddressType = "H";
            homeAddress.AddressPlace = textBoxAddressHPlace.Text;
            homeAddress.AddressRegion = textBoxAddressHRegion.Text;
            homeAddress.AddressText = textBoxAddressHText.Text;
            homeAddress.AddressPcode = textBoxAddressHPostCode.Text;
            homeAddress.AddresMunicipality = textBoxAddressHMunicipality.Text;

            // Private Adddress fields
            privateAddress.AddressType = "P";
            privateAddress.AddressPlace = textBoxAddressPPlace.Text;
            privateAddress.AddressRegion = textBoxAddressPRegion.Text;
            privateAddress.AddressText = textBoxAddressPText.Text;
            privateAddress.AddressPcode = textBoxAddressPPostCode.Text;
            privateAddress.AddresMunicipality = textBoxAddressPMunicipality.Text;
        }
    }
}
