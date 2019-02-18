using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeUserAndAwardSqlDao : IUserAndAwardDao
    {
        private string connectionString;

        public FakeUserAndAwardSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(UserAndAward userAndAward)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddDependency";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterAwardId = new SqlParameter("@AwardId", userAndAward.AwardId);
                command.Parameters.Add(parameterAwardId);

                SqlParameter parameterUserId = new SqlParameter("@UserId", userAndAward.UserId);
                command.Parameters.Add(parameterUserId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int awardId)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteDependencies";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterAwardId = new SqlParameter("@AwardId", awardId);
                command.Parameters.Add(parameterAwardId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<int> GetAll(int userId)
        {
            var result = new List<int>();

            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllDependencies";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserId = new SqlParameter("@UserId", userId);
                command.Parameters.Add(parameterUserId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add((int)reader["AwardId"]);
                }
            }

            return result;
        }
    }
}
