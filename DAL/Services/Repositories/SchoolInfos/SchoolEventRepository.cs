using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using DAL.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.SchoolInfos
{
    public class SchoolEventRepository : ICRUDRepository<SchoolEvent, DBErrors>
    {
        private Connection _connection;
        public SchoolEventRepository(Connection connection)
        {
            _connection = connection;
        }

        public DBErrors Create(SchoolEvent entity)
        {
            Command cmd = new Command("CreateSchoolEvent", true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("date", entity.Date);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("[UK_SchoolEvents_EventName]"))
                    return DBErrors.Name_Exist;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            throw new NotImplementedException("Not needed here.");
        }

        public DBErrors Delete(SchoolEvent entity)
        {
            Command cmd = new Command("DeleteSchoolEvent", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("nbrOfPersons", entity.NbrOfPersons);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public IEnumerable<SchoolEvent> GetAll()
        {
            Command cmd = new Command("SELECT * FROM ViewSchoolEvents");
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalEvent());
        }

        public IEnumerable<SchoolEvent> GetNotActive()
        {
            Command cmd = new Command("SELECT * FROM [SchoolEvents] WHERE isActive = 0");
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalEvent());
        }

        public SchoolEvent GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [SchoolEvents] WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalEvent()).SingleOrDefault();
        }

        public IEnumerable<SchoolEvent> GetByUserId(int userId)
        {
            throw new NotImplementedException("Not Needed Here.");
        }

        public DBErrors Update(SchoolEvent entity)
        {
            Command cmd = new Command("UpdateSchoolEvent", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("date", entity.Date);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[UK_SchoolEvents_EventName]"))
                    return DBErrors.Name_Exist;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }
    }
}
