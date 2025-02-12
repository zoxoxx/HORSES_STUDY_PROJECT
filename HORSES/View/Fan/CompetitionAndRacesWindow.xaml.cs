using HORSES.Controller;
using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HORSES.View.Fan
{
    /// <summary>
    /// Логика взаимодействия для CompetitionAndRacesWindow.xaml
    /// </summary>
    public partial class CompetitionAndRacesWindow : Window
    {
        ObservableCollection<Competition> competitions = null;
        ObservableCollection<CheckIn> races = null;
        bool mode = false;
        public CompetitionAndRacesWindow(bool mode = false)
        {
            InitializeComponent();
            this.mode = mode;
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            competitions = await AllRaces();
            DG_COMPETITIONS.ItemsSource = competitions;
        }

        private async Task<ObservableCollection<Competition>> AllRaces() => new ObservableCollection<Competition>(await App.db.Competitions.ToListAsync());

        private async void DG_COMPETITIONS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_COMPETITIONS.SelectedItem is null)
                return;

            var selectedItem = DG_COMPETITIONS.SelectedItem as Competition;
            races = await CompetitionsAndRacesController.CurrentRaceForCompetition(selectedItem);
            DG_RACES.ItemsSource = races;
        }

        private async void DG_RACES_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_RACES.SelectedItem is null)
                return;

            if (!mode)
            {
                MessageBox.Show("Это забеги!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var selectedItem = DG_RACES.SelectedItem as CheckIn;
            MessageBoxResult result = MessageBox.Show("Посмотреть результаты?\nНет - участников.", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ResultWindow windowR = new ResultWindow(selectedItem);
                this.Hide();
                windowR.Show();
                return;
            }

            ParticipantsRaceWindow window = new ParticipantsRaceWindow(selectedItem);
            this.Hide();
            window.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
