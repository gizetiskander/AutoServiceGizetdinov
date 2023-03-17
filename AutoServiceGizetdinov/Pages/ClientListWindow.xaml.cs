using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static CrashAuto_dbEntities dbEntities = new CrashAuto_dbEntities();
        public ClientListWindow()
        {
            InitializeComponent();

            RefreshComboBox();
            RefreshButtons();
            ClientLst.ItemsSource = dbEntities.Client.ToList();
            foreach (var serv in dbEntities.Gender)
            {
                FilterCB.ItemsSource = dbEntities.Gender.ToList();

            }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
            view.Filter = UserFilter;

        }
        int pageSize;
        int pageNumber;
        List<Client> prod1 = dbEntities.Client.ToList();

        private void RefreshPagination()
        {
            ClientLst.ItemsSource = null;
            ClientLst.ItemsSource = prod1.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        private void RefreshComboBox()
        {
            CBNumberWrite.Items.Add("20");
        }

        private void RefreshButtons()
        {
            WPButtons.Children.Clear();
            if (prod1.Count % pageSize == 0)
            {
                for (int i = 0; i < prod1.Count / pageSize; i++)
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    button.Margin = new Thickness(0, 5, 0, 5);
                    button.Width = 20;
                    button.Height = 20;
                    button.Foreground = Brushes.White;
                    button.BorderBrush = Brushes.Blue;
                    button.Background = Brushes.Blue;
                    button.FontSize = 8;
                    WPButtons.Children.Add(button);
                }
            }
            else
            {
                for (int i = 0; i < prod1.Count / pageSize; i++)
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    button.Margin = new Thickness(0, 5, 0, 5);
                    button.Width = 20;
                    button.Height = 20;
                    button.Foreground= Brushes.White;
                    button.BorderBrush = Brushes.Blue;
                    button.Background = Brushes.Blue;
                    button.FontSize = 8;
                    WPButtons.Children.Add(button);
                }
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(SearchTB.Text))
                return true;
            else
                return ((item as Client).Gender.Code.IndexOf(SearchTB.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            pageNumber = Convert.ToInt32(button.Content) - 1;
            RefreshPagination();
        }

        private void ClientLst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var insert = ClientLst.SelectedItem as Client;
            ClientInsertWindow clientInsertWindow = new ClientInsertWindow(insert);
            clientInsertWindow.Show();
            this.Close();
        }

        private void PagLeft_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber == 0)
                return;
            pageNumber--;
            RefreshPagination();
        }

        private void PagRight_Click(object sender, RoutedEventArgs e)
        {
            if (prod1.Count % pageSize == 0)
            {
                if (pageNumber == (prod1.Count / pageSize) - 1)
                    return;
            }
            else
            {

                if (pageNumber == (prod1.Count / pageSize))
                    return;
            }
            pageNumber++;
            RefreshPagination();
        }

        private void CBNumberWrite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageSize = Convert.ToInt32(CBNumberWrite.SelectedItem.ToString());
            RefreshPagination();
            RefreshButtons();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var typeName = ((Gender)FilterCB.SelectedItem).Code;
            var type = dbEntities.Gender.Where(x => x.Code == typeName).FirstOrDefault();
            ClientLst.ItemsSource = dbEntities.Client.Where(x => x.Gender.Code == typeName).ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedIndex == 0)
            {
                ClientLst.ItemsSource = dbEntities.Client.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Client.FirstName", ListSortDirection.Ascending));


            }
            else if (SortCB.SelectedIndex == 1)
            {
                ClientLst.ItemsSource = dbEntities.Client.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Client.FirstName", ListSortDirection.Descending));


            }
            else if (SortCB.SelectedIndex == 2)
            {
                ClientLst.ItemsSource = dbEntities.Client.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Client.LastName", ListSortDirection.Ascending));

            }
            else if (SortCB.SelectedIndex == 3)
            {
                ClientLst.ItemsSource = dbEntities.Client.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Client.LastName", ListSortDirection.Descending));

            }
            else if (SortCB.SelectedIndex == 4)
            {
                ClientLst.ItemsSource = dbEntities.Client.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Client.Patronymic", ListSortDirection.Ascending));

            }
            else if (SortCB.SelectedIndex == 5)
            {
                ClientLst.ItemsSource = dbEntities.Client.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ClientLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Client.Patronymic", ListSortDirection.Descending));

            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientLst.ItemsSource = dbEntities.Client.ToList();

            SortCB.SelectedItem = null;
            SearchTB.Clear();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientAddWindow clientAddWindow = new ClientAddWindow();
            clientAddWindow.Show();
            this.Show();    
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var TBSQ = dbEntities.Client.OrderBy(a => a.FirstName).ToList();
            TBSQ = TBSQ.Where(a => a.FirstName.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
            ClientLst.ItemsSource = TBSQ;
        }
    }
}
