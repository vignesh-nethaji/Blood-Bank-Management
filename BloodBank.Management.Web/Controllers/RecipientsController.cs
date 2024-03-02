using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BloodBank.Management.DataAccess;
using BloodBank.Management.Models.Entity;
using BloodBank.Management.Models.ViewModel;

namespace BloodBank.Management.Web.Controllers
{
    public class RecipientsController : Controller
    {
        private readonly BloodCenterContext db = new BloodCenterContext();

        // GET: Recipients
        public ActionResult Index()
        {
            List<RecipientList> recipientList = new List<RecipientList>();

            var bloodGroups = db.BloodGroup.ToList();
            var hospitals = db.Hospital.ToList();

            foreach (var item in db.Recipient.ToList())
            {
                recipientList.Add(new RecipientList()
                {
                    Name = item.Name,
                    Address = item.Address,
                    Hospital = hospitals.FirstOrDefault(o => o.Id == item.HospitalId).Name,
                    BloodGroup = bloodGroups.FirstOrDefault(o => o.Id == item.BloodGroupId).Name,
                    Email = item.Email,
                    Id = item.Id,
                    Mobile = item.Mobile
                });
            }
            return View(recipientList);
        }

        // GET: Recipients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Recipient.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            var recipientData = new RecipientList()
            {
                Name = recipient.Name,
                Address = recipient.Address,
                Hospital = db.Hospital.FirstOrDefault(o => o.Id == recipient.HospitalId).Name,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == recipient.BloodGroupId).Name,
                Email = recipient.Email,
                Id = recipient.Id,
                Mobile = recipient.Mobile
            };
            return View(recipientData);
        }

        // GET: Recipients/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroups = db.BloodGroup.ToList();
            ViewBag.Hospitals = db.Hospital.ToList();
            return View();
        }

        // POST: Recipients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BloodGroupId,HospitalId,Name,Mobile,Email,Address")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                db.Recipient.Add(recipient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipient);
        }

        // GET: Recipients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Recipient.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroups = db.BloodGroup.ToList();
            ViewBag.Hospitals = db.Hospital.ToList();
            return View(recipient);
        }

        // POST: Recipients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BloodGroupId,HospitalId,Name,Mobile,Email,Address")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipient);
        }

        // GET: Recipients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Recipient.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            var recipientData = new RecipientList()
            {
                Name = recipient.Name,
                Address = recipient.Address,
                Hospital = db.Hospital.FirstOrDefault(o => o.Id == recipient.HospitalId).Name,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == recipient.BloodGroupId).Name,
                Email = recipient.Email,
                Id = recipient.Id,
                Mobile = recipient.Mobile
            };
            return View(recipientData);
        }

        // POST: Recipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipient recipient = db.Recipient.Find(id);
            db.Recipient.Remove(recipient);
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
