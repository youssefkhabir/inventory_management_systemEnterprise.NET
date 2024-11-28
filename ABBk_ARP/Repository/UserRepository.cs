using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using ABBk_ARP.Model;

namespace ABBk_ARP.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
               
                command.CommandText = @"INSERT INTO [User] 
                                (Id, Username, Password, Name, LastName, Email) 
                                VALUES 
                                (@Id, @Username, @Password, @Name, @LastName, @Email)";

                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = userModel.Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = userModel.Password;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = userModel.Name;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userModel.LastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = userModel.Email;

                command.ExecuteNonQuery();
            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
    }
}
