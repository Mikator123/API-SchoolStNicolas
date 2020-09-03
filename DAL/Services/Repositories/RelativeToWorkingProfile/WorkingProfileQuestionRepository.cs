using DAL.Enumerations;
using DAL.Models;
using DAL.Models.RelativeToClass;
using DAL.Models.RelativeToWorkingProfile;
using DAL.Services.IRepositories;
using DAL.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.RelativeToWorkingProfile
{
    public class WorkingProfileQuestionRepository : ICRUDRepository<WorkingProfileQuestion, DBErrors>
    {
        private Connection _connection;

        public WorkingProfileQuestionRepository(Connection connection)
        {
            _connection = connection;
        }
        public DBErrors Create(WorkingProfileQuestion entity)
        {
            Command cmd = new Command("CreateQuestion", true);
            cmd.AddParameter("question", entity.Question);
            cmd.AddParameter("correction", entity.Correction);
            cmd.AddParameter("explanation", entity.Explanation);
            cmd.AddParameter("firstHint", entity.FirstHint);
            cmd.AddParameter("secondHint", entity.SecondHint);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("categoryId", entity.CategoryId);
            cmd.AddParameter("trimester", entity.Trimester);
            cmd.AddParameter("schoolYearCategoryId", entity.SchoolYearCategoryId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("[FK_Questions_Categories]"))
                    return DBErrors.TeachingCategoryId_NotFound;
                if (ex.Message.Contains("[FK_Questions_SchoolYearCategoryNames]"))
                    return DBErrors.YearCategoryId_NotFound;
                if (ex.Message.Contains("[CK_Questions_Trimester]"))
                    return DBErrors.IncorrectNumber;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteQuestion",true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public IEnumerable<WorkingProfileQuestion> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Questions");
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalDistTest());
        }

        public WorkingProfileQuestion GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Questions WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, x => x.ReaderToDalDistTest()).SingleOrDefault();
        }

        public IEnumerable<WorkingProfileQuestion> GetByUserId(int userId)
        {
            throw new NotImplementedException("Not Needed.");
        }

        public DBErrors Update(WorkingProfileQuestion entity)
        {
            Command cmd = new Command("UpdateQuestion", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("question", entity.Question);
            cmd.AddParameter("correction", entity.Correction);
            cmd.AddParameter("explanation", entity.Explanation);
            cmd.AddParameter("firstHint", entity.FirstHint);
            cmd.AddParameter("secondHint", entity.SecondHint);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("categoryId", entity.CategoryId);
            cmd.AddParameter("trimester", entity.Trimester);
            cmd.AddParameter("schoolYearCategoryId", entity.SchoolYearCategoryId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[FK_Questions_Categories]"))
                    return DBErrors.TeachingCategoryId_NotFound;
                if (ex.Message.Contains("[FK_Questions_SchoolYearCategoryNames]"))
                    return DBErrors.YearCategoryId_NotFound;
                if (ex.Message.Contains("[CK_Questions_Trimester]"))
                    return DBErrors.IncorrectNumber;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }
    }
}
