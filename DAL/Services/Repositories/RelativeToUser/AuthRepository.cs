using DAL.Models.RelativeToUser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace DAL.Services.Repositories.RelativeToUser
{
    public class AuthRepository
    {
        private Connection _connection;
        public AuthRepository(Connection connection)
        {
            _connection = connection;
        }

        public User Login(string login, string password)
        {
            Command cmd = new Command("Login", true);
            cmd.AddParameter("login", login);
            cmd.AddParameter("password", password);
            User user = new User();
            try
            {
                user = _connection.ExecuteReader(cmd, reader => new User()
                {
                    Id = (int)reader["Id"],
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Birthdate = (DateTime)reader["Birthdate"],
                    Login = reader["Login"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    FirstLogin = (reader["FirstLogin"] is DBNull) ? default : (DateTime)reader["FirstLogin"],
                    StatusCode = (int)reader["StatusCode"],
                }).SingleOrDefault();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("LoginNotFound"))
                    throw new Exception(ex.Message);
                if (ex.Message.Contains("PasswordDoesntMatch"))
                    throw new Exception(ex.Message);
            }
            return user;
        }
    }
}
