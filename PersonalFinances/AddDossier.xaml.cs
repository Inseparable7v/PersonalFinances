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
            var Year = yearTextBox.Text;
            var MinBalance = minBalanceTextBox.Text;

            // todo
            //context.Dossiers.Add(new Dossier());
        }

    }
}
