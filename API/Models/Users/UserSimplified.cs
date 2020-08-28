using System;

namespace API.Models.Users
{
    public class UserSimplified
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Login { get; set; }
        public string Gender { get; set; }
        public string Token { get; set; }
        public DateTime? FirstLogin { get; set; }
        public int StatusCode { get; set; }
    }
}
