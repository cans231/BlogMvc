using BlogMvc.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.DAL.Context 
{
   
    public class BlogMvcDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        public BlogMvcDbContext()
        {
        }
        public BlogMvcDbContext(DbContextOptions<BlogMvcDbContext>options):base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        //OnModelCreating metodu, Entity Framework Core'da veri tabanı modelinin oluşturulması sırasında çağrılır. Bu metodun içinde, tablo yapılarını, ilişkileri, kısıtlamaları ve diğer veritabanı yapılandırmalarını tanımlayabiliriz.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Bu satır, geçerli projedeki tüm Entity Configuration sınıflarını otomatik olarak uygulamak için kullanılır.
            base.OnModelCreating(builder);//IDentity kütüphanesini kurmamızdan mütevellit bu yapıyı oluşturuyoruz.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Assembly.GetExecutingAssembly ifadesi, çalışmakta olan yürütülebilir dosyanın bulunduğu derlemeyi ifade eder.
            //Bu yöntem, projedeki tüm konfigürasyonları manuel olarak tek tek uygulamak yerine, o derlemedeki tüm konfigürasyon sınıflarını otomatik olarak bulur ve uygular. Yani, entity sınıfları için belirlenmiş tüm yapılandırmalar (fluent API kullanılarak yapılanlar) modelleme sırasında uygulanır.
        }





    }
}
