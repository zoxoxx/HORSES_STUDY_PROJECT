using HORSES.Controller;
using HORSES.Models;
using HORSES.View.Fan;
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

namespace HORSES.View.Entrance
{
    /// <summary>
    /// Логика взаимодействия для Autorize.xaml
    /// </summary>
    public partial class Autorize : Window
    {
        public Autorize()
        {
            InitializeComponent();
        }

        private async void BTN_VHOD_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_LOGIN.Text) || string.IsNullOrWhiteSpace(TB_PASSWORD.Text))
            {
                MessageBox.Show("Заполните данные для авторизации!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UserI? user = await AutorizeController.Autorize(TB_LOGIN.Text, TB_PASSWORD.Text);
            if (user == null)
            {
                MessageBox.Show("Пользователь отсутствует в системе.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainUserWindow window = new MainUserWindow(user);
            this.Close();
            window.Show();
        }


        private async void BTN_FAN_Click(object sender, RoutedEventArgs e)
        {
            MainFanWindow window = new MainFanWindow();
            this.Close();
            window.Show();
        }

        private async void BTN_RETURN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }
    }
}
