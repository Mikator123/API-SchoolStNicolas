using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models.Enumerations
{
    [Flags]
    public enum UserStatus
    {
        Undefined = 0,
        Student = 1,
        Professor = 2,
        Management = 4,
        Admin = 8
    }
}
