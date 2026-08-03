using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.ViewModels
{
    public static class ProductConfig
    {
        public static readonly int NoOfProductCategoryPerPage = 6;
        public static readonly int NoOfProductItemPerPage = 6;
        public static readonly int MinPrice = 0;
        public static readonly int MaxPrice = 9300;
        public static readonly int MaxItemAllowedInCart = 10;

        //Landing Page Section at /Home
        public static readonly int MaxColumnAllowedInLandingPageSectionRow = 4;
    }
}
