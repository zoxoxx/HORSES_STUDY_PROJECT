﻿using HORSES.View.Entrance.JudgeWindows;
using HORSES.View.Fan;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HORSES.View.Entrance.MainPages
{
    /// <summary>
    /// Логика взаимодействия для MainJudgePage.xaml
    /// </summary>
    public partial class MainJudgePage : Page
    {
        public MainJudgePage()
        {
            InitializeComponent();
        }

        private void Track_Assignment_Click(object sender, RoutedEventArgs e)
        {
            TrackAssignmentWindow window = new TrackAssignmentWindow();
            window.Show();
        }

        private void Check_in_Click(object sender, RoutedEventArgs e)
        {
            ResultDialog window = new ResultDialog(ResultDialog.Mode.Create);
            window.Show();
        }

        private void Violations_Click(object sender, RoutedEventArgs e)
        {
            ViolationsWindow window = new ViolationsWindow();
            window.Show();
        }

        private void BTN_BACK_MAIN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Window currentWindow = Window.GetWindow(this);
            if (currentWindow != null)
                currentWindow.Close();

            window.Show();
        }

        private void Information_Participants_Click(object sender, RoutedEventArgs e)
        {
            CompetitionAndRacesWindow window = new CompetitionAndRacesWindow(true);
            window.Show();
        }

        private void REPORT_BTN_Click(object sender, RoutedEventArgs e)
        {
            ArrivalReportWindow window = new ArrivalReportWindow();
            window.Show();
        }
    }
}
