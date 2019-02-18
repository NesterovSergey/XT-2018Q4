using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeAccountSqlDao : IAccountDao
    {
        private string connectionString;
        private const string DefaultRole = "user";

        public FakeAccountSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public object Account { get; private set; }

        public void AssignRole(string username, string role)
        {
            Account account = GetAccountByUsername(username);

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AssignRole";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUsername = new SqlParameter("@Username", username);
                command.Parameters.Add(parameterUsername);

                SqlParameter parameterRole = new SqlParameter("@UserRole", role);
                command.Parameters.Add(parameterRole);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Account> GetAll()
        {
            var result = new List<Account>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllAccounts";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Account
                        {
                            Id = (int)reader["Id"],
                            Username = (string)reader["Username"],
                            Role = (string)reader["UserRole"],
                        });
                }
            }

            return result;
        }

        public string GetRole(string username)
        {
            Account account = GetAccountByUsername(username);

            if (account == null)
            {
                throw new Exception("There is no user with the username");
            }

            return account.Role;
        }

        public string LogIn(string username)
        {
            Account account = GetAccountByUsername(username);

            if (account == null)
            {
                throw new Exception("There is no user with the username");
            }

            return account.HashedPassword;
        }

        public bool Registration(string username, string password)
        {
            if (GetAccountByUsername(username) != null)
            {
                throw new ArgumentException("Username with this name already exists");
            }
            else
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "AddAccount";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameterUsername = new SqlParameter("@Username", username);
                    command.Parameters.Add(parameterUsername);

                    SqlParameter parameterPassword = new SqlParameter("@HashedPassword", password);
                    command.Parameters.Add(parameterPassword);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }

                return true;
            }
        }

        private Account GetAccountByUsername(string username)
        {
            Account account = null;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAccountByUsername";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUsername = new SqlParameter("@Username", username);
                command.Parameters.Add(parameterUsername);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    account = new Account
                    {
                        HashedPassword = (string)reader["HashedPassword"],
                        Role = (string)reader["UserRole"],
                    };
                }

                return account;
            }
        }
    }
}
