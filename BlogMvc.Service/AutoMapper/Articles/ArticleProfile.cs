using AutoMapper;
using BlogMvc.Entity.Dtos.Articles;
using BlogMvc.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.Service.AutoMapper.Articles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto,Article >().ReverseMap(); //Burdaki CreateMap metodu ile ArticleDto istediğimizde bize Article ı veriyo ReverseMap ise Article istersekde bize ArticleDto ile dönüş yapılmasını sağlıyor.
        }
    }
}
