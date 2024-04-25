namespace Tietoa.Domain.Models.Player;
public class BirthCity
{
    public string @default { get; set; }
}

public class BirthStateProvince
{
    public string @default { get; set; }
}

public class Career
{
    public int assists { get; set; }
    public int gameWinningGoals { get; set; }
    public int gamesPlayed { get; set; }
    public int goals { get; set; }
    public int otGoals { get; set; }
    public int pim { get; set; }
    public int plusMinus { get; set; }
    public int points { get; set; }
    public int powerPlayGoals { get; set; }
    public int powerPlayPoints { get; set; }
    public double shootingPctg { get; set; }
    public int shorthandedGoals { get; set; }
    public int shorthandedPoints { get; set; }
    public int shots { get; set; }
}

public class CareerTotals
{
    public RegularSeason regularSeason { get; set; }
}

public class CurrentTeamRoster
{
    public int playerId { get; set; }
    public LastName lastName { get; set; }
    public FirstName firstName { get; set; }
    public string playerSlug { get; set; }
}

public class DraftDetails
{
    public int year { get; set; }
    public string teamAbbrev { get; set; }
    public int round { get; set; }
    public int pickInRound { get; set; }
    public int overallPick { get; set; }
}

public class FeaturedStats
{
    public int season { get; set; }
    public RegularSeason regularSeason { get; set; }
}

public class FirstName
{
    public string @default { get; set; }
    public string es { get; set; }
}

public class FullTeamName
{
    public string @default { get; set; }
    public string fr { get; set; }
}

public class Last5Game
{
    public int assists { get; set; }
    public string gameDate { get; set; }
    public int gameId { get; set; }
    public int gameTypeId { get; set; }
    public int goals { get; set; }
    public string homeRoadFlag { get; set; }
    public string opponentAbbrev { get; set; }
    public int pim { get; set; }
    public int plusMinus { get; set; }
    public int points { get; set; }
    public int powerPlayGoals { get; set; }
    public int shifts { get; set; }
    public int shorthandedGoals { get; set; }
    public int shots { get; set; }
    public string teamAbbrev { get; set; }
    public string toi { get; set; }
}

public class LastName
{
    public string @default { get; set; }
}

public class RegularSeason
{
    public SubSeason subSeason { get; set; }
    public Career career { get; set; }
    public int assists { get; set; }
    public string avgToi { get; set; }
    public double faceoffWinningPctg { get; set; }
    public int gameWinningGoals { get; set; }
    public int gamesPlayed { get; set; }
    public int goals { get; set; }
    public int otGoals { get; set; }
    public int pim { get; set; }
    public int plusMinus { get; set; }
    public int points { get; set; }
    public int powerPlayGoals { get; set; }
    public int powerPlayPoints { get; set; }
    public double shootingPctg { get; set; }
    public int shorthandedGoals { get; set; }
    public int shorthandedPoints { get; set; }
    public int shots { get; set; }
}

public class Root
{
    public int playerId { get; set; }
    public bool isActive { get; set; }
    public int currentTeamId { get; set; }
    public string currentTeamAbbrev { get; set; }
    public FullTeamName fullTeamName { get; set; }
    public FirstName firstName { get; set; }
    public LastName lastName { get; set; }
    public string teamLogo { get; set; }
    public int sweaterNumber { get; set; }
    public string position { get; set; }
    public string headshot { get; set; }
    public string heroImage { get; set; }
    public int heightInInches { get; set; }
    public int heightInCentimeters { get; set; }
    public int weightInPounds { get; set; }
    public int weightInKilograms { get; set; }
    public string birthDate { get; set; }
    public BirthCity birthCity { get; set; }
    public BirthStateProvince birthStateProvince { get; set; }
    public string birthCountry { get; set; }
    public string shootsCatches { get; set; }
    public DraftDetails draftDetails { get; set; }
    public string playerSlug { get; set; }
    public int inTop100AllTime { get; set; }
    public int inHHOF { get; set; }
    public FeaturedStats featuredStats { get; set; }
    public CareerTotals careerTotals { get; set; }
    public string shopLink { get; set; }
    public string twitterLink { get; set; }
    public string watchLink { get; set; }
    public List<Last5Game> last5Games { get; set; }
    public List<SeasonTotal> seasonTotals { get; set; }
    public List<CurrentTeamRoster> currentTeamRoster { get; set; }
}

public class SeasonTotal
{
    public int assists { get; set; }
    public int gameTypeId { get; set; }
    public int gamesPlayed { get; set; }
    public int goals { get; set; }
    public string leagueAbbrev { get; set; }
    public int pim { get; set; }
    public int points { get; set; }
    public int season { get; set; }
    public int sequence { get; set; }
    public TeamName teamName { get; set; }
    public int? plusMinus { get; set; }
    public string avgToi { get; set; }
    public double? faceoffWinningPctg { get; set; }
    public int? gameWinningGoals { get; set; }
    public int? otGoals { get; set; }
    public int? powerPlayGoals { get; set; }
    public int? powerPlayPoints { get; set; }
    public double? shootingPctg { get; set; }
    public int? shorthandedGoals { get; set; }
    public int? shorthandedPoints { get; set; }
    public int? shots { get; set; }
}

public class SubSeason
{
    public int assists { get; set; }
    public int gameWinningGoals { get; set; }
    public int gamesPlayed { get; set; }
    public int goals { get; set; }
    public int otGoals { get; set; }
    public int pim { get; set; }
    public int plusMinus { get; set; }
    public int points { get; set; }
    public int powerPlayGoals { get; set; }
    public int powerPlayPoints { get; set; }
    public double shootingPctg { get; set; }
    public int shorthandedGoals { get; set; }
    public int shorthandedPoints { get; set; }
    public int shots { get; set; }
}

public class TeamName
{
    public string @default { get; set; }
    public string cs { get; set; }
    public string de { get; set; }
    public string fi { get; set; }
    public string sk { get; set; }
    public string sv { get; set; }
    public string fr { get; set; }
}

