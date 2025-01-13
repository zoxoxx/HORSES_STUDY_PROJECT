using HORSES.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HORSES
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HorseCompetitionsContext db = new HorseCompetitionsContext();
    }

}
