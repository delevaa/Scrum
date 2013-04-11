using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ScrumProject.Models
{
    public class StoryRepository : IDisposable
    {
        private SMRPO6Context db = new SMRPO6Context();

        public void AddStory(Story story)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.InsertStory @Name, @Description, @Tests,@Priority,@BusinessValue,@Notes,@Points,ProjectId",
                                              new SqlParameter("Name", story.Name),
                                              new SqlParameter("Description", story.Description),
                                              new SqlParameter("Tests", story.Tests),
                                              new SqlParameter("Priority", story.Priority),
                                              new SqlParameter("BusinessValue", story.BusinessValue),
                                              new SqlParameter("Notes", story.Notes),
                                              new SqlParameter("Points", story.Points),
                                              new SqlParameter("ProjectId", story.ProjectId));
               
                db.SaveChanges();

            }
        }
        public IQueryable<Story> GetAllStories()
        {
            return db.Stories;
        }

        public IQueryable<Story> GetAllStories(int id)
        {
            return from Story in db.Stories
                   where Story.Id == id
                   select Story;
        }

        public IQueryable<Story> GetAllStoriesByProject(int id)
        {
            return from Story in db.Stories
                   where Story.ProjectId == id
                   select Story;
        }

        public Story GetStory(int id)
        {
            return (from Story in db.Stories
                    where Story.Id == id
                    select Story).SingleOrDefault();
        }

        public string GetStoryName(int id)
        {
            return (from Story in db.Stories
                    where Story.Id == id
                    select Story.Name).SingleOrDefault();
        }

        public Story GetStoryByName(string name)
        {
            return (from Story in db.Stories
                    where Story.Name == name
                    select Story).SingleOrDefault();
        }
       

        public Story GetStoryFromProjectByName(string name, int pid)
        {
            return (from Story in db.Stories
                    where Story.Name == name
                    && Story.ProjectId == pid
                    select Story).SingleOrDefault();
        }

        public void DeleteStory(Story story)
        {
            
            using (var db = new SMRPO6Context())
            {
                db.Stories.Remove(story);
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