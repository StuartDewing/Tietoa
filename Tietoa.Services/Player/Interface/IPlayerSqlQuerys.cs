using System.Data;
using Tietoa.Domain.Models.Player;

namespace Tietoa.Services.Player.Interface
{
    public interface IPlayerSqlQuerys
    {
        DataTable InsertToNhlPlayerTable(PlayerResponseModel response);
    }
}