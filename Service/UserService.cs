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

        public List<UserDTO> GetUsers()
        {
            return new List<UserDTO>(_userRepository.GetUsers());
        }
    }
}
