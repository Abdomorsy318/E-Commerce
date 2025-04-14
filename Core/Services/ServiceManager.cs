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
        public ServiceManager(IUniteOfWork uniteOfWork , IMapper mapper)
        {
            _productService = new Lazy<IProductService>(()=> new ProductService(uniteOfWork, mapper));
        }
        public IProductService ProductService => _productService.Value;
    }
}
