using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeesController(AppDbContext db)
        {  
            _db = db; 
        }

        public ActionResult Index()
        {
            IEnumerable<Employee> emp = _db.Employees.ToList();
            return View(emp);
        }


        // Create 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(employee);
        }


        // Edit 
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var emp = _db.Employees.Find(Id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(employee);

        }

        // Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var emp = _db.Employees.Find(Id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {

            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
