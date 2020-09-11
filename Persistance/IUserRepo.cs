using System;
using System.Collections.Generic;
using System.Text;
using Model.model;

namespace Persistence
{
    public interface IUserRepo : ICRUDRepository<int, User>
    {

        User findUser(string username, string password);
        //public User findUser(string username, string password);

    }
}
