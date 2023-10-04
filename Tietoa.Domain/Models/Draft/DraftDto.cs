namespace Tietoa.Domain.Models.Draft

{
    public class DraftDto
    {
        public int ProspectId { get; set; }
        public int DraftYear { get; set; }
        public string Round { get; set; }
        public int Pick { get; set; }
        public string Team { get; set; }
        public string FullName { get; set; }
    }
}
