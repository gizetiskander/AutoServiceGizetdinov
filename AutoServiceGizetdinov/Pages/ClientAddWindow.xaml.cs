using AutoServiceGizetdinov.db;
using Microsoft.Win32;
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
    /// Логика взаимодействия для ClientAddWindow.xaml
    /// </summary>
    public partial class ClientAddWindow : Window
    {
        OpenFileDialog ofdImage = new OpenFileDialog();
        public static CrashAuto_dbEntities dbEntities = new CrashAuto_dbEntities();
        public ClientAddWindow()
        {
            InitializeComponent();
            GenderCB.ItemsSource = dbEntities.Gender.ToList();
        }

        private void ImgBtn_Click(object sender, RoutedEventArgs e)
        {
            ofdImage.Filter = "Image files|*.bmp;*.jpg;*.png|All files|*.*";
            ofdImage.FilterIndex = 1;
            if (ofdImage.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(ofdImage.FileName);
                image.EndInit();
                playim.Source = image;
            }
        }
        private void DelImgBtn_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.Freeze();
            playim.Source = image;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTB.Text == "" || FirstNameTB.Text == "" || LastNameTB.Text == "" || PatronymicTB.Text == "")
            {
                MessageBox.Show("Введите данные!");
            }
            else
            {
                Client client = new Client();
                client.FirstName = FirstNameTB.Text;
                client.Email = EmailTB.Text;
                client.LastName = LastNameTB.Text;
                client.Patronymic = PatronymicTB.Text;
                client.Phone = PhoneTB.Text;
                client.RegistrationDate = RegDateDP.SelectedDate.Value.Date;
                client.Birthday = BirthDateDP.SelectedDate.Value.Date;
                var GenderCode = GenderCB.SelectedItem;
                var Code = ((Gender)GenderCode).Code;
                client.GenderCode = Code;

                dbEntities.Client.Add(client);
                dbEntities.SaveChanges();
                MessageBox.Show("Выполнено!");

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
