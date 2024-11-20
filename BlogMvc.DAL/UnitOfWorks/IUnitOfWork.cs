using BlogMvc.Core.BaseEntity;
using BlogMvc.DAL.Repositories.Abstracttions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.DAL.UnitOfWorks
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class,IBaseEntity,new();

        Task<int> SaveAsync();
        int save();
    }
}
