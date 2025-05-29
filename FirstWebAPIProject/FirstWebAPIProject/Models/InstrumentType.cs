namespace FirstWebAPIProject.Models
{
    public class InstrumentType
    {
        public int InstrumentTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerInstrument> PlayerInstruments { get; set; } = new List<PlayerInstrument>();
    }
}
