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
    /// Логика взаимодействия для ClientInsertWindow.xaml
    /// </summary>
    public partial class ClientInsertWindow : Window
    {
        public static CrashAuto_dbEntities dbEntities = new CrashAuto_dbEntities();
        Client client;
        public ClientInsertWindow(Client clients)
        {
            InitializeComponent();
            this.client = clients;
            ClientFill();

        }

        void ClientFill()
        {
            FirstNameTB.Text = Convert.ToString(client.FirstName);
            IDTB.Text = Convert.ToString(client.ID);
            LastNameTB.Text = Convert.ToString(client.LastName);
            PatronymicTB.Text = Convert.ToString(client.Patronymic);
            EmailTB.Text = Convert.ToString(client.Email);
            PhoneTB.Text = Convert.ToString(client.Phone);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Client clients = dbEntities.Client.FirstOrDefault();
            clients = client;
            clients.FirstName = FirstNameTB.Text;
            clients.FirstName = FirstNameTB.Text;
            clients.Email = EmailTB.Text;
            clients.LastName = LastNameTB.Text;
            clients.Patronymic = PatronymicTB.Text;
            clients.Phone = PhoneTB.Text;

            dbEntities.SaveChanges();
            MessageBox.Show("Выполнено!");

            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.ClientLst.ItemsSource = dbEntities.Client.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.Show();
            this.Close();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientDeleteWindow clientDeleteWindow = new ClientDeleteWindow();
            clientDeleteWindow.Show();
            this.Close();
        }
    }
}
