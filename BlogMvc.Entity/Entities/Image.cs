using BlogMvc.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.Entity.Entities
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get;set; }
    }
}
