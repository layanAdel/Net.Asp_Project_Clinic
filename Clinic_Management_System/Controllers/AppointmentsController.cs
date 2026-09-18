using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _db;
        public AppointmentsController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Appointment> appo = _db.Appointments.ToList();
            return View(appo);
        }

        //Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _db.Appointments.Add(appointment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(appointment);
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var appo = _db.Appointments.Find(Id);
            if (appo == null)
            {
                return NotFound();
            }

            return View(appo);
        }

        [HttpPost]
        public ActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _db.Appointments.Update(appointment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(appointment);

        }

        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var appo = _db.Appointments.Find(Id);  
            if (appo == null)
            {
                return NotFound();
            }

            return View(appo);
        }

        [HttpPost]
        public ActionResult Delete(Appointment appointment)
        {
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
