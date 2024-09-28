using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entities;
using System.Text.Json;


namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Store.Repository/SeedData/brands.json"); // if you have text and you needd to convert to object
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData); // if you have object and you needd to convert to text (Revers)

                    if (brands is not null )
                        await context.ProductBrands.AddRangeAsync(brands); 
                }

                if (context.ProductsTypes != null && !context.ProductsTypes.Any())
                {
                    var typesData = File.ReadAllText("../Store.Repository/SeedData/types.json"); // if you have text and you needd to convert to object
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData); // if you have object and you needd to convert to text (Revers)

                    if (types is not null)
                        await context.ProductsTypes.AddRangeAsync(types);
                }
                    await context.SaveChangesAsync(); // i had an error with set the data from seedin in the dataBAse whene i Run the Program 
                                                      // so Chenge the coniction string in (appsettings) and add the savechenge point in the (StoreContextSeed)

                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Store.Repository/SeedData/products.json"); // if you have text and you needd to convert to object
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData); // if you have object and you needd to convert to text (Revers)

                    if (products is not null)
                        await context.Products.AddRangeAsync(products);
                }

                await context.SaveChangesAsync(); // you save one time
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
            //
        }
    }
}
