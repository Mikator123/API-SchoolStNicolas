using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Commons
{
    public class UserVerification
    {
        public string Login { get; set; }
        public string UserNationalNumber { get; set; }
        public string ContactNationalNumber { get; set; }
    }
}
