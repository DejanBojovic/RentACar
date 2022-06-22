using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class CustomerMembershipTypeViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}