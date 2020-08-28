using API.Models.Users;
using System;
using System.Collections.Generic;

namespace API.Models.Contacts
{
    public class ContactDetailed
    {
        public int Id { get; set; }
        public string NationalNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string AdCity { get; set; }
        public int AdPostalCode { get; set; }
        public string AdStreet { get; set; }
        public int AdNumber { get; set; }
        public string AdBox { get; set; }
        public string MobilePhone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PersonalNote { get; set; }
        public IEnumerable<UserEntities> Users { get; set; }
    }
}
