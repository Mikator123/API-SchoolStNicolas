namespace API.Models.Users
{
    public class UserForEntities
    {
        public int Id { get; set; }
        public string NationalNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? ClassId { get; set; }
    }
}
