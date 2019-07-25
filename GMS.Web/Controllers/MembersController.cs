using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMS.Web.DBContext;

namespace GMS.Web.Controllers
{
    public class MembersController : Controller
    {
        private crudEntities db = new crudEntities();

        // GET: Members
        public ActionResult Index()
        {
           // var members = db.Members.Include(m => m.Branch).Include(m => m.Club).Include(m => m.Members1).Include(m => m.Member1).Include(m => m.MemberShipType).Include(m => m.Status);
            var members = db.Members;
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Name");
            ViewBag.ClubTypeID = new SelectList(db.Clubs, "ID", "Description");
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName");
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName");
            ViewBag.MembershipTypeID = new SelectList(db.MemberShipTypes, "ID", "Description");
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,IdNumber,Address,BranchID,MembershipTypeID,ClubTypeID,BankName,BanchAcc,DOB,StartDate,EndDate,CellNo,TellNo,Occupation,CompanyName,Gender,Age,StatusID")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Name", member.BranchID);
            ViewBag.ClubTypeID = new SelectList(db.Clubs, "ID", "Description", member.ClubTypeID);
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName", member.ID);
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName", member.ID);
            ViewBag.MembershipTypeID = new SelectList(db.MemberShipTypes, "ID", "Description", member.MembershipTypeID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description", member.StatusID);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Name", member.BranchID);
            ViewBag.ClubTypeID = new SelectList(db.Clubs, "ID", "Description", member.ClubTypeID);
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName", member.ID);
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName", member.ID);
            ViewBag.MembershipTypeID = new SelectList(db.MemberShipTypes, "ID", "Description", member.MembershipTypeID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description", member.StatusID);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,IdNumber,Address,BranchID,MembershipTypeID,ClubTypeID,BankName,BanchAcc,DOB,StartDate,EndDate,CellNo,TellNo,Occupation,CompanyName,Gender,Age,StatusID")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Name", member.BranchID);
            ViewBag.ClubTypeID = new SelectList(db.Clubs, "ID", "Description", member.ClubTypeID);
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName", member.ID);
            ViewBag.ID = new SelectList(db.Members, "ID", "FirstName", member.ID);
            ViewBag.MembershipTypeID = new SelectList(db.MemberShipTypes, "ID", "Description", member.MembershipTypeID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description", member.StatusID);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
