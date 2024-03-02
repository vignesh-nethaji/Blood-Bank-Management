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
    public class DonorsController : Controller
    {
        private BloodCenterContext db = new BloodCenterContext();

        // GET: Donors
        public ActionResult Index()
        {
            List<DonarList> donarLists = new List<DonarList>();

            var bloodGroups = db.BloodGroup.ToList();

            foreach (var item in db.Donor.ToList())
            {
                donarLists.Add(new DonarList()
                {
                    Name = item.Name,
                    Address = item.Address,
                    BloodGroup = bloodGroups.FirstOrDefault(o => o.Id == item.BloodGroupId).Name,
                    Email = item.Email,
                    Id = item.Id,
                    LastDonationDate = item.LastDonationDate,
                    Mobile= item.Mobile
                });
            }
            return View(donarLists);
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donor.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            var donarData = new DonarList()
            {
                Name = donor.Name,
                Address = donor.Address,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == donor.BloodGroupId).Name,
                Email = donor.Email,
                Id = donor.Id,
                LastDonationDate = donor.LastDonationDate,
                Mobile = donor.Mobile
            };
            return View(donarData);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroups = db.BloodGroup.ToList();
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BloodGroupId,Name,Mobile,Email,Address,LastDonationDate")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donor.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donor);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donor.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroups = db.BloodGroup.ToList();
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BloodGroupId,Name,Mobile,Email,Address,LastDonationDate")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donor.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            var donarData = new DonarList()
            {
                Name = donor.Name,
                Address = donor.Address,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == donor.BloodGroupId).Name,
                Email = donor.Email,
                Id = donor.Id,
                LastDonationDate = donor.LastDonationDate,
                Mobile = donor.Mobile
            };
            return View(donarData);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donor.Find(id);
            db.Donor.Remove(donor);
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
