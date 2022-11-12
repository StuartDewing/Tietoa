namespace Tietoa.Domain.Models.Draft.JsonClasses
{
    public class Pick
    {
        public int year { get; set; }
        public string round { get; set; }
        public int pickOverall { get; set; }
        public int pickInRound { get; set; }
        public Team team { get; set; }
        public Prospect prospect { get; set; }
    }

}
