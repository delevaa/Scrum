using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumProject.Models;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace ScrumProject.Controllers
{
    public class LoginController : Controller
    {
        private UserRepository userR = new UserRepository();
        //
        // GET: /login/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /login/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    User user = userR.GetByUsername(model.Username);
                    string roles = null;
                    // Build a roles string if we recognize the user
                    if (user.isAdmin)
                    {
                        roles = "admin";
                    }
                    else
                    {
                        roles = "user";
                    }
                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.Id;
                    serializeModel.Username = user.Username;
                    serializeModel.Roles = new String[1]{roles};

                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    string userData = serializer.Serialize(serializeModel);

                    FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(1,
                                                        user.Username,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(15),
                                                        model.RememberMe,
                                                        userData);
                    string encTicket = FormsAuthentication.Encrypt(authTicket);

                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    //FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /login/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile(String Username)
        {
            UserController um = new UserController();
            User userDetail = um.GetUserDetail(Username);

            User user = new User();
            user.Name = userDetail.Name;
            user.Surname = userDetail.Surname;
            user.Password = userDetail.Password;
            user.Email = userDetail.Email;
            user.isAdmin = userDetail.isAdmin;
            user.Username = userDetail.Username;

            return View(user);
        } 

        [HttpPost] 
        public ActionResult MyProfile(User userProfile) { 

           UserController um = new UserController();
           um.UpdateUserProfile(userProfile); 

           ViewData["Status"] = "Update Sucessful!"; 

           return View(userProfile); 
        } 
    }
}
