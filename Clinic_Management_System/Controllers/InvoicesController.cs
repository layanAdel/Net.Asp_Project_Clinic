using Clinic_Management_System.Data;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Clinic_Management_System.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly AppDbContext _db;

        public InvoicesController(AppDbContext db)
        {
            _db = db;
        }


        public ActionResult Index()
        {
            IEnumerable<Invoice> inv = _db.Invoices.ToList();
            return View(inv);
        }

        //Create 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice) 
        {
            if (ModelState.IsValid)
            {
                _db.Invoices.Add(invoice);
                _db.SaveChanges();
              return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields ");
            return View(invoice); 
        }

        // Edit 
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var inv = _db.Invoices.Find(Id);
            if (inv == null)
            {
                return NotFound();
            }

            return View(inv);
        }

        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _db.Invoices.Update(invoice);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Please fill all the required fields.");
            return View(invoice);
        }

        //Delete

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var inv = _db.Invoices.Find(Id);
            if(inv == null)
            {
                return NotFound();
            }
            return View(inv);
        }

        [HttpPost]
        public ActionResult Delete(Invoice invoice)
        {
            _db.Invoices.Remove(invoice);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
