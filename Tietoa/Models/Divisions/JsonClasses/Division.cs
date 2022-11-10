namespace Tietoa.Models.Divisions.JsonClasses
{
    public class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public string link { get; set; }
        public string abbreviation { get; set; }
        public Conference conference { get; set; }
        public bool active { get; set; }
    }

}
