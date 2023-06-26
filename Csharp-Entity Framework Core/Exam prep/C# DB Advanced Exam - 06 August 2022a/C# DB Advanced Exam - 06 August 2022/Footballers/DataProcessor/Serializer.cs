namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.Utilities;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches.Where(x => x.Footballers.Count() >= 1).ToArray().Select(x => new ExportCoachDTO()
            {
                CoachName = x.Name,
                FootballersCount = x.Footballers.Count(),
                Footballers = (ExportFootballerDTO[])x.Footballers.Select(f => new ExportFootballerDTO()
                {
                    Name = f.Name,
                    Position = f.PositionType.ToString()
                }).OrderBy(f => f.Name)
                .ToArray()
            }).OrderByDescending(x => x.Footballers.Count())
            .ThenBy(x => x.CoachName)
            .ToArray();
            var seriliazed = XmlHelper.Serialize<ExportCoachDTO>(coaches, "Coaches");
            return seriliazed;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(x => x.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(x => new
                {
                    x.Name,
                    Footballers = x.TeamsFootballers
                        .Where(x => x.Footballer.ContractStartDate >= date)
                        .ToArray()
                        .OrderByDescending(x => x.Footballer.ContractEndDate)
                        .ThenBy(f => f.Footballer.Name)
                        .Select(f => new
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.Footballer.BestSkillType.ToString(),
                            PositionType = f.Footballer.PositionType.ToString()

                        }).ToArray()
                })
                .OrderByDescending(x => x.Footballers.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }

    }
}
