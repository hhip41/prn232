using FirstWebAPIProject.DTOs.PlayerInstrument;

namespace FirstWebAPIProject.DTOs.Players
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
        public List<CreatePlayerInstrumentRequest> PlayerInstruments { get; set; }
    }
}
