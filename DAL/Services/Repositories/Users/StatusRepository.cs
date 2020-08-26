using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.Users
{
    public class StatusRepository : ICRUDRepository<Status> , IManyToManyRepository
    {
        private Connection _connection;
        public StatusRepository(Connection connection)
        {
            _connection = connection;
        }


        public int Create(Status entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public int Update(Status entity)
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
            Command cmd = new Command("SELECT * FROM User_Status WHERE UserId = @userId");
            cmd.AddParameter("userId", Id);
            return _connection.ExecuteReader(cmd, r => new Status()
            {
                Id = (int)r["Id"],
                Name = r["StatusName"].ToString()
            });
        }

        public int LinkEntityWithUser(int entityId, int userId)
        {
            Command cmd = new Command("CreateUserStatus", true);
            cmd.AddParameter("id", userId);
            cmd.AddParameter("statusId", entityId);
            return _connection.ExecuteNonQuery(cmd);
        }

        public int UnlinkEntityFromALL(int entityId)
        {
            Command cmd = new Command("DeleteUserStatus", true);
            cmd.AddParameter("statusId", entityId);
            return _connection.ExecuteNonQuery(cmd);
        }

        public int UnlinkEntityFromUser(int entityId, int userId)
        {
            Command cmd = new Command("DeleteUserStatus", true);
            cmd.AddParameter("Id", userId);
            cmd.AddParameter("statusId", entityId);
            return _connection.ExecuteNonQuery(cmd);
        }


    }
}
