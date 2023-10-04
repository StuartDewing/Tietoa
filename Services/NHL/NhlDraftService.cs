using Newtonsoft.Json;
using Services.NHL.Interface;
using Services.Sql.Interface;
using Tietoa.Domain;
using Tietoa.Domain.Models.Draft;
using Tietoa.Domain.Models.Draft.JsonClasses;

namespace Services.NHL

{
    public class NhlDraftService : INhlDraftService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly IDraftSql _DraftSql;

        private async Task<string> nhlDraftRequest(int year)
        {
            string urlSegment = $"{NhlConstants.Draft}/{year}";
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            return response;
        }

        public NhlDraftService(INhlRequest nhlRequest, IDraftSql draftSql)
        {
            _NhlRequest = nhlRequest;
            _DraftSql = draftSql;
        }

        public async Task<List<DraftDto>> DraftByYearRequest(int year)
        {
            var response = await nhlDraftRequest(year);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<DraftDto> draftByYearsDto = new List<DraftDto>();

            if (root == null)
                return draftByYearsDto;

            foreach (var drafts in root.drafts)
            {
                foreach (var rounds in drafts.rounds)
                {
                    foreach (var picks in rounds.picks)
                    {
                        draftByYearsDto.Add(new DraftDto
                        {
                            ProspectId = picks.prospect.id,
                            DraftYear = picks.year,
                            Round = picks.round,
                            Pick = picks.pickOverall,
                            Team = picks.team.name,
                            FullName = picks.prospect.fullName
                        });

                        _DraftSql.InsertDraftTable(picks.prospect.id, picks.round, picks.pickOverall, picks.team.name, picks.prospect.fullName, picks.year);
                    }
                }
            }
            return draftByYearsDto;
        }

        public async Task<List<DraftDto>> DraftByTeamRequest(int year, string teamName)
        {
            var response = await nhlDraftRequest(year);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<DraftDto> draftByNameDto = new List<DraftDto>();

            if (root == null)
                return draftByNameDto;

            foreach (var drafts in root.drafts)
            {
                foreach (var rounds in drafts.rounds)
                {
                    foreach (var picks in rounds.picks.Where(t => t.team.name == teamName))
                    {
                        draftByNameDto.Add(new DraftDto
                        {
                            ProspectId = picks.prospect.id,
                            Round = picks.round,
                            Pick = picks.pickOverall,
                            Team = picks.team.name,
                            FullName = picks.prospect.fullName,
                            DraftYear = picks.year
                        });

                        _DraftSql.InsertDraftTable(picks.prospect.id, picks.round, picks.pickOverall, picks.team.name, picks.prospect.fullName, picks.year);
                    }
                }
            }
            return draftByNameDto;
        }
    }
}