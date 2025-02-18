using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
using System.Windows.Shapes;

namespace HORSES.View.Entrance.JockeyWindows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        UserI currentUser; 
        public RegistrationWindow(UserI currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (RACE_CMB.SelectedValue is null || HorseComboBox.SelectedValue is null)
            {
                MessageBox.Show("Необходимо заполнить все данные!");
                return;
            }

            Participant newParticipant = new Participant {HorseId = Convert.ToInt32(HorseComboBox.SelectedValue), ClothesSetId = 1, UserId = currentUser.Id, Disqualification = false };
            await App.db.Participants.AddAsync(newParticipant);
            await App.db.SaveChangesAsync();
            CompetitionAndCheckIn newEvent = new CompetitionAndCheckIn{ CheckInId = Convert.ToInt32(RACE_CMB.SelectedValue.ToString()),  CompetitionId = 1, ParticipantId = newParticipant.Id};
            await App.db.CompetitionAndCheckIns.AddAsync(newEvent);
            await App.db.SaveChangesAsync();
            MessageBox.Show("Регистрация " + currentUser.Phyo + " успешно завершена!");
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var checkIns = await App.db.CheckIns.ToListAsync();
            var compAndCheckIns = await App.db.CompetitionAndCheckIns.ToListAsync();
            var participants = await App.db.Participants.ToListAsync();

            var raceWithParticipants = from race in checkIns
                           join link in compAndCheckIns
                           on race.Id equals link.CheckInId into raceLinks
                           from raceLink in raceLinks.DefaultIfEmpty()
                           join participant in participants
                           on raceLink?.ParticipantId equals participant.Id into raceParticipants
                           from raceParticipant in raceParticipants.DefaultIfEmpty()
                           select new 
                           { 
                               Race = race,
                               RaceParticipant = raceParticipant ?? new Participant() // или любое значение по умолчанию, если нужно
                           };

            var racesWithoutCurrentUser = raceWithParticipants
                .GroupBy(rwp => rwp.Race.Id)
                .Where(group => !group.Any(r => r.RaceParticipant != null && r.RaceParticipant.UserId == currentUser.Id))
                .Select(group => group.First().Race)
                .ToList();

            RACE_CMB.ItemsSource = new ObservableCollection<CheckIn>(racesWithoutCurrentUser);
        }

        private async void HorseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RACE_CMB.SelectedValue is null)
            {
                MessageBox.Show("Сначала необходимо выбрать заезд!!!");
                return;
            }
        }

        private void HorseComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (RACE_CMB.SelectedValue is null)
            {
                MessageBox.Show("Сначала необходимо выбрать заезд!!!");
                return;
            }
        }

        private async void RACE_CMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRaceId = Convert.ToInt32(RACE_CMB.SelectedValue);

            var horses = await App.db.Horses.ToListAsync();
            var participants = await App.db.Participants.ToListAsync();
            var links = await App.db.CompetitionAndCheckIns.ToListAsync();
            CheckIn currentRace = App.db.CheckIns.FirstOrDefault(r => r.Id == Convert.ToInt32(RACE_CMB.SelectedValue.ToString()));
            string[] typs = currentRace.TypeHorseIdCollection.Split(",");
            List<int>? currentTyps = new List<int>();
            int currentAge = Convert.ToInt32(currentRace.Age);
            for(int i = 0; i < typs.Length; i++)
            {
                currentTyps.Add(Convert.ToInt32(typs[i]));
            }



            var unusedHorses = horses
                .Where(horse => !participants
                    .Any(participant => participant.HorseId == horse.Id && links
                        .Any(link => link.ParticipantId == participant.Id && link.CheckInId == selectedRaceId)) && currentTyps.Contains(horse.TypId ?? 0)
                        && horse.Birthday.Value.Year >= currentAge)
                .ToList();

            HorseComboBox.ItemsSource = new ObservableCollection<Horse>(unusedHorses);
        }
    }
}
