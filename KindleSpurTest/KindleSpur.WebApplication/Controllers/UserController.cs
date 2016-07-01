using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KindleSpur.Models;
using KindleSpur.Models.Interfaces;
using KindleSpur.Data;
using System.Net.Mail;
using KindleSpur.WebApplication.MessageHelper;

namespace KindleSpur.WebApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Login(User signupObject)
        {
            UserRepository _repo = new UserRepository();
            if (_repo.AddNewUser(signupObject))
            {
                string uri = Request.Url.AbsoluteUri.Replace("/User/Login", "/User/PasswordPromp?UserId=" + signupObject.Id);
                EmailNotification.SendEmail(signupObject, uri);
                TempData["StatusMessage"] = "Please check your mail to activate account!!!";
            }
            else
            {
                TempData["ErrorMessage"] = "User is already registered!!!";
            }
            return View();
        }

        public ActionResult PasswordPromp(int? UserId)
        {
            //RedirectToAction("", "Home");
            TempData["UserId"] = Request["UserId"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult SavePassword(User signupObject)
        {
            UserRepository _repo = new UserRepository();
        
            User obj= _repo.SavePassword(TempData["UserId"].ToString(), signupObject);

            return View();
        }
        
        [HttpPost]
        public ActionResult linkedIn(User _obj)
        {
            UserRepository _repo = new UserRepository();
            if (!_repo.AddNewUser(_obj))
            {
                ViewBag.ErrorMessage = "User already exists.";
            }
            else
            {
                Session["User"] = _obj;
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public Object LoginResult(User signupObject)
        {
            UserRepository _repo = new UserRepository();

            IUser u = _repo.GetUserDetail(signupObject.EmailAddress);

            if (u != null && u.Password==signupObject.Password)
            {
                Session["User"] = u;
                return Session["User"];
            }
            else
            {
                return null;
            }

        }



    }
}