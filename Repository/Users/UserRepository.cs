using Interface.Repositories;
using Model.DTOs;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbModels.DbModels context;

        public UserRepository(DbModels.DbModels context)
        {
            this.context = context;
        }

        public UserDTO AddUser(UserDTO user)
        {
            try
            {
                context.Users.Add(new DbModels.User
                {
                    ID = user.ID,
                    EnrollmentDate = user.EnrollmentDate,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                });
                context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public UserDTO DeleteUser(int ID)
        {
            User user = context.Users.Find(ID);
            if (user != null)
            {
                var deletedUser = new UserDTO
                {
                    ID = user.ID,
                    EnrollmentDate = user.EnrollmentDate,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
                context.Users.Remove(user);
                context.SaveChanges();
                return deletedUser;
            }
            return null;
        }

        public UserDTO GetUserByID(int ID)
        {
            try 
            { 
                var existingUser = context.Users.Find(ID);
                if(existingUser != null)
                {
                    return new UserDTO
                    {
                        ID = existingUser.ID,
                        EnrollmentDate = existingUser.EnrollmentDate,
                        FirstName = existingUser.FirstName,
                        LastName = existingUser.LastName,
                    };
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            try 
            { 
                return context.Users.Select(u => new UserDTO
                {
                    ID = u.ID,
                    EnrollmentDate = u.EnrollmentDate,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public UserDTO UpdateUser(UserDTO userChangesDTO)
        {
            try 
            { 
                var userChanges = new User
                {
                    ID = userChangesDTO.ID,
                    EnrollmentDate = userChangesDTO.EnrollmentDate,
                    FirstName = userChangesDTO.FirstName,
                    LastName = userChangesDTO.LastName,
                };
                var user = context.Users.Attach(userChanges);
                user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return userChangesDTO;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
