using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeAwardSqlDao : IAwardDao
    {
        private string connectionString;

        public FakeAwardSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Award award)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAward";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterTitle = new SqlParameter("@Title", award.Title);
                command.Parameters.Add(parameterTitle);
                SqlParameter parameterAwardImage;

                parameterAwardImage = new SqlParameter("@AwardImage", award.Image);

                command.Parameters.Add(parameterAwardImage);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();

                command.CommandText = "DeleteAward";

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();

                return true;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var result = new List<Award>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllAwards";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Award
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Image = (byte[])reader["AwardImage"],
                        });
                }
            }

            return result;
        }

        public Award GetById(int id)
        {
            Award award = null;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAwardById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    award = new Award
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Image = (byte[])reader["AwardImage"],
                    };
                }

                return award;
            }
        }

        public bool Update(int id, string newTitle, byte[] newImage)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateAward";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                SqlParameter parameterTitle = new SqlParameter("@Title", newTitle);
                command.Parameters.Add(parameterTitle);

                SqlParameter parameterAwardImage = new SqlParameter("@AwardImage", newImage);
                command.Parameters.Add(parameterAwardImage);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}
