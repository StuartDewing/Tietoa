using System.Data;

namespace Services.Sql.Interface

{
    public interface IGetData
    {
        DataTable GetDataFromTable(string TableName);
    }
}