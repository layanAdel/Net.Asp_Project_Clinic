using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class PatientsController : Controller
    {
        private readonly AppDbContext _db;
        public PatientsController(AppDbContext db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            IEnumerable<Patient> pat = _db.Patients.ToList();
            return View(pat);
        }



        // Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _db.Patients.Add(patient);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(patient);

        }


        // Edit 

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var pat = _db.Patients.Find(Id);
            if (pat == null)
            {
                return NotFound();
            }

            return View(pat);
        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _db.Patients.Update(patient);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(patient);

        }


        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var pat = _db.Patients.Find(Id);
            if (pat == null)
            {
                return NotFound();
            }

            return View(pat);
        }

        [HttpPost]
        public ActionResult Delete(Patient patient)
        {

            _db.Patients.Remove(patient);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}
