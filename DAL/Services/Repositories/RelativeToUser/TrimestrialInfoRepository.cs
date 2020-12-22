using DAL.Enumerations;
using DAL.Models;
using DAL.Models.RelativeToUser;
using DAL.Services.IRepositories;
using DAL.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.RelativeToUser
{
    public class TrimestrialInfoRepository : ICRUDRepository<TrimestrialInfo, DBErrors>
    {
        private readonly Connection _connection;
        public TrimestrialInfoRepository(Connection connection)
        {
            _connection = connection;
        }
        public DBErrors Create(TrimestrialInfo entity)
        {
            Command cmd = new Command("CreateTrimestrialInfo", true);
            cmd.AddParameter("description",entity.Description);
            cmd.AddParameter("trimester", entity.Trimester);
            cmd.AddParameter("userId", entity.UserId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("FK_TrimestrialInfos_Users"))
                    return DBErrors.UserId_NotFound;
                if (ex.Message.Contains("CK_TrimestrialInfos_YearQuarter"))
                    return DBErrors.YearQuarter_NotFound;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteTrimestrialInfo", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public IEnumerable<TrimestrialInfo> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [TrimestrialInfos]");
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTrim());
        }

        public TrimestrialInfo GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [TrimestrialInfos] WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTrim()).SingleOrDefault();
        }

        public IEnumerable<TrimestrialInfo> GetByUserId(int userId)
        {
            Command cmd = new Command("SELECT * FROM [TrimestrialInfos] WHERE UserId = @userId");
            cmd.AddParameter("userId", userId);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTrim());
        }

        public DBErrors Update(TrimestrialInfo entity)
        {
            Command cmd = new Command("UpdateTrimestrialInfo", true);
            cmd.AddParameter("Id", entity.Id);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("trimester", entity.Trimester);
            cmd.AddParameter("userId", entity.UserId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("FK_TrimestrialInfos_Users"))
                    return DBErrors.UserId_NotFound;
                if (ex.Message.Contains("CK_TrimestrialInfos_YearQuarter"))
                    return DBErrors.YearQuarter_NotFound;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }
    }
}
