using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для DonationWindow.xaml
    /// </summary>
    public partial class DonationWindow : Window
    {

        public DonationWindow()
        {
            InitializeComponent();
        }

        private void DonationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Horse> horses = App.db.Horses.ToList();

            HorseComboBox.ItemsSource = horses;
            HorseComboBox.DisplayMemberPath = "Name";
            HorseComboBox.SelectedValuePath = "Id";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                MessageBox.Show("Данные успешно отправлены!");
                ClearData();
            }
        }

        private bool ValidateInputs()
        {
            if (HorseComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите лошадь.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(DonationAmountTextBox.Text, out decimal donationAmount) || donationAmount <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму пожертвования.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string cardNumber = CardNumberTextBox.Text;
            if (!IsValidCardNumber(cardNumber))
            {
                MessageBox.Show("Некорректный номер банковской карты. Должно быть 16 цифр.", "Ошибка карты", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (MonthComboBox.SelectedItem == null || YearComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите срок действия карты.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите фамилию и имя отправителя.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string cvvText = CVVTextBox.Text;
            if (!Regex.IsMatch(cvvText, @"^\d{3}$"))
            {
                MessageBox.Show("Некорректный CVV2 код. Должно быть 3 цифры.", "Ошибка CVV", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            MessageBox.Show("Все данные корректны!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            App.db.Donations.Add(new Donation(Convert.ToInt32(DonationAmountTextBox.Text), Convert.ToInt32(HorseComboBox.SelectedValue)));
            App.db.SaveChanges();

            return true;
        }


        private bool IsValidCardNumber(string cardNumber)
        {
            return Regex.IsMatch(cardNumber, @"^\d{16}$");
        }

        private void ClearData()
        {
            HorseComboBox.SelectedItem = null;
            DonationAmountTextBox.Clear();
            CardNumberTextBox.Clear();
            MonthComboBox.SelectedItem = null;
            YearComboBox.SelectedItem = null;
            FullNameTextBox.Clear();
            CVVTextBox.Clear();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainFanWindow window = new MainFanWindow();
            window.Show();
            this.Close();
        }
    }
}

