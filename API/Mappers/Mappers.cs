using D = DAL.Models;
using API.Models.Users;
using API.Models.Contacts;
using API.Models.Lunch;

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
        public static ContactUser DalToApi(this D.Contact c)
        {
            return new ContactUser()
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
        public static D.Contact ApitoDal(this ContactUser c)
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
        public static D.Status ApitoDal(this Status s)
        {
            return new D.Status()
            {
                Id = s.Id,
                Name = s.Name,
            };
        }
        public static Status DaltoApi(this D.Status s)
        {
            return new Status()
            {
                Id = s.Id,
                Name = s.Name,
            };
        }

        public static LunchUser DaltoApi (this D.Lunch l)
        {
            return new LunchUser()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static D.Lunch DaltoApi(this LunchUser l)
        {
            return new D.Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
    }
}
