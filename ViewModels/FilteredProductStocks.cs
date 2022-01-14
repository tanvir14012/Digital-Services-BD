using Digital_Services_BD.Models;
using System.Collections.Generic;

public class FilteredProductStocks
{
    public FilteredProductStocks()
    {
        ProductStocksUnderFilter = new List<ProductStock>();
    }

    public int PageNo { get; set; } = 1;
    public int ProductStockPerPage { get; set; } = 5;
    public string SortBy { get; set; } = "date_desc";
    public int TotalProductStocks { get; set; } = 0;
    public int GroupId { get; set; } = -1;
    public int CategoryId { get; set; } = -1;
    public int ProductId { get; set; } = -1;
    public IEnumerable<ProductStock> ProductStocksUnderFilter { get; set; }
}