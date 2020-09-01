using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Enumerations
{
    public enum DBErrors
    {
        Success, 
        LinkAlreadyExist,
        ClassName_Exist,
        NationalNumber_Exist,
        ClassId_NotFound,
        YearCategoryId_NotFound,
        UserId_NotFound,
        LunchId_NotFound,
        NotKnowedError,
        StartDate_Birthdate_Error,
        NullExeption,
        YearQuarter_NotFound,
    }
}
