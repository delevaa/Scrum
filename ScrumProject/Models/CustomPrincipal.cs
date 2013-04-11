using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace ScrumProject.Models
{
    interface ICustomPrincipal : IPrincipal
    {
        int UserId { get; set; }
        string Username { get; set; }
        string[] Roles { get; set; }
        Members Members { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return Roles.Contains<String>(role); }

        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string[] Roles { get; set; }
        public Members Members { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string[] Roles { get; set; }
       // public Project[] Members { get; set; }
    }
}