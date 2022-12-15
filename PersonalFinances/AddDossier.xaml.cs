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
    /// Interaction logic for AddDossier.xaml
    /// </summary>
    public partial class AddDossier : Window
    {
        public AddDossier()
        {
            InitializeComponent();
        }

        PersonalFinancesDBContext context = new();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var year = 0m;
            var minBalance = 0m;
           
            Decimal.TryParse(yearTextBox.Text, out year);
            Decimal.TryParse(minBalanceTextBox.Text, out minBalance);

            Dossier dossier = new Dossier(year, minBalance);
            dossier.DossierStatus = "O";
            dossier.ClientId = Global.client.ClientId;
            
            try
            {
                context.Dossiers.Add(dossier);
                context.SaveChanges();
                clearFields();
                Message.Text = "Successfully added dossier!";
            } catch (Exception ex)
            {
                clearFields();
                Message.Text = "Error while adding dossier!";
            }


        }

        private void clearFields()
        {
            yearTextBox.Text = "";
            minBalanceTextBox.Text = "";
        }
        private void OnTextBoxTextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
