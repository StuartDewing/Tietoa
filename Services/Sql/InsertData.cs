using Services.Sql;
using Services.Sql.Interface;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Tietoa.Domain;

namespace Services.Sql.UpdateData
{
    public class InsertData : IInsertData
    {
        private readonly IInsertData _InsertData;
        private readonly IConfiguration _configuration;

        private string sqlPopulateTableFromResponse(int divisionId, string divisionName, string divisionConference)
        {
            string sqlQuery = $"IF NOT EXISTS (SELECT * FROM NhlDivisions WHERE [divisionsId] = {divisionId}) BEGIN INSERT into NhlDivisions ([divisionsId],[divisionName],[conferenceName]) Values ({divisionId},'{divisionName}','{divisionConference}');END";
            return sqlQuery;
        }

        public InsertData(IInsertData InsertData, IConfiguration configuration)
        {
            _InsertData = InsertData;
            _configuration = configuration;
        }

        public DataTable InsertTable(int divisionId, string divisionName, string divisionConference)
        {
            var config = _configuration.GetConnectionString("TietoaConnectionString");

            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            string query = sqlPopulateTableFromResponse(divisionId, divisionName, divisionConference);
            SqlCommand command = new SqlCommand(query, connection);

            DataTable datatable = new DataTable();
            datatable.Load(command.ExecuteReader());
            connection.Close();

            return datatable; 
        }
    }
}