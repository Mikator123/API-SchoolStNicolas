using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using ToolBoxDB;

namespace DAL.Services.Repositories.Users
{
    public class UserRepository /*: IUserRepository<User>*/
    {
        private Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }
        public User Login(string login, string password)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("login", login);
            cmd.AddParameter("password", password);
            return _connection.ExecuteReader(cmd, reader => new User()
            {
                Id = (int)reader["Id"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                Birthdate = (DateTime)reader["Birthdate"],
                Login = reader["Login"].ToString(),
                Gender = reader["Gender"].ToString(),
                FirstLogin = (reader["FirstLogin"] is DBNull) ? default : (DateTime)reader["FirstLogin"],
                StatusCode = (int)reader["StatusCode"]
            }).SingleOrDefault();
        }

        public UserCodes Create(User entity)
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
            catch(SqlException ex)
            {
                if (ex.Message.Contains("UK_Users_NationalNumber"))
                    return UserCodes.NationalNumberExist;
                else if (ex.Message.Contains("FK_Users_ClassId"))
                    return UserCodes.ClassIdDoenstExist;
                else
                    return UserCodes.NotKnowedError;
            }
            return UserCodes.Success;

        }
    }

    //    public UserCodes Update(User entity)
    //    {
    //        Command cmd = new Command("UpdateUser", true);
    //        cmd.AddParameter("id", entity.Id);
    //        cmd.AddParameter("nationalNumber", entity.NationalNumber);
    //        cmd.AddParameter("lastName", entity.LastName);
    //        cmd.AddParameter("firstName", entity.FirstName);
    //        cmd.AddParameter("birthdate", entity.Birthdate);
    //        cmd.AddParameter("adCity", entity.AdCity);
    //        cmd.AddParameter("adPostalCode", entity.AdPostalCode);
    //        cmd.AddParameter("adStreet", entity.AdStreet);
    //        cmd.AddParameter("adNumber", entity.AdNumber);
    //        cmd.AddParameter("adBox", entity.AdBox);
    //        cmd.AddParameter("mobilePhone", entity.MobilePhone);
    //        cmd.AddParameter("gender", entity.Gender);
    //        cmd.AddParameter("photo", entity.Photo);
    //        cmd.AddParameter("personalNote", entity.PersonalNote);
    //        cmd.AddParameter("startDate", entity.StartDate);
    //        cmd.AddParameter("email", entity.Email);
    //        cmd.AddParameter("password", entity.Password);
    //        cmd.AddParameter("classId", entity.ClassId);
    //        return _connection.ExecuteNonQuery(cmd);
    //    }

    //    public UserCodes Delete(int Id)
    //    {
    //        Command cmd = new Command("DeleteUser", true);
    //        cmd.AddParameter("id", Id);
    //        return _connection.ExecuteNonQuery(cmd);
    //    }

    //    public IEnumerable<User> GetAll()
    //    {
    //        Command cmd = new Command("SELECT * FROM ViewUsers");
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }

    //    public User GetById(int Id)
    //    {
    //        Command cmd = new Command("SELECT * FROM ViewUsers WHERE Id = @id");
    //        cmd.AddParameter("id", Id);
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        }).SingleOrDefault();
    //    }




    //    public IEnumerable<User> GetAllStudents()
    //    {
    //        Command cmd = new Command("SELECT * FROM User_Status US JOIN Users U ON U.Id = US.UserId WHERE StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Student')");
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }

    //    public IEnumerable<User> GetAllProfessors()
    //    {
    //        Command cmd = new Command("SELECT * FROM User_Status US JOIN Users U ON U.Id = US.UserId WHERE StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Professor')");
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }

    //    public IEnumerable<User> GetAllManagers()
    //    {
    //        Command cmd = new Command("SELECT * FROM User_Status US JOIN Users U ON U.Id = US.UserId WHERE StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Manager')");
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }
    //    public IEnumerable<User> GetAllAdmins()
    //    {
    //        Command cmd = new Command("SELECT * FROM User_Status US JOIN Users U ON U.Id = US.UserId WHERE StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Admin')");
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }

    //    public IEnumerable<User> GetAllProfessorsByClassId(int classId)
    //    {
    //        Command cmd = new Command("SELECT * FROM User_Status US JOIN Users U ON U.Id = US.UserId WHERE StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Professor') AND U.ClassId = @id");
    //        cmd.AddParameter("id", classId);
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }

    //    public IEnumerable<User> GetAllStudentsByClassId(int classId)
    //    {
    //        Command cmd = new Command("SELECT * FROM User_Status US JOIN Users U ON U.Id = US.UserId WHERE StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Student') AND U.ClassId = @id");
    //        cmd.AddParameter("id", classId);
    //        return _connection.ExecuteReader(cmd, r => new User()
    //        {
    //            Id = (int)r["Id"],
    //            NationalNumber = r["NationalNumber"].ToString(),
    //            LastName = r["LastName"].ToString(),
    //            FirstName = r["FirstName"].ToString(),
    //            Birthdate = (DateTime)r["Birthdate"],
    //            AdCity = r["AdCity"].ToString(),
    //            AdPostalCode = (int)r["AdPostalCode"],
    //            AdStreet = r["AdStreet"].ToString(),
    //            AdNumber = (int)r["AdNumber"],
    //            AdBox = r["AdBox"] is DBNull ? null : r["AdBox"].ToString(),
    //            MobilePhone = r["MobilePhone"] is DBNull ? null : r["MobilePhone"].ToString(),
    //            Login = r["Login"].ToString(),
    //            Gender = r["Gender"].ToString(),
    //            Photo = r["Photo"] is DBNull ? null : r["Photo"].ToString(),
    //            PersonalNote = r["PersonalNote"] is DBNull ? null : r["PersonalNote"].ToString(),
    //            Email = r["Email"] is DBNull ? null : r["Email"].ToString(),
    //            StartDate = (DateTime)r["StartDate"],
    //            ClassId = (int)r["ClassId"]
    //        });
    //    }


    //    public UserCodes UnlinkUserFromLunches(int Id)
    //    {
    //        Command cmd = new Command("DeleteUserLunch_User", true);
    //        cmd.AddParameter("Id", Id);
    //        return _connection.ExecuteNonQuery(cmd);

    //    }

    //    public UserCodes UnlinkUserFromContacts(int Id)
    //    {
    //        Command cmd = new Command("DeleteUserContact_User", true);
    //        cmd.AddParameter("userId", Id);
    //        return _connection.ExecuteNonQuery(cmd);
    //    }

    //    public UserCodes UnlinkUserFromStatus(int Id)
    //    {
    //        Command cmd = new Command("DeleteUserLunch_User", true);
    //        cmd.AddParameter("userId", Id);
    //        return _connection.ExecuteNonQuery(cmd);
    //    }
    //}
}


