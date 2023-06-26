using BookShop.Models.Enums;

namespace BookShop
{
    using BookShop.Models;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            //using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);


            var context = new BookShopContext();
            //Console.WriteLine(GetBooksByAgeRestriction(context, "miNor"));//02. Age Restriction
            //Console.WriteLine(GetGoldenBooks(context));//03. Golden Books
            //Console.WriteLine(GetBooksNotReleasedIn(context, 2000));//05. Not Released In
            //Console.WriteLine(GetBooksByPrice(context));//04. Books by Price
            //Console.WriteLine(GetBooksNotReleasedIn(context,2000));//05. Not Released In
            //Console.WriteLine(GetBooksByCategory(context, "horror mystery drama"));//06. Book Titles by Category
            //Console.WriteLine(GetBooksReleasedBefore(context, "12-04-1992"));//07. Released Before Date
            //Console.WriteLine(GetAuthorNamesEndingIn(context, "e"));//08. Author Search
            //Console.WriteLine(GetBookTitlesContaining(context, "WOR"));//09. Book Search
            //Console.WriteLine(GetBooksByAuthor(context, "po"));//10. Book Search by Author
            //Console.WriteLine(CountBooks(context, 12));//11. Count Books
            //Console.WriteLine(CountCopiesByAuthor(context));//12. Total Book Copies
            //Console.WriteLine(GetTotalProfitByCategory(context));//13. Profit by Category
            Console.WriteLine(GetMostRecentBooks(context));//14. Most Recent Books


        }
        //problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var result = context.Books.Where(x => x.AgeRestriction == ageRestriction).OrderBy(x => x.Title).Select(x => x.Title).ToList();
            return String.Join(Environment.NewLine, result);

        }
        //problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.AppendLine($"{item.Title} - ${item.Price:F2}");
            }
            return sb.ToString().Trim();
        }
        //problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = context.Books
               .Where(x => x.ReleaseDate.Value.Year != year)
               .OrderBy(x => x.BookId)
               .Select(x => x.Title)
               .ToList();
            return String.Join(Environment.NewLine, result);

        }
        //problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var list = input.Split(" ").Select(x => x.ToLower()).ToList();

            var result = context.Books
           .Where(x => x.BookCategories.Any(bc => list.Contains(bc.Category.Name.ToLower())))
           .OrderBy(x => x.Title)
           .Select(x => x.Title)
           .ToList();

            return String.Join(Environment.NewLine, result);
        }
        //problem 7

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var result = context.Books
              .Where(x => x.ReleaseDate < parsedDate)
              .OrderByDescending(x => x.ReleaseDate)
              .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}")
              .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context.Authors
              .Where(x => x.FirstName.EndsWith(input))
              .OrderBy(x => x.FirstName)
              .ThenBy(a => a.LastName)
              .Select(x => $"{x.FirstName} {x.LastName}")
              .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context.Books
            .Where(x => x.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(x => x.Title)
            .Select(x => x.Title)
            .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();
        }
        //problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = context.Authors
                .OrderByDescending(x => x.Books.Sum(x => x.Copies))
                .Select(x => $"{x.FirstName} {x.LastName} - {x.Books.Sum(x => x.Copies)}")
                .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .OrderByDescending(x => x.CategoryBooks.Sum(p => p.Book.Price * p.Book.Copies))
                .Select(x => $"{x.Name} ${x.CategoryBooks.Sum(p => p.Book.Price * p.Book.Copies):F2}")
                .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Category = x.Name,
                    Books = x.CategoryBooks
                    .OrderByDescending(p => p.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})")
                    .ToList()
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.AppendLine($"--{item.Category}");
                sb.AppendLine(String.Join(Environment.NewLine, item.Books));
            }
            return sb.ToString().Trim();
        }
        //problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();
            foreach (var item in result)
            {
                item.Price += 5;
            }

            context.SaveChanges();
        }
        //problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();
            var count = 0;
            foreach (var item in result)
            {
                context.Remove(item);
                count++;
            }
            context.SaveChanges();
            return count;

        }
    }
}



