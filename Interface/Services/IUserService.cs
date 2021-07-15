using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IUserService
    {
        UserDTO GetUserByID(int ID);
        List<UserDTO> GetUsers();
        UserDTO Add(UserDTO user);
        UserDTO Update(UserDTO userChanges);
        UserDTO Delete(int ID);        
    }
}
