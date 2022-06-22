using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
    }
}