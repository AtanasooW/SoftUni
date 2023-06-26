namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using ProductShop.Utilities;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachDTOs = XmlHelper.DeserializeCollection<ImportCoachDTO>(xmlString, "Coaches");
            var validCoaches = new HashSet<Coach>();
            var sb = new StringBuilder();
            foreach (var coachDTO in coachDTOs)
            {
                if (!IsValid(coachDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(coachDTO.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Coach coach = new Coach()
                {
                    Name = coachDTO.Name,
                    Nationality = coachDTO.Nationality
                };

                foreach (var footballerDTO in coachDTO.Footballers)
                {
                    if (!IsValid(footballerDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime startDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(footballerDTO.ContractStartDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out startDate);
                    if (!isFootballerContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime endDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(footballerDTO.ContractEndDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out endDate);
                    if (!isFootballerContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (startDate >= endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDTO.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        PositionType = (PositionType)footballerDTO.PositionType,
                        BestSkillType = (BestSkillType)footballerDTO.BestSkillType,
                        Coach = coach
                    };
                    coach.Footballers.Add(footballer);
                }
                validCoaches.Add(coach);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }
            context.AddRange(validCoaches);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamDTOs = JsonConvert.DeserializeObject<ImportTeamDTO[]>(jsonString);
            var validTeams = new HashSet<Team>();   
            var sb = new StringBuilder();
            foreach (var teamDTO in teamDTOs)
            {
                if (!IsValid(teamDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (teamDTO.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Team team = new Team()
                {
                    Name = teamDTO.Name,
                    Nationality = teamDTO.Nationality,
                    Trophies = teamDTO.Trophies
                };
                foreach (var footballerId in teamDTO.FootballersIDs.Distinct())
                {
                    Footballer f = context.Footballers.Find(footballerId);
                    if (f == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = f
                    });
                }
                validTeams.Add(team);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }
            context.AddRange(validTeams);
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
