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
using HORSES.Controller;

namespace HORSES.View.Fan
{
    /// <summary>
    /// Логика взаимодействия для CompetitionAndRacesWindow.xaml
    /// </summary>
    public partial class CompetitionAndRacesWindow : Window
    {
        ObservableCollection<Competition> competitions = null;
        ObservableCollection<CheckIn> races = null;
        public CompetitionAndRacesWindow()
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            competitions = await AllRaces();
        }

        private async Task<ObservableCollection<Competition>> AllRaces() => new ObservableCollection<Competition>(await App.db.Competitions.ToListAsync());

        private async void DG_COMPETITIONS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_COMPETITIONS.SelectedItem is null)
                return;

            var selectedItem = DG_COMPETITIONS.SelectedItem as Competition;
            races = await CompetitionsAndRacesController.CurrentRaceForCompetition(selectedItem);
        }

        private async void DG_RACES_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
