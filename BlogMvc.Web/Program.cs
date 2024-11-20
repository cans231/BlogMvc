using Microsoft.EntityFrameworkCore;
using BlogMvc.DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using BlogMvc.DAL.Extensions;
using BlogMvc.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using BlogMvc.Entity.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDALExtensitons(builder.Configuration);
builder.Services.LoadServiceLayerExtensions();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireNonAlphanumeric = true;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;

})
    .AddRoleManager<RoleManager<AppRole>>() //Identity k�t�phanesinin Role �zelliklerini kullanmam�z� sa�lar.
    .AddEntityFrameworkStores<BlogMvcDbContext>()//Identity k�t�phanesini database de olu�turam�z� sa�lar.
    .AddDefaultTokenProviders(); //Kimlik do�rulama 2 katmanl� kimlik do�rulama gibi g�venlik i�lemlerine token olu�turur.
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie=new CookieBuilder
    {
        Name= "BlogMvc", //Olu�turulacak Cookie'yi isimlendiriyoruz.
        HttpOnly=true, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
        SameSite=SameSiteMode.Strict,//K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
        SecurePolicy=CookieSecurePolicy.SameAsRequest //HTTPS �zerinden eri�ilebilir yap�yoruz.

    };
    config.SlidingExpiration=true;//Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
    config.ExpireTimeSpan=TimeSpan.FromDays(5);//CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
    config.AccessDeniedPath=new PathString("/Admin/Auth/AccessDenied");//Yetkisiz bir giri� oldu�unda bizi burdaki sayfaya atacak.
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();//Kimlik do�rulama i�lemi.
app.UseAuthorization(); // Yetkilendirme i�lemi.
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Auth}/{action=Login}/{id?}"
        );
        endpoints.MapDefaultControllerRoute();

        
});

app.Run();
