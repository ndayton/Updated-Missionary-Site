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

namespace Project2.Controllers
{
    public class MissionsController : Controller
    {
        private MissionaryContext db = new MissionaryContext();

        // GET: Missions
        public ActionResult Index(int id)
        {
            Missions mission = db.Missions.Find(id);
            //stores the mission id in case it is needed when creating a new mission question in the question forum
            ViewBag.id = id;
            return View(mission);
        }

        // GET: Missions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Missions missions = db.Missions.Find(id);
            if (missions == null)
            {
                return HttpNotFound();
            }
            return View(missions);
        }

        // GET: Missions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Missions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "missionID,missionName,missionPresFName,missionPresLName,missionAddress,missionCity,missionState,missionCountry,missionZip,language,climate,dominantReligion,missionSymbol")] Missions missions)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Add(missions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missions);
        }

        // GET: Missions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Missions missions = db.Missions.Find(id);
            if (missions == null)
            {
                return HttpNotFound();
            }
            return View(missions);
        }

        // POST: Missions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionID,missionName,missionPresFName,missionPresLName,missionAddress,missionCity,missionState,missionCountry,missionZip,language,climate,dominantReligion,missionSymbol")] Missions missions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(missions);
        }

        // GET: Missions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Missions missions = db.Missions.Find(id);
            if (missions == null)
            {
                return HttpNotFound();
            }
            return View(missions);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Missions missions = db.Missions.Find(id);
            db.Missions.Remove(missions);
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

        //This method plugs in the mission address to get directions from Provo, UT
        public ActionResult Directions(string missionName)
        {
            if (missionName == "Virginia Chesapeake")
            {
                ViewBag.Address = "1115 Cherokee Road, Portsmouth, VA 23701";
            }
            else if (missionName == "Washington Seattle")
            {
                ViewBag.Address = "10675 NE 20th St, Bellevue, WA 98004";
            }
            else if (missionName == "Arizona Tempe")
            {
                ViewBag.Address = "1871 E Del Rio Dr, Tempe, AZ 85282";
            }
            return View();
        }
    }
}
