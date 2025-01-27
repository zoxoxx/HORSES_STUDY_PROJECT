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
using System.Windows.Shapes;

namespace HORSES.View.Fan
{
    /// <summary>
    /// Логика взаимодействия для ParticipantsRaceWindow.xaml
    /// </summary>
    public partial class ParticipantsRaceWindow : Window
    {
        CheckIn currentRace;
        public ParticipantsRaceWindow(CheckIn currentRace)
        {
            this.currentRace = currentRace;
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title += " " + currentRace.SequenceNumber.ToString();
            DG_PARTICIPANTS.DataContext = await CurrentParticipants();
        }

        private async Task<ObservableCollection<object>> CurrentParticipants()
        {
           var participantList = await
            App.db.CompetitionAndCheckIns
            .Join(App.db.Participants,
            link => link.ParticipantId,
            participant => participant.Id,
            (link, participant) => new { link, participant })
            .Join(App.db.UserIs,
            raceComb => raceComb.participant.UserId,
            user => user.Id,
            (raceComb, user) => new { raceComb, user })
            .Join(App.db.ClothesSets,
            comb => comb.raceComb.participant.ClothesSetId,
            clothes => clothes.Id,
            (comb, clothes) => new { comb, clothes })
            .Join(App.db.Horses,
            combo => combo.comb.raceComb.participant.HorseId,
            horse => horse.Id,
            (combo, horse) => new { combo, horse })
            .Join(App.db.TypHorses,
                fullCombo => fullCombo.horse.TypId,
                typHorse => typHorse.Id,
                (fullCombo, typHorse) => new { fullCombo, typHorse })
            .Where(finalCombo => finalCombo.fullCombo.combo.comb.raceComb.link.CheckInId == currentRace.Id)
            .Select(finalCombo => new
            {
                PHYO = finalCombo.fullCombo.combo.comb.user.Phyo,
                Horse = finalCombo.fullCombo.horse.Name,
                TypHorse = finalCombo.typHorse.Name,
                ColorHelmet = finalCombo.fullCombo.combo.clothes.HelmetColor,
                Discval = finalCombo.fullCombo.combo.comb.raceComb.participant.Disqualification == true ? "Дисквалифицирован" : "Не дисквалифицирован"
            })
            .ToListAsync();

            return new ObservableCollection<object>(participantList);
        }
    }
}
