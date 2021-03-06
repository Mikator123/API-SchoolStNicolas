﻿using DAL.Models.RelativeToClass;
using DAL.Models.RelativeToSchool;
using DAL.Models.RelativeToUser;
using DAL.Models.RelativeToWorkingProfile;
using System;
using System.Data;

namespace DAL.Services.Mappers
{
    public static class Mappers
    {
        public static Lunch ReaderToDalLunch(this IDataReader r)
        {
            return new Lunch()
            {
                Id = (int)r["Id"],
                Name = r["LunchName"].ToString(),
                Description = r["LunchDescription"] is DBNull ? null : r["LunchDescription"].ToString(),
                Date = (DateTime)r["LunchDate"]
            };
        }

        public static Contact ReaderToDalContact(this IDataReader r)
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

        public static Class ReaderToDalClass(this IDataReader r)
        {
            return new Class()
            {
                Id = (int)r["Id"],
                Name = r["ClassName"].ToString(),
                Description = r["ClassDescription"] is DBNull ? null : r["ClassDescription"].ToString(),
                SchoolYear = (int)r["SchoolYear"],
                SchoolYearCategoryId = (int)r["SchoolYearCategoryId"]
            };
        }
        public static User ReaderToDalUser(this IDataReader r)
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
                ClassId = r["ClassId"] is DBNull ? null : (int?)r["ClassId"],
                StatusCode = (int)r["StatusCode"]
            };
        }

        public static TrimestrialInfo ReaderToDalTrim(this IDataReader r)
        {
            return new TrimestrialInfo()
            {
                Id = (int)r["Id"],
                UserId = (int)r["UserId"],
                Description = r["InfoDescription"].ToString(),
                CreateInfoDate = (DateTime)r["CreateInfoDate"],
                UpdateInfoDate = r["UpdateInfoDate"] is DBNull ? null : (DateTime?)r["UpdateInfoDate"],
                ClassName = r["ClassName"].ToString(),
                Trimester = (int)r["Trimester"]
                
            };
        }

        public static SchoolRule ReaderToDalRule(this IDataReader r)
        {
            return new SchoolRule()
            {
                Id = (int)r["Id"],
                Name = r["RuleName"].ToString(),
                Description = r["RuleDescription"].ToString()
            };
        }
        public static SchoolEvent ReaderToDalEvent (this IDataReader r)
        {
            return new SchoolEvent()
            {
                Id = (int)r["Id"],
                Name = r["EventName"].ToString(),
                Description = r["EventDescription"] is DBNull ? null : r["EventDescription"].ToString(),
                Date = r["EventDate"] is DBNull ? null : (DateTime?)r["EventDate"],
                NbrOfPersons = r["NbrOfPersons"] is DBNull ? null : (int?)r["NbrOfPersons"]
            };
        }

        public static SchoolYearCategory ReaderToDalYearCategory (this IDataReader r)
        {
            return new SchoolYearCategory()
            {
                Id = (int)r["Id"],
                Name = r["CategoryName"].ToString()
            };
        }

        public static TeachingCategory ReaderToDalTeachCategory (this IDataReader r)
        {
            return new TeachingCategory()
            {
                Id = (int)r["Id"],
                Name = r["CategoryName"].ToString(),
            };
        }
        public static TestResult ReaderToDalTestResult (this IDataReader r)
        {
            return new TestResult()
            {
                Id = (int)r["Id"],
                Result = (double)r["Result"],
                Date = (DateTime)r["TestDate"],
                Description = r["TestDescription"] is DBNull ? null : r["TestDescription"].ToString(),
                CategoryId = r["CategoryId"] is DBNull ? null : (int?)r["CategoryId"],
                ClassId = r["ClassId"] is DBNull ? null : (int?)r["ClassId"],
                StudentId = (int)r["UserId"],
                Document = r["Document"] is DBNull ? null: r["Document"].ToString()
            };
        }

        public static WorkingProfileQuestion ReaderToDalDistTest (this IDataReader r)
        {
            return new WorkingProfileQuestion()
            {
                Id = (int)r["Id"],
                Subject = r["Subject"].ToString(),
                LastUpdate = (DateTime)r["LastUpdate"],
                Question = r["Question"].ToString(),
                Correction = r["Correction"].ToString(),
                Explanation = r["Explanation"].ToString(),
                FirstHint = r["FirstHint"].ToString(),
                SecondHint = r["SecondHint"] is DBNull ? null : r["SecondHint"].ToString(),
                CategoryId = r["CategoryId"] is DBNull ? null : (int?)r["CategoryId"],
                SchoolYear = (int)r["SchoolYear"],
                Trimester = (int)r["Trimester"],
                SchoolYearCategoryId = (int)r["SchoolYearCategoryId"]
            };
        }

        public static WorkingProfileDocument ReaderToDalWorkDoc (this IDataReader r)
        {
            return new WorkingProfileDocument()
            {
                Id = (int)r["Id"],
                Description = r["DocumentDescription"].ToString(),
                Link = r["DocumentLink"].ToString(),
                Name = r["DocumentName"].ToString(),
                CategoryId = r["CategoryId"] is DBNull ? null : (int?)r["CategoryId"],
                SchoolYear = (int)r["SchoolYear"],
                Trimester = (int)r["Trimester"],
                SchoolYearCategoryId = (int)r["SchoolyearNameId"]
            };
        }
    }
}
