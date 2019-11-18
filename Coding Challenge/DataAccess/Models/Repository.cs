using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataAccess.Models.Data;
using DataAccess.Models;

namespace DataAccess.Models.Data
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

        public List<User> GetUsers()
        {
            var users = context.Users.ToList();
            return users;
        }
        public List<ModelUser> GetModelUsers()
        {
            return MakeUserList(context.Users.ToList()); ;
        }

        public User GetUser(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public bool UpdateUser(int id, User value)
        {
            var user = GetUser(id);
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
        public List<UserProject> GetProjectIdyUser(int id)
        {
            List<UserProject> userproject = context.UserProjects.Where(x => x.UserId == id).ToList();
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
        /******************************************************************************************************Projects***************************************************************************************************************************/
        public bool Createproject(Project value)
        {
            context.Projects.Add(value);

            return true;
        }

        public List<Project> Getprojects()
        {
            var projects = context.Projects.ToList();
            return projects;
        }

        public Project Getproject(int id)
        {
            var project = context.Projects.FirstOrDefault(x => x.Id == id);
            return project;
        }
        public bool Updateproject(int id, Project value)
        {
            var project = Getproject(id);
            if (project == null)
            {
                return false;
            }
            project.Credits = value.Credits;
            project.EndDate = value.EndDate;
            context.Entry(project).State = EntityState.Modified;
            SaveAll();
            return true;
        }
        public List<ModelProject> GetProjectByUser(int id)
        { 
            return MakeProjectList(GetProjectIdyUser(id)); 
        }
        /******************************************************************************************************Options****************************************************************************************************************************/
        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
        private List<ModelProject> MakeProjectList(List<UserProject> listup) 
        {
            List<ModelProject> list = new List<ModelProject>();
            foreach (UserProject up in listup)
            {
                ModelProject MP = new ModelProject
                {
                    Id = up.Project.Id,
                    StartDate = up.Project.StartDate.ToShortDateString(),
                    EndDate = up.Project.EndDate.ToShortDateString(),
                    TimeToStart=up.Project.StartDate.CompareTo(up.AssignedDate),
                    Credits= up.Project.Credits,
                    IsActive=up.IsActive
                };
                list.Add(MP);
            }
            return list;
        }
        private List<ModelUser> MakeUserList(List<User> listup)
        {
            List<ModelUser> list = new List<ModelUser>();
            foreach (User up in listup)
            {
                ModelUser MP = new ModelUser
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName
                };
                list.Add(MP);
            }
            return list;
        }
        private List<ModelUserProject> MakeUserProjectList(List<UserProject> listup)
        {
            List<ModelUserProject> list = new List<ModelUserProject>();
            foreach (UserProject up in listup)
            {
                ModelUserProject MP = new ModelUserProject
                {
                    ProjectId = up.ProjectId,
                    UserId = up.UserId,
                    IsActive = up.IsActive
                };
                list.Add(MP);
            }
            return list;
        }
    }
}