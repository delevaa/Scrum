using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ScrumProject.Models
{
    public class SprintRepository : IDisposable
    {
        private SMRPO6Context db = new SMRPO6Context();

        public void AddSprint(Sprint sprint)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.InsertSprint @DateTo, @DateFrom, @Velocity,@ProjectId",
                                             new SqlParameter("DateTo", sprint.DateTo),
                                             new SqlParameter("DateFrom", sprint.DateFrom),
                                             new SqlParameter("Velocity", sprint.Velocity),
                                             new SqlParameter("ProjectId", sprint.ProjectId));
                db.SaveChanges();

            }
        }

        public IQueryable<Sprint> GetAllSprints()
        {
            return db.Sprints;
        }

        public IQueryable<Sprint> GetAllSprints(int id)
        {
            return from Sprint in db.Sprints
                   where Sprint.Id == id
                   select Sprint;
        }

        public IQueryable<Sprint> GetAllSprintsByProject(int id)
        {
            return from Sprint in db.Sprints
                   where Sprint.ProjectId == id
                   select Sprint;
        }

        public Sprint GetSprint(int id)
        {
            return (from Sprint in db.Sprints
                    where Sprint.Id == id
                    select Sprint).SingleOrDefault();
        }

        

        public void DeleteSprint(Sprint sprint)
        {
            using (var db = new SMRPO6Context())
            {
                db.Sprints.Remove(sprint);
                db.SaveChanges();
            }

        }
        public IQueryable<DateTime> GetAllSprintStartDatesByProject(int id) {

            return from Sprint in db.Sprints
                   where Sprint.ProjectId == id
                   select Sprint.DateFrom;
        }
        public IQueryable<DateTime> GetAllSprintEndDatesByProject(int id) {

            return from Sprint in db.Sprints
                   where Sprint.ProjectId == id
                   select Sprint.DateTo;
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