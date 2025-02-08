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
    /// Логика взаимодействия для HorseDialogWindow.xaml
    /// </summary>
    public partial class HorseDialogWindow : Window
    {
        public enum Mode
        {
            Create,
            Edit
        }
        public HorseDialogWindow(Mode mode)
        {
            InitializeComponent();
            SetTitle(mode);
        }

        private async void SetTitle(Mode mode)
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


        private async void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
