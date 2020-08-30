using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace DAL.Services.Mappers
{
    public static class Mappers
    {
        public static Lunch LunchToDal(this IDataReader r)
        {
            return new Lunch()
            {
                Id = (int)r["Id"],
                Name = r["LunchName"].ToString(),
                Description = r["LunchDescription"] is DBNull ? null : r["LunchDescription"].ToString(),
                Date = (DateTime)r["LunchDate"]
            };
        }

        public static Contact ContactToDal(this IDataReader r)
        {
            return new Contact()
            {
                Id = (int)r["Id"],
                NationalNumber = r["NationalNumber"].ToString(),
                LastName = r["LastName"].ToString(),
                FirstName = r["FirstName"].ToString(),
                BirthDate = (DateTime)r["Birthdate"],
                AdCity = r["AdCity"].ToString(),
                AdPostalCode = (int)r["AdPostalCode"],
                AdStreet = r["AdStreet"].ToString(),
                AdNumber = (int)r["AdNumber"],
                AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
                MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
                Gender = r["Gender"].ToString(),
                Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
                PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString()
            };
        }

        public static Class ClassToDal(this IDataReader r)
        {
            return new Class()
            {
                Id = (int)r["Id"],
                Name = r["ClassName"].ToString(),
                Description = r["ClassDescription"].ToString(),
                SchoolYear = (int)r["SchoolYear"],
                SchoolYearCategoryId = (int)r["SchoolYearCategoryId"]
            };
        }
        public static User UserToDal(this IDataReader r)
        {
            return new User()
            {
                Id = (int)r["Id"],
                NationalNumber = r["NationalNumber"].ToString(),
                LastName = r["LastName"].ToString(),
                FirstName = r["FirstName"].ToString(),
                Birthdate = (DateTime)r["Birthdate"],
                AdCity = r["AdCity"].ToString(),
                AdPostalCode = (int)r["AdPostalCode"],
                AdStreet = r["AdStreet"].ToString(),
                AdNumber = (int)r["AdNumber"],
                AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
                MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
                Login = r["Login"].ToString(),
                Gender = r["Gender"].ToString(),
                Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
                PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
                Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
                StartDate = (DateTime)r["StartDate"],
                ClassId = r["ClassId"] is DBNull ? 0 : (int)r["ClassId"],
                StatusCode = (int)r["StatusCode"]
            };
        }
    }
}
