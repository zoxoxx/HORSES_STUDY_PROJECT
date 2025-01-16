﻿using HORSES.Controller;
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

namespace HORSES.View.Entrance
{
    /// <summary>
    /// Логика взаимодействия для Autorize.xaml
    /// </summary>
    public partial class Autorize : Window
    {
        public Autorize()
        {
            InitializeComponent();
        }

        private async void BTN_VHOD_Click(object sender, RoutedEventArgs e)
        {
            if (TB_LOGIN.Text == String.Empty || TB_PASSWORD.Text == String.Empty)
            {
                MessageBox.Show("Заполните данные для авторизации!");
            }
            UserI? user = await AutorizeController.Autorize(TB_LOGIN.Text, TB_PASSWORD.Text);
            if (user == null)
            {
                MessageBox.Show("Пользователь отсутствует в системе.");
            }
            //Судья
            if (user.RoleId == 1)

            //Жокей
            if (user.RoleId == 2)
        }
    }
}
