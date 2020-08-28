using API.Models.Users;
using System;
using System.Collections.Generic;

namespace API.Models.Lunch
{
    public class LunchDetailed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<UserSimplified> Users { get; set; }

    }
}
