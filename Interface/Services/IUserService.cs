using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
    }
}
