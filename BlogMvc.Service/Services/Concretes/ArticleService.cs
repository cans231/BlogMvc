using AutoMapper;
using BlogMvc.DAL.UnitOfWorks;
using BlogMvc.Entity.Dtos.Articles;
using BlogMvc.Entity.Entities;
using BlogMvc.Service.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogMvc.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private  readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;   
            this.mapper=mapper;
        }

        public async Task<List<ArticleDto>> GetAllArticlesAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync();
            var map =mapper.Map<List<ArticleDto>>(articles);

            return map;

            
        }
    }
}
