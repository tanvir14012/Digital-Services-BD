using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class Carousel
    {
        public Carousel()
        {
            CarouselJoinCarouselImage = new List<CarouselJoinCarouselImage>();
        }
        public int Id { get; set; }
        [StringLength(128, ErrorMessage = "Carousel name should not contain more than 128 characters")]
        public string Name { get; set; }
        public int Rank { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        [BindProperty]
        public List<CarouselJoinCarouselImage> CarouselJoinCarouselImage { get; set; }
    }
}
