namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.Where(a => a.ProducerId == producerId)
                .ToList()//For bug
                .OrderByDescending(a => a.Price)
                .ToList();
            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}" + Environment.NewLine +
                    $"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}" + Environment.NewLine +
                    $"-ProducerName: {album.Producer.Name}" + Environment.NewLine +
                    $"-Songs:");
                int count = 1;
                foreach (var item in album.Songs.OrderByDescending(x => x.Name).ThenBy(x => x.Writer.Name))
                {
                    sb.AppendLine($"---#{count}" + Environment.NewLine +
                    $"---SongName: {item.Name}" + Environment.NewLine +
                    $"---Price: {item.Price:F2}" + Environment.NewLine +
                    $"---Writer: {item.Writer.Name}");
                    count++;
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");

            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var result = context.Songs.AsEnumerable().Where(x => x.Duration.TotalSeconds > duration).OrderBy(x => x.Name).ThenBy(x => x.Writer.Name).ToList();
            var sb = new StringBuilder();
            int count = 1;

            foreach (var item in result)
            {
                sb.AppendLine($"-Song #{count}" + Environment.NewLine +
                   $"---SongName: {item.Name}" + Environment.NewLine +
                   $"---Writer: {item.Writer.Name}");
                foreach (var performer in item.SongPerformers.OrderBy(p=> p.Performer.FirstName))
                {
                    sb.AppendLine($"---Performer: {performer.Performer.FirstName} {performer.Performer.LastName}");
                }
                sb.AppendLine($"---AlbumProducer: {item.Album.Producer.Name}" + Environment.NewLine +
                   $"---Duration: {item.Duration.ToString("c")}");
                count++;
            }
            return sb.ToString().Trim();
        }
    }
}
