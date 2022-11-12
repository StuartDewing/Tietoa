namespace Tietoa.Domain.Models.Draft.JsonClasses
{
    public class Round
    {
        public int roundNumber { get; set; }
        public string round { get; set; }
        public List<Pick> picks { get; set; }
    }

}
