using System.Data;

namespace Services.Database.Interface

{
    public interface IGetData
    {
       DataTable GetDataFromTable(string TableName);
    }
}
