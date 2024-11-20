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
    .AddRoleManager<RoleManager<AppRole>>() //Identity kütüphanesinin Role özelliklerini kullanmamýzý saðlar.
    .AddEntityFrameworkStores<BlogMvcDbContext>()//Identity kütüphanesini database de oluþturamýzý saðlar.
    .AddDefaultTokenProviders(); //Kimlik doðrulama 2 katmanlý kimlik doðrulama gibi güvenlik iþlemlerine token oluþturur.
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie=new CookieBuilder
    {
        Name= "BlogMvc", //Oluþturulacak Cookie'yi isimlendiriyoruz.
        HttpOnly=true, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
        SameSite=SameSiteMode.Strict,//Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
        SecurePolicy=CookieSecurePolicy.SameAsRequest //HTTPS üzerinden eriþilebilir yapýyoruz.

    };
    config.SlidingExpiration=true;//Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
    config.ExpireTimeSpan=TimeSpan.FromDays(5);//CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
    config.AccessDeniedPath=new PathString("/Admin/Auth/AccessDenied");//Yetkisiz bir giriþ olduðunda bizi burdaki sayfaya atacak.
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
app.UseAuthentication();//Kimlik doðrulama iþlemi.
app.UseAuthorization(); // Yetkilendirme iþlemi.
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
