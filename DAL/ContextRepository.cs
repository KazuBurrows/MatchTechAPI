using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TournamentAPI.sakila;

namespace TournamentAPI.DAL
{
    public class ContextRepository
    {
    }

    public class ClubRepository : IClubRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public ClubRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteClub(int clubID)
        {
            Club club = context.Clubs.Find(clubID);
            context.Clubs.Remove(club);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Club GetClubByID(int clubId)
        {
            return context.Clubs.Find(clubId);
        }

        public IEnumerable<Club> GetClubs()
        {
            return context.Clubs.ToList();
        }

        public void InsertClub(Club club)
        {
            context.Clubs.Add(club);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateClub(Club club)
        {
            context.Entry(club).State = EntityState.Modified;
        }
    }


    public class ClubsFieldRepository : IClubsFieldRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public ClubsFieldRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteClubsField(int clubsFieldID)
        {
            ClubsField clubsField = context.ClubsFields.Find(clubsFieldID);
            context.ClubsFields.Remove(clubsField);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ClubsField GetClubsFieldByID(int clubsFieldId)
        {
            return context.ClubsFields.Find(clubsFieldId);
        }

        public IEnumerable<ClubsField> GetClubsFields()
        {
            return context.ClubsFields.ToList();
        }

        public void InsertClubsField(ClubsField clubsField)
        {
            context.ClubsFields.Add(clubsField);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateClubsField(ClubsField clubsField)
        {
            context.Entry(clubsField).State = EntityState.Modified;
        }
    }


    public class FieldRepository : IFieldRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public FieldRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteField(int fieldID)
        {
            Field field = context.Fields.Find(fieldID);
            context.Fields.Remove(field);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public Field GetFieldByID(int fieldId)
        {
            return context.Fields.Find(fieldId);
        }

        public IEnumerable<Field> GetFields()
        {
            return context.Fields.ToList();
        }

        public void InsertField(Field field)
        {
            context.Fields.Add(field);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateField(Field field)
        {
            context.Entry(field).State = EntityState.Modified;
        }
    }




    public class MatchdayfixtureRepository : IMatchdayfixtureRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public MatchdayfixtureRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteMatchdayfixture(int matchdayfixtureID)
        {
            Matchdayfixture matchdayfixture = context.Matchdayfixtures.Find(matchdayfixtureID);
            context.Matchdayfixtures.Remove(matchdayfixture);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public Matchdayfixture GetMatchdayfixtureByID(int matchdayfixtureId)
        {
            return context.Matchdayfixtures.Find(matchdayfixtureId);
        }

        public IEnumerable<Matchdayfixture> GetMatchdayfixtures()
        {
            return context.Matchdayfixtures.ToList();
        }

        public void InsertMatchdayfixture(Matchdayfixture matchdayfixture)
        {
            context.Matchdayfixtures.Add(matchdayfixture);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMatchdayfixture(Matchdayfixture matchdayfixture)
        {
            context.Entry(matchdayfixture).State = EntityState.Modified;
        }

        
    }



    public class MatchweekfixtureRepository : IMatchweekfixtureRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public MatchweekfixtureRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteMatchweekfixture(int matchweekfixtureID)
        {
            Matchweekfixture matchweekfixture = context.Matchweekfixtures.Find(matchweekfixtureID);
            context.Matchweekfixtures.Remove(matchweekfixture);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Matchweekfixture GetMatchweekfixtureByID(int matchweekfixtureId)
        {
            return context.Matchweekfixtures.Find(matchweekfixtureId);
        }

        public IEnumerable<Matchweekfixture> GetMatchweekfixtures()
        {
            return context.Matchweekfixtures.ToList();
        }

        public void InsertMatchweekfixture(Matchweekfixture matchweekfixture)
        {
            context.Matchweekfixtures.Add(matchweekfixture);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMatchweekfixture(Matchweekfixture matchweekfixture)
        {
            context.Entry(matchweekfixture).State = EntityState.Modified;
        }
    }



    public class MatchweekMatchdayRepository : IMatchweekMatchdayRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public MatchweekMatchdayRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteMatchweekMatchday(int matchweekMatchdayID)
        {
            MatchweekMatchday matchweekMatchday = context.MatchweekMatchdays.Find(matchweekMatchdayID);
            context.MatchweekMatchdays.Remove(matchweekMatchday);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public MatchweekMatchday GetMatchweekMatchdayByID(int matchweekMatchdayId)
        {
            return context.MatchweekMatchdays.Find(matchweekMatchdayId);
        }

        public IEnumerable<MatchweekMatchday> GetMatchweekMatchdays()
        {
            return context.MatchweekMatchdays.ToList();
        }

        public void InsertMatchweekMatchday(MatchweekMatchday matchweekMatchday)
        {
            context.MatchweekMatchdays.Add(matchweekMatchday);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMatchweekMatchday(MatchweekMatchday matchweekMatchday)
        {
            context.Entry(matchweekMatchday).State = EntityState.Modified;
        }
    }




    public class TeamRepository : ITeamRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public TeamRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteTeam(int teamID)
        {
            Team team = context.Teams.Find(teamID);
            context.Teams.Remove(team);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Team GetTeamByID(int teamId)
        {
            return context.Teams.Find(teamId);
        }

        public IEnumerable<Team> GetTeams()
        {
            return context.Teams.ToList();
        }

        public void InsertTeam(Team team)
        {
            context.Teams.Add(team);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateTeam(Team team)
        {
            context.Entry(team).State = EntityState.Modified;
        }

        public Team GetByeTeam()
        {
            return context.Teams.Where(t => t.Name == "BYE").FirstOrDefault();
        }
    }


    public class TournamentRepository : ITournamentRepository, IDisposable
    {
        private DbAa1c85MtechContext context;

        public TournamentRepository(DbAa1c85MtechContext context)
        {
            this.context = context;
        }

        public void DeleteTournament(int tournamentID)
        {
            Tournament tournament = context.Tournaments.Find(tournamentID);
            context.Tournaments.Remove(tournament);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Tournament GetTournamentByID(int tournamentId)
        {
            return context.Tournaments.Find(tournamentId);
        }

        public IEnumerable<Tournament> GetTournaments()
        {
            return context.Tournaments.ToList();
        }

        public void InsertTournament(Tournament tournament)
        {
            context.Tournaments.Add(tournament);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateTournament(Tournament tournament)
        {
            context.Entry(tournament).State = EntityState.Modified;
        }
    }


}
