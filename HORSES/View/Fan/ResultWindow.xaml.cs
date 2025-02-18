using HORSES.Models;
using HORSES.View.Entrance;
using HORSES.View.Entrance.JockeyWindows;
using HORSES.View.Entrance.JudgeWindows;
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
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        CheckIn currentRace;
        public ResultWindow(CheckIn currentRace)
        {
            this.currentRace = currentRace;
            InitializeComponent();
        }
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainUserWindow.CurrentUser is null || MainUserWindow.CurrentUser.RoleId == 2 || MainUserWindow.CurrentUser.RoleId == 3)
            {
                BTN_ADD.Visibility = Visibility.Hidden;
                BTN_EDIT.Visibility = Visibility.Hidden;
            }
            DG_RESULT.ItemsSource = await CurrentResults();
        }
        private async Task<ObservableCollection<object>> CurrentResults()
        {
            var resultList = await
            App.db.CheckInResults
            .Join(App.db.Participants,
            result => result.ParticipantId,
            participant => participant.Id,
            (result, participant) => new { result, participant })
            .Join(App.db.ClothesSets,
            partResCombo => partResCombo.participant.ClothesSetId,
            clothes => clothes.Id,
            (partResCombo, clothes) => new {partResCombo, clothes})
            .Join(App.db.Horses,
            clothesCombo => clothesCombo.partResCombo.participant.HorseId,
            horse => horse.Id,
            (clothesCombo, horse) => new {clothesCombo, horse })
            .Join(App.db.UserIs,
            horseCombo => horseCombo.clothesCombo.partResCombo.participant.UserId,
            user => user.Id,
            (horseCombo, user) => new {horseCombo, user})
            .Join(App.db.TypHorses,
            userCombo => userCombo.horseCombo.horse.TypId,
            typHorse => typHorse.Id,
            (userCombo, typHorse) => new {userCombo, typHorse})
            .Where(finalCombo => finalCombo.userCombo.horseCombo.clothesCombo.partResCombo.result.CheckInId == currentRace.Id)
            .Select(finalCombo => new
            {
                PHYO = finalCombo.userCombo.user.Phyo,
                NameSkak = finalCombo.userCombo.horseCombo.horse.Name,
                Poroda = finalCombo.typHorse.Name,
                ColorClothes = finalCombo.userCombo.horseCombo.clothesCombo.clothes.HelmetColor,
                TimeFinish = finalCombo.userCombo.horseCombo.clothesCombo.partResCombo.result.TimeEnd,
                ID = finalCombo.userCombo.horseCombo.clothesCombo.partResCombo.result.CheckInId.ToString(),
                IDR = finalCombo.userCombo.horseCombo.clothesCombo.partResCombo.result.Id.ToString()
            })
            .ToListAsync();


            return new ObservableCollection<object>(resultList);
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (DG_RESULT.SelectedItem is null)
            {
                MessageBox.Show("Сначала необходимо выбрать строку!");
                return;
            }
            var selectedRow = DG_RESULT.SelectedItem;
            string cellValue;

            DataGridColumn column = DG_RESULT.Columns[5];
            DG_RESULT.CurrentColumn = column;
            if (column.GetCellContent(selectedRow) is TextBlock cellContent)
            {
                CheckIn? currentRace = await App.db.CheckIns.FirstOrDefaultAsync(h => h.Id == Convert.ToInt32(cellContent));
                ResultDialog window = new ResultDialog(ResultDialog.Mode.Create, currentRace);
                window.ShowDialog();
            }
            DG_RESULT.ItemsSource = await CurrentResults();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DG_RESULT.SelectedItem is null)
            {
                MessageBox.Show("Сначала необходимо выбрать строку!");
                return;
            }
            var selectedRow = DG_RESULT.SelectedItem;

            DataGridColumn column = DG_RESULT.Columns[6];
            DG_RESULT.CurrentColumn = column;
            if (column.GetCellContent(selectedRow) is TextBlock cellContent)
            {
                CheckInResult? currentResult = await App.db.CheckInResults.FirstOrDefaultAsync(h => h.Id == Convert.ToInt32(cellContent.Text));
                ResultDialog window = new ResultDialog(ResultDialog.Mode.Edit, null, currentResult);
                window.ShowDialog();
            }
            DG_RESULT.ItemsSource = await CurrentResults();

        }
    }
}
