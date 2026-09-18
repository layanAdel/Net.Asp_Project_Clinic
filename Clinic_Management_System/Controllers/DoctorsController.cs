using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _db;
        public DoctorsController(AppDbContext db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            IEnumerable<Doctor> doct = _db.Doctors.ToList();
            return View(doct);
        }



        // Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(doctor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(doctor);

        }


        // Edit 

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var doct = _db.Doctors.Find(Id);
            if (doct == null)
            {
                return NotFound();
            }

            return View(doct);
        }

        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Update(doctor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(doctor);

        }


        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var doct = _db.Doctors.Find(Id);
            if (doct == null)
            {
                return NotFound();
            }

            return View(doct);
        }

        [HttpPost]
        public ActionResult Delete(Doctor doctor)
        {

            _db.Doctors.Remove(doctor);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }



    }
}
