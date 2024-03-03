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
    public class DonationsController : Controller
    {
        private BloodCenterContext db = new BloodCenterContext();
        public DonationsController()
        {
            ViewBag.ControllerName = "Donations";
        }

        // GET: Donations
        public ActionResult Index()
        {
            List<DonationList> donationList = new List<DonationList>();
            var bloodGroups = db.BloodGroup.ToList();
            var donors = db.Donor.ToList();
            var recipients = db.Recipient.ToList();
            var donations = db.Donation.ToList();

            foreach (var item in donations)
            {
                var donor = donors.FirstOrDefault(o => o.Id == item.DonorId);
                var donation = new DonationList()
                {
                    Id = item.Id,
                    DonationDate = item.DonationDate,
                    Donor = donor.Name,
                    BloodGroup = bloodGroups.FirstOrDefault(o => o.Id == donor.BloodGroupId).Name,
                    Quantity = item.Quantity,
                    Recipient = recipients.FirstOrDefault(o => o.Id == item.RecipientId).Name
                };
                donationList.Add(donation);
            }
            return View(donationList);
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }

            var donor = db.Donor.FirstOrDefault(o => o.Id == donation.DonorId);
            var donationData = new DonationList()
            {
                Id = donation.Id,
                DonationDate = donation.DonationDate,
                Donor = donor.Name,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == donor.BloodGroupId).Name,
                Quantity = donation.Quantity,
                Recipient = db.Recipient.FirstOrDefault(o => o.Id == donation.RecipientId).Name
            };

            return View(donationData);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.Donors = db.Donor.ToList();
            ViewBag.Recipients = db.Recipient.ToList();
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonorId,RecipientId,DonationDate,Quantity")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donation.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Donors = db.Donor.ToList();
            ViewBag.Recipients = db.Recipient.ToList();
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonorId,RecipientId,DonationDate,Quantity")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            var donor = db.Donor.FirstOrDefault(o => o.Id == donation.DonorId);
            var donationData = new DonationList()
            {
                Id = donation.Id,
                DonationDate = donation.DonationDate,
                Donor = donor.Name,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == donor.BloodGroupId).Name,
                Quantity = donation.Quantity,
                Recipient = db.Recipient.FirstOrDefault(o => o.Id == donation.RecipientId).Name
            };

            return View(donationData);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donation.Find(id);
            db.Donation.Remove(donation);
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
