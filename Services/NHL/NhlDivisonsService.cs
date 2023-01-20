using Newtonsoft.Json;
using Services.NHL.Interface;
using Tietoa.Domain;
using Tietoa.Domain.Models.Divisions;
using Tietoa.Domain.Models.Divisions.JsonClasses;

namespace Services.NHL

{
    public class NhlDivisionsService : INhlDivisionsService
    {
        private readonly INhlRequest _NhlRequest;
        private string urlSegment = $"{NhlConstants.Division}";

        public NhlDivisionsService(INhlRequest nhlRequest)
        {
            _NhlRequest = nhlRequest;
        }

        public async Task<List<DivisionsDto>> DivisionsRequest()
        {
            var response = await _NhlRequest.NhlGetResponse(urlSegment);
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<DivisionsDto> divisionsDto = new List<DivisionsDto>();

            if (root == null)
                return divisionsDto;

            foreach (var division in root.divisions)
            {
                if (division.active)
                {
                    divisionsDto.Add(new DivisionsDto
                    {
                        Id = division.id,
                        Name = division.name,
                        Conference = division.conference.name
                    });
                }
            }
            return divisionsDto;
        }
    }
}