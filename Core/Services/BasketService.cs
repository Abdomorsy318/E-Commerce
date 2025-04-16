using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities.Basket;
using Domain.Exceptions;
using Services.Abstraction;
using Shared;

namespace Services
{
    public class BasketService(IBasketReposatory basketReposatory, IMapper mapper) : IBasketService
    {
        public async Task<BasketDto?> GetBasketAsync(string id)
        {
            var basket = await basketReposatory.GetBasketAsync(id);
            return basket is null ? throw new BasketNotFoundException(id) :
                mapper.Map<BasketDto>(basket);
        }
        public async Task<BasketDto?> UpdateBasketAsync(BasketDto basketDto)
        {
            var CustomerBasket = mapper.Map<CustomerBasket>(basketDto);
            var updatedBasket = await basketReposatory.UpdateBasketAsync(CustomerBasket);
            return updatedBasket is null ? throw new Exception("We Can Not Update Basket") :
                mapper.Map<BasketDto>(updatedBasket);
        }
        public async Task<bool> DeleteBasketAsync(string id)
        => await basketReposatory.DeleteBasketAsync(id);
    }
}
