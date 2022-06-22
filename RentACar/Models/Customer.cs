using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public string IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    }
}