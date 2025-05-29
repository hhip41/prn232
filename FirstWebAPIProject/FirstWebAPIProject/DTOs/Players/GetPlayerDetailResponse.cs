using FirstWebAPIProject.DTOs.PlayerInstrument;

namespace FirstWebAPIProject.DTOs.Players
{
    public class GetPlayerDetailResponse
    {   
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments { get; set; }
    }
}
