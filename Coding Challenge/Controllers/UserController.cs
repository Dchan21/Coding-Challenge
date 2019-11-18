using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Models.Data;

namespace Coding_Challenge.Controllers
{
    public class UserController : Controller
    {
        private IRepository repository = new Repository();
        // GET: User
        [HttpPost]
        public void CreateUser(User value)
        {
            repository.CreateUser(value);
        }
        [HttpGet]
        public JsonResult UsersList()
        {
            var users = repository.GetModelUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetUser(int id)
        {
            return Json(repository.GetUser(id), JsonRequestBehavior.AllowGet);
        }
    }
}