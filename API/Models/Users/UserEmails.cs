using API.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Users
{
    public class UserForEmails
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int StatusCode { get; set; }
        public string Gender { get; set; }

        public IEnumerable<ContactEmail> Contacts { get; set; }

    }
}
