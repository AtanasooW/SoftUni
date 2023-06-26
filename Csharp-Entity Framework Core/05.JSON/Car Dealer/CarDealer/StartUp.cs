using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {

        }
        //09. Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
            var supplierDTOs = JsonConvert.DeserializeObject<ImportSupplierDTO[]>(inputJson);
            var suppliers = new List<Supplier>();
            foreach (var item in supplierDTOs)
            {
                suppliers.Add(mapper.Map<Supplier>(item));
            }
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }
        //10. Import Parts

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
            var partDTOs = JsonConvert.DeserializeObject<ImportPartDTO[]>(inputJson);
            var parts = new List<Part>();
            foreach (var item in partDTOs)
            {
                if (context.Suppliers.Any(x => x.Id == item.SupplierId))
                {
                    parts.Add(mapper.Map<Part>(item));

                }
            }
            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }
        //11. Import Cars 50/100?

        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
            var carDTOs = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);
            var cars = mapper.Map<Car[]>(carDTOs);

            context.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Length}.";
        }
        //12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
            var customerDTOs = JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson);
            var customers = mapper.Map<Customer[]>(customerDTOs);

            context.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}.";
        }
        //13. Import Sales

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
            var saleDTOs = JsonConvert.DeserializeObject<ImportSaleDTO[]>(inputJson);
            var sales = mapper.Map<Sale[]>(saleDTOs);

            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Length}.";
        }
        //14. Export Ordered Customers

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var result = context.Customers.OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                }).ToArray();
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        //15. Export Cars From Make Toyota 0/100????
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var result = context.Cars
                .Where(x => x.Make.ToLower() == "toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TravelledDistance,
                }).ToArray();
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        //16. Export Local Suppliers

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var result = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                }).ToArray();
            return JsonConvert.SerializeObject(result, Formatting.Indented);

        }
        //17. Export Cars With Their List Of Parts

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var result = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TravelledDistance
                    },
                    parts = c.PartsCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                }).ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        //18. Export Total Sales By Customer

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var result = context.Customers.Where(x => x.Sales.Count >= 1)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(c => c.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();
            return JsonConvert.SerializeObject(result, Formatting.Indented);

        }
        //19. Export Sales With Applied Discount 0/100
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var result = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TraveledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    discount = $"{x.Discount}:F2",
                    price = $"{x.Car.PartsCars.Sum(x => x.Part.Price)}:F2",
                    priceWithDiscount = $"{x.Car.PartsCars.Sum(x => x.Part.Price) * (1 - x.Discount / 100)}:F2"
                }).ToArray();
            return JsonConvert.SerializeObject(result, Formatting.Indented);

        }

    }
}