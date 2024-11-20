using BlogMvc.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.Entity.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid? ImageID { get; set; }
        public Image Image { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

    }
}
