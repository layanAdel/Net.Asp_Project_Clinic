using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private readonly AppDbContext _db;
        public MedicalRecordsController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<MedicalRecord> med = _db.MedicalRecords.ToList();
            return View(med);
        }

        //Create 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _db.MedicalRecords.Add(medicalRecord);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(medicalRecord);
        }



        //Edit

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var med = _db.MedicalRecords.Find(Id);
            if (med == null)
            {
                return NotFound();
            }

            return View(med);
        }

        [HttpPost]
        public ActionResult Edit(MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _db.MedicalRecords.Update(medicalRecord);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(medicalRecord);

        }

        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var med = _db.MedicalRecords.Find(Id);
            if (med == null)
            {
                return NotFound();
            }

            return View(med);
        }

        [HttpPost]
        public ActionResult Delete(MedicalRecord medicalRecord)
        {

            _db.MedicalRecords.Remove(medicalRecord);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
