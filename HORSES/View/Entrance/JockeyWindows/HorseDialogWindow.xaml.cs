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

namespace HORSES.View.Entrance.JockeyWindows
{
    /// <summary>
    /// Логика взаимодействия для HorseDialogWindow.xaml
    /// </summary>
    public partial class HorseDialogWindow : Window
    {
        Horse? currentHorse;
        ObservableCollection<Gender>? genders; 
        string mode;
        public enum Mode
        {
            Create,
            Edit
        }
        public HorseDialogWindow(Mode mode, Horse currentHorse = null)
        {
            this.currentHorse = currentHorse;
            this.mode = mode.ToString();
            InitializeComponent();
            SetTitle(mode);
        }

        private async void SetTitle(Mode mode)
        {
            if (mode == Mode.Create)
                TitleTextBlock.Text = "Создание";
            
            TitleTextBlock.Text = "Редактирование";
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (TrainerComboBox.SelectedItem is null || GenderComboBox.SelectedValue is null || HorseTypeComboBox.SelectedValue is null)
            {
                MessageBox.Show("Не все данные заполнены!");
                return;
            }

            if (mode == "Create")
            {
                DateOnly parsedDate = DateOnly.Parse("2023-10-25");
                Horse newHorse = new Horse(Convert.ToInt32(GenderComboBox.SelectedValue.ToString()), Convert.ToInt32(HorseTypeComboBox.SelectedValue.ToString()),
                    TrainerComboBox.SelectedItem.ToString(), Convert.ToInt32(TrainerComboBox.SelectedValue.ToString()),
                    DateOnly.FromDateTime(BIRTHDAY_DP.SelectedDate.GetValueOrDefault()), HorseNameTextBox.Text,
                    Convert.ToInt32(PLACE_BIRTH_CMB.SelectedValue.ToString()));

                await App.db.Horses.AddAsync(newHorse);
                await App.db.SaveChangesAsync();
                MessageBox.Show("Новая лошадь успешно добавлена!!!");
                this.Close();
                return;
            }

            if (currentHorse is null)
                return;

            currentHorse.Name = HorseNameTextBox.Text;
            currentHorse.PlaceBirthId = Convert.ToInt32(PLACE_BIRTH_CMB.SelectedValue.ToString());
            currentHorse.Birthday = DateOnly.FromDateTime(BIRTHDAY_DP.SelectedDate.GetValueOrDefault());
            currentHorse.PhyoTrener = TrainerComboBox.SelectedItem.ToString();
            currentHorse.OwnerId = Convert.ToInt32(TrainerComboBox.SelectedValue.ToString());
            currentHorse.GenderId = Convert.ToInt32(GenderComboBox.SelectedValue.ToString());
            currentHorse.TypId = Convert.ToInt32(HorseTypeComboBox.SelectedValue.ToString());

            App.db.Horses.Update(currentHorse);
            await App.db.SaveChangesAsync();
            MessageBox.Show("Данные успешно обновлены!");
            this.Close();
        }

        private async void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GenderComboBox.ItemsSource = new ObservableCollection<Gender>(await App.db.Genders.ToListAsync());
            HorseTypeComboBox.ItemsSource = new ObservableCollection<TypHorse>(await App.db.TypHorses.ToListAsync());
            TrainerComboBox.ItemsSource = new ObservableCollection<Owner>(await App.db.Owners.ToListAsync());
            PLACE_BIRTH_CMB.ItemsSource = new ObservableCollection<PlaceBirth>(await App.db.PlaceBirths.ToListAsync());

            if (mode == "Create")
                return;

            var genderItems = GenderComboBox.ItemsSource as IEnumerable<Gender>;
            var selectedGender = genderItems.FirstOrDefault(item => item.Id == currentHorse.TypId);
            GenderComboBox.SelectedItem = selectedGender;

            var typeItems = HorseTypeComboBox.ItemsSource as IEnumerable<TypHorse>;
            var selectedTyp = typeItems.FirstOrDefault(items => items.Id == currentHorse.TypId);
            HorseTypeComboBox.SelectedItem = selectedTyp;

            var trainerItems = TrainerComboBox.ItemsSource as IEnumerable<Owner>;
            var selectedTrainer = trainerItems.FirstOrDefault(items => items.Id == currentHorse.OwnerId);
            TrainerComboBox.SelectedItem = selectedTrainer;
            TrainerIdTextBox.Text = selectedTrainer.Id.ToString();

            var placeItems = PLACE_BIRTH_CMB.ItemsSource as IEnumerable<PlaceBirth>;
            var selectedPlace = placeItems.FirstOrDefault(items => items.Id == currentHorse.PlaceBirthId);
            PLACE_BIRTH_CMB.SelectedItem = selectedPlace;
            HorseNameTextBox.Text = currentHorse.Name;

        }

        private void TrainerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TrainerComboBox.SelectedValue is null)
                return;

            TrainerIdTextBox.Text = TrainerComboBox.SelectedValue.ToString();
        }
    }
}
