using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.Data
{
    public interface IRepository
    {
        /***************************************************************************************************************Users**********************************************************************************************************************************/
        bool CreateUser(User value);
        List<User> GetUsers();
        List<ModelUser> GetModelUsers();
        User GetUser(int id);
        bool UpdateUser(int id, User value);
        /***************************************************************************************************************UsersProjects****************************************************************************************************************************/
        bool CreateUserProject(UserProject value);
        List<UserProject> GetUserProjects();
        UserProject GetUserProjectByProject(int id);
        UserProject GetUserProjectByUser(int id);
        bool UpdateUserProject(int id, UserProject value);
        //List<UserProject> GetListUserProjectsByUser(int id);
        /***************************************************************************************************************Projects********************************************************************************************************************************/
        bool Createproject(Project value);
        List<Project> Getprojects();
        Project Getproject(int id);
        bool Updateproject(int id, Project value);
        List<ModelProject> GetProjectByUser(int id);
       /***************************************************************************************************************UsersProjects****************************************************************************************************************************/
        bool SaveAll();
    }
}