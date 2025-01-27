using HORSES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSES.Controller
{
    class CompetitionsAndRacesController
    {
        public static async Task<ObservableCollection<CheckIn>> CurrentRaceForCompetition(Competition currentCompetition)
        {
            var checkIns = await App.db.Competitions
                .Join(App.db.CompetitionAndCheckIns,
                    competition => competition.Id,
                    link => link.CompetitionId,
                    (competition, link) => new { competition, link })
                .Join(App.db.CheckIns,
                    combinedEntry => combinedEntry.link.CheckInId,
                    checkIn => checkIn.Id,
                    (combinedEntry, checkIn) => new { combinedEntry, checkIn })
                .Where(finalEntry => finalEntry.combinedEntry.competition.Id == currentCompetition.Id && finalEntry.combinedEntry.competition.DateStart >= DateOnly.FromDateTime(DateTime.Now))
                .OrderBy(finalEntry => finalEntry.checkIn.SequenceNumber)
                .Select(finalEntry => finalEntry.checkIn).ToListAsync();
            return new ObservableCollection<CheckIn>(checkIns);
        }
    }
}
