using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ScrumProject.Models
{
    public class UserRepository :IDisposable
    {
        private SMRPO6Context db=new SMRPO6Context();

        public void AddUser(User user)
        {


            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.InsertUser @Username, @Name, @Surname,@Email,@Password,@isAdmin",
                                              new SqlParameter("Username", user.Username),
                                              new SqlParameter("Name", user.Name),
                                              new SqlParameter("Surname", user.Surname),
                                              new SqlParameter("Email", user.Email),
                                              new SqlParameter("Password", user.Password),
                                              new SqlParameter("isAdmin", user.isAdmin));
                db.SaveChanges();

            }
        }
        public IQueryable<User> GetAllUsers()
        {
            return db.Users;
        }

        public IQueryable<User> GetAllUsers(int id)
        {
            return from User in db.Users
                   where User.Id == id
                   select User;
        }

        public User GetUser(int id)
        {
            return (from User in db.Users
                    where User.Id == id
                    select User).SingleOrDefault();
        }

        public string GetUserName(int id)
        {
            var UserName = (from User in db.Users
                               where User.Id == id
                               select User.Name).FirstOrDefault();

            return UserName;
        }

        public string GetUsername(int id)
        {
            var Username = (from User in db.Users
                            where User.Id == id
                            select User.Username).FirstOrDefault();

            return Username;
        }

        public void UpdateUser(User user)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.UpdateUser @Id, @Username, @Name, @Surname,@Email,@Password,@isAdmin",
                                              new SqlParameter("Id", user.Id),
                                              new SqlParameter("Username", user.Username),
                                              new SqlParameter("Name", user.Name),
                                              new SqlParameter("Surname", user.Surname),
                                              new SqlParameter("Email", user.Email),
                                              new SqlParameter("Password", user.Password),
                                              new SqlParameter("isAdmin", user.isAdmin));

                db.SaveChanges();
            }
            
        }

        public void DeleteUser(User user)
        {
            using (var db = new SMRPO6Context())
            {
                db.Database.ExecuteSqlCommand("exec dbo.DeleteUser @Id",
                                              new SqlParameter("Id", user.Id));
                db.SaveChanges();
            }
            // db.Users.Remove(User);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public User GetByUsername(string username)
        {
            return (from User in db.Users
                    where User.Username == username
                    select User).SingleOrDefault();
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