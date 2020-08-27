using A = API.Models;
using D = DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Users;
using System.Net.NetworkInformation;
using API.Models;
using System.Runtime.CompilerServices;

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
                StatusCode = user.StatusCode,
                LoginError = user.LoginError
                
            };
        }
        public static A.Contact DalToApi(this D.Contact c)
        {
            return new A.Contact()
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
        public static D.Contact ApitoDal(this A.Contact c)
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
    }
}
