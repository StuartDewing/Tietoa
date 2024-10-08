﻿using Newtonsoft.Json;
using Services.NHL.Player.Interface;
using Tietoa.Services.Player.Interface;
using Tietoa.Domain.Models.Player;
using Services.NHL.Interface;

namespace Services.NHL.Player

{
    public class NhlPlayerService : INhlPlayerService222
    {
        private readonly INhlRequest _NhlRequest;
        private readonly IPlayerSqlQuerys _addPlayerToTable;

        public NhlPlayerService(INhlRequest nhlRequest, IPlayerSqlQuerys addPlayerToTable)
        {
            _NhlRequest = nhlRequest;
            _addPlayerToTable = addPlayerToTable;
        }

        public async Task<List<PlayerDto>> PlayerRequest(PlayerRequestModel request)
        {
            var response = await nhlPlayerRequest(request.PlayerId);
            var playerResponseModel = JsonConvert.DeserializeObject<PlayerResponseModel>(response);

            List<PlayerDto> playerDto = new List<PlayerDto>();

            if (playerResponseModel == null)
                return playerDto;

                playerDto.Add(new PlayerDto
                {
                    FirstName = playerResponseModel.firstName.@default,
                    LastName = playerResponseModel.lastName.@default,
                    Team = playerResponseModel.fullTeamName.@default,
                    Position = playerResponseModel.position,
                    PlayerNumber = playerResponseModel.sweaterNumber
                });

            _addPlayerToTable.InsertToNhlPlayerTable(playerResponseModel);
            return playerDto;
        }

        private async Task<string> nhlPlayerRequest(int playerId)
        {
            string urlSegment = $"player/{playerId}/landing";
            var response = await _NhlRequest.NhlApiResponse(urlSegment);
            return response;
        }
    }
}