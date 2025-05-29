using FirstWebAPIProject.DTOs;
using FirstWebAPIProject.DTOs.Players;

namespace FirstWebAPIProject.Services
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest playerRequest);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);
        Task<bool> DeletePlayerAsync(int id);
        Task<GetPlayerDetailResponse> GetPlayerDetailResponse(int id);
        Task<PagedResponse<GetPlayerResponse>> GetPlayersAsync(UrlQueryParameters urlQueryParameters);

    }
}
