using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace AzureDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder => {
                builder
                       .AddConsole();
                }
            );

            var builder = new DbContextOptionsBuilder<AkademiaDemoContext>();
            builder
                //.UseSqlServer("<CONNECTION_STRING>")
                .UseSqlite("Data Source=akademia.db")
                .UseLoggerFactory(loggerFactory);

            var dbContext = new AkademiaDemoContext(builder.Options);

            var users = dbContext.Users.Select(x => x).ToList();
            Console.WriteLine(users.Count());

            //var users2 = dbContext.Users.Where(x => x.Name == "Zykfryd").ToList();


            //var userStatistic = from user in dbContext.Users
            //                    join post in dbContext.Posts on user.Id equals post.UserId
            //                    group user by user.Name into grouped
            //                    select new { PersonName = grouped.Key, CountP = grouped.Count() };

            //foreach (var userS in userStatistic)
            //{
            //    Console.WriteLine($"{userS.PersonName} has: {userS.CountP} posts.");
            //}

        }
    }
}
