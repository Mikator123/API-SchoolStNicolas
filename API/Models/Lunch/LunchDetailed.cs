using API.Models.Users;
using System;
using System.Collections.Generic;

namespace API.Models.Lunch
{
    public class LunchDetailed : Lunch
    {

        public IEnumerable<UserForEntities> Users { get; set; }

    }
}
