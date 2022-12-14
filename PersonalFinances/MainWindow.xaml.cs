using PersonalFinances.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalFinances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(Global.client == null)
            {
                searchClient.Visibility = Visibility.Hidden;
                searchDossier.Visibility = Visibility.Hidden;
                addDossier.Visibility = Visibility.Hidden;
            }
        }

        public MainWindow(string message) : base()
        {
            InitializeComponent();
            LoginHeading.Text = message;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var register = new Register();
            register.Show();
        }

        private void SearchClient_Click(object sender, RoutedEventArgs e)
        {
            var searchClient = new SearchClient();
            searchClient.Show();
        }

        private void SearchDossier_Click(object sender, RoutedEventArgs e)
        {
            var searchDossier = new DossierSearch();
            searchDossier.Show();
        }

        private void AddDossier_Click(object sender, RoutedEventArgs e)
        {
            var addDossier = new AddDossier();
            addDossier.Show();
        }
    }
}
