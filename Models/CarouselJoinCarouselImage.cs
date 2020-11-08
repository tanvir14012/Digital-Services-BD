using Digital_Services_BD.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class CarouselJoinCarouselImage
    {
        public int Id { get; set; }
        [MaxFileSize(1)]
        [AllowedExtensions(new string[] { "jpg", "jpeg", "png", "gif", "tiff" })]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public Carousel Carousel { get; set; }
        public int CarouselId { get; set; }
    }
}
