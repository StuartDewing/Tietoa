namespace Tietoa.Domain.Models.Schedule.JsonClasses
{
    public class Root
    {
        public string copyright { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalMatches { get; set; }
        public MetaData metaData { get; set; }
        public int wait { get; set; }
        public List<Date> dates { get; set; }
    }
}
