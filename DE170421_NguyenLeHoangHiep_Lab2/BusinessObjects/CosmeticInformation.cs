using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CosmeticInformation
    {
        public string CosmeticId { get; set; }
        public string CosmeticName { get; set; }
        public string SkinType { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public string CosmeticSize { get; set; }
        public decimal DollarPrice { get; set; }
        public int CategoryId { get; set; }
        public CosmeticCategory Category { get; set; }
    }
}
