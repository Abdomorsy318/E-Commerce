using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstraction;
using Services.Specifications;
using Shared;

namespace Services
{
    public class ProductService(IUniteOfWork uniteOfWork , IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var Brands = await uniteOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var BrandsResult = mapper.Map<IEnumerable<BrandResultDto>>(Brands);
            return BrandsResult;
        }

        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(ProductSepcificationsParameters parameters)
        {
            var Products = await uniteOfWork.GetRepository<Product, int>().GetAllWithSpecificationsAsync(new ProductWithrandAndTypeSpecifications(parameters));
            var ProductsResult = mapper.Map<IEnumerable<ProductResultDto>>(Products);
            return ProductsResult;
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var Types = await uniteOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesResult = mapper.Map<IEnumerable<TypeResultDto>>(Types);
            return TypesResult;
        }

        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var Product = await uniteOfWork.GetRepository<Product, int>().GetByIdWithSpecificationsAsync(new ProductWithrandAndTypeSpecifications(id));
            var ProductResult = mapper.Map<ProductResultDto>(Product);
            return ProductResult;
        }
    }
}
