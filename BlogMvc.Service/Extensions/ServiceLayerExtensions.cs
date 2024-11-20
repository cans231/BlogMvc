using BlogMvc.DAL.Context;
using BlogMvc.DAL.Repositories.Abstracttions;
using BlogMvc.DAL.Repositories.Concretes;
using BlogMvc.DAL.UnitOfWorks;
using BlogMvc.Service.Services.Abstractions;
using BlogMvc.Service.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            var assembly =Assembly.GetExecutingAssembly(); //Bu metodu çağırmaızın sebebi bütün bu servis projesi içindeki  tüm Profile dan kalıtım alanları otamatik olarak bulup dependenciy injektion yapıyor.
            services.AddScoped<IArticleService,ArticleService> ();
            services.AddAutoMapper (assembly); //Aoutomapper ı çağırıyoruz. 
            return services;
        }
    }
}
