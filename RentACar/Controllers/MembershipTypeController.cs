using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class MembershipTypeController : Controller
    {
        private ApplicationDbContext _context;

        public MembershipTypeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();

            if (User.IsInRole(RoleName.CanManageAll))
            {
                return View(MembershipTypes);
            }

            return View("ReadOnlyMembershipType", MembershipTypes);

        }

        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult CreateSubmit(double SignUpFee, int DurationInMonths, int DiscountRate)
        {
            var MembershipType = new MembershipType { SignUpFee = SignUpFee, DurationInMonths = DurationInMonths, DiscountRate = DiscountRate };
            _context.MembershipTypes.Add(MembershipType);

            _context.SaveChanges();

            return RedirectToAction("Index", "MembershipType");
        }

        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Update(int id)
        {
            var MembershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);

            return View(MembershipType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult UpdateSubmit(int id, double SignUpFee, int DurationInMonths, int DiscountRate)
        {
            var MembershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);
            MembershipType.SignUpFee = SignUpFee;
            MembershipType.DurationInMonths = DurationInMonths;
            MembershipType.DiscountRate = DiscountRate;

            _context.SaveChanges();

            return RedirectToAction("Index", "MembershipType");
        }

        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Delete(int id)
        {
            var MembershipTypeDeleted = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);
            _context.MembershipTypes.Remove(MembershipTypeDeleted);

            _context.SaveChanges();

            var membershipTypes = _context.MembershipTypes.ToList();
            return RedirectToAction("Index", "MembershipType");
        }
    }
}