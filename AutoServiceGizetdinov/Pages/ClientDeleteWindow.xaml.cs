using AutoServiceGizetdinov.db;
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

namespace AutoServiceGizetdinov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientDeleteWindow.xaml
    /// </summary>
    public partial class ClientDeleteWindow : Window
    {
        public static CrashAuto_dbEntities dbEntities = new CrashAuto_dbEntities();
        public ClientDeleteWindow()
        {
            InitializeComponent();
            ClientLst.ItemsSource = dbEntities.Client.ToList();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var q = ClientLst.SelectedItem as Client;
            if (q == null)
            {
                MessageBox.Show("Ничего не выбрано!");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удалить?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    dbEntities.Client.Remove(q);
                    ClientLst.ItemsSource = dbEntities.Client.ToList();
                    dbEntities.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.Show();
            this.Close();
        }
    }
}
