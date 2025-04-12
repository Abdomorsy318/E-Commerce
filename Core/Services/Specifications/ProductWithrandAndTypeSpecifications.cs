using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Shared;

namespace Services.Specifications
{
    public class ProductWithrandAndTypeSpecifications : Specifications<Product>
    {
        //Use To Retrive Product By Id
        public ProductWithrandAndTypeSpecifications(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);

        }
        //Use To Get All Products
        public ProductWithrandAndTypeSpecifications(ProductSepcificationsParameters parameters) : 
            base(product => 
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
            #region Sort
            if (parameters.Sort != null)
            {
                switch(parameters.Sort)
                {
                    case ProductSortingOptions.NameDesc:
                        SetOrderByDesc(p => p.Name);
                            break;
                    case ProductSortingOptions.NameAsc:
                        SetOrderBy(p => p.Name);
                        break;
                    case ProductSortingOptions.PriceDesc:
                        SetOrderByDesc(p => p.Price);
                        break;
                    case ProductSortingOptions.PriceAsc:
                        SetOrderBy(p => p.Price);
                        break;
                    default:
                        break;
                }
            }
            #endregion
        }
    }
}
