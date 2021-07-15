using Interface;
using Interface.Repositories;
using Interface.Services;
using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public UserDTO Add(UserDTO user)
        {
            return _userRepository.Add(user);
        }

        public UserDTO Delete(int ID)
        {
            return _userRepository.Delete(ID);
        }

        public UserDTO GetUserByID(int ID)
        {
            return _userRepository.GetUserByID(ID);
        }

        public List<UserDTO> GetUsers()
        {
            return new List<UserDTO>(_userRepository.GetUsers());
        }

        public UserDTO Update(UserDTO userChanges)
        {
            return _userRepository.Update(userChanges);
        }
    }
}
