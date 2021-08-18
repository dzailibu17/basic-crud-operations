using Interface.Repositories;
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

        public UserRepository(DbModels.DbModels context)
        {
            _context = context;
        }

        public UserDTO AddUser(UserDTO user)
        {
            _context.Users.Add(new User
            {
                EnrollmentDate = user.EnrollmentDate.Value,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            });
            _context.SaveChanges();
            return user;
        }

        public UserDTO DeleteUser(int ID)
        {
            User user = _context.Users.Find(ID);
            if (user != null)
            {
                var deletedUser = new UserDTO
                {
                    ID = user.ID,
                    EnrollmentDate = user.EnrollmentDate,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
                _context.Users.Remove(user);
                _context.SaveChanges();
                return deletedUser;
            }
            throw new NotFoundException(String.Format("User with ID = {0} does not exist.", ID));
        }

        public UserDTO GetUserByID(int ID)
        {
            var existingUser = _context.Users.Find(ID);
            if (existingUser != null)
            {
                return new UserDTO
                {
                    ID = existingUser.ID,
                    EnrollmentDate = existingUser.EnrollmentDate,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    Email = existingUser.Email,
                };
            }
            throw new NotFoundException(String.Format("User with ID = {0} does not exist.", ID));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _context.Users.Select(u => new UserDTO
            {
                ID = u.ID,
                EnrollmentDate = u.EnrollmentDate,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
            });
        }

        public UserDTO UpdateUser(UserDTO userChangesDTO)
        {
            if (_context.Users.Any(x => x.ID == userChangesDTO.ID))
            {
                var userChanges = new User
                {
                    ID = userChangesDTO.ID,
                    EnrollmentDate = userChangesDTO.EnrollmentDate.Value,
                    FirstName = userChangesDTO.FirstName,
                    LastName = userChangesDTO.LastName,
                    Email = userChangesDTO.Email,
                };
                var user = _context.Users.Attach(userChanges);
                user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return userChangesDTO;
            }
            throw new NotFoundException(String.Format("User with ID = {0} does not exist.", userChangesDTO.ID));
        }
    }
}
