using D = DAL.Models;
using API.Models.Users;
using API.Models.Contacts;
using API.Models.Lunch;
using API.Models.Classes;

namespace API.Mappers
{
    public static class Mappers
    {
        public static UserDetailed DalToDetailedUserApi(this D.User user)
        {
           
            return new UserDetailed()
            {
                Id = user.Id,
                NationalNumber = user.NationalNumber,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                AdCity = user.AdCity,
                AdPostalCode = user.AdPostalCode,
                AdStreet = user.AdStreet,
                AdNumber = user.AdNumber,
                AdBox = user.AdBox,
                MobilePhone = user.MobilePhone,
                Login = user.Login,
                Gender = user.Gender,
                Photo = user.Photo,
                PersonalNote = user.PersonalNote,
                StartDate = user.StartDate,
                FirstLogin = user.FirstLogin,
                Email = user.Email,
                ClassId = user.ClassId,
                StatusCode = user.StatusCode
            };
        }
        public static D.User ApiToDal(this UserDetailed user)
        {
            return new D.User()
            {
                Id = user.Id,
                NationalNumber = user.NationalNumber,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                AdCity = user.AdCity,
                AdPostalCode = user.AdPostalCode,
                AdStreet = user.AdStreet,
                AdNumber = user.AdNumber,
                AdBox = user.AdBox,
                MobilePhone = user.MobilePhone,
                Login = user.Login,
                Password = user.Password,
                Gender = user.Gender,
                Photo = user.Photo,
                PersonalNote = user.PersonalNote,
                StartDate = user.StartDate,
                FirstLogin = user.FirstLogin,
                Email = user.Email,
                ClassId = user.ClassId,
                StatusCode = user.StatusCode
            };
        }
        public static UserSimplified DalToSimplifiedUserApi(this D.User user)
        {
            return new UserSimplified()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Login = user.Login,
                Gender = user.Gender,
                FirstLogin = user.FirstLogin,
                StatusCode = user.StatusCode
            };
        }
        public static UserForEntities DalToForEntitiesApi(this D.User user)
        {
            return new UserForEntities()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                NationalNumber = user.NationalNumber,
                ClassId = (int)user.ClassId
            };
        }
        public static D.User DalToApi(this UserForEntities user)
        {
            return new D.User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                NationalNumber = user.NationalNumber,
            };
        }
        public static Contact DalToForUserApi(this D.Contact c)
        {
            return new Contact()
            {
                Id = c.Id,
                NationalNumber = c.NationalNumber,
                LastName = c.LastName,
                FirstName = c.FirstName,
                BirthDate = c.BirthDate,
                AdCity = c.AdCity,
                AdPostalCode = c.AdPostalCode,
                AdStreet = c.AdStreet,
                AdNumber = c.AdNumber,
                AdBox = c.AdBox,
                MobilePhone = c.MobilePhone,
                Gender = c.Gender,
                Email = c.Email,
                PersonalNote = c.PersonalNote
            };
        }
        public static ContactDetailed DalToDetailedApi(this D.Contact c)
        {
            return new ContactDetailed()
            {
                Id = c.Id,
                NationalNumber = c.NationalNumber,
                LastName = c.LastName,
                FirstName = c.FirstName,
                BirthDate = c.BirthDate,
                AdCity = c.AdCity,
                AdPostalCode = c.AdPostalCode,
                AdStreet = c.AdStreet,
                AdNumber = c.AdNumber,
                AdBox = c.AdBox,
                MobilePhone = c.MobilePhone,
                Gender = c.Gender,
                Email = c.Email,
                PersonalNote = c.PersonalNote
            };
        }
        public static D.Contact ApitoDal(this Contact c)
        {
            return new D.Contact()
            {
                Id = c.Id,
                NationalNumber = c.NationalNumber,
                LastName = c.LastName,
                FirstName = c.FirstName,
                BirthDate = c.BirthDate,
                AdCity = c.AdCity,
                AdPostalCode = c.AdPostalCode,
                AdStreet = c.AdStreet,
                AdNumber = c.AdNumber,
                AdBox = c.AdBox,
                MobilePhone = c.MobilePhone,
                Gender = c.Gender,
                Email = c.Email,
                PersonalNote = c.PersonalNote
            };
        }

        public static LunchDetailed DaltoDetailedApi (this D.Lunch l)
        {
            return new LunchDetailed()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static D.Lunch ApitoDal (this LunchDetailed l)
        {
            return new D.Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static Lunch DaltoSimplifiedApi(this D.Lunch l)
        {
            return new Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static D.Lunch ApitoDal(this Lunch l)
        {
            return new D.Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }

        public static Class DaltoSimplifiedApi(this D.Class c)
        {
            return new Class()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                SchoolYear = c.SchoolYear,
                SchoolYearCategoryId = c.SchoolYearCategoryId
            };
        }
        public static ClassDetailed DaltoDetailedApi(this D.Class c)
        {
            return new ClassDetailed()
            {

                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                SchoolYear = c.SchoolYear,
                SchoolYearCategoryId = c.SchoolYearCategoryId
            };
        }
        public static D.Class ApiToDal(this Class c)
        {
            return new D.Class()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                SchoolYear = c.SchoolYear,
                SchoolYearCategoryId = c.SchoolYearCategoryId
            };
        }


    }
}
