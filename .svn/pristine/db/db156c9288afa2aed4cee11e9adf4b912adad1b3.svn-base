using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumProject.Models;
using ScrumProject.ViewModels;
using System.Web.Security;

namespace ScrumProject.Controllers
{
    [Authorize]
    public class MyProjectsController : Controller
    {
        MembersRepository memberR = new MembersRepository();
        UserRepository userR = new UserRepository();
        //
        // GET: /MyProjects/

        public ActionResult Index()
        {            
            var viewModel = new ProjectIndexData();
            viewModel.Projects = memberR.GetAllProjectsOfUser(userR.GetByUsername(User.Identity.Name).Id);
            return View(viewModel);
        }

    }
}
