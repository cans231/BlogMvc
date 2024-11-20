using BlogMvc.Entity.Dtos.Articles;
using BlogMvc.Entity.Entities;
using BlogMvc.Service.Services.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesAsync();
    }
}
