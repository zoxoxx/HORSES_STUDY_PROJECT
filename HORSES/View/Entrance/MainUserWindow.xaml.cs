﻿using HORSES.Models;
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
    /// Логика взаимодействия для MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
       public static UserI CurrentUser = null; 
        public MainUserWindow(UserI currentUser)
        {
            InitializeComponent();
            MainUserWindow.CurrentUser = currentUser;
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.RoleId == 1)
                MainFrame.Navigate(new MainPages.MainJudgePage());

            if (CurrentUser.RoleId == 2)
                MainFrame.Navigate(new MainPages.MainJockeyPage());
        }
    }
}
