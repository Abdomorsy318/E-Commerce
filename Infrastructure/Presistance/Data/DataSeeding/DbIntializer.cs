using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Presistance.Data.DataSeeding
{
    public class DbIntializer : IDbIntializer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DbIntializer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task IntializeAsync()
        {
            try
            {
                if(_applicationDbContext.Database.GetPendingMigrations().Any())
                {
                    await _applicationDbContext.Database.MigrateAsync();
                    if (!_applicationDbContext.ProductTypes.Any())
                    {
                        //D:\Route Course\Back-End\MVC Project\E-Commerce\Infrastructure\Presistance\Data\DataSeeding\types.json
                        var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeeding\types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                        if(types != null && types.Any())
                        {
                            await _applicationDbContext.AddRangeAsync(types);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                    if (!_applicationDbContext.ProductBrands.Any())
                    {
                        //D:\Route Course\Back-End\MVC Project\E-Commerce\Infrastructure\Presistance\Data\DataSeeding\brands.json
                        var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeeding\brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                        if (brands != null && brands.Any())
                        {
                            await _applicationDbContext.AddRangeAsync(brands);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                    if (!_applicationDbContext.Products.Any())
                    {
                        //D:\Route Course\Back-End\MVC Project\E-Commerce\Infrastructure\Presistance\Data\DataSeeding\products.json
                        var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeeding\products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                        if (products != null && products.Any())
                        {
                            await _applicationDbContext.AddRangeAsync(products);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
