namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using ProductShop.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var dtos = XmlHelper.Deserialize<ImportCreatorDTO[]>(xmlString, "Creators");
            var validCreators = new HashSet<Creator>();
            foreach (var creatorDTO in dtos)
            {
                if (!IsValid(creatorDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Creator creator = new Creator()
                {
                    FirstName = creatorDTO.FirstName,
                    LastName = creatorDTO.LastName
                };
                foreach (var boardgameDTO in creatorDTO.Boardgames)
                {
                    if (!IsValid(boardgameDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    creator.Boardgames.Add(new Boardgame()
                    {
                        Name = boardgameDTO.Name,
                        Rating = boardgameDTO.Rating,
                        YearPublished = boardgameDTO.YearPublished,
                        CategoryType = (CategoryType)boardgameDTO.CategoryType,
                        Mechanics = boardgameDTO.Mechanics
                    });
                }
                validCreators.Add(creator);
                sb.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }
            context.AddRange(validCreators);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var sellerDTOs = JsonConvert.DeserializeObject<ImportSellerDTO[]>(jsonString);
            var validSellers = new HashSet<Seller>();
            foreach (var sellerDTO in sellerDTOs)
            {
                if (!IsValid(sellerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Seller seller = new Seller()
                {
                    Name = sellerDTO.Name,
                    Address = sellerDTO.Address,
                    Country = sellerDTO.Country,
                    Website = sellerDTO.Website
                };
                foreach (var boardgameid in sellerDTO.BoardgamesIds.Distinct())
                {
                    Boardgame boardgame = context.Boardgames.Find(boardgameid);
                    if (boardgame == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    seller.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        BoardgameId = boardgame.Id
                    });
                }
                validSellers.Add(seller);
                sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }
            context.AddRange(validSellers);
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
