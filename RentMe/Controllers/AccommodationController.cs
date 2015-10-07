using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentMe.Models;
using RentMe.Models.Entities;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;
using RentMe.Models.Enums;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RentMe.Controllers
{
    public class AccommodationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accommodation
        public ActionResult Index()
        {
            return View(db.Accommodations.ToList());
        }
        public ActionResult Rent()
        {
            var Accommodations = db.Accommodations.Where(t => t.RentSale == RentSale.Rent).ToList();
            ViewBag.Message = "Your contact page.";
            return View(Accommodations);
        }
        public ActionResult Sale()
        {
            var Accommodations = db.Accommodations.Where(t => t.RentSale == RentSale.Sale).ToList();
            ViewBag.Message = "Your contact page.";
            return View(Accommodations);
        }

        // GET: Accommodation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accommodation accommodation = db.Accommodations.Include(s => s.Images).SingleOrDefault(s => s.Id == id);

            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }

        // GET: Accommodation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accommodation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,StreetAddress,City,PostalCode,imageName,Types,RentSale")] Accommodation accommodation, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new Image
                        {
                            ImageName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = Models.Enums.FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        accommodation.Images = new List<Image> { avatar };
                    }

                    string currentUserId = User.Identity.GetUserId();
                    accommodation.ApplicationUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);/*db.Users.FirstOrDefault(x => x.Id == currentUserId);*/
                    db.Accommodations.Add(accommodation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(accommodation);
        }

       
        public ActionResult Sent()
        {
            return View();
        }
        // GET: Accommodation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accommodation accommodation = db.Accommodations.Find(id);
            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }

        // POST: Accommodation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,StreetAddress,City,PostalCode,imageName")] Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accommodation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accommodation);
        }

        // GET: Accommodation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accommodation accommodation = db.Accommodations.Find(id);
            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }

        // POST: Accommodation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accommodation accommodation = db.Accommodations.Find(id);
            db.Accommodations.Remove(accommodation);
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
