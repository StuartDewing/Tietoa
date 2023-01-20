using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain;
using Tietoa.Domain.Models.Standings;
using Tietoa.Domain.Models.Standings.JsonClasses;

namespace Services.NHL

{
    public class NhlStandingsService : INhlStandingsService
    {
        private readonly INhlRequest _NhlRequest;

        private async Task<string> nhlStandingsRequest()
        {
            string urlSegment = $"{NhlConstants.Standings}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlStandingsService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
        }

        public async Task<List<StandingsDto>> StandingsRequest()
        {
            var response = await nhlStandingsRequest();
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<StandingsDto> standingsDto = new List<StandingsDto>();

            if (root == null)
                return standingsDto;

            foreach (var records in root.records)
            {
                foreach (var teamRecords in records.teamRecords)
                {
                    standingsDto.Add(new StandingsDto
                    {
                        Name = teamRecords.team.name,
                        Wins = teamRecords.leagueRecord.wins,
                        Losses = teamRecords.leagueRecord.losses,
                        OT = teamRecords.leagueRecord.ot,
                        Points = teamRecords.points,
                        Goals = teamRecords.goalsScored,
                        GoalsAgainst = teamRecords.goalsAgainst
                    });
                }
            }
            return standingsDto;
        }

        public async Task<List<StandingsDto>> StandingsTeamRequest(string team)
        {
            var response = await nhlStandingsRequest();
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<StandingsDto> standingsDto = new List<StandingsDto>();

            if (root == null)
                return standingsDto;

            foreach (var records in root.records)
            {
                foreach (var teamRecords in records.teamRecords.Where(t => t.team.name == team))
                {
                    standingsDto.Add(new StandingsDto
                    {
                        Name = teamRecords.team.name,
                        Wins = teamRecords.leagueRecord.wins,
                        Losses = teamRecords.leagueRecord.losses,
                        OT = teamRecords.leagueRecord.ot,
                        Points = teamRecords.points,
                        Goals = teamRecords.goalsScored,
                        GoalsAgainst = teamRecords.goalsAgainst
                    });
                }
            }
            return standingsDto;
        }

    }
}