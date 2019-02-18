using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeUserSqlDao : IUserDao
    {
        private string connectionString;

        public FakeUserSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(User user)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUsername = new SqlParameter("@Username", user.Name);
                command.Parameters.Add(parameterUsername);

                SqlParameter parameterDateOfBirth = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                command.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterUserImage = new SqlParameter("@UserImage", user.Image);
                command.Parameters.Add(parameterUserImage);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();

                return true;
            }
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllUsers";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new User
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Username"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Image = (byte[])reader["UserImage"],
                        });
                }
            }

            return result;
        }

        public User GetById(int id)
        {
            User user = null;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetUserById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Username"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Image = Encoding.ASCII.GetBytes((string)reader["UserImage"]),
                    };
                }

                return user;
            }
        }

        public bool Update(int id, string newName, DateTime newDate, byte[] newImage)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                SqlParameter parameterUsername = new SqlParameter("@Username", newName);
                command.Parameters.Add(parameterUsername);

                SqlParameter parameterDateOfBirth = new SqlParameter("@DateOfBirth", newDate);
                command.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterUserImage = new SqlParameter("@UserImage", newImage);
                command.Parameters.Add(parameterUserImage);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
