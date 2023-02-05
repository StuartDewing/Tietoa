using Services.Sql;
using Services.Sql.Interface;
using System.Data;
using Microsoft.Extensions.Configuration;
using Tietoa.Domain;
using System.Data.SqlClient;

namespace Services.Sql.GetData
{
    public class GetData : IGetData
    {
        private readonly IGetData _GetData;
        private readonly IConfiguration _configuration;

        public GetData(IGetData getData, IConfiguration configuration)
        {
            _GetData = getData;
            _configuration = configuration;
        }

        public DataTable GetDataFromTable(string TableName)
        {
            var config = _configuration.GetConnectionString("TietoaConnectionString");

            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            string query = SqlConstants.SelectEverythingFrom + "[" + TableName + "]";
            SqlCommand command = new SqlCommand(query, connection);

            DataTable datatable = new DataTable();
            datatable.Load(command.ExecuteReader());
            connection.Close();

            return datatable;
        }
    }
}