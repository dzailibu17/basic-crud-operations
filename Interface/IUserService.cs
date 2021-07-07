using Model;
using System;
using System.Collections.Generic;

namespace Interface
{
    public interface IUserService
    {
        User GetUserByID(int ID);
        IEnumerable<User> GetUsers();
        User Add(User user);
        User Update(User userChanges);
        User Delete(int ID);
    }
}
