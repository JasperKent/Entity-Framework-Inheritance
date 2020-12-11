using EF6TPCInheritance;
using System;

namespace EFInheritanceConsole
{
    class Program
    {
        private static void CreateDB()
        {
            using (var db = new PetsContext("PetsTPC"))
            {
                db.Database.Delete();
                db.Database.CreateIfNotExists();

                // Note:
                // 1) With TPC, we can't have a foreign key column in the base class - thus we have no Owner.
                // 2) With TPC, auto generation of integer promary keys does not work, hence manually provided
                db.Dogs.Add(new Dog { Id = 1, Name = "Rover", FavouriteBone = "Beef" });
                db.Dogs.Add(new Dog { Id = 2, Name = "Fido", FavouriteBone = "Lamb" });
                db.Cats.Add(new Cat { Id = 3, Name = "Tiddles", Lives = 9 });
                db.Cats.Add(new Cat { Id = 4, Name = "Felix", Lives = 2 });

                db.SaveChanges();
            }
        }

        private static void ShowDBData()
        {
            using (var db = new PetsContext("PetsTPC"))
            {
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
        }

        static void Main()
        {
            CreateDB();

            ShowDBData();
        }
    }
}
