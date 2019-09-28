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
            //Migirationu a�t�k
            AutomaticMigrationsEnabled = true;
            
            //Veri kay�plar�na izin ver komutu
            AutomaticMigrationDataLossAllowed = true;
        }


        //Her bir de�i�iklikte bu s�n�f �al��acak,
        //public class DbInitializer : CreateDatabaseIfNotExists<DatabaseContext>
        //{
        //    protected override void Seed(DatabaseContext context)
        // bu metot ile ayn�
        protected override void Seed(DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //Her Migration sonras� Seed metodu �al���r
            for (int i =0; i < 10; i++)
            {
                //Ayn� verinin yediden eklnemmemisi i�in "AddOrUpdate()" kullan�lmaml� bu sayede kopyaveri olu�mayacakt�r.
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
