using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
        }
        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var userDTOs = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);
            List<User> users = new List<User>();
            foreach (var item in userDTOs)
            {
                users.Add(mapper.Map<User>(item));
            }
            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
        //02. Import Products

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            var produsctsDTOs = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);
            List<Product> products = new List<Product>();
            foreach (var item in produsctsDTOs)
            {
                products.Add(mapper.Map<Product>(item));
            }
            context.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }
        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            var categoriesDTOs = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);
            var categories = new List<Category>();
            foreach (var item in categoriesDTOs)
            {
                if (item.Name != null)
                {
                    categories.Add(mapper.Map<Category>(item));
                }
            }
            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }
        //04. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            var categoryProductDTOs = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            var categoryProducts = new List<CategoryProduct>();
            foreach (var item in categoryProductDTOs)
            {
                categoryProducts.Add(mapper.Map<CategoryProduct>(item));
            }
            context.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }
        //05. Export Products In Range

        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            var productDTOs = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ExportProductDTO>(mapper.ConfigurationProvider)
                .ToArray();
            var result = JsonConvert.SerializeObject(productDTOs, Formatting.Indented);
            return result;

        }
        //06. Export Sold Products 50/100
        public static string GetSoldProducts(ProductShopContext context)
        {
            var result = context.Users.Where(x => x.ProductsSold.Count >= 1 || x.ProductsSold.FirstOrDefault(ps => ps.Buyer != null) != null)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(ps => ps.Buyer != null).Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName

                    }).ToArray()
                });
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var result = context.Categories
                .OrderByDescending(x => x.CategoriesProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoriesProducts.Count,
                    averagePrice = (x.CategoriesProducts.Any() ? x.CategoriesProducts.Average(x => x.Product.Price) : 0).ToString("f2"),
                    totalRevenue = (x.CategoriesProducts.Any() ? x.CategoriesProducts.Sum(x => x.Product.Price) : 0).ToString("f2"),

                });
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var result = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(y => new
                {
                    firstName = y.FirstName,
                    lastName = y.LastName,
                    age = y.Age,
                    soldProducts = new
                    {
                        count = y.ProductsSold
                        .Count(p=> p.Buyer != null),

                        products = y.ProductsSold
                        .Where(p=> p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        }).ToArray()
                    }
                }).ToArray();
            var resultObject = new
            {
                usersCount = result.Length,
                users = result
            };
            return JsonConvert.SerializeObject(resultObject, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}