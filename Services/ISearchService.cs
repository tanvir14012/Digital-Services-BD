using Digital_Services_BD.Models;
using Digital_Services_BD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Services
{
    public interface ISearchService
    {
        Task<SearchView> SearchProducts(SearchView model);
    }
}
