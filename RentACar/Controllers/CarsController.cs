using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var cars = _context.Cars.ToList();

            if(User.IsInRole(RoleName.CanManageCars) || User.IsInRole(RoleName.CanManageAll))
            {
                return View(cars);
            }

            return View("ReadOnlyCars", cars);

        }

        
        [Authorize(Roles = RoleName.CanManageAll + ", " + RoleName.CanManageCars)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageAll + ", " + RoleName.CanManageCars)]
        public ActionResult CreateSubmit(string Name)
        {
            var car = new Car { Name = Name };
            _context.Cars.Add(car);

            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }

        [Authorize(Roles = RoleName.CanManageAll + ", " + RoleName.CanManageCars)]
        public ActionResult Update(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            return View(car);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageAll + ", " + RoleName.CanManageCars)]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSubmit(int id, string Name)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            car.Name = Name;

            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }

        [Authorize(Roles = RoleName.CanManageAll + ", " + RoleName.CanManageCars)]
        public ActionResult Delete(int id)
        {
            var deletedCar = _context.Cars.SingleOrDefault(c => c.Id == id);
            _context.Cars.Remove(deletedCar);

            _context.SaveChanges();

            var cars = _context.Cars.ToList();
            return RedirectToAction("Index", "Cars");
        }
    }
}