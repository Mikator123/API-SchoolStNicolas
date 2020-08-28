using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.Users
{
    public class ContactRepository : ICRUDRepository<Contact, DBErrors>, IManyToManyRepository<DBErrors>
    {
        private Connection _connection;

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
            catch
            {

            }
            return DBErrors.Success;


        }

        public DBErrors Create(Func<Contact> apitoDal)
        {
            throw new NotImplementedException();
        }

        public DBErrors Delete(int Id)
        {
            UnlinkEntityFromALL(Id);
            Command cmd = new Command("DeleteContact", true);
            cmd.AddParameter("id", Id);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch
            {

            }
            return DBErrors.Success;
        }

        public DBErrors Update(Contact entity)
        {
            Command cmd = new Command("UpdateContacts", true);
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
            catch
            {

            }
            return DBErrors.Success;
        }
        public IEnumerable<Contact> GetByUserId(int userId)
        {
            Command cmd = new Command("SELECT * FROM User_Contact UC RIGHT JOIN Contacts C ON C.Id = UC.ContactId WHERE UC.UserId = @userId");
            cmd.AddParameter("userId", userId);
            return _connection.ExecuteReader(cmd, r => new Contact()
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
            });
        }


        public Contact GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM ViewContacts WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => new Contact()
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
            }).SingleOrDefault();
        }

        public IEnumerable<Contact> GetAll()
        {
            Command cmd = new Command("SELECT * FROM ViewContacts");
            return _connection.ExecuteReader(cmd, r => new Contact()
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
            });
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
