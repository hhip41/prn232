namespace FirstWebAPIProject.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public ICollection<PlayerInstrument> PlayerInstruments { get; set; } = new List<PlayerInstrument>();
    }
}
