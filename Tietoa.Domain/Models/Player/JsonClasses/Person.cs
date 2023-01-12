using static Tietoa.Domain.Models.Player.PlayerDto;

namespace Tietoa.Domain.Models.Player.JsonClasses
{

    public class Person
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string primaryNumber { get; set; }
        public string birthDate { get; set; }
        public int currentAge { get; set; }
        public string birthCity { get; set; }
        public string birthCountry { get; set; }
        public string nationality { get; set; }
        public string height { get; set; }
        public int weight { get; set; }
        public bool active { get; set; }
        public bool alternateCaptain { get; set; }
        public bool captain { get; set; }
        public bool rookie { get; set; }
        public string shootsCatches { get; set; }
        public string rosterStatus { get; set; }
        public CurrentTeam currentTeam { get; set; }
        public PrimaryPosition primaryPosition { get; set; }
    }
}
