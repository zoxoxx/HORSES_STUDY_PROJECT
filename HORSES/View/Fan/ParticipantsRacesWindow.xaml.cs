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

namespace HORSES.View.Fan
{
    /// <summary>
    /// Логика взаимодействия для ParticipantsRaceWindow.xaml
    /// </summary>
    public partial class ParticipantsRaceWindow : Window
    {
        CheckIn currentRace;
        public ParticipantsRaceWindow(CheckIn currentRace)
        {
            this.currentRace = currentRace;
            InitializeComponent();
        }
    }
}
