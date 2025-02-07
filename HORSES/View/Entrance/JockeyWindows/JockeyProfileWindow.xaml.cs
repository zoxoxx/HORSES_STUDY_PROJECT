using HORSES.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для JockeyProfileWindow.xaml
    /// </summary>
    public partial class JockeyProfileWindow : Window
    {
        UserI MyUser { get; set; }
        public JockeyProfileWindow(UserI MyUser = null)
        {
            this.MyUser = MyUser;
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (this.MyUser != null)
            {
                DateOnly date = DateOnly.Parse(DP_BIRTHDAY.Text);
                MyUser.Birthday = date;
                string[] PHYO = MyUser.Phyo.Split(' ');
                MyUser.Phyo = TB_LASTNAME.Text + " " + TB_NAME.Text + " " + PHYO[2];
                UserI? dbUser = App.db.UserIs
                    .Where(user => user.Id == MyUser.Id)
                    .FirstOrDefault();
                if (dbUser != null)
                {
                    dbUser = MyUser;
                    App.db.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DP_BIRTHDAY.Text = MyUser.Birthday.ToString();
            string[] PHYO = MyUser.Phyo.Split(' ');
            if (PHYO.Length > 0)
                TB_NAME.Text = PHYO[1];

            TB_LASTNAME.Text = PHYO[0];
        }
    }
}
