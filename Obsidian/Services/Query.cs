using Obsidian.Models;
using Obsidian.Models.TournamentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obsidian.Services
{
    public static class Query
    {
        public static Tournament GetTournamentByName(string Name)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Tournaments.Select(x => x).Where(z => z.Name == Name).SingleOrDefault();
        }

        public static void SetTournamentByTournament(string Name, Tournament NewTournament)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Tournament OldTournament = db.Tournaments.Select(x => x).Where(z => z.Id == NewTournament.Id).SingleOrDefault();
            OldTournament = NewTournament;
            db.SaveChanges();
        }
        public static List<Match> GetMatchesByTournamentName(string Name)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Matches.Select(x => x).Where(z => z.Tournament.Name == Name).ToList();
        }
        public static void SetMatchByMatch(string Name, Match NewMatch)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Match OldMatch = db.Matches.Select(x => x).Where(z => z.Id == NewMatch.Id).SingleOrDefault();
            OldMatch = NewMatch;
            db.SaveChanges();
        }
        public static List<Tournament> SearchTournaments(string QueryString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Tournaments.Select(x => x).Where(z => z.Name.Contains("%QueryString%")).ToList();
        }
    }
}