using Digital_Services_BD.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public class CarouselOps : ICarouselOps
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarouselOps(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public Carousel AddCarousel(Carousel carousel)
        {
            //Add save images to server, save path
            if (carousel.CarouselJoinCarouselImage != null)
            {
                foreach (var item in carousel.CarouselJoinCarouselImage)
                {
                    if (item.Image != null)
                    {
                        item.ImageUrl = AddImage(item.Image);
                    }
                    item.CreatedOn = DateTime.UtcNow;
                    item.LastModifiedOn = DateTime.UtcNow;
                }
            }
            carousel.CreatedOn = DateTime.UtcNow;
            carousel.LastModifiedOn = DateTime.UtcNow;
            context.Carousels.Add(carousel);
            try
            {
                context.SaveChanges();
                return carousel;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Carousel DeleteCarousel(int carouselId)
        {
            var carousel = context.Carousels.Find(carouselId);
            if (carousel != null)
            {
                carousel.CarouselJoinCarouselImage = context.carouselJoinCarouselImages.Where(j => j.CarouselId == carousel.Id).ToList();
                context.Carousels.Remove(carousel);

                try
                {
                    context.SaveChanges();
                    foreach (var item in carousel.CarouselJoinCarouselImage)
                    {
                        if (item.ImageUrl != null)
                        {
                            DeleteFile(item.ImageUrl);
                        }
                    }
                    return carousel;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public IEnumerable<Carousel> GetAllCarousel()
        {
            return context.Carousels.AsNoTracking().ToList();
        }

        public Carousel GetCarousel(int carouselId)
        {
            var carousel = context.Carousels.Find(carouselId);
            if (carousel != null)
            {
                carousel.CarouselJoinCarouselImage = context.carouselJoinCarouselImages.Where(j => j.CarouselId == carousel.Id).ToList();
            }
            return carousel;
        }

        public Carousel UpdateCarousel(Carousel carousel)
        {
            //Update images by deleting, uploading etc.
            foreach (var item in carousel.CarouselJoinCarouselImage)
            {
                if (item.Image != null)
                {
                    if (item.ImageUrl != null)
                    {
                        DeleteFile(item.ImageUrl);
                    }
                    item.ImageUrl = AddImage(item.Image);
                }
                item.LastModifiedOn = DateTime.UtcNow;
            }
            carousel.LastModifiedOn = DateTime.UtcNow;
            context.Carousels.Update(carousel);
            try
            {
                context.SaveChanges();
                return carousel;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private string AddImage(IFormFile imageFile)
        {
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "Carousel");
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var filePath = Path.Combine(fileDirectory, uniqueName);
            try
            {
                //Save only path relative to wwwroot
                imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                return Path.Combine("ImageResources", "Carousel", uniqueName);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private bool DeleteFile(string relativePath)
        {
            try
            {
                var fileDirectory = Path.Combine(webHostEnvironment.WebRootPath, "ImageResources", "Carousel");
                if (Directory.Exists(fileDirectory))
                {
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                    File.Delete(filePath);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}
