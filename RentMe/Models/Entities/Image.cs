using RentMe.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentMe.Models.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        [StringLength(255)]
        public string ImageName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int AccommodationId { get; set; }
        public virtual Accommodation Accommodation { get; set; }
    }
}