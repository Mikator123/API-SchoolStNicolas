using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Enumerations
{
    public enum UserCodes
    {
        Success = 0,
        NationalNumber_Exist = 1,
        ClassId_NotFound = 2,
        NotKnowedError = 3,
        UserId_NotFound = 4,
        StartDate_Birthdate_Error = 5,
        NullExeption = 6,
    }
}
