using Tietoa.Domain.Models.Player.JsonClasses;

namespace Tietoa.Domain.Models.Player
{
    public partial class PlayerDto
    {
        public class Root
        {
            public string copyright { get; set; }
            public List<Person> people { get; set; }
        }


    }
}
