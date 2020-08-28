using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.Users
{
    public class StatusRepository : ICRUDRepository<Status, DBErrors> , IManyToManyRepository<DBErrors>
    {
        private Connection _connection;
        public StatusRepository(Connection connection)
        {
            _connection = connection;
        }


        public DBErrors Create(Status entity)
        {
            throw new NotImplementedException();
        }

        public DBErrors Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public DBErrors Update(Status entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Status> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Status");
            return _connection.ExecuteReader(cmd, r => new Status()
            {
                Id = (int)r["Id"],
                Name = r["StatusName"].ToString()
            });
        }

        public Status GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Status WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => new Status()
            {
                Id = (int)r["Id"],
                Name = r["StatusName"].ToString()
            }).SingleOrDefault();
        }

        public IEnumerable<Status> GetByUserId(int Id)
        {
            Command cmd = new Command("SELECT * FROM User_Status US JOIN Status S ON US.[StatusId] = S.Id WHERE US.UserId = @userId");
            cmd.AddParameter("userId", Id);
            return _connection.ExecuteReader(cmd, r => new Status()
            {
                Id = (int)r["Id"],
                Name = r["StatusName"].ToString()
            });
        }

        public DBErrors LinkEntityWithUser(int entityId, int userId)
        {
            Command cmd = new Command("CreateUserStatus", true);
            cmd.AddParameter("id", userId);
            cmd.AddParameter("statusId", entityId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PK_User_Status"))
                    return DBErrors.LinkAlreadyExist;
            }
            return DBErrors.Success;
        }

        public DBErrors UnlinkEntityFromALL(int entityId)
        {
            Command cmd = new Command("DeleteUserStatus", true);
            cmd.AddParameter("statusId", entityId);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public DBErrors UnlinkEntityFromUser(int entityId, int userId)
        {
            Command cmd = new Command("DeleteUserStatus", true);
            cmd.AddParameter("Id", userId);
            cmd.AddParameter("statusId", entityId);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }


    }
}
