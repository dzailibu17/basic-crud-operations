using AutoMapper;
using Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Exceptions;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbModels.DbModels _context;
        private readonly IMapper _mapper;

        public UserRepository(DbModels.DbModels context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserDTO AddUser(UserDTO userDTO)
        {
            _context.Users.Add(_mapper.Map<User>(userDTO));
            _context.SaveChanges();

            return userDTO;
        }

        public UserDTO DeleteUser(int ID)
        {
            User user = _context.Users.Find(ID);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return _mapper.Map<UserDTO>(user);
            }

            throw new NotFoundException(String.Format("User with ID = {0} does not exist.", ID));
        }

        public UserDTO GetUserByID(int ID)
        {
            var existingUser = _context.Users.Find(ID);
            if (existingUser != null)
            {
                return _mapper.Map<UserDTO>(existingUser);
            }

            throw new NotFoundException(String.Format("User with ID = {0} does not exist.", ID));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_context.Users.Include(u => u.Enrollments));
        }

        public UserDTO UpdateUser(UserDTO userChangesDTO)
        {
            if (_context.Users.Any(x => x.ID == userChangesDTO.ID))
            {
                var user = _context.Users.Attach(_mapper.Map<User>(userChangesDTO));
                user.State = EntityState.Modified;
                _context.SaveChanges();

                return userChangesDTO;
            }

            throw new NotFoundException(String.Format("User with ID = {0} does not exist.", userChangesDTO.ID));
        }
    }
}
