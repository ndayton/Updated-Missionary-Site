using Project2.DAL;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {

        MissionaryContext db = new MissionaryContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //This is a dropdown list for the subject part of the message form
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Advice From Former Missionaries", Value = "0" });
            items.Add(new SelectListItem { Text = "Contacting Your Future Mission", Value = "1" });
            items.Add(new SelectListItem { Text = "Preparing For a Mission", Value = "2", Selected = true });

            ViewBag.subject = items;

            return View();
        }

        // GET: Missions
        public ActionResult MissionIndex()
        {
            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            //This finds if the credentials entered in the form match a user in the user database
            var currentUser =
                db.Database.SqlQuery<Users>(
            "Select * " +
            "FROM Users " +
            "WHERE userEmail = '" + email + "' AND " +
            "password = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                //returns the user to the select a mission page so that the questions forum has to be accessed through a specific mission page
                //so that a mission id can be attached to a new question
                return RedirectToAction("MissionIndex", "Home");
                //return Redirect(form["ReturnURL"].ToString());

            }
            else
            {
                return View();
            }
        }

    }
}