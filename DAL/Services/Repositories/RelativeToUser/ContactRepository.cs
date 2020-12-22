using DAL.Enumerations;
using DAL.Models.RelativeToUser;
using DAL.Services.IRepositories;
using DAL.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.RelativeToUser
{
    public class ContactRepository : ICRUDRepository<Contact, DBErrors>, IManyToManyRepository<DBErrors>
    {
        private readonly Connection _connection;

        public ContactRepository(Connection connection)
        {
            _connection = connection;
        }

        public DBErrors Create(Contact entity)
        {
            Command cmd = new Command("CreateContact", true);
            cmd.AddParameter("nationalNumber", entity.NationalNumber);
            cmd.AddParameter("lastName", entity.LastName);
            cmd.AddParameter("firstName", entity.FirstName);
            cmd.AddParameter("birthdate", entity.BirthDate);
            cmd.AddParameter("adCity", entity.AdCity);
            cmd.AddParameter("adPostalCode", entity.AdPostalCode);
            cmd.AddParameter("adStreet", entity.AdStreet);
            cmd.AddParameter("adNumber", entity.AdNumber);
            cmd.AddParameter("adBox", entity.AdBox);
            cmd.AddParameter("mobilePhone", entity.MobilePhone);
            cmd.AddParameter("gender", entity.Gender);
            cmd.AddParameter("email", entity.Email);
            cmd.AddParameter("personalNote", entity.PersonalNote);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Users_NationalNumber"))
                    return DBErrors.NationalNumber_Exist;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }


        public DBErrors Delete(int Id)
        {
            UnlinkEntityFromALL(Id);
            Command cmd = new Command("DeleteContact", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }


        public DBErrors Update(Contact entity)
        {
            Command cmd = new Command("UpdateContact", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("nationalNumber", entity.NationalNumber);
            cmd.AddParameter("lastName", entity.LastName);
            cmd.AddParameter("firstName", entity.FirstName);
            cmd.AddParameter("birthdate", entity.BirthDate);
            cmd.AddParameter("adCity", entity.AdCity);
            cmd.AddParameter("adPostalCode", entity.AdPostalCode);
            cmd.AddParameter("adStreet", entity.AdStreet);
            cmd.AddParameter("adNumber", entity.AdNumber);
            cmd.AddParameter("adBox", entity.AdBox);
            cmd.AddParameter("mobilePhone", entity.MobilePhone);
            cmd.AddParameter("gender", entity.Gender);
            cmd.AddParameter("email", entity.Email);
            cmd.AddParameter("personalNote", entity.PersonalNote);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_Users_NationalNumber"))
                    return DBErrors.NationalNumber_Exist;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }


        public IEnumerable<Contact> GetByUserId(int userId)
        {
            Command cmd = new Command("SELECT * FROM User_Contact UC RIGHT JOIN Contacts C ON C.Id = UC.ContactId WHERE UC.UserId = @userId");
            cmd.AddParameter("userId", userId);
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalContact());
        }


        public Contact GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM ViewContacts WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalContact()).SingleOrDefault();

        }

        public IEnumerable<Contact> GetAll()
        {
            Command cmd = new Command("SELECT * FROM ViewContacts");
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalContact());
        }

        public DBErrors LinkEntityWithUser(int entityId, int userId)
        {
            Command cmd = new Command("CreateUserContact", true);
            cmd.AddParameter("userId", userId);
            cmd.AddParameter("contactId", entityId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PK_User_Contact"))
                    return DBErrors.LinkAlreadyExist;
            }
            return DBErrors.Success;
        }

        public DBErrors UnlinkEntityFromUser(int entityId, int userId)
        {
            Command cmd = new Command("DeleteUserContact_OneByOne", true);
            cmd.AddParameter("userId", userId);
            cmd.AddParameter("contactId", entityId);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public DBErrors UnlinkEntityFromALL(int entityId)
        {
            Command cmd = new Command("DeleteUserContact_Contact", true);
            cmd.AddParameter("contactId", entityId);
             _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }
    }
}
