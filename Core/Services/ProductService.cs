using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions.Product;
using Services.Abstraction;
using Services.Specifications;
using Shared;

namespace Services
{
    public class ProductService(IUniteOfWork uniteOfWork, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var Brands = await uniteOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var BrandsResult = mapper.Map<IEnumerable<BrandResultDto>>(Brands);
            return BrandsResult;
        }

        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSepcificationsParameters parameters)
        {
            var Products = await uniteOfWork.GetRepository<Product, int>().GetAllWithSpecificationsAsync(new ProductWithrandAndTypeSpecifications(parameters));
            var ProductsResult = mapper.Map<IEnumerable<ProductResultDto>>(Products);
            var count = ProductsResult.Count();
            var totalCount = await uniteOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecifications(parameters));
            var result = new PaginatedResult<ProductResultDto>
                (
                parameters.PageIndex,
                parameters.PageSize,
                totalCount,
                ProductsResult
                );
            return result;
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
            return Product is null ? throw new ProductNotFoundException(id) : mapper.Map<ProductResultDto>(Product);
        }
    }
}
