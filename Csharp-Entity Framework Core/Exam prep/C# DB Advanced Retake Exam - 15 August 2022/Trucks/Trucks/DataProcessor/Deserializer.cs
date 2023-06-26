namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despachers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportDespacherDTO), xmlRoot);

            StringReader reader = new StringReader(xmlString);
            ImportDespacherDTO[] despatcherDTOs = (ImportDespacherDTO[])xmlSerializer.Deserialize(reader);
            List<Despatcher> despatchers = new List<Despatcher>();
            var sb = new StringBuilder();
            foreach (var item in despatcherDTOs)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                ICollection<Truck> validTrucks = new HashSet<Truck>();
                foreach (var truck in item.Trucks)
                {
                    if (!IsValid(truck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Truck truck1 = new Truck()
                    {
                        RegistrationNumber = truck.RegistrationNumber,
                        VinNumber = truck.VinNumber,
                        TankCapacity = truck.TankCapacity,
                        CargoCapacity = truck.CargoCapacity,
                        CategoryType = (CategoryType)truck.CategoryType,
                        MakeType = (MakeType)truck.MakeType
                    };
                    validTrucks.Add(truck1);
                }
                Despatcher despatcher = new Despatcher()
                {
                    Name = item.Name,
                    Position = item.Position,
                    Trucks = validTrucks
                };
                despatchers.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }
            context.AddRange(despatchers);
            context.SaveChanges();
            return sb.ToString().Trim();


        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var clientDTOs = JsonConvert.DeserializeObject<ImportClientDTO[]>(jsonString);
            List<int> exTrucks = context.Trucks.Select(x => x.Id).ToList();
            var clients = new HashSet<Client>();
            var sb = new StringBuilder();
            foreach (var client in clientDTOs)
            {
                if (!IsValid(client))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (client.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client1 = new Client()
                {
                    Name = client.Name,
                    Nationality = client.Nationality,
                    Type = client.Type
                };
                foreach (var truckId in client.TruckId)
                {
                    if (!exTrucks.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client1,
                        TruckId = truckId
                    };
                    client1.ClientsTrucks.Add(clientTruck);

                }
                clients.Add(client1);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client1.Name, client1.ClientsTrucks.Count));
            }
            context.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().Trim();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}