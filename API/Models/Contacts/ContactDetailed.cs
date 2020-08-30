using API.Models.Users;
using System;
using System.Collections.Generic;

namespace API.Models.Contacts
{
    public class ContactDetailed : ContactForUser
    {

        public IEnumerable<UserForEntities> Users { get; set; }
    }
}
