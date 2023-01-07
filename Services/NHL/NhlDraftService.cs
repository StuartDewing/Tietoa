using Services.NHL.Interface;
using Tietoa.Domain.Models.Draft;

namespace Services.NHL

{
    public class NhlDraftService : INhlDraftService
    {
        private readonly INhlRequest _NhlRequest;
        private readonly INhlDraftMappingService _NhlDraftMappingService;

        public NhlDraftService(INhlRequest nhlRequest, INhlDraftMappingService nhlDraftMappingService)
        {
            _NhlRequest = nhlRequest;
            _NhlDraftMappingService = nhlDraftMappingService;
        }

        public async Task<List<DraftByYearDto>> GetDraftByYear(int year)
        {
            string urlSegment = $"draft/{year}"; 
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            var name = await _NhlDraftMappingService.MapDraftByYear(response);
            
            return name;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetByYearTeam(int year, string team)
        //{
        //    if (year == 0)
        //        return BadRequest("Draft year missing");
        //    if (string.IsNullOrWhiteSpace(team))
        //        return BadRequest("Team name missing");

        //    var year = $"https://statsapi.web.nhl.com/api/v1/draft/{year}";
        //    var response = await _NhlRequest.NHLGetResponse(url);
        //    var root = JsonConvert.DeserializeObject<Root>(response);

        //    if (root?.drafts == null)
        //        return NotFound();

        //    List<DraftByYearDto> draftByYearsDto = new List<DraftByYearDto>();
        //    foreach (var drafts in root.drafts)
        //    {
        //        foreach (var rounds in drafts.rounds)
        //        {
        //            foreach (var picks in rounds.picks.Where(t => t.team.name == team))
        //            {
        //                draftByYearsDto.Add(new DraftByYearDto
        //                {
        //                    Round = picks.round,
        //                    Pick = picks.pickOverall,
        //                    Team = picks.team.name,
        //                    FullName = picks.prospect.fullName
        //                });
        //            }
        //        }
        //    }
        //    return Ok(draftByYearsDto);
        //}
    }
}