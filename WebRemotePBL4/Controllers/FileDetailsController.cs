using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRemotePBL4.Models;

namespace WebRemotePBL4.Controllers
{
    public class FileDetailsController : Controller
    {
        private DB_PBL4Entities1 db = new DB_PBL4Entities1();

        // GET: FileDetails
        public ActionResult Index()
        {
            var fileDetails = db.FileDetails.Include(f => f.Folder);
            return View(fileDetails.ToList());
        }

        // GET: FileDetails/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listFile = db.FileDetails.Where(filedetail => filedetail.ID_Folder == id).ToList();
            return View(listFile);
        }

        // GET: FileDetails/Create
        public ActionResult Create()
        {
            ViewBag.ID_Folder = new SelectList(db.Folders, "ID_Folder", "Type");
            return View();
        }

        // POST: FileDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Detail,Link,Time,ID_Folder")] FileDetail fileDetail)
        {
            if (ModelState.IsValid)
            {
                db.FileDetails.Add(fileDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Folder = new SelectList(db.Folders, "ID_Folder", "Type", fileDetail.ID_Folder);
            return View(fileDetail);
        }

        // GET: FileDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDetail fileDetail = db.FileDetails.Find(id);
            if (fileDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Folder = new SelectList(db.Folders, "ID_Folder", "Type", fileDetail.ID_Folder);
            return View(fileDetail);
        }

        // POST: FileDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Detail,Link,Time,ID_Folder")] FileDetail fileDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Folder = new SelectList(db.Folders, "ID_Folder", "Type", fileDetail.ID_Folder);
            return View(fileDetail);
        }

        // GET: FileDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDetail fileDetail = db.FileDetails.Find(id);
            if (fileDetail == null)
            {
                return HttpNotFound();
            }
            return View(fileDetail);
        }

        // POST: FileDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FileDetail fileDetail = db.FileDetails.Find(id);
            db.FileDetails.Remove(fileDetail);
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
