namespace Tietoa.Domain.Models.Standings.JsonClasses
{
    public class TeamRecord
    {
        public Team team { get; set; }
        public LeagueRecord leagueRecord { get; set; }
        public int regulationWins { get; set; }
        public int goalsAgainst { get; set; }
        public int goalsScored { get; set; }
        public int points { get; set; }
        public string divisionRank { get; set; }
        public string divisionL10Rank { get; set; }
        public string divisionRoadRank { get; set; }
        public string divisionHomeRank { get; set; }
        public string conferenceRank { get; set; }
        public string conferenceL10Rank { get; set; }
        public string conferenceRoadRank { get; set; }
        public string conferenceHomeRank { get; set; }
        public string leagueRank { get; set; }
        public string leagueL10Rank { get; set; }
        public string leagueRoadRank { get; set; }
        public string leagueHomeRank { get; set; }
        public string wildCardRank { get; set; }
        public int row { get; set; }
        public int gamesPlayed { get; set; }
        public Streak streak { get; set; }
        public double pointsPercentage { get; set; }
        public string ppDivisionRank { get; set; }
        public string ppConferenceRank { get; set; }
        public string ppLeagueRank { get; set; }
        public DateTime lastUpdated { get; set; }
    }










}
