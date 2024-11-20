using BlogMvc.DAL.Context;
using BlogMvc.DAL.Repositories.Abstracttions;
using BlogMvc.DAL.Repositories.Concretes;
using BlogMvc.DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.DAL.Extensions
{
    public static  class DALExtensitons
    {
        public static IServiceCollection LoadDALExtensitons(this IServiceCollection services,IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<BlogMvcDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
