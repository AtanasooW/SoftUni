namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using ProductShop.Utilities;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var result = context.Creators.Where(x=> x.Boardgames.Any())
                .Select(x=> new ExportCreatorDTO()
                {
                    CreatorName = x.FirstName + " " + x.LastName,
                    BoardgamesCount = x.Boardgames.Count(),
                    Boardgames = x.Boardgames.Select(x=> new ExportBoardgameDTO()
                    {
                        BoardgameName = x.Name,
                        BoardgameYearPublished = x.YearPublished
                    })
                    .OrderBy(x=> x.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(x=> x.Boardgames.Count())
                .ThenBy(x=> x.CreatorName)
                .ToArray();
            return XmlHelper.Serialize(result, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var result = context.Sellers
                .Where(x => x.BoardgamesSellers.Any(x => x.Boardgame.YearPublished >= year && x.Boardgame.Rating <= rating))
                .ToArray()
                .Select(x => new
                {
                    Name = x.Name,
                    Website = x.Website,
                    Boardgames = x.BoardgamesSellers
                    .Where(x => x.Boardgame.YearPublished >= year && x.Boardgame.Rating <= rating)
                    .ToArray()
                    .OrderByDescending(b => b.Boardgame.Rating)
                    .ThenBy(b => b.Boardgame.Name)
                    .Select(b => new
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.Boardgames.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        
    }
}