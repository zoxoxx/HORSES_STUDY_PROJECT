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

namespace HORSES.View.Fan
{
    /// <summary>
    /// Логика взаимодействия для MainFanWindow.xaml
    /// </summary>
    public partial class MainFanWindow : Window
    {
        public MainFanWindow()
        {
            InitializeComponent();
        }

        private async void BTN_BACK_MAIN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private async void BTN_COMPETITION_INFO_Click(object sender, RoutedEventArgs e)
        {
            CompetitionAndRacesWindow window = new CompetitionAndRacesWindow();
            this.Close();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CompetitionAndRacesWindow window = new CompetitionAndRacesWindow(true);
            this.Close();
            window.Show();
        }

        private void BTN_DONATION_Click(object sender, RoutedEventArgs e)
        {
            DonationWindow window = new DonationWindow();
            this.Close();
            window.Show();
        }
    }
}
