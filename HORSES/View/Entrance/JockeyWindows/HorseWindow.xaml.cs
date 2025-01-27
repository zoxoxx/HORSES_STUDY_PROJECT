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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            HorseDialogWindow createWindow = new HorseDialogWindow(HorseDialogWindow.Mode.Create);
            createWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            HorseDialogWindow editWindow = new HorseDialogWindow(HorseDialogWindow.Mode.Edit);
            editWindow.ShowDialog();
        }
    }
}
