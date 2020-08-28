using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using ToolBoxDB;

namespace DAL.Services.Repositories.Users
{
    public class UserRepository : IUserRepository<User>
    {
        private Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }
        public int getIdWithNN(string NationalNumber)
        {
            Command cmd = new Command("SELECT Id FROM Users WHERE NationalNumber = @nationalNumber");
            cmd.AddParameter("@nationalNumber", NationalNumber);
            return (int)_connection.ExecuteScalar(cmd);
        }
        public User Login(string login, string password)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("login", login);
            cmd.AddParameter("password", password);
            User user = new User();
            try
            {
                user = _connection.ExecuteReader(cmd, reader => new User()
                {
                    Id = (int)reader["Id"],
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Birthdate = (DateTime)reader["Birthdate"],
                    Login = reader["Login"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    FirstLogin = (reader["FirstLogin"] is DBNull) ? default : (DateTime)reader["FirstLogin"],
                    StatusCode = (int)reader["StatusCode"],
                }).SingleOrDefault();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("LoginNotFound"))
                    throw new Exception(ex.Message);
                if (ex.Message.Contains("PasswordDoesntMatch"))
                    throw new Exception(ex.Message);
            }
            return user;
        }

        public DBErrors Create(User entity)
        {

            Command cmd = new Command("CreateUser", true);
            cmd.AddParameter("nationalNumber", entity.NationalNumber);
            cmd.AddParameter("lastName", entity.LastName);
            cmd.AddParameter("firstName", entity.FirstName);
            cmd.AddParameter("birthdate", entity.Birthdate);
            cmd.AddParameter("adCity", entity.AdCity);
            cmd.AddParameter("adPostalCode", entity.AdPostalCode);
            cmd.AddParameter("adStreet", entity.AdStreet);
            cmd.AddParameter("adNumber", entity.AdNumber);
            cmd.AddParameter("adBox", entity.AdBox);
            cmd.AddParameter("mobilePhone", entity.MobilePhone);
            cmd.AddParameter("gender", entity.Gender);
            cmd.AddParameter("photo", entity.Photo);
            cmd.AddParameter("personalNote", entity.PersonalNote);
            cmd.AddParameter("startDate", entity.StartDate);
            cmd.AddParameter("email", entity.Email);
            cmd.AddParameter("password", entity.Password);
            cmd.AddParameter("classId", entity.ClassId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Users_NationalNumber"))
                    return DBErrors.NationalNumber_Exist;
                else if (ex.Message.Contains("FK_Users_ClassId"))
                    return DBErrors.ClassId_NotFound;
                else if (ex.Message.Contains("CK_Users_StartDate"))
                    return DBErrors.StartDate_Birthdate_Error;
                else if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Update(User entity)
        {
            Command cmd = new Command("UpdateUser", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("nationalNumber", entity.NationalNumber);
            cmd.AddParameter("lastName", entity.LastName);
            cmd.AddParameter("firstName", entity.FirstName);
            cmd.AddParameter("birthdate", entity.Birthdate);
            cmd.AddParameter("adCity", entity.AdCity);
            cmd.AddParameter("adPostalCode", entity.AdPostalCode);
            cmd.AddParameter("adStreet", entity.AdStreet);
            cmd.AddParameter("adNumber", entity.AdNumber);
            cmd.AddParameter("adBox", entity.AdBox);
            cmd.AddParameter("mobilePhone", entity.MobilePhone);
            cmd.AddParameter("gender", entity.Gender);
            cmd.AddParameter("photo", entity.Photo);
            cmd.AddParameter("personalNote", entity.PersonalNote);
            cmd.AddParameter("startDate", entity.StartDate);
            cmd.AddParameter("email", entity.Email);
            cmd.AddParameter("password", entity.Password);
            cmd.AddParameter("classId", entity.ClassId);
            try
            {
                if (_connection.ExecuteNonQuery(cmd) > 0)
                    return DBErrors.Success;
                else
                    return DBErrors.UserId_NotFound;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Users_NationalNumber"))
                    return DBErrors.NationalNumber_Exist;
                else if (ex.Message.Contains("FK_Users_ClassId"))
                    return DBErrors.ClassId_NotFound;
                else if (ex.Message.Contains("CK_Users_StartDate"))
                    return DBErrors.StartDate_Birthdate_Error;
                else if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }

        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteUser", true);
            cmd.AddParameter("id", Id);
            if (_connection.ExecuteNonQuery(cmd) > 0)
                return DBErrors.Success;
            else
                return DBErrors.UserId_NotFound;
        }
        public IEnumerable<User> GetAll()
        {
            Command cmd = new Command("GetALLUsers", true);
            return _connection.ExecuteReader(cmd, r => new User()
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
            });
        }
        public DBErrors UnlinkUserFromLunches(int Id)
        {
            Command cmd = new Command("DeleteUserLunch_User", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public DBErrors UnlinkUserFromContacts(int Id)
        {
            Command cmd = new Command("DeleteUserContact_User", true);
            cmd.AddParameter("userId", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public DBErrors UnlinkUserFromStatus(int Id)
        {
            Command cmd = new Command("DeleteUserStatus", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public User GetById(int Id)
        {
            Command cmd = new Command("GetUser", true);
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => new User()
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
            }).SingleOrDefault();
        }

        public IEnumerable<User> GetAllByStatusId(int statusId)
        {
            Command cmd = new Command("GetAllUsersByStatusId", true);
            cmd.AddParameter("statusId", statusId);
            return _connection.ExecuteReader(cmd, r => new User()
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
            });
        }

        public IEnumerable<User> GetAllByClassId(int classId)
        {
            Command cmd = new Command("GetAllUsersByClassId", true);
            cmd.AddParameter("classId", classId);
            return _connection.ExecuteReader(cmd, r => new User()
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
            });
        }

    }
}




















