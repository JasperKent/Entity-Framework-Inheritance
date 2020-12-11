using EFInheritance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFInheritanceConsole
{
    class Program
    {
        private static Owner CreateData()
        {
            return new Owner
            {
                Pets = new List<Pet>
                {
                    new Dog { Name = "Rover", FavouriteBone = "Beef" },
                    new Dog { Name = "Fido", FavouriteBone = "Lamb" },
                    new Cat { Name = "Tiddles", Lives = 9 },
                    new Cat { Name = "Felix", Lives = 2 }
                }
            };
        }

        private static void ShowLocalData()
        {
            var owner = CreateData();

            Console.WriteLine(owner);
        }

        private static void CreateDB()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<PetsContext>()
                .UseSqlServer(config.GetConnectionString("PetsDB"))
                .Options;

            using var db = new PetsContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var owner = CreateData();

            db.Owners.Add(owner);

            db.SaveChanges();
        }

        private static void ShowDBData()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<PetsContext>()
                .UseSqlServer(config.GetConnectionString("PetsDB"))
                .Options;

            using var db = new PetsContext(options);

            Console.WriteLine("From Owner:");
            Console.WriteLine(db.Owners.Include(o => o.Pets).First());

            Console.WriteLine("All Pets:");

            foreach (var p in db.Pets)
                Console.WriteLine(p);

            Console.WriteLine("\nAll Cats:");

            foreach (var c in db.Cats)
                Console.WriteLine(c);

            Console.WriteLine("\nAll Dogs:");

            foreach (var d in db.Dogs)
                Console.WriteLine(d);
        }

        static void Main()
        {
            //ShowLocalData();

            CreateDB();

            ShowDBData();
        }
    }
}
