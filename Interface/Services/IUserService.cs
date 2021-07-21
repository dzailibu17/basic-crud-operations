using Model.DTOs;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IUserService
    {
        UserDTO GetUserByID(int ID);
        List<UserDTO> GetUsers();
        UserDTO AddUser(UserDTO user);
        UserDTO UpdateUser(UserDTO userChanges);
        UserDTO DeleteUser(int ID);        
    }
}
