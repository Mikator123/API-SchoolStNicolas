﻿using DAL.Enumerations;
using DAL.Models;
using DAL.Models.RelativeToClass;
using DAL.Services.IRepositories;
using DAL.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.RelativeToClass
{
    public class ClassRepository : ICRUDRepository<Class, DBErrors>
    {
        private readonly Connection _connection;

        public ClassRepository(Connection connection)
        {
            _connection = connection;
        }

        public DBErrors Create(Class entity)
        {
            Command cmd = new Command("CreateClass", true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("schoolYearCategoryId", entity.SchoolYearCategoryId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("[CK_Classes_ClassName]"))
                    return DBErrors.Name_Exist;
                if (ex.Message.Contains("[FK_Classes_SchoolYearCategoryNames]"))
                    return DBErrors.YearCategoryId_NotFound;
                if (ex.Message.Contains("NULL"))
                    return DBErrors.NullExeption;
                else
                    return DBErrors.NotKnowedError;
            }
            return DBErrors.Success;
        }

        public DBErrors Delete(int Id)
        {
            Command cmd = new Command("DeleteClass", true);
            cmd.AddParameter("id", Id);
            _connection.ExecuteNonQuery(cmd);
            return DBErrors.Success;
        }

        public IEnumerable<Class> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Classes");
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalClass());
        }

        public Class GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Classes WHERE Id = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalClass()).SingleOrDefault();
        }

        public IEnumerable<Class> GetByUserId(int userId)
        {
            throw new NotImplementedException("Already in UserRepository");
        }
        public IEnumerable<Class> GetByCategoryId(int Id)
        {
            Command cmd = new Command("SELECT * FROM Classes WHERE SchoolYearCategoryId = @id");
            cmd.AddParameter("id", Id);
            return _connection.ExecuteReader(cmd, r => r.ReaderToDalClass());
        }

        public DBErrors Update(Class entity)
        {
            Command cmd = new Command("UpdateClass", true);
            cmd.AddParameter("id", entity.Id);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("description", entity.Description);
            cmd.AddParameter("schoolYear", entity.SchoolYear);
            cmd.AddParameter("schoolYearCategoryId", entity.SchoolYearCategoryId);
            try
            {
                _connection.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("[CK_Classes_ClassName]"))
                    return DBErrors.Name_Exist;
                if (ex.Message.Contains("[FK_Classes_SchoolYearCategoryNames]"))
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
