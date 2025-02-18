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

namespace HORSES.View.Entrance.JudgeWindows
{
    /// <summary>
    /// Логика взаимодействия для ResultDialog.xaml
    /// </summary>
    public partial class ResultDialog : Window
    {
        CheckIn? currentRace;
        CheckInResult? currentResult;
        string mode;
        public enum Mode
        {
            Create,
            Edit
        }
        public ResultDialog(Mode mode, CheckIn? currentRace = null, CheckInResult? currentResult = null)
        {
            this.mode = mode.ToString();
            this.currentRace = currentRace;
            this.currentResult = currentResult;
            InitializeComponent();
            SetTitle(mode);
        }

        private void SetTitle(Mode mode)
        {
            if (mode == Mode.Create)
            {
                TitleTextBlock.Text = "Создание";
            }
            else
            {
                TitleTextBlock.Text = "Редактирование";
            }
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (FinishTimePicker.SelectedDate is null)
            {
                MessageBox.Show("Необходимо заполнить данные финиша!!!");
                return;
            }
            if (mode == "Create")
            {
                return;
            }

            TimeOnly? date = TimeOnly.FromDateTime((DateTime)FinishTimePicker.SelectedDate);

            App.db.CheckInResults.Where(c => c.Id == currentResult.Id).ExecuteUpdateAsync(u => u.SetProperty(upd => upd.TimeEnd, upd => date));
            MessageBox.Show("Данные сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            ClearFields();

            this.Close();
        }

        private void ClearFields()
        {
            JockeyComboBox.SelectedIndex = -1;
            HorseTypeComboBox.SelectedIndex = -1;
            EquipmentColorComboBox.SelectedIndex = -1;
            FinishTimePicker.SelectedDate = null;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (mode == "Create")
            {
                return;
            }

            JockeyComboBox.SelectedValuePath = "Id";
            JockeyComboBox.DisplayMemberPath = "Phyo";
            try
            {
                JockeyComboBox.ItemsSource = new ObservableCollection<UserI>(await App.db.UserIs.Where(u => u.Id == currentResult.Participant.User.Id).ToListAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            HorseTypeComboBox.SelectedValuePath = "Id";
            HorseTypeComboBox.DisplayMemberPath = "Name";
            HorseTypeComboBox.ItemsSource = await App.db.TypHorses.Where(t => t.Id == currentResult.Participant.Horse.TypId).ToListAsync();

            EquipmentColorComboBox.SelectedValuePath= "Id";
            EquipmentColorComboBox.DisplayMemberPath = "HelmetColor";
            EquipmentColorComboBox.ItemsSource = await App.db.ClothesSets.Where(c => c.Id == currentResult.Participant.ClothesSetId).ToListAsync();

        }
    }
}
