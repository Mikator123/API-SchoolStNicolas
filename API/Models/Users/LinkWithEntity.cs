using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Users
{
    public class LinkWithEntity
    {
        public int EntityId { get; set; }
        public int UserId { get; set; }
    }
}
