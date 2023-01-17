namespace Tietoa.Domain.Models.Player.JsonClasses

{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CurrentTeam
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }
}
