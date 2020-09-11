using System;
using System.Collections.Generic;
using System.Text;

namespace Model.model
{
    public class User : IEntity<int>
    {
        private string username;
        private string password;
        private int idUser;

        public User() { }
        public User(string username)
        {
            this.username = username;
        }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public int Id
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }

        }
    }
}
