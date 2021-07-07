using Interface;
using Model;
using Repository.DbModels;
using System;
using System.Collections.Generic;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly DbModels context;

        public UserService(DbModels context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int ID)
        {
            User user = context.Users.Find(ID);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public User GetUserByID(int ID)
        {
            return context.Users.Find(ID);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User Update(User userChanges)
        {
            var user = context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}
