using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumProject.Models;
using ScrumProject.ViewModels;

namespace ScrumProject.Controllers
{
    public class ProjectController : Controller
    {
        private SMRPO6Context db = new SMRPO6Context();
        UserRepository userR = new UserRepository();
        ProjectRepository projectR = new ProjectRepository();
        MembersRepository memberR = new MembersRepository();

        //
        // GET: /Project/

        [Authorize(Roles = "admin")]
        public ActionResult Index(Int32? id)
        {
            var viewModel = new ProjectIndexData();
            viewModel.Projects = db.Projects.Include(i => i.Stories);
            if (id != null)
            {
                ViewBag.ProjectID = id.Value;
                viewModel.Stories = viewModel.Projects.Where(i => i.Id == id.Value).Single().Stories;
            }
            return View(viewModel);            
        }

        //
        // GET: /Project/Details/5

        public ViewResult Details(int id)
        {
            Project project = db.Projects.Find(id);
            ViewBag.projectName = project.Name;
            ViewBag.projectDesc = project.Description;
            var viewModel = new ProjectIndexData();
            viewModel.Projects =  db.Projects.Include(i => i.Stories);

            ViewBag.projectId = id;
            viewModel.Stories = viewModel.Projects.Where(i => i.Id == id).Single().Stories;
            viewModel.Sprints = viewModel.Projects.Where(i => i.Id == id).Single().Sprints;

            ViewBag.manageStories = false;
            ViewBag.manageSprints = false;
            CustomPrincipal user = HttpContext.User as CustomPrincipal;
            user.Members = db.Members.Where(pr => pr.ProjectId == id).Where(pr => pr.UserId == user.UserId).FirstOrDefault();
            if (user.Members.Role != "team")
            {
                ViewBag.manageStories = true;
                ViewBag.manageSprints = true;
            }
            return View(viewModel);
        }

        //
        // GET: /Project/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //

        // POST: /Project/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (projectR.GetByNameProject(project.Name) == null)
                    {
                        db.Projects.Add(project);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The project name is already used.");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(project);
        }
        
        //
        // GET: /Project/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int projectId)
        {
            Project project = db.Projects.Find(projectId);
            return View(project);
        }

        //
        // POST: /Project/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Project/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // POST: /Project/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Project/AddUser
        [Authorize(Roles = "admin")]
        public ActionResult AddUser(int projectId)
        {
            ViewBag.Users = new SelectList(db.Users,"Id","Username");
            Members projectUser = new Members();
            projectUser.ProjectId = projectId;
            return View(projectUser);
        }

        //
        // POST: /Project/AddUser
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddUser(Members projectUser)
        {
            try
            {
                User user = memberR.GetAllMembersOfProject(projectUser.ProjectId).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    if (user == null || user.Id != projectUser.UserId)
                    {
                        db.Members.Add(projectUser);
                        db.SaveChanges();
                        return RedirectToAction("Edit", new { projectId = projectUser.ProjectId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user is already working on project.");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(projectUser);
        }

        //
        // GET: /Project/RemoveUser
        [Authorize(Roles = "admin")]
        public ActionResult RemoveUser(int id)
        {
            Members projectMember = db.Members.Find(id);
            return View(projectMember);
        }

        //
        // POST: /Project/RemoveUser
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("RemoveUser")]
        public ActionResult RemoveUserConfirm(Members member)
        {
            Members projectUser = db.Members.Find(member.Id);
            int projectId = projectUser.ProjectId;
            db.Members.Remove(projectUser);
            db.SaveChanges();
            return RedirectToAction("Edit", new { projectId = projectId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}