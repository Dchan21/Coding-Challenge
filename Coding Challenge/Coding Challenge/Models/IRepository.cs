using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding_Challenge.Models.Data
{
    public interface IRepository
    {
        /***************************************************************************************************************Users**********************************************************************************************************************************/
        bool CreateUser(User value);
        List<User> GetUsers();
        User GetUser(int id);
        bool UpdateUser(int id, User value);
        /***************************************************************************************************************UsersProjects**********************************************************************************************************************************/
        bool CreateUserProject(UserProject value);
        List<UserProject> GetUserProjects();
        UserProject GetUserProjectByProject(int id);
        UserProject GetUserProjectByUser(int id);
        bool UpdateUserProject(int id, UserProject value);
        bool SaveAll();
    }
}