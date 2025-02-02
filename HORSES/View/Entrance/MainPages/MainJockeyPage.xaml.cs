using HORSES.View.Entrance.JockeyWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HORSES.View.Entrance.MainPages
{
    /// <summary>
    /// Логика взаимодействия для MainJockeyPage.xaml
    /// </summary>
    public partial class MainJockeyPage : Page
    {
        public MainJockeyPage()
        {
            InitializeComponent();
        }

        private void Information_Jockey_Click(object sender, RoutedEventArgs e)
        {
            JockeyProfileWindow window = new JockeyProfileWindow();
            window.ShowDialog();
        }

        private void Information_Horse_Clickkj(object sender, RoutedEventArgs e)
        {
            HorseWindow window = new HorseWindow();
            window.ShowDialog();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Information_Participants_Click(object sender, RoutedEventArgs e)
        {
            CompetitionAndRacesWindow window = new CompetitionAndRacesWindow(true);
            window.Show();
        }

        private void Viewing_Results_Click(object sender, RoutedEventArgs e)
        {
            ResultWindow window = new ResultWindow();
            window.Show();
        }

        private void BTN_BACK_MAIN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
