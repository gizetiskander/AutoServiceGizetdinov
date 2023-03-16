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
using AutoServiceGizetdinov.db;

namespace AutoServiceGizetdinov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        AutoServ_dbEntities dbEntities = new AutoServ_dbEntities();
        public ClientListWindow()
        {
            InitializeComponent();
            ClientLst.ItemsSource = dbEntities.Client.ToList();
        }

        private void ClientLst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void PagLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PagRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CBNumberWrite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
