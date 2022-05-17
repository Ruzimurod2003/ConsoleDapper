using Dapper;
using DotnetUz.Model;
using System.Data;
using System.Data.SqlClient;

namespace DotnetUz
{
    public interface IUserRepository
    {
        int MaxId();
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<User> GetUsers();
        void Update(User user);
        int Count { get; }
    }
    public class UserRepository : IUserRepository
    {
        string? connectionString = @"Data Source=(localdb)\Ruzimurod;Initial Catalog=UzDotnet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Count
        {
            get
            {
                IDbConnection db = new SqlConnection(connectionString);
                db.Open();
                return db.QuerySingleOrDefault<int>("SELECT COUNT(Id) FROM Users");
            }
        }
        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }
        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault() ?? new User { };
            }
        }
        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users VALUES(@Id, @Name, @Age)";
                db.Execute(sqlQuery, user);
            }
        }
        public int MaxId()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "SELECT MAX(Id)+1 FROM Users";
                return db.QuerySingleOrDefault<int>(sqlQuery);
            }
        }
        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}

