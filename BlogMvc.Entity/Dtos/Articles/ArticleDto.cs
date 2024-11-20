using BlogMvc.Core.BaseEntity;
using BlogMvc.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.Entity.Dtos.Articles
{
    public class ArticleDto 
    {
        public Guid Id {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public string  CreatedBy {  get; set; }
        public DateTime CreatedDate {  get; set; }





    }
}
