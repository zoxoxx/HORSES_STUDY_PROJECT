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

namespace HORSES.View.Entrance.JudgeWindows
{
    /// <summary>
    /// Логика взаимодействия для ResultDialog.xaml
    /// </summary>
    public partial class ResultDialog : Window
    {
        public enum Mode
        {
            Create,
            Edit
        }
        public ResultDialog(Mode mode)
        {
            InitializeComponent();
            SetTitle(mode);
        }

        private void SetTitle(Mode mode)
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


        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
