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
    public class InventoriesController : Controller
    {
        private BloodCenterContext db = new BloodCenterContext();

        public InventoriesController()
        {
            ViewBag.ControllerName = "Inventories";
        }
        // GET: Inventories
        public ActionResult Index()
        {
            List<InventoryList> inventoryList = new List<InventoryList>();

            var bloodGroups = db.BloodGroup.ToList();
            var donors = db.Donor.ToList();
            var recipients = db.Recipient.ToList();
            var donations = db.Donation.ToList();

            foreach (var item in db.Inventory.ToList())
            {
                var inventory = new InventoryList()
                {
                    Id = item.Id,
                    Donor = donors.FirstOrDefault(o => o.Id == item.DonorId).Name,
                    BloodGroup = bloodGroups.FirstOrDefault(o => o.Id == item.BloodGroupId).Name,
                    DonationId = item.DonationId,
                    ExpiryDate = item.ExpiryDate,
                    Status = item.Status
                };
                if (item.DonationId > 0 && donations.Count() > 0 && recipients.Count() > 0)
                {
                    var recipientId = donations.FirstOrDefault(o => o.Id == item.DonationId).RecipientId;
                    var recipientName = recipients.FirstOrDefault(o => o.Id == recipientId).Name;
                    inventory.Recipient = recipientName;
                }
                inventoryList.Add(inventory);
            }
            return View(inventoryList);
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventory.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            var recipients = db.Recipient.ToList();
            var donations = db.Donation.ToList();
            var inventoryData = new InventoryList()
            {
                Id = inventory.Id,
                Donor = db.Donor.FirstOrDefault(o => o.Id == inventory.DonorId).Name,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == inventory.BloodGroupId).Name,
                DonationId = inventory.DonationId,
                ExpiryDate = inventory.ExpiryDate,
                Status = inventory.Status
            };
            if (inventory.DonationId > 0 && donations.Count() > 0 && recipients.Count() > 0)
            {
                var recipientId = donations.FirstOrDefault(o => o.Id == inventory.DonationId).RecipientId;
                var recipientName = recipients.FirstOrDefault(o => o.Id == recipientId).Name;
                inventoryData.Recipient = recipientName;
            }
            return View(inventoryData);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroups = db.BloodGroup.ToList();
            ViewBag.Donors = db.Donor.ToList();
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonorId,BloodGroupId,ExpiryDate,Status")] Inventory inventory)
        {
            inventory.BloodGroupId = db.Donor.FirstOrDefault(o => o.Id == inventory.DonorId).BloodGroupId;
            if (ModelState.IsValid)
            {
                db.Inventory.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventory.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroups = db.BloodGroup.ToList();
            ViewBag.Donors = db.Donor.ToList();
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonorId,BloodGroupId,ExpiryDate,Status")] Inventory inventory)
        {
            inventory.BloodGroupId = db.Donor.FirstOrDefault(o => o.Id == inventory.DonorId).BloodGroupId;
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventory.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            var recipients = db.Recipient.ToList();
            var donations = db.Donation.ToList();
            var inventoryData = new InventoryList()
            {
                Id = inventory.Id,
                Donor = db.Donor.FirstOrDefault(o => o.Id == inventory.DonorId).Name,
                BloodGroup = db.BloodGroup.FirstOrDefault(o => o.Id == inventory.BloodGroupId).Name,
                DonationId = inventory.DonationId,
                ExpiryDate = inventory.ExpiryDate,
                Status = inventory.Status
            };
            if (inventory.DonationId > 0 && donations.Count() > 0 && recipients.Count() > 0)
            {
                var recipientId = donations.FirstOrDefault(o => o.Id == inventory.DonationId).RecipientId;
                var recipientName = recipients.FirstOrDefault(o => o.Id == recipientId).Name;
                inventoryData.Recipient = recipientName;
            }
            return View(inventoryData);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventory.Find(id);
            db.Inventory.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetBloodGroupId(int donorId = 0)
        {
            var bloodGroupId = db.Donor.FirstOrDefault(o => o.Id == donorId).BloodGroupId;
            return Json(bloodGroupId, JsonRequestBehavior.AllowGet);
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
