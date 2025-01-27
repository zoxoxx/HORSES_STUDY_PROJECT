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
    /// Логика взаимодействия для MainJudgePage.xaml
    /// </summary>
    public partial class MainJudgePage : Page
    {
        public MainJudgePage()
        {
            InitializeComponent();
        }

        private void Track_Assignment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Viewing_Information_About_Participants_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Viewing_Check_Results_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Violations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_BACK_MAIN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultWindow window = new ResultWindow();
            window.Show();
        }

        private void Information_Participants_Click(object sender, RoutedEventArgs e)
        {
            CompetitionAndRacesWindow window = new CompetitionAndRacesWindow(true);
            window.Show();
        }
    }
}
