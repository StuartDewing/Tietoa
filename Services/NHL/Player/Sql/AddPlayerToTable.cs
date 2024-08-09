using Microsoft.Extensions.Configuration;
using Services.NHL.Player.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tietoa.Domain.Models.Player;

namespace Services.NHL.Player.Sql
{
    public class AddPlayerToTable : IAddPlayerToTable
    {
        private readonly IConfiguration _configuration;

        public AddPlayerToTable(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable InsertToNhlPlayerTable(PlayerResponseModel response)
        {

            var config = _configuration.GetConnectionString("TietoaConnectionString");

            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            string query = CreateSqlQuery(response);

            SqlCommand command = new SqlCommand(query, connection);

            DataTable datatable = new DataTable();
            datatable.Load(command.ExecuteReader());
            connection.Close();

            return datatable;

        }

        private string CreateSqlQuery(PlayerResponseModel response)
        {
            string sqlQuery = $"IF NOT EXISTS (SELECT * FROM [NhlPlayer] WHERE [PlayerId] = {response.playerId}) " +
                $"BEGIN INSERT into NhlPlayer ([PlayerId], [CurrentTeamId], [FirstName], [LastName], [Number], [Postion], [HeightCM], [DateOfBirth], [Nationality], [ShootCatches]) " +
                $"Values ({response.playerId},{response.currentTeamId},'{response.firstName.@default}','{response.lastName.@default}',{response.sweaterNumber},'{response.position}',{response.heightInCentimeters},'{response.birthDate}','{response.birthCountry}','{response.shootsCatches}');END";
            return sqlQuery;
        }
    }
}
