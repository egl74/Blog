using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Model;

namespace Blog.Web.Controllers
{
    public class LoginItem
    {
        public string Login {get;set;}
        public string Password {get;set;}
        public bool RememberMe {get;set;}
    }

    public class ProfileItem
    {
        public string FirstName;
        public string LastName;
        public string City;
        public string Login;
        public int Id;
    }

    public class UserItem
    {
        public string Login;
        public int Id;
    }

    public class ProfileController : Controller
    {
            //
            // GET: /Profile/

        private dbModel db = new dbModel();

        public ActionResult Index(int id)
        {
            var model =
                db.Users.Select(
                t =>
                    new ProfileItem
                    {
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        City = t.City.Name,
                        Login = t.Login,
                        Id = t.Id,
                    }).SingleOrDefault(t => t.Id == id);
            return View(model);
        }
    }

    public class UserController : Controller
    {
        //
        // GET: /User/

        private dbModel db = new dbModel();

        public bool IsValid(string _username, string _password)
        {
            var user = db.Users.SingleOrDefault(t => t.Login == _username && t.Password == _password);
            return user != null;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult Login(LoginItem user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Login, user.Password))
                {
                    if (user.RememberMe)
                    {
                        FormsAuthentication.SetAuthCookie(user.Login, true);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.Login, false);
                    }
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}
