using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class SystemAccount
    {
        public int AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string EmailAddress { get; set; }
        public string AccountNote { get; set; }
        public int Role { get; set; }
    }
}
