using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public class ProductItemFeature
    {
        public ProductItemFeature()
        {
                
        }
        public int Id { get; set; }
        //Foreign key, having it will make delete cascade
        public int ProductItemId { get; set; }
        [StringLength(64, ErrorMessage = "Company field should not contain more than 64 characters")]
        public string Company { get; set; }
        [StringLength(64, ErrorMessage = "Developer field should not contain more than 64 characters")]
        public string Developer { get; set; }
        [StringLength(64, ErrorMessage = "Publisher field should not contain more than 64 characters")]
        public string Publisher { get; set; }
        [StringLength(2048, ErrorMessage = "Description field should not contain more than 2048 characters")]
        public string Description { get; set; }
        [StringLength(1024, ErrorMessage = "RegionCodes field should not contain more than 1024 characters")]
        public string RegionCodes { get; set; }
        [StringLength(1024, ErrorMessage = "RegionCountries field should not contain more than 1024 characters")]
        public string RegionCountries { get; set; }
        [StringLength(64, ErrorMessage = "DeliveryInfo field should not contain more than 64 characters")]
        public string DeliveryInfo { get; set; }
        [StringLength(64, ErrorMessage = "ValidityPeriod field should not contain more than 64 characters")]
        public string ValidityPeriod { get; set; }
        [StringLength(128, ErrorMessage = "Genre field should not contain more than 128 characters")]
        public string Genre { get; set; }
        [StringLength(256, ErrorMessage = "Os field should not contain more than 256 characters")]
        public string Os { get; set; }
        [StringLength(256, ErrorMessage = "Platform field should not contain more than 256 characters")]
        public string Platform { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [StringLength(256, ErrorMessage = "RequirementCpu field should not contain more than 256 characters")]
        public string RequirementCpu { get; set; }
        [StringLength(128, ErrorMessage = "RequirementRam field should not contain more than 128 characters")]
        public string RequirementRam { get; set; }
        [StringLength(128, ErrorMessage = "RequirementGpu field should not contain more than 128 characters")]
        public string RequirementGpu { get; set; }
        [StringLength(128, ErrorMessage = "RequirementDisk field should not contain more than 128 characters")]
        public string RequirementDisk { get; set; }
        [StringLength(64, ErrorMessage = "DownloadSize field should not contain more than 64 characters")]
        public string DownloadSize { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
