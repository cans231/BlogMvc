using BlogMvc.DAL.Context;
using BlogMvc.DAL.Repositories.Abstracttions;
using BlogMvc.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogMvcDbContext dbContext;

        public UnitOfWork(BlogMvcDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }

        public int save()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return  await dbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(dbContext);
        }
    }
}
