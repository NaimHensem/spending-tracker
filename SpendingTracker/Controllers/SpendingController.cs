using System;
using System.Linq;
using System.Web.Mvc;
using SpendingTracker.Models;

namespace SpendingTracker.Controllers
{
    public class SpendingController : Controller
    {
        private SpendingContext db = new SpendingContext();

        // GET: Spending (Homepage showing total spending)
        public ActionResult Index()
        {
            var totalSpent = db.SpendingRecords.Sum(r => (decimal?)r.Amount) ?? 0;
            ViewBag.TotalSpent = totalSpent;
            return View(db.SpendingRecords.ToList());
        }

        // GET: Add a new spending record
        public ActionResult Add()
        {
            return View();
        }

        // POST: Add a new spending record
        [HttpPost]
        public ActionResult Add(SpendingRecord record)
        {
            if (ModelState.IsValid)
            {
                record.Date = DateTime.Now; // Automatically record the date and time
                db.SpendingRecords.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record);
        }

        // POST: Save spending via AJAX
        [HttpPost]
        public JsonResult AddSpending(decimal amount, string description)
        {
            try
            {
                SpendingRecord newRecord = new SpendingRecord
                {
                    Amount = amount,
                    Description = description,
                    Date = DateTime.Now
                };

                db.SpendingRecords.Add(newRecord);
                db.SaveChanges();

                return Json(new { success = true, id = newRecord.Id, amount, description, date = newRecord.Date.ToString("d MMM yyyy h:mm tt") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Edit a spending record
        public ActionResult Edit(int id)
        {
            var record = db.SpendingRecords.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Edit a spending record
        [HttpPost]
        public ActionResult Edit(SpendingRecord record)
        {
            if (ModelState.IsValid)
            {
                var existingRecord = db.SpendingRecords.AsNoTracking().FirstOrDefault(r => r.Id == record.Id);
                if (existingRecord != null)
                {
                    record.Date = existingRecord.Date; // Retain original date
                    db.Entry(record).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(record);
        }

        // GET: Delete a spending record
        public ActionResult Delete(int id)
        {
            var record = db.SpendingRecords.Find(id);
            if (record != null)
            {
                db.SpendingRecords.Remove(record);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Switch to Spending Limit Mode
        public ActionResult Index2()
        {
            return View();
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
