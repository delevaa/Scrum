using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using ScrumProject.Models;
using System.Web.Script.Serialization;

namespace ScrumProject
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        /*protected void Application_AuthenticateRequest(Object sender,
                                               EventArgs e)
        {

            // Get the authentication cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];

            // If the cookie can't be found, don't issue the ticket
            if (authCookie == null) return;

            // Get the authentication ticket and rebuild the principal 
            // & identity
            FormsAuthenticationTicket authTicket =
              FormsAuthentication.Decrypt(authCookie.Value);
            string[] roles = authTicket.UserData.Split(new Char[] { '|' });
            CustomPrincipal userPrincipal =
              new CustomPrincipal(authTicket.Name, roles);
            HttpContext.Current.User = userPrincipal;
            IPrincipal principal = HttpContext.Current.User as IPrincipal;
        }*/

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                try
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                    CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                    newUser.UserId = serializeModel.UserId;
                    newUser.Username = serializeModel.Username;
                    newUser.Roles = serializeModel.Roles;
                    HttpContext.Current.User = newUser;
                }
                catch (NullReferenceException exc)
                {
                    HttpCookie myCookie = new HttpCookie("UserSettings");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
            }
        }
    }
}