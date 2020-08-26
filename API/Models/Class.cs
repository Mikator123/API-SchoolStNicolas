using API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
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
