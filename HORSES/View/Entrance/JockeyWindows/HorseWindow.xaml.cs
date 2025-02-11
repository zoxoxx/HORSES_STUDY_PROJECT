using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    /// Логика взаимодействия для HorseWindow.xaml
    /// </summary>
    public partial class HorseWindow : Window
    {
        public HorseWindow()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            HorseDialogWindow createWindow = new HorseDialogWindow(HorseDialogWindow.Mode.Create);
            createWindow.ShowDialog();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = DG_HORSES.SelectedItem;
            if (selectedRow is null)
            {
                MessageBox.Show("Необходимо выбрать строку!");
                return;
            }
            
            string cellValue;

            DataGridColumn column = DG_HORSES.Columns[7];
            DG_HORSES.CurrentColumn = column;
            
            if (column.GetCellContent(selectedRow) is TextBlock cellContent)
            {
                cellValue = cellContent.Text;
                var selectedItem = (object)selectedRow;
                Horse currentHorse = App.db.Horses.FirstOrDefault(horse => horse.Id == Convert.ToInt32(cellValue.ToString()));
                HorseDialogWindow editWindow = new HorseDialogWindow(HorseDialogWindow.Mode.Edit, currentHorse);
                editWindow.ShowDialog();
            }
            await DataGridLoad();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            await DataGridLoad();
        }

        private async Task DataGridLoad()
        {
            DG_HORSES.ItemsSource = new ObservableCollection<object>(await App.db.Horses
                .Join(App.db.Genders,
                horse => horse.GenderId,
                gender => gender.Id,
                (horse, gender) => new { horse, gender })
                .Join(App.db.TypHorses,
                firstCombo => firstCombo.horse.TypId,
                typHorse => typHorse.Id,
                (firstCombo, typHorse) => new { firstCombo, typHorse })
                .Join(App.db.PlaceBirths,
                secondCombo => secondCombo.firstCombo.horse.PlaceBirthId,
                place => place.Id,
                (secondCombo, place) => new { secondCombo, place })
                .Select(finalEntry => new
                {
                    Gender = finalEntry.secondCombo.firstCombo.gender.Name,
                    TypHorse = finalEntry.secondCombo.typHorse.Name,
                    TrainerName = finalEntry.secondCombo.firstCombo.horse.PhyoTrener,
                    OwnerID = finalEntry.secondCombo.firstCombo.horse.OwnerId,
                    Birthday = finalEntry.secondCombo.firstCombo.horse.Birthday,
                    Name = finalEntry.secondCombo.firstCombo.horse.Name,
                    Place = finalEntry.place.Name,
                    ID = finalEntry.secondCombo.firstCombo.horse.Id.ToString()
                })
                .ToListAsync());
        }
    }
}
