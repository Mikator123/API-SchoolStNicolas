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
    public class TestResultRepository : ICRUDRepository<TestResult, DBErrors>
    {
        private Connection _connection;
        public TestResultRepository(Connection connection)
        {
            _connection = connection;
        }

        public DBErrors Create(TestResult entity)
        {
            Command cmd = new Command("CreateTestResult", true);
            cmd.AddParameter("date", entity.Date);
            cmd.AddParameter("result", entity.Result);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("categoryId", entity.CategoryId);
            cmd.AddParameter("userId", entity.StudentId);
            cmd.AddParameter("document", entity.Document);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[FK_TestResults_Users]"))
                    return DBErrors.UserId_NotFound;
                if (ex.Message.Contains("[FK_TestResults_Categories]"))
                    return DBErrors.TeachingCategoryId_NotFound;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("[CK_TestResults_Result]"))
                    return DBErrors.IncorrectNumber;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteTestResult", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
                
        }

        public IEnumerable<TestResult> GetAll()
        {
            Command cmd = new Command("Select * from TestResults");
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTestResult());
        }

        public TestResult GetById(int Id)
        {
            Command cmd = new Command("Select * from TestResults WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTestResult()).SingleOrDefault();
        }

        public IEnumerable<TestResult> GetByUserId(int userId)
        {
            Command cmd = new Command("Select * from TestResults WHERE UserId = @userId");
            cmd.AddParameter("userId", userId);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTestResult());
        }

        public IEnumerable<TestResult> GetByCategoryId(int catId)
        {
            Command cmd = new Command("Select * from TestResults WHERE CategoryId = @id");
            cmd.AddParameter("id", catId);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTestResult());
        }

        public DBErrors Update(TestResult entity)
        {
            Command cmd = new Command("UpdateTestResult", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("date", entity.Date);
            cmd.AddParameter("result", entity.Result);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("categoryId", entity.CategoryId);
            cmd.AddParameter("userId", entity.StudentId);
            cmd.AddParameter("document", entity.Document);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[FK_TestResults_Users]"))
                    return DBErrors.UserId_NotFound;
                if (ex.Message.Contains("[FK_TestResults_Categories]"))
                    return DBErrors.TeachingCategoryId_NotFound;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                if (ex.Message.Contains("[CK_TestResults_Result]"))
                    return DBErrors.IncorrectNumber;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public IEnumerable<TestResult> GetByClassId(int classId)
        {
            Command cmd = new Command("SELECT * FROM TestResults WHERE ClassId = @id");
            cmd.AddParameter("id", classId);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalTestResult());
        }
    }
}
