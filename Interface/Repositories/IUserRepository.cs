using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Repositories
{
    public interface IUserRepository
    {
        UserDTO GetUserByID(int ID);
        IEnumerable<UserDTO> GetUsers();
        UserDTO Add(UserDTO user);
        UserDTO Update(UserDTO userChanges);
        UserDTO Delete(int ID);
    }
}
