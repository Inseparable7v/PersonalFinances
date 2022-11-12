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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView.DataContext = dt;
        }
    }
}
