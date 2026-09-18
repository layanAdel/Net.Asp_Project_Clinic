using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _db;
        public DepartmentsController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Department> dep = _db.Departments.ToList();
            return View(dep);
        }

        //Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(department);
        }

        //Edit

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dep = _db.Departments.Find(Id);
            if (dep == null)
            {
                return NotFound();
            }

            return View(dep);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(department);

        }

        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var dep = _db.Departments.Find(Id);
            if (dep == null)
            {
                return NotFound();
            }

            return View(dep);
        }


        [HttpPost]
        public ActionResult Delete(Department department)
        {

            _db.Departments.Remove(department);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
