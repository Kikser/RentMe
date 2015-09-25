using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentMe.Models.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}