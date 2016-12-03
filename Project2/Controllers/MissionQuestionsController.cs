using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2.DAL;
using Project2.Models;
using System.Web.Security;

namespace Project2.Controllers
{
    public class MissionQuestionsController : Controller
    {
        private MissionaryContext db = new MissionaryContext();
        

        // GET: MissionQuestions
        [Authorize]
        public ActionResult Index(int? mid)
        {
            //Grabs the mission id so it can assign it when creating a new question
            ViewBag.mid = mid;
            return View(db.MissionQuestions.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create(int mid)
        {
            //Grabs the mission id so it can assign it when creating a new question
            ViewBag.mid = mid;
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "missionQuestionID,missionID,userID,question,answer,answeredBy")] MissionQuestions missionQuestions, int mid)
        {
            if (ModelState.IsValid)
            {
                db.MissionQuestions.Add(missionQuestions);
                //Assigns the mission id as the specific mission the questions forum was accessed through
                missionQuestions.missionID = mid;

                //This code gets the userID of the currently logged in user
                ViewBag.test = User.Identity.Name;
                ViewBag.use = null;
                var use = db.Users;
                //cycles through the users model to find the user who has that email (User.Identity.Name)
                foreach (var id in use)
                {
                    if (id.userEmail == ViewBag.test)
                    {
                        ViewBag.use = id.userID;
                    }
                }
                //Assigns the userID of the question to the currently logged in user
                missionQuestions.userID = ViewBag.use;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missionQuestions);
        }

        // GET: MissionQuestion to edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionQuestionID,missionID,userID,question,answer,answeredBy")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestions).State = EntityState.Modified;
                ViewBag.test = User.Identity.Name;
                ViewBag.answerer = null;
                var use = db.Users;
                //cycles through the users model to find the user who has that email (User.Identity.Name)
                foreach (var id in use)
                {
                    if (id.userEmail == ViewBag.test)
                    {
                        //Stores the first name of the answerer
                        ViewBag.answerer = id.userFName;
                    }
                }
                //Assigns the first name of answerer as the current user's first name
                missionQuestions.answeredBy = ViewBag.answerer;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            db.MissionQuestions.Remove(missionQuestions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
