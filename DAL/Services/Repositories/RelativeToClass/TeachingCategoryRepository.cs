using DAL.Enumerations;
using DAL.Models;
using DAL.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using ToolBoxDB;
using DAL.Services.Mappers;
using System.Linq;
using System.Data.SqlClient;
using DAL.Models.RelativeToClass;

namespace DAL.Services.Repositories.RelativeToClass
{
    public class TeachingCategoryRepository : ICRUDRepository<TeachingCategory, DBErrors>
    {
        private Connection _connection;
        public TeachingCategoryRepository(Connection connection)
        {
            _connection = connection;
        }

        public DBErrors Create(TeachingCategory entity)
        {
            Command cmd = new Command("CreateCategory", true);
            cmd.AddParameter("name", entity.Name);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("[UK_SchoolYearCategoryNames_CategoryName]"))
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
            Command cmd = new Command("DeleteCategory", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public IEnumerable<TeachingCategory> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Categories");
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalTeachCategory());
            
        }

        public TeachingCategory GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Categories WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalTeachCategory()).SingleOrDefault();
        }

        public IEnumerable<TeachingCategory> GetByUserId(int userId)
        {
            throw new NotImplementedException("Not needed.");
        }

        public DBErrors Update(TeachingCategory entity)
        {
            Command cmd = new Command("UpdateCategory", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("name", entity.Name);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[CK_Classes_ClassName]"))
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
