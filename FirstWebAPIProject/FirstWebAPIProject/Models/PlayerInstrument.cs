using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebAPIProject.Models
{
    public class PlayerInstrument
    {
        public int PlayerInstrumentId { get; set; }
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
        public int InstrumentTypeId { get; set; }

        [ForeignKey("InstrumentTypeId")]
        public InstrumentType InstrumentType { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
