using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tietoa.Domain.Models.Draft;

namespace Services.Sql.Interface
{
    public class DraftSql : IDraftSql
    {
        private readonly IConfiguration _configuration;
        public DraftSql(IConfiguration configuration) 
        {
            _configuration = configuration;
        }


        private string SqlPopulateDraftTable(int ProspectId, string Round, int Pick, string Team, string FullName, int DraftYear)
        {
            string sqlQuery = $"IF NOT EXISTS (SELECT * FROM NhlDraft WHERE [ProspectId] = {ProspectId}) BEGIN INSERT into NhlDraft ([ProspectId],[Round],[Pick],[Team],[FullName],[DraftYear]) Values ({ProspectId},'{Round}',{Pick},'{Team}', '{FullName}', {DraftYear});END";
            return sqlQuery;
        }


        public DataTable InsertDraftTable(int ProspectId, string Round, int Pick, string Team, string FullName, int DraftYear)
        {
            var config = _configuration.GetConnectionString("TietoaConnectionString");

            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            string query = SqlPopulateDraftTable(ProspectId, Round, Pick, Team, FullName, DraftYear);
            //string query = "Select * FROM ";
            SqlCommand command = new SqlCommand(query, connection);

            DataTable datatable = new DataTable();
            datatable.Load(command.ExecuteReader());
            connection.Close();

            return datatable;
        }



    }
}
