using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSepcificationsParameters
    {
        private const int MaximumPageSize = 10;
        private const int DefaultPageSize = 5;
        private int _pageSize;
        public int? TypeId {  get; set; }
        public int? BrandId { get; set; }
        public ProductSortingOptions Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = value > MaximumPageSize? MaximumPageSize : value;
        }
        public string? Search { get; set; }
    }
    public enum ProductSortingOptions
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
    }
}
