using RentMe.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentMe.Models.Entities
{
    public class Accommodation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string imageName { get; set; }
        public RentSale RentSale { get; set; }
        public AccommodationType Types { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }

    }
}