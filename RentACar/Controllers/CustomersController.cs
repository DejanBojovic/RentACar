using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController ()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            if (User.IsInRole(RoleName.CanManageAll))
            {
                return View(customers);
            }

            return View("ReadOnlyCustomers", customers);
        }

        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            return View(membershipTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult CreateSubmit(string Name, string IsSubscribedToNewsLetter, string MembershipId)
        {
            var customer = new Customer { Name = Name, IsSubscribedToNewsletter = IsSubscribedToNewsLetter, MembershipTypeId = Convert.ToInt32(MembershipId)};
            _context.Customers.Add(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Update(int id)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var model = new CustomerMembershipTypeViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult UpdateSubmit(int id, string Name, string isSubscribedToNewsLetter, string MembershipId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            customer.Name = Name;
            customer.IsSubscribedToNewsletter = isSubscribedToNewsLetter;
            customer.MembershipTypeId = Convert.ToInt32(MembershipId);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Delete(int id)
        {
            var deletedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(deletedCustomer);

            _context.SaveChanges();

            var customers = _context.Customers.ToList();
            return RedirectToAction("Index", "Customers");
        }
    }
   
}