using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Services.Abstraction;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;
        public ServiceManager(IUniteOfWork uniteOfWork , IMapper mapper , IBasketReposatory basketReposatory)
        {
            _productService = new Lazy<IProductService>(()=> new ProductService(uniteOfWork, mapper));
            _basketService = new Lazy<IBasketService>(()=> new BasketService(basketReposatory , mapper));
        }
        public IProductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;
    }
}
