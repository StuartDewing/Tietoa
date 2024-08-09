using System.Data;
using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player.Interface
{
    public interface IAddPlayerToTable
    {
        DataTable InsertToNhlPlayerTable(PlayerResponseModel response);
    }
}