using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentMe.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int Price { get; set; }
        public int RentTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Accommodation Accommodations { get; set; }
    }
}