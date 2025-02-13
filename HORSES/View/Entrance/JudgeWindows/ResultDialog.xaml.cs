using HORSES.Models;
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
using System.Windows.Shapes;

namespace HORSES.View.Entrance.JudgeWindows
{
    /// <summary>
    /// Логика взаимодействия для ResultDialog.xaml
    /// </summary>
    public partial class ResultDialog : Window
    {
        CheckIn? currentRace;
        public enum Mode
        {
            Create,
            Edit
        }
        public ResultDialog(Mode mode, CheckIn? currentRace = null)
        {
            this.currentRace = currentRace;
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
    }
}
