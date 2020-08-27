using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Enumerations
{
    public enum DBErrors
    {
        Success = 0, 
        LinkAlreadyExist = 1,
        NationalNumber_Exist = 2,
        ClassId_NotFound = 3,
        UserId_NotFound = 4,
        NotKnowedError = 5,
        StartDate_Birthdate_Error = 6,
        NullExeption = 7,
        
    }
}
