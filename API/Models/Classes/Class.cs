using API.Models.Users;
using System.Collections.Generic;

namespace API.Models.Classes
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolYear { get; set; }
        public string SchoolYearCategoryName { get; set; }
        public IEnumerable<UserDetailed> Users { get; set; }
    }
}
