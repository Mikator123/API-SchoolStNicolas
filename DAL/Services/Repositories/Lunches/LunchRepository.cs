using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.Lunches
{
    public class LunchRepository : ICRUDRepository<Lunch, DBErrors>, IManyToManyRepository<DBErrors>
    {
        private Connection _connection;

        public LunchRepository(Connection connection)
        {
            _connection = connection;
        }

        public DBErrors Create(Lunch entity)
        {
            Command cmd = new Command("CreateLunch", true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("lunchDate", entity.Date);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message != null)
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }
        public DBErrors Update(Lunch entity)
        {
            Command cmd = new Command("UpdateLunch", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("lunchDate", entity.Date);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message != null)
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteLunch", true);
            cmd.AddParameter("id", Id);
            return DBErrors.Success;
        }

        public IEnumerable<Lunch> GetAll()
        {
            Command cmd = new Command("Select * FROM Lunches");
            return _connection.ExecuteReader(cmd, r => new Lunch()
            {
                Id = (int)r["Id"],
                Name = r["LunchName"].ToString(),
                Description = r["LunchDescription"] is DBNull ? null : r["LunchDescription"].ToString(),
                Date = (DateTime)r["LunchDate"]
            });

        }

        public IEnumerable<Lunch> GetByUserId (int userId)
        {
            Command cmd = new Command("SELECT * FROM User_Lunch UL RIGHT JOIN Lunches L ON UL.LunchId = L.Id WHERE UL.UserId = @id");
            cmd.AddParameter("id", userId);
            return _connection.ExecuteReader(cmd, r => new Lunch()
            {
                Id = (int)r["Id"],
                Name = r["LunchName"].ToString(),
                Description = r["LunchDescription"] is DBNull ? null : r["LunchDescription"].ToString(),
                Date = (DateTime)r["LunchDate"]
            });
        }

        public Lunch GetById(int Id)
        {
            Command cmd = new Command("Select * FROM Lunches WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => new Lunch()
            {
                Id = (int)r["Id"],
                Name = r["LunchName"].ToString(),
                Description = r["LunchDescription"] is DBNull ? null : r["LunchDescription"].ToString(),
                Date = (DateTime)r["LunchDate"]
            }).SingleOrDefault();
        }

        public DBErrors LinkEntityWithUser(int entityId, int userId)
        {
            Command cmd = new Command("CreateUserLunch", true);
            cmd.AddParameter("userId", userId);
            cmd.AddParameter("lunchId", entityId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("PK_User_Lunch"))
                    return DBErrors.LinkAlreadyExist;
            }
            return DBErrors.Success;
        }

        public DBErrors UnlinkEntityFromALL(int entityId)
        {
            Command cmd = new Command("DeleteUserLunch_Lunch", true);
            cmd.AddParameter("id", entityId);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public DBErrors UnlinkEntityFromUser(int entityId, int userId)
        {
            Command cmd = new Command("DeleteUserLunch_OneByOne", true);
            cmd.AddParameter("lunchId", entityId);
            cmd.AddParameter("userId", userId);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }


    }
}
