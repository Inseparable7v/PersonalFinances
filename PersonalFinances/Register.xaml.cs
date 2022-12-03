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
        public Register()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
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
            textBoxAddressMunicipality.Text = "";
            textBoxAddressPCode.Text = "";
            textBoxAddressPlace.Text = "";
            textBoxAddressRegion.Text = "";
            textBoxAddressType.Text = "";
            textBoxAddressText.Text = "";
            textBoxEGN.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                address = new Address();
                dossier = new Dossier();


                var firstName = textBoxFirstName.Text;
                var lastName = textBoxLastName.Text;
                var surrName = textBoxSurrName.Text;
                var email = textBoxEmail.Text;
                var egn = textBoxEGN.Text;
                var addressType = textBoxAddressType.Text;
                var addressRegion = textBoxAddressRegion.Text;
                var addressPlace = textBoxAddressPlace.Text;
                var addressPCode = textBoxAddressPCode.Text;
                var addressText = textBoxAddressText.Text;
                var addressMunicipality = textBoxAddressMunicipality.Text;
                var phone = textBoxPhone.Text;

                dossier.DossierNo = randomIntDossierNumber;
                var randomIntDossierBalance = r.Next(0, 5000);
                dossier.DossierMinBalance = randomIntDossierBalance;
                dossier.DossierYear = new DateTime().Year;

                SetClient(firstName, lastName, surrName, email, egn, phone,
                    addressPCode, addressMunicipality, addressType, addressText, addressRegion, addressPlace);

                client.Addresses.Add(address);
                errormessage.Text = "";
                context.Add(client);
                context.SaveChanges();

                var clientId = context.Clients.FirstOrDefault(c => c.ClientEgn == egn).ClientId;
                address.ClientId = clientId;
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

        private void SetClient(string firstName,string lastName, string surrName,
            string email, string egn, string phone, string addressPCode,
            string addressMunicipality, string addressType, string addressText,
            string addressRegion, string addressPlace)
        {
            client.ClientEmail = email;
            client.ClientName = firstName;
            client.ClientLastname = lastName;
            client.ClientEgn = egn;
            client.ClientPhone = phone;
            client.ClientSurname = surrName;
            address.AddressPcode = addressPCode;
            address.AddressPlace = addressPlace;
            address.AddressRegion = addressRegion;
            address.AddressText = addressText;
            address.AddressType = addressType;
            address.AddresMunicipality = addressMunicipality;
        }
    }
}
