using Model.DTOs;
using System.Collections.Generic;

namespace Interface.Repositories
{
    public interface IUserRepository
    {
        UserDTO GetUserByID(int ID);
        IEnumerable<UserDTO> GetUsers();
        UserDTO AddUser(UserDTO user);
        UserDTO UpdateUser(UserDTO userChanges);
        UserDTO DeleteUser(int ID);
    }
}
