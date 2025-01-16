using HORSES.View;
using HORSES.View.Entrance;
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

        private void AppExit() => Process.GetCurrentProcess().Kill();

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            AppExit();
        }

        private void BTN_START_Click(object sender, RoutedEventArgs e)
        {
            Autorize autorize = new Autorize();
            this.Hide();
            autorize.Show();
        }

        private void BTN_INFORMATION_Click(object sender, RoutedEventArgs e)
        {
            StartInfoWindow window = new StartInfoWindow();
            window.ShowDialog();
        }
    }
}