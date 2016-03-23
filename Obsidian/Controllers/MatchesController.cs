using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Obsidian.Models;
using Obsidian.Models.TournamentModels;

namespace Obsidian.Controllers
{
    public class MatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.TeamOne).Include(m => m.TeamTwo).Include(m => m.Tournament);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "Id", "Name");
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.TeamOneId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.TeamTwoId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.TournamentId = new SelectList(db.Tournaments, "Id", "Name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamOneId,TeamTwoId,TournamentId,VideoFile,TeamOneIsWinner,TeamTwoIsWinner,IsLosersFinals,IsWinnersFinals,IsGrandFinals")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamOneId = new SelectList(db.Teams, "Id", "Name", match.TeamOneId);
            ViewBag.TeamTwoId = new SelectList(db.Teams, "Id", "Name", match.TeamTwoId);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "Id", "Tournament Name");
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamOneId = new SelectList(db.Teams, "Id", "Name", match.TeamOneId);
            ViewBag.TeamTwoId = new SelectList(db.Teams, "Id", "Name", match.TeamTwoId);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "Id", "Name", match.TournamentId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamOneId,TeamTwoId,TournamentId,VideoFile,TeamOneIsWinner,TeamTwoIsWinner,IsLosersFinals,IsWinnersFinals,IsGrandFinals")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamOneId = new SelectList(db.Teams, "Id", "Name", match.TeamOneId);
            ViewBag.TeamTwoId = new SelectList(db.Teams, "Id", "Name", match.TeamTwoId);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "Id", "Name", match.TournamentId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
