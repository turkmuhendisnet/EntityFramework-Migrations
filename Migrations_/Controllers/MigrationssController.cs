using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Migrations_.Controllers
{
    public class MigrationssController : Controller
    {
        // GET: Migrationss
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            db.Books.ToList();
            return View();
        }
    }
}
public class DatabaseContext : DbContext
{

    public DbSet<Book> Books { get; set; }

    public DatabaseContext()
    {

        //bu set SetInitializer bizden "MigrateDatabaseToLatestVersion" bu da contextimizin ismini ve "Migrations" clasımızın olduğu yeri sitiyor
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,Migrations_.Migrations.Configuration>());
    }


}
//Migirationda değişiklik yaparken tabloya sutun eklerken Null olarak geçile bilne string değerlerin daha sonra değiştirildiğinde "int" yapıldığından 
//Null olduğundan int uyarlayamayacaktır adım adım yaparak ayarlanırsa hata vermiyecektir.Çünkü Null int dönüşmeyecektir ilk önce değer atayıp sonra int yapıla bilir.

[Table("Books")]
public class Book
{
    [Key]
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime PublishedDate { get; set; }
}
/*
 * Manuel Migiration ayarları (için parça parça yapmak için)
 * 
 * Consola: Add-Migration ve bir isim girildiğinde 
 * değişiklikler algılanıcak ve bir adet Migration klosörüne bir claa üretilecek ve içerisinde 
 * Up ve Down adından iki metot olucak 
 * bunlar 
 * Up yapılan değişikliklerin olduğu metot
 * Down ise değişiklikler yansımaz ise bu değişiklikleri geri almak için olan metot
 * 
 * Up metotudun içerisinde yaptığımız değişiklikleri database yansıması için
 * Consola 
 * Update-Database yazılmalı
 * eğer bir hata alınırsa bu uygunamadığını gösterir yine veri tabanında ontrol et belki uygulamıştır
 * 
 * Burada oluşan Migration dosyası siline bilir her seferinde bu dosya çalışmayacaktır.
 */