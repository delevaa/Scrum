using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ScrumProject.Models
{
    public class ProjectUserRepository : IDisposable
    {
        private SMRPO6Context db = new SMRPO6Context();

        public void AddProject(Project_User project_user)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.InsertProjectUser @Id, @ProjectId,@UserId, @Role",
                                           new SqlParameter("Id", project_user.Id),
                                            new SqlParameter("ProjectId", project_user.ProjectId),
                                           new SqlParameter("UserId", project_user.UserId),
                                           new SqlParameter("Role", project_user.Role));
     
                db.SaveChanges();

            }
        }
        public IQueryable<Project> GetAllProjectsOfUser(int Id)
        {
            return from Project_User in db.Project_User
                   where Project_User.UserId == Id
                   select Project_User.Project;
        }

        public IQueryable<User> GetAllMembersOfProject(int id)
        {
            return from Project_User in db.Project_User
                   where Project_User.ProjectId == id
                   select Project_User.User;
        }

        public string GetRole(int id)
        {
            return (from Project_User in db.Project_User
                    where Project_User.Id == id
                    select Project_User.Role).SingleOrDefault();
        }

        public void UpdateRole(int id,string role)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.UpdateProjectUser @Id, @Role",
                                            new SqlParameter("Id", id),
                                            new SqlParameter("Role", role));

                db.SaveChanges();
            }

        }

        public void DeleteMember(int id)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.DeleteProject_User @Id ",
                                           new SqlParameter("Id", id));
                db.SaveChanges();
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}