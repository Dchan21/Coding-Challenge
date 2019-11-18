using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Models.Data;
using Newtonsoft.Json;

namespace Coding_Challenge.Controllers
{
    public class ProjectController : Controller
    {
        private IRepository repository = new Repository();
        [HttpPost]
        public void CreateProject(Project value)
        {
            repository.Createproject(value);
        }
        [HttpGet]
        public JsonResult ProjectList()
        {
            var users = repository.Getprojects();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProject(int id)
        {
            return Json(repository.Getproject(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ProjectListByUser(int id)
        {
            var json = repository.GetProjectByUser(id);           
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}