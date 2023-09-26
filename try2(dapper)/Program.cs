using System;
using try_dapper_;
using try2_dapper_;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Aqsin1213;Database=Mytask;";
        UsersRepository usersRepository = new UsersRepository(connectionString);

      
        Users user = new Users
        {
            email = "example@emailaaaaaa.com",
            password = "password123",
            name = "AGSHIN GARAYEV",
            location = "Some Location",
            join_date = DateTime.Now
        };

        //usersRepository.Add(user);
        //usersRepository.UpdateUser(user);
        //usersRepository.DeleteUser(20);
        //usersRepository.GetUserById(9);

    }
}