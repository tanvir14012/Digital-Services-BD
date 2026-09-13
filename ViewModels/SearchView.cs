using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Digital_Services_BD.Models;

namespace Digital_Services_BD.ViewModels;

public sealed class SearchView
{
    [Required, MinLength(2), MaxLength(256)]
    public string Term { get; set; } = string.Empty;
    public int PageNo { get; set; } = 1;
    public string SortBy { get; set; } = "name";
    public string? PriceRange { get; set; }
    public int TotalItems { get; set; }
    [ValidateNever]
    public IEnumerable<ProductItem> Products { get; set; } = [];
}
