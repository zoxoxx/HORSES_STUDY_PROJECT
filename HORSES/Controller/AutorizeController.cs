using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace HORSES.Controller
{
    class AutorizeController
    {
        public static async Task<UserI> Autorize(string login, string password)
        {
            var user = await App.db.UserIs
                    .Where(x => x.Login == login && x.Password == password)
                    .ToListAsync();
            return user.FirstOrDefault();
        }
    }
}
