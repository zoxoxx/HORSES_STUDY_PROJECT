using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    /// Логика взаимодействия для ViolationsWindow.xaml
    /// </summary>
    public partial class ViolationsWindow : Window
    {
        bool disqual = false;
        public ViolationsWindow()
        {
            InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!disqual)
            {
                MessageBox.Show("Ни один жокей не был дисквалифицирован!");
                return;
            }

            if (JockeySelectionComboBox.SelectedValue is null)
            {
                MessageBox.Show("Сначала необходимо выбрать жокея!");
                return;
            }

            Participant? currentParticipant = await App.db.Participants
                .Where(p => p.UserId == Convert.ToInt32(JockeySelectionComboBox.SelectedValue.ToString()))
                .FirstOrDefaultAsync();

            if (currentParticipant is null)
            {
                MessageBox.Show("Пользователь отсутствует в системе!");
                return;
            }

            string violationText = TrainerIdTextBox.Text.Trim();
            if (string.IsNullOrEmpty(violationText))
            {
                MessageBox.Show("Введите описание нарушения!");
                return;
            }

            Violation newViolation = new Violation
            {
                ParticipantId = currentParticipant.Id,
                Violations = violationText
            };

            await App.db.Violations.AddAsync(newViolation);
            currentParticipant.Disqualification = true;
            await App.db.SaveChangesAsync();

            MessageBox.Show("Успешно сохранено!");
            this.Close();
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Disqualification_Click(object sender, RoutedEventArgs e)
        {
            if (JockeySelectionComboBox.SelectedValue is null)
            {
                MessageBox.Show("Сначала необходимо выбрать жокея!");
                return;
            }
            disqual = true;
            Participant? currentParticipant = await App.db.Participants
                .Where(p => p.UserId == Convert.ToInt32(JockeySelectionComboBox.SelectedValue.ToString()))
                .FirstOrDefaultAsync();
            if (currentParticipant is null)
            {
                MessageBox.Show("Пользователь отсутствует в системе!");
                return;
            }
            currentParticipant.Disqualification = true;
            DiSQUAL_BTN.IsEnabled = false;
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            JockeySelectionComboBox.ItemsSource = new ObservableCollection<Object>(await App.db.UserIs
                .Join(App.db.Participants,
                user => user.Id,
                participant => participant.UserId,
                (user, participant) => new { user, participant })
                .Where(finalEntry => finalEntry.participant.Disqualification == false)
                .Select(finalEntry => new
                {
                    Id = finalEntry.user.Id,
                    Phyo = finalEntry.user.Phyo
                }).ToListAsync());
        }
    }
}
