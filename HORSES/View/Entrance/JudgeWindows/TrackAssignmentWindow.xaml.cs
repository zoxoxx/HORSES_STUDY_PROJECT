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

namespace HORSES.View.Entrance.JudgeWindows
{
    /// <summary>
    /// Логика взаимодействия для TrackAssignmentWindow.xaml
    /// </summary>
    public partial class TrackAssignmentWindow : Window
    {
        public TrackAssignmentWindow()
        {
            InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (JockeyComboBox.SelectedValue is null || TrackComboBox.SelectedValue is null || RaceComboBox.SelectedValue is null)
            {
                MessageBox.Show("Необходимо заполнить все данные!");
                return;
            }

            Participant? currentParticipant = App.db.Participants
                .Join(App.db.UserIs,
                participant => participant.UserId,
                user => user.Id,
                (participant, user) => new { participant, user })
                .Where(finalEntry => finalEntry.user.Id == Convert.ToInt32(JockeyComboBox.SelectedValue.ToString()))
                .Select(finalEntry => finalEntry.participant).FirstOrDefault();

            if (currentParticipant is null)
            {
                MessageBox.Show("Жокей отсутствует в ситеме!");
                return;
            }

            await App.db.CompetitionAndCheckIns
                .Where(link => link.CheckInId == Convert.ToInt32(RaceComboBox.SelectedValue) && link.ParticipantId == currentParticipant.Id)
                .ExecuteUpdateAsync(upd => upd.SetProperty(update => update.TrackId, Convert.ToInt32(TrackComboBox.SelectedValue)));

            MessageBox.Show("Дорожка была успешно назначена!");
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            JockeyComboBox.ItemsSource = await LoadJockeys();
            TrackComboBox.ItemsSource = await LoadTracks();
        }

        private async Task<ObservableCollection<UserI>> LoadJockeys() => new ObservableCollection<UserI>(await App.db.UserIs
            .Join(App.db.Participants,
            user => user.Id,
            participant => participant.UserId,
            (user, participant) => new { user, participant })
        .Join(App.db.CompetitionAndCheckIns,
            firstCombo => firstCombo.participant.Id,
            link => link.ParticipantId,
            (firstCombo, link) => new { firstCombo, link })
        .GroupJoin(App.db.Tracks,
            secondCombo => secondCombo.link.TrackId,
            track => track.Id,
            (secondCombo, track) => new { secondCombo, track })
        .SelectMany(
            joined => joined.track.DefaultIfEmpty(),
            (joined, track) => new { joined.secondCombo.firstCombo.user, track })
        .Where(finalEntry => finalEntry.track == null)
        .Select(finalEntry => finalEntry.user)
        .ToListAsync());

        private async Task<ObservableCollection<Track?>> LoadTracks() => new ObservableCollection<Track?>(await App.db.UserIs
            .Join(App.db.Participants,
            user => user.Id,
            participant => participant.UserId,
            (user, participant) => new { user, participant })
        .Join(App.db.CompetitionAndCheckIns,
            firstCombo => firstCombo.participant.Id,
            link => link.ParticipantId,
            (firstCombo, link) => new { firstCombo, link })
        .GroupJoin(App.db.Tracks,
            secondCombo => secondCombo.link.TrackId,
            track => track.Id,
            (secondCombo, track) => new { secondCombo, track })
        .SelectMany(
            joined => joined.track.DefaultIfEmpty(),
            (joined, track) => new { joined.secondCombo.firstCombo.user, track })
        .Where(finalEntry => finalEntry.track == null)
        .Select(finalEntry => finalEntry.track)
        .ToListAsync());

        private async void RaceComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (JockeyComboBox.SelectedValue == null)
            {
                MessageBox.Show("Сначала необходимо выбрать жокея!");
                return;
            }

            int selectedJockeyId = Convert.ToInt32(JockeyComboBox.SelectedValue.ToString());

            var checkIns = await (from user in App.db.UserIs
                                  join participant in App.db.Participants on user.Id equals participant.UserId
                                  join link in App.db.CompetitionAndCheckIns on participant.Id equals link.ParticipantId
                                  join checkIn in App.db.CheckIns on link.CheckInId equals checkIn.Id
                                  join track in App.db.Tracks on link.TrackId equals track.Id into trackGroup
                                  from track in trackGroup.DefaultIfEmpty()
                                  where track == null && link.ParticipantId == selectedJockeyId
                                  select checkIn).ToListAsync();

            RaceComboBox.ItemsSource = new ObservableCollection<CheckIn>(checkIns);
        }

        private async void TrackComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (JockeyComboBox.SelectedValue == null || RaceComboBox.SelectedValue is null)
            {
                MessageBox.Show("Сначало необходимо заполнить другие поля!");
                return;
            }
            int selectedJockeyId = Convert.ToInt32(JockeyComboBox.SelectedValue.ToString());
            ObservableCollection<Track> unusedTracks = new ObservableCollection<Track>(await (from track in App.db.Tracks
                                      join link in App.db.CompetitionAndCheckIns
                                      on track.Id equals link.TrackId into trackLink
                                      from subLink in trackLink.DefaultIfEmpty()
                                      where subLink == null || subLink.CheckInId != Convert.ToUInt32(RaceComboBox.SelectedValue.ToString())
                                      orderby track.Number
                                      select track).ToListAsync());
            TrackComboBox.ItemsSource = unusedTracks;
        }
    }
}
