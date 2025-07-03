using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CosmeticCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UsagePurpose { get; set; }
        public string FormulationType { get; set; }

        public ICollection<CosmeticInformation> CosmeticInformations { get; set; }
    }
}
