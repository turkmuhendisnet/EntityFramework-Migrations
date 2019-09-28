namespace Migrations_.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            //Migirationu açtýk
            AutomaticMigrationsEnabled = true;
            
            //Veri kayýplarýna izin ver komutu
            AutomaticMigrationDataLossAllowed = true;
        }


        //Her bir deðiþiklikte bu sýnýf çalýþacak,
        //public class DbInitializer : CreateDatabaseIfNotExists<DatabaseContext>
        //{
        //    protected override void Seed(DatabaseContext context)
        // bu metot ile ayný
        protected override void Seed(DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //Her Migration sonrasý Seed metodu çalýþýr
            for (int i =0; i < 10; i++)
            {
                //Ayný verinin yediden eklnemmemisi için "AddOrUpdate()" kullanýlmamlý bu sayede kopyaveri oluþmayacaktýr.
                //context.Books.Add(new Book()
                context.Books.AddOrUpdate(new Book()
                {
                    Id = i + 1,
                    Name = FakeData.NameData.GetCompanyName(),
                    Description = FakeData.TextData.GetSentence(),
                    PublishedDate = FakeData.DateTimeData.GetDatetime()

                });
            }
        }
    }
}
