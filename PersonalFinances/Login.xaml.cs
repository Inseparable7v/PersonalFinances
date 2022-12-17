using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using PersonalFinances.Models;

namespace PersonalFinances
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }

        Register registration = new();
        PersonalFinancesDBContext context = new();
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
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
                var email = textBoxEmail.Text;
                var egn = egnBox.Password;
                if (context.Clients.Any(u => u.ClientEgn == egn && u.ClientEmail == email))
                {
                    var successfullLoginMessage = "You have login succeffully";
                    var mainWindow = new MainWindow(successfullLoginMessage);
                    Global.client = context.Clients.FirstOrDefault(u => u.ClientEgn == egn && u.ClientEmail == email);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    errormessage.Text = "Sorry! Please enter existing email/EGN.";
                }
            }
        }
    }
}
