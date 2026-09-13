using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Digital_Services_BD.Models;

using Microsoft.AspNetCore.Http;

namespace Digital_Services_BD.Services
{
    public interface ICarouselOps
    {
        Carousel AddCarousel(Carousel carousel);
        IEnumerable<Carousel> GetAllCarousel();
        Carousel GetCarousel(int carouselId);
        Carousel UpdateCarousel(Carousel carousel);
        Carousel DeleteCarousel(int carouselId);
        Task<Carousel> GetFirstCarousel();
    }
}
