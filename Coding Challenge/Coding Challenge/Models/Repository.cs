using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Coding_Challenge.Models.Data;

namespace Coding_Challenge.Models.Data
{
    public class Repository : IRepository
    {
        private CodingChallengeEntities context = new CodingChallengeEntities();

        /***************************************************************************************************************Users**********************************************************************************************************************************/
        public bool CreateUser(User value) 
        {
            context.Users.Add(value);

            return true;
        }
      
        public  List<User> GetUsers()
        {
            var users =  context.Users.ToList();
            return users;
        }

        public  User GetUser(int id)
        {
            var user =  context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public  bool UpdateUser(int id, User value)
        {
            var user =  GetUser(id);
            if (user == null)
            {
                return false;
            }
            user.FirstName = value.FirstName;
            user.LastName = value.LastName;
            context.Entry(user).State = EntityState.Modified;
             SaveAll();
            return true;
        }
        /***************************************************************************************************************UsersProjects**********************************************************************************************************************************/
        public bool CreateUserProject(UserProject value)
        {
            context.UserProjects.Add(value);

            return true;
        }

        public List<UserProject> GetUserProjects()
        {
            var userproject = context.UserProjects.ToList();
            return userproject;
        }

        public UserProject GetUserProjectByProject(int id)
        {
            var userproject = context.UserProjects.FirstOrDefault(x => x.ProjectId == id);
            return userproject;
        }
        public UserProject GetUserProjectByUser(int id)
        {
            var userproject = context.UserProjects.FirstOrDefault(x => x.UserId == id);
            return userproject;
        }
        public bool UpdateUserProject(int id, UserProject value)
        {
            var userproject = GetUserProjectByUser(id);
            if (userproject == null)
            {
                return false;
            }
            userproject.IsActive = value.IsActive;
            context.Entry(userproject).State = EntityState.Modified;
            SaveAll();
            return true;
        }
        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}