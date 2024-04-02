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
            CreatePreLoadData();
            Donation donation = new Donation
            {
                DonationDate = System.DateTime.Today
            };
            return View(donation);
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonorId,RecipientId,DonationDate,Quantity")] Donation donation)
        {
            if (donation.DonorId <= 0)
            {
                ModelState.AddModelError("DonorId", "Donor is mandatory");
            }
            if (donation.RecipientId <= 0)
            {
                ModelState.AddModelError("RecipientId", "Recipient is mandatory");
            }

            var donorBloodGroup = db.Donor.FirstOrDefault(o => o.Id == donation.DonorId).BloodGroupId;
            var recipientBloodGroup = db.Recipient.FirstOrDefault(o => o.Id == donation.RecipientId).BloodGroupId;

            if (donorBloodGroup != recipientBloodGroup)
            {
                ModelState.AddModelError("DonorId", "Donor and Recipient should be same blood group");
            }
            var inventories = db.Inventory.Where(o => o.DonorId == donation.DonorId && !o.Status);
            if (donation.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Quantity should not be less than 1.");
            }
            else
            {
                if (inventories.Count() < donation.Quantity)
                {
                    ModelState.AddModelError("Quantity", "Currently inventory had only " + inventories.Count() + " quantity of blood. so please select quantity less than or equal to " + inventories.Count());
                }
            }
            if (ModelState.IsValid)
            {

                db.Donation.Add(donation);
                db.SaveChanges();
                var selectedInventories = inventories.Take(donation.Quantity);
                foreach (var item in selectedInventories)
                {
                    item.DonationId = donation.Id;
                    item.Status = true;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                CreatePreLoadData();
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

        [HttpGet]
        public JsonResult GetBloodGroupInfo(int donorId = 0)
        {
            var donor = db.Donor.FirstOrDefault(o => o.Id == donorId);
            var inventory = db.Inventory.Where(o => o.DonorId == donorId && o.Status == false);
            var bloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == donor.BloodGroupId);

            return Json(new { donor = donor.Name, bloodGroup = bloodGroup.Name, count = inventory.Count() }, JsonRequestBehavior.AllowGet);
        }

        private void CreatePreLoadData()
        {
            var donors = new List<Donor>();
            foreach (var item in db.Donor.ToList())
            {
                item.Name = item.Name + " - (" + db.BloodGroup.FirstOrDefault(o => o.Id == item.BloodGroupId).Name + ")";
                donors.Add(item);
            }
            ViewBag.Donors = donors;

            var recipients = new List<Recipient>();
            foreach (var item in db.Recipient.ToList())
            {
                item.Name = item.Name + " - (" + db.BloodGroup.FirstOrDefault(o => o.Id == item.BloodGroupId).Name + ")";
                recipients.Add(item);
            }
            ViewBag.Recipients = recipients;
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
