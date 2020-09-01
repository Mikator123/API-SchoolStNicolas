using API.Models.Users;
using System.Collections.Generic;

namespace API.Models.Classes
{
    public class ClassDetailed : Class
    {

        public IEnumerable<UserForEntities> Users { get; set; }
    }
}
