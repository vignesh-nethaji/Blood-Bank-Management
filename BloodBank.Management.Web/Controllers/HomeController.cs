using BloodBank.Management.DataAccess;
using BloodBank.Management.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BloodBank.Management.Web.Controllers
{
    public class HomeController : Controller
    {
        private BloodCenterContext db = new BloodCenterContext();
        public HomeController()
        {
            ViewBag.ControllerName = "Home";
        }
        public ActionResult Index()
        {
            ViewBag.Donors = db.Donor.Count();
            ViewBag.Recipients = db.Recipient.Count();
            ViewBag.Hospitals = db.Hospital.Count();
            ViewBag.Donations = db.Donation.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult InventoryChart()
        {
            var inventory = db.Inventory.Where(o => o.Status == false).ToList();
            var bloodGroups = db.BloodGroup.ToList();
            var data = new List<int>();
            var labels = new List<string>();

            foreach (var bgId in inventory.Select(o => o.BloodGroupId).Distinct().ToList())
            {
                var specficBloodGroups = inventory.Count(o => o.BloodGroupId == bgId);
                var bgName = bloodGroups.FirstOrDefault(o => o.Id == bgId).Name;
                labels.Add(bgName);
                data.Add(specficBloodGroups);
            }
            return Json(new { labels, data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DonationChart()
        {
            var months = new List<string>()
            {
                "Jan",
                "Feb",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Aug",
                "Sep",
                "Oct",
                "Nov",
                "Dec"
            };

            var donations = db.Donation.OrderByDescending(o => o.DonationDate).GroupBy(x => new { x.DonationDate.Year, x.DonationDate.Month }).ToList();

            var data = new List<int>();
            var labels = new List<string>();
            foreach (var item in donations)
            {
                labels.Add(months[item.Key.Month] + " " + item.Key.Year.ToString().Substring(2, 2));
                data.Add(item.Count());
            }
            return Json(new { labels, data }, JsonRequestBehavior.AllowGet);
        }
    }
}