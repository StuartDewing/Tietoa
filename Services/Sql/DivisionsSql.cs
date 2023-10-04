using Microsoft.Extensions.Configuration;
using Services.Sql.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Services.Sql.UpdateData
{
    public class DivisionsSql : IInsertData
    {
        //private readonly IInsertData _InsertData;
        private readonly IConfiguration _configuration;

        public DivisionsSql(IConfiguration configuration)
        {
            //_InsertData = InsertData;
            _configuration = configuration;
        }

        private string SqlPopulateDivisionsTable(int divisionId, string divisionName, string divisionConference)
        {
            string sqlQuery = $"IF NOT EXISTS (SELECT * FROM NhlDivisions WHERE [divisionsId] = {divisionId}) BEGIN INSERT into NhlDivisions ([divisionsId],[divisionName],[conferenceName]) Values ({divisionId},'{divisionName}','{divisionConference}');END";
            return sqlQuery;
        }


        public DataTable InsertTable(int divisionId, string divisionName, string divisionConference)
        {
            var config = _configuration.GetConnectionString("TietoaConnectionString");

            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            string query = SqlPopulateDivisionsTable(divisionId, divisionName, divisionConference);
            //string query = "Select * FROM ";
            SqlCommand command = new SqlCommand(query, connection);

            DataTable datatable = new DataTable();
            datatable.Load(command.ExecuteReader());
            connection.Close();

            return datatable;
        }
}
}