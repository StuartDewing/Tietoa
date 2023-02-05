using System.Data;

namespace Services.Sql.Interface

{
    public interface IInsertData
    {
        DataTable InsertTable(int divisionId, string divisionName, string divisionConference);
    }
}