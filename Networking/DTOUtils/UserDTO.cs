using System;
using System.Collections.Generic;
using System.Text;

namespace Model.model
{
    [Serializable]
    public class UserDTO
    {
        private string username;
        private string password;
        private int idUser;

        public UserDTO() { }
        public UserDTO(string username)
        {
            this.username = username;
        }
        public UserDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public int Id
        {
            get { return idUser; }

        }

        public string Username
        {
            get { return username; }

        }

        public string Password
        {
            get { return password; }


        }
    }
}
