using Interface.Repositories;
using Interface.Services;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public UserDTO AddUser(UserDTO user)
        {
            return _userRepository.AddUser(user);
        }

        public UserDTO DeleteUser(int ID)
        {
            return _userRepository.DeleteUser(ID);
        }

        public UserDTO GetUserByID(int ID)
        {
            return _userRepository.GetUserByID(ID);
        }

        public List<UserDTO> GetUsers()
        {
            return _userRepository.GetUsers().ToList();
        }

        public UserDTO UpdateUser(UserDTO userChanges)
        {
            return _userRepository.UpdateUser(userChanges);
        }
    }
}
