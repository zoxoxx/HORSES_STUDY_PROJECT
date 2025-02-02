using HORSES.View;
using HORSES.View.Entrance;
using HORSES.View.Entrance.JockeyWindows;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HORSES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AppExit() => Process.GetCurrentProcess().Kill();

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            AppExit();
        }

        private async void BTN_START_Click(object sender, RoutedEventArgs e)
        {
            Autorize autorize = new Autorize();
            this.Hide();
            autorize.Show();
        }

        private async void BTN_INFORMATION_Click(object sender, RoutedEventArgs e)
        {
            StartInfoWindow window = new StartInfoWindow();
            window.ShowDialog();
        }
    }
}