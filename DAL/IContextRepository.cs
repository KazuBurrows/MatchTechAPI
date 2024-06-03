
using TournamentAPI.sakila;

namespace TournamentAPI.DAL
{
    public class IContextRepository
    {

    }

    public interface IClubRepository : IDisposable
    {
        IEnumerable<Club> GetClubs();
        Club GetClubByID(int clubId);
        void InsertClub(Club club);
        void DeleteClub(int clubID);
        void UpdateClub(Club club);
        void Save();
    }


    public interface IClubsFieldRepository : IDisposable
    {
        IEnumerable<ClubsField> GetClubsFields();
        ClubsField GetClubsFieldByID(int clubsFieldId);
        void InsertClubsField(ClubsField clubsField);
        void DeleteClubsField(int clubsFieldID);
        void UpdateClubsField(ClubsField clubsField);
        void Save();
    }


    public interface IFieldRepository : IDisposable
    {
        IEnumerable<Field> GetFields();
        Field GetFieldByID(int fieldId);
        void InsertField(Field field);
        void DeleteField(int fieldID);
        void UpdateField(Field field);
        void Save();
    }


    public interface IMatchdayfixtureRepository : IDisposable
    {
        IEnumerable<Matchdayfixture> GetMatchdayfixtures();
        Matchdayfixture GetMatchdayfixtureByID(int matchdayfixtureId);
        void InsertMatchdayfixture(Matchdayfixture matchdayfixture);
        void DeleteMatchdayfixture(int matchdayfixtureID);
        void UpdateMatchdayfixture(Matchdayfixture matchdayfixture);
        void Save();
    }


    public interface IMatchweekfixtureRepository : IDisposable
    {
        IEnumerable<Matchweekfixture> GetMatchweekfixtures();
        Matchweekfixture GetMatchweekfixtureByID(int matchweekfixtureId);
        void InsertMatchweekfixture(Matchweekfixture matchweekfixture);
        void DeleteMatchweekfixture(int matchweekfixtureID);
        void UpdateMatchweekfixture(Matchweekfixture matchweekfixture);
        void Save();
    }


    public interface IMatchweekMatchdayRepository : IDisposable
    {
        IEnumerable<MatchweekMatchday> GetMatchweekMatchdays();
        MatchweekMatchday GetMatchweekMatchdayByID(int matchweekMatchdayId);
        void InsertMatchweekMatchday(MatchweekMatchday matchweekMatchday);
        void DeleteMatchweekMatchday(int matchweekMatchdayID);
        void UpdateMatchweekMatchday(MatchweekMatchday matchweekMatchday);
        void Save();
    }


    public interface ITeamRepository : IDisposable
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamByID(int teamId);
        void InsertTeam(Team team);
        void DeleteTeam(int teamID);
        void UpdateTeam(Team team);
        Team GetByeTeam();

        void Save();
    }


    public interface ITournamentRepository : IDisposable
    {
        IEnumerable<Tournament> GetTournaments();
        Tournament GetTournamentByID(int tournamentId);
        void InsertTournament(Tournament tournament);
        void DeleteTournament(int tournamentID);
        void UpdateTournament(Tournament tournament);
        void Save();
    }


}
