
using API.Models.WorkingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Users
{
    public class UserDocuments
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<WorkingProfileDocument> Documents { get; set; }

    }
}
