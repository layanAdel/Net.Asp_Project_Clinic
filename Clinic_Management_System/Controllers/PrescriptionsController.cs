using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class PrescriptionsController : Controller
    {
        private readonly AppDbContext _db;
        public PrescriptionsController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Prescription> pre = _db.Prescriptions.ToList();
            return View(pre);
        }


        //Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _db.Prescriptions.Add(prescription);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(prescription);
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var pre = _db.Prescriptions.Find(Id);
            if (pre == null)
            {
                return NotFound();
            }

            return View(pre);
        }


        [HttpPost]
        public ActionResult Edit(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _db.Prescriptions.Update(prescription);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(prescription);

        }

        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var pre = _db.Prescriptions.Find(Id);
            if (pre == null)
            {
                return NotFound();
            }

            return View(pre);
        }

        [HttpPost]
        public ActionResult Delete(Prescription prescription)
        {
            _db.Prescriptions.Remove(prescription);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
