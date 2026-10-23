using AgenticEngineer.Application.Common.Interfaces.Repositories;
using AgenticEngineer.Domain.Entities;
using AgenticEngineer.Persistence.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public UserRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(User user)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
            INSERT INTO Users (Id, Name, Email, CreatedAt, UpdatedAt)
            VALUES (@Id, @Name, @Email, @CreatedAt, @UpdatedAt)
            """;
            var parameters = new DynamicParameters();
            parameters.Add("Id", user.Id.ToString());
            parameters.Add("Name", user.Name);
            parameters.Add("Email", user.Email);
            parameters.Add("CreatedAt", user.CreatedAt);
            parameters.Add("UpdatedAt", user.UpdatedAt);
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);
            var count = await connection.ExecuteScalarAsync<int>(sql, parameters);
            return count > 0;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Users where Email=@Email ";
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);
            return await connection.QuerySingleOrDefaultAsync<User>(sql, parameters);

        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Users WHERE Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id.ToString());
            var result = await connection.QuerySingleOrDefaultAsync<User>(sql, parameters);
            return result!;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "Select * From Users";
            var result =await connection.QueryAsync<User>(sql);
            return result;
        }

        public async Task UpdateAsync(User user)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "UPDATE Users SET Name=@Name, Email=@Email, UpdatedAt=@UpdatedAt WHERE Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", user.Id.ToString());
            parameters.Add("Name", user.Name);
            parameters.Add("Email", user.Email);
            parameters.Add("UpdatedAt", user.UpdatedAt);
            await connection.ExecuteAsync(sql,parameters);
            
        }

        public async Task DeleteAsync(Guid id)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "Delete from Users where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id.ToString());
            await connection.ExecuteAsync(sql,parameters);
           
        }
    }
}
