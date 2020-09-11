using Model.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Persistence
{
    public class UserRepository : IUserRepo
    {
        SqliteConnectionFactory sqliteConnection;

        public UserRepository(SqliteConnectionFactory sqliteConnection)
        {
            this.sqliteConnection = sqliteConnection;
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> findAll()
        {
            throw new NotImplementedException();
        }

        public User findOne(int id)
        {
            throw new NotImplementedException();
        }

        public User findUser(string username, string password)
        {
            SQLiteConnection connection = sqliteConnection.getConnection();
            SQLiteCommand command = new SQLiteCommand("select * from User u where u.name=@name and u.password=@pass", connection);
            command.Parameters.AddWithValue("@name", username);
            command.Parameters.AddWithValue("@pass", password);


            SQLiteDataReader reader = command.ExecuteReader();
            bool isOk = reader.Read();
            if (isOk)
                return new User(username, password);
            return null;

        }

        public void save(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
