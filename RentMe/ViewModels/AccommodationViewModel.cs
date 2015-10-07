using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentMe.Models.Entities;

namespace RentMe.ViewModels
{
    public class AccommodationViewModel
    {
        public bool LoggedUser { get; set; }
        public Accommodation Accommodation { get; set; }
        public List<Accommodation> Accommodations { get; set; }
    }
}