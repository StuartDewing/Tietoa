using Newtonsoft.Json;
using Services.NHL.Interface;
using Services.NHL.Player.Interface;
using Services.Sql.Interface;
using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player

{
    public class NhlPlayerService : INhlPlayerService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly IDraftSql _DraftSql;

        private async Task<string> nhlPlayerRequest(int playerId)
        {
            string urlSegment = $"player/{playerId}/landing";
            var response = await _NhlRequest.NhlApiResponse(urlSegment);
            return response;
        }

        public NhlPlayerService(INhlRequest nhlRequest, IDraftSql draftSql)
        {
            _NhlRequest = nhlRequest;
            _DraftSql = draftSql;
        }

        public async Task<List<PlayerDto>> PlayerRequest(int playerId)
        {
            var response = await nhlPlayerRequest(playerId);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<PlayerDto> playerDto = new List<PlayerDto>();

            if (root == null)
                return playerDto;


                        playerDto.Add(new PlayerDto
                        {
                            FirstName = root.firstName.@default,
                            LastName = root.lastName.@default,
                            Team = root.fullTeamName.@default,
                            Position = root.position,
                            PlayerNumber = root.sweaterNumber
                        });

            return playerDto;
        }

        //public async Task<List<DraftDto>> DraftByTeamRequest(int year, string teamName)
        //{
        //    var response = await nhlDraftRequest(year);
        //    var root = JsonConvert.DeserializeObject<Root>(response);

        //    List<DraftDto> draftByNameDto = new List<DraftDto>();

        //    if (root == null)
        //        return draftByNameDto;

        //    foreach (var drafts in root.drafts)
        //    {
        //        foreach (var rounds in drafts.rounds)
        //        {
        //            foreach (var picks in rounds.picks.Where(t => t.team.name == teamName))
        //            {
        //                draftByNameDto.Add(new DraftDto
        //                {
        //                    ProspectId = picks.prospect.id,
        //                    Round = picks.round,
        //                    Pick = picks.pickOverall,
        //                    Team = picks.team.name,
        //                    FullName = picks.prospect.fullName,
        //                    DraftYear = picks.year
        //                });

        //                _DraftSql.InsertDraftTable(picks.prospect.id, picks.round, picks.pickOverall, picks.team.name, picks.prospect.fullName, picks.year);
        //            }
        //        }
        //    }
        //    return draftByNameDto;
        //}
    }
}