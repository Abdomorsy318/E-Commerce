﻿
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProduct([FromQuery]ProductSepcificationsParameters parameters)
        {
            var Products = await serviceManager.ProductService.GetAllProductsAsync(parameters);
            return Ok(Products);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GatAllBrands()
        {
            var Brands = await serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
        {
            var Types = await serviceManager.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDto>> GetProduct(int id)
        {
            var Product = await serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(Product);
        }
    }
}
