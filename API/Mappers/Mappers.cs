
using API.Models.Users;
using API.Models.Contacts;
using API.Models.Lunch;
using API.Models.Classes;
using DalUser = DAL.Models.RelativeToUser;
using DalClass = DAL.Models.RelativeToClass;
using DalSchool = DAL.Models.RelativeToSchool;
using DalWProfile = DAL.Models.RelativeToWorkingProfile;
using API.Models.DistancialTest;
using API.Models.WorkingProfile;

namespace API.Mappers
{
    public static class Mappers
    {
        public static UserDetailed DalToDetailedUserApi(this DalUser.User user)
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
                lastResetPwd = user.FirstLogin,
                Email = user.Email,
                ClassId = user.ClassId,
                StatusCode = user.StatusCode
            };
        }

        public static UserForEmails DalToForEmailsUserApi(this DalUser.User user)
        {
            return new UserForEmails()
            {
                Id = user.Id,
                FullName = user.LastName + ' ' + user.FirstName,
                StatusCode = user.StatusCode,
                Gender= user.Gender,
                Photo = user.Photo,
            };
        }

        public static DalUser.User ApiToDal(this UserDetailed user)
        {
            return new DalUser.User()
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
                FirstLogin = user.lastResetPwd,
                Email = user.Email,
                ClassId = user.ClassId,
                StatusCode = user.StatusCode
            };
        }
        public static UserSimplified DalToSimplifiedUserApi(this DalUser.User user)
        {
            return new UserSimplified()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Login = user.Login,
                Gender = user.Gender,
                lastResetPwd = user.FirstLogin,
                StatusCode = user.StatusCode,
                ClassId = user.ClassId,
                
            };
        }
        public static UserForEntities DalToForEntitiesApi(this DalUser.User user)
        {
            return new UserForEntities()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                NationalNumber = user.NationalNumber,
                ClassId = user.ClassId,
                StatusCode = user.StatusCode,
                Email = user.Email
            };
        }
        public static DalUser.User DalToApi(this UserForEntities user)
        {
            return new DalUser.User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                NationalNumber = user.NationalNumber,
                StatusCode = user.StatusCode,
                Email = user.Email

            };
        }
        public static Contact DalToForUserApi(this DalUser.Contact c)
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

        public static ContactEmail DalToForEmailUserApi(this DalUser.Contact c)
        {
            return new ContactEmail()
            {
                Id = c.Id,
                FullName = c.LastName + ' ' + c.FirstName,
                Email = c.Email,
            };
        }
        public static ContactDetailed DalToDetailedApi(this DalUser.Contact c)
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
        public static DalUser.Contact ApitoDal(this Contact c)
        {
            return new DalUser.Contact()
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

        public static LunchDetailed DaltoDetailedApi (this DalSchool.Lunch l)
        {
            return new LunchDetailed()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static DalSchool.Lunch ApitoDal (this LunchDetailed l)
        {
            return new DalSchool.Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static Lunch DaltoSimplifiedApi(this DalSchool.Lunch l)
        {
            return new Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }
        public static DalSchool.Lunch ApitoDal(this Lunch l)
        {
            return new DalSchool.Lunch()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Date = l.Date
            };
        }

        public static Class DaltoSimplifiedApi(this DalClass.Class c)
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
        public static ClassDetailed DaltoDetailedApi(this DalClass.Class c)
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
        public static DalClass.Class ApiToDal(this Class c)
        {
            return new DalClass.Class()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                SchoolYear = c.SchoolYear,
                SchoolYearCategoryId = c.SchoolYearCategoryId
            };
        }

        public static WorkingProfileQuestion DalToAPI(this DalWProfile.WorkingProfileQuestion t )
        {
            return new WorkingProfileQuestion()
            {
                Id = t.Id,
                LastUpdate = t.LastUpdate,
                Subject = t.Subject,
                Question = t.Question,
                Correction = t.Correction,
                Explanation = t.Explanation,
                FirstHint = t.FirstHint,
                SecondHint = t.SecondHint,
                CategoryId = t.CategoryId,
                SchoolYear = t.SchoolYear,
                Trimester = t.Trimester,
                SchoolYearCategoryId = t.SchoolYear
            };
        }
        public static DalWProfile.WorkingProfileQuestion ApiToDal(this WorkingProfileQuestion t)
        {
            return new DalWProfile.WorkingProfileQuestion()
            {
                Id = t.Id,
                Subject = t.Subject,
                LastUpdate = t.LastUpdate,
                Question = t.Question,
                Correction = t.Correction,
                Explanation = t.Explanation,
                FirstHint = t.FirstHint,
                SecondHint = t.SecondHint,
                CategoryId = t.CategoryId,
                SchoolYear = t.SchoolYear,
                Trimester = t.Trimester,
                SchoolYearCategoryId = t.SchoolYear
            };
        }
        public static WorkingProfileDocument DalToApi(this DalWProfile.WorkingProfileDocument d)
        {
            return new WorkingProfileDocument()
            {
                Id = d.Id,
                Description = d.Description,
                Link = d.Link,
                Name = d.Name,
                CategoryId = d.CategoryId,
                SchoolYear = d.SchoolYear,
                Trimester = d.Trimester,
                SchoolYearCategoryId = d.SchoolYearCategoryId

            };
        }
        public static DalWProfile.WorkingProfileDocument ApiToDal(this WorkingProfileDocument d)
        {
            return new DalWProfile.WorkingProfileDocument()
            {
                Id = d.Id,
                Description = d.Description,
                Link = d.Link,
                Name = d.Name,
                CategoryId = d.CategoryId,
                SchoolYear = d.SchoolYear,
                Trimester = d.Trimester,
                SchoolYearCategoryId = d.SchoolYearCategoryId
            };
        }



    }
}
