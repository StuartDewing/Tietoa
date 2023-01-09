using Newtonsoft.Json;
using Services.NHL.Interface.Divisions;
using Tietoa.Domain.Models.Divisions;
using Tietoa.Domain.Models.Divisions.JsonClasses;

namespace Services.NHL.Divisions
{
    public class NhlDivisionsMappingService : INhlDivisionsMappingService

    {

        public async Task<List<DivisionsDto>> MapDivisions(string response)
        {
            var root = JsonConvert.DeserializeObject<Root>(response);

            List<DivisionsDto> divisionsDto = new List<DivisionsDto>();
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