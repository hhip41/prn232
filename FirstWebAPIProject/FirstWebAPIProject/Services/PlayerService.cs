using FirstWebAPIProject.Db;
using FirstWebAPIProject.DTOs;
using FirstWebAPIProject.DTOs.PlayerInstrument;
using FirstWebAPIProject.DTOs.Players;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPIProject.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly CodeFirstDemoContext _context;
        public PlayerService(CodeFirstDemoContext context)
        {
            _context = context;
        }
        // Implement methods from IPlayerService here
        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            var player = new Models.Player
            {
                NickName = playerRequest.Name,
                JoinedDate = DateTime.Now,
                PlayerInstruments = playerRequest.PlayerInstruments.Select(p => new Models.PlayerInstrument
                {
                    InstrumentTypeId = p.InstrumentTypeId,
                    PlayerId = p.PlayerId,
                    ModelName = p.ModelName,
                    Level = p.Level
                }).ToList()
            };
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;
            player.NickName = playerRequest.Name;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GetPlayerDetailResponse> GetPlayerDetailResponse(int id)
        {
            var player = await _context.Players
                .Include(p => p.PlayerInstruments)
                .ThenInclude(pi => pi.InstrumentType)
                .FirstOrDefaultAsync(p => p.PlayerId == id);
            if (player == null) return null;
            var playerDetail = new GetPlayerDetailResponse
            {
                NickName = player.NickName,
                JoinedDate = player.JoinedDate,
                PlayerInstruments = player.PlayerInstruments.Select(pi => new GetPlayerInstrumentResponse
                {
                    PlayerInstrumentId = pi.PlayerInstrumentId,
                    PlayerId = pi.PlayerId,
                    InstrumentTypeId = pi.InstrumentTypeId,
                    ModelName = pi.ModelName,
                    Level = pi.Level,
                }).ToList()

            };
            return playerDetail;
        }

        public async Task<PagedResponse<GetPlayerResponse>> GetPlayersAsync(UrlQueryParameters urlQueryParameters)
        {
            var players = await _context.Players
                .Include(p => p.PlayerInstruments)
                .Skip((urlQueryParameters.PageNumber - 1) * urlQueryParameters.PageSize)
                .Take(urlQueryParameters.PageSize)
                .ToListAsync();
            var totalCount = await _context.Players.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / urlQueryParameters.PageSize);
            var playerResponses = players.Select(p => new GetPlayerResponse
            {
                PlayerId = p.PlayerId,
                NickName = p.NickName,
                JoinedDate = p.JoinedDate,
                InstrumentSubmittedCount = p.PlayerInstruments.Count(),
            }).ToList();
            return new PagedResponse<GetPlayerResponse>
            {
                Items = playerResponses,
                TotalRecords = totalCount,
                CurrentPage = urlQueryParameters.PageNumber,
                PageSize = urlQueryParameters.PageSize,
                TotalPages = totalPages
            };
        }
    }
    
}
