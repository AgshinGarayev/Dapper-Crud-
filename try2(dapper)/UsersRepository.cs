using System;
using System.Data;
using Npgsql;
using Dapper;
using System.Threading.Tasks;
using try2_dapper_;

namespace try_dapper_
{
    internal class UsersRepository
    {
        private readonly IDbConnection _dbConnection;
        private const string TABLE_NAME = "users";

        public UsersRepository(string connectionString)
        {
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public async Task Add(Users user)
        {
            string commandText = $"INSERT INTO {TABLE_NAME} (email, password, name, location, join_date) " +
                                 "VALUES (@email, @password, @name, @location, @join_date)";

            var queryArguments = new
            {
                email = user.email,
                password = user.password,
                name = user.name,
                location = user.location,
                join_date = user.join_date
            };


            _dbConnection.Open();


            await _dbConnection.ExecuteAsync(commandText, queryArguments);


            _dbConnection.Close();
        }

        public void DeleteUser(int userId)
        {
            string commandText = $"DELETE FROM {TABLE_NAME} WHERE user_id = @userId";

            using (_dbConnection)
            {
                if (_dbConnection.State == ConnectionState.Closed)
                {
                    _dbConnection.Open();
                }

                _dbConnection.Execute(commandText, new { userId });

               
            }
        }



        public void UpdateUser(Users user)
        {
            string commandText = $"UPDATE {TABLE_NAME} " +
                                 "SET email = @email, " +
                                 "    password = @password, " +
                                 "    name = @name, " +
                                 "    location = @location, " +
                                 "    join_date = @join_date " +
                                 "WHERE user_id = @user_id";

            using (_dbConnection) 
            {
                if (_dbConnection.State == ConnectionState.Closed)
                {
                    _dbConnection.Open();
                }

                _dbConnection.Execute(commandText, user);

                
            }
        }


        public void GetUserById(int userId)
        {
            string commandText = $"SELECT email, password, name, location, join_date " +
                                 $"FROM {TABLE_NAME} WHERE user_id = @userId";

            using (_dbConnection)
            {
                if (_dbConnection.State == ConnectionState.Closed)
                {
                    _dbConnection.Open();
                }

                var user = _dbConnection.QueryFirstOrDefault<Users>(commandText, new { userId });

                if (user != null)
                {
                    Console.WriteLine($"User ID: {userId}");
                    Console.WriteLine($"Email: {user.email}");
                    Console.WriteLine($"Name: {user.name}");
                    Console.WriteLine($"Location: {user.location}");
                    Console.WriteLine($"Join Date: {user.join_date}");
                }
                else
                {
                    Console.WriteLine($"User with ID {userId} not found.");
                }
            }
        }

    }


}