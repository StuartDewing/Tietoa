using System.Data;
using Tietoa.Domain.Models.Draft;

namespace Services.Sql.Interface
{
    public interface IDraftSql
    {
        DataTable InsertDraftTable(int ProspectId, string Round, int Pick, string Team, string FullName, int DraftYear);
    }
}
