namespace Tietoa.Domain.Models.Standings.JsonClasses
{
    public class Record
    {
        public string standingsType { get; set; }
        public League league { get; set; }
        public Division division { get; set; }
        public Conference conference { get; set; }
        public List<TeamRecord> teamRecords { get; set; }
    }

}
