using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeAutoMapper();
            var xmlHelper = new XmlHelper();
            var userDTOs = xmlHelper.DeserializeCollection<ImportUserDTO>(inputXml, "Users");
            var users = new List<User>();
            foreach (var item in userDTOs)
            {
                users.Add(mapper.Map<User>(item));
            }
            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";

        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeAutoMapper();
            var xmlHelper = new XmlHelper();
            var productDTOs = xmlHelper.DeserializeCollection<ImportProductDTO>(inputXml, "Products");
            var products = new List<Product>();
            foreach (var item in productDTOs)
            {
                products.Add(mapper.Map<Product>(item));
            }
            context.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeAutoMapper();
            var xmlHelper = new XmlHelper();
            var categoryDTOs = xmlHelper.DeserializeCollection<ImportCategoryDTO>(inputXml, "Categories");
            var categories = new List<Category>();
            foreach (var item in categoryDTOs)
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
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeAutoMapper();
            var xmlHelper = new XmlHelper();
            var categoryProductDTOs = xmlHelper.DeserializeCollection<ImportCategoryProductDTO>(inputXml, "CategoryProducts");
            var categoryProducts = new List<CategoryProduct>();
            foreach (var item in categoryProductDTOs)
            {
                if (item.CategoryId != null)
                {
                    if (item.ProductId != null)
                    {
                        categoryProducts.Add(mapper.Map<CategoryProduct>(item));

                    }
                }
            }
            context.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }

        //05. Export Products In Range 0/100
        public static string GetProductsInRange(ProductShopContext context)
        {

            var xmlHelper = new XmlHelper();
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(p => new ExportProductDTO()
                {
                    Price = p.Price,
                    Name = p.Name,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            return xmlHelper.Serialize(products, "Products");
        }

        // Problem 06 50/100
        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportUserDTO[] exportUserDtos = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ExportProductDTO()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize(exportUserDtos, "Users");
        }
        private static IMapper InitializeAutoMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}