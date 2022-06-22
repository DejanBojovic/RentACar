using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class RandomCarViewModel
    {
        public Car Car { get; set; }
        public List<Customer> Customers { get; set; }

    }
}