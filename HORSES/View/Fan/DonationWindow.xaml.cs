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
        private readonly HorseCompetitionsContext _context;

        public DonationWindow()
        {
            InitializeComponent();
            _context = new HorseCompetitionsContext();
        }

        private void DonationWindow_Loaded(object sender, RoutedEventArgs e)
        {
           /* List<Horse> horses = _context.Horses.ToList();

            HorseComboBox.ItemsSource = horses;
            HorseComboBox.DisplayMemberPath = "Name";
            HorseComboBox.SelectedValuePath = "Id";*/
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                ShowCardTypeLogo(CardNumberTextBox.Text);
                MessageBox.Show("Данные успешно отправлены!");
                ClearData();
            }
        }

        private void ShowCardTypeLogo(string cardNumber)
        {
            string logoPath = GetCardLogoPath(cardNumber);
            if (logoPath != null)
            {
                CardTypeLogo.Source = new BitmapImage(new Uri(logoPath, UriKind.Relative));
                CardTypeLogo.Visibility = Visibility.Visible;
            }
            else
            {
                CardTypeLogo.Visibility = Visibility.Collapsed;
            }
        }

        private void CardNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowCardTypeLogo(CardNumberTextBox.Text);
        }

        private string GetCardLogoPath(string cardNumber)
        {
            if (IsVisa(cardNumber))
                return "Resources/Cards/visa.png";
            else if (IsMasterCard(cardNumber))
                return "Resources/Cards/mastercard.png";
            else if (IsMir(cardNumber)) 
                return "Resources/Cards/mir.png";
            else
                return null;
        }

        private bool IsMir(string cardNumber)
        {
            return cardNumber.StartsWith("2200") && cardNumber.Length == 16;
        }


        private bool IsVisa(string cardNumber)
        {
            return cardNumber.StartsWith("4") && cardNumber.Length == 16;
        }

        private bool IsMasterCard(string cardNumber)
        {
            return (cardNumber.StartsWith("51") || cardNumber.StartsWith("52") || cardNumber.StartsWith("53") ||
                    cardNumber.StartsWith("54") || cardNumber.StartsWith("55")) && cardNumber.Length == 16;
        }

        private bool ValidateInputs()
        {
            if (HorseComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите лошадь.");
                return false;
            }

            if (!decimal.TryParse(DonationAmountTextBox.Text, out decimal donationAmount) || donationAmount <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму пожертвования.");
                return false;
            }

            string cardNumber = CardNumberTextBox.Text;
            if (!IsValidCardNumber(cardNumber))
            {
                MessageBox.Show("Некорректный номер банковской карты. Должно быть 16 цифр.");
                return false;
            }

            if (MonthComboBox.SelectedItem == null || YearComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите срок действия карты.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите фамилию и имя отправителя.");
                return false;
            }
            string cvvText = CVVTextBox.Text;
            if (!Regex.IsMatch(cvvText, @"^\d{3}$"))
            {
                MessageBox.Show("Некорректный CVV2 код. Должно быть 3 цифры.");
                return false;
            }

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

