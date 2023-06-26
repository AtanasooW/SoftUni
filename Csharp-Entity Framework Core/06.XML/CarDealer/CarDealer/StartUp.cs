using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using ProductShop.Utilities;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {

        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeAutoMapper();
            var xmlHelper = new XmlHelper();
            var supplierDTOs = xmlHelper.DeserializeCollection<ImportSupplierDTO>(inputXml, "Suppliers");
            var suppliers = new List<Supplier>();
            foreach (var item in supplierDTOs)
            {
                suppliers.Add(mapper.Map<Supplier>(item));
            }
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeAutoMapper();
            var xmlHelper = new XmlHelper();
            var partDTOs = xmlHelper.DeserializeCollection<ImportPartDTO>(inputXml, "Parts");
            var parts = new List<Part>();
            foreach (var item in partDTOs)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }

                if (!item.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == item.SupplierId))
                {
                    // Missing or wrong supplier id
                    continue;
                }
                parts.Add(mapper.Map<Part>(item));

            }
            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }
        //11. Import Cars 

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDTO[] carDtos =
                xmlHelper.Deserialize<ImportCarDTO[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (ImportCarDTO carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) ||
                    string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);

                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };
                    car.PartsCars.Add(carPart);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";

        }
        private static IMapper InitializeAutoMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}