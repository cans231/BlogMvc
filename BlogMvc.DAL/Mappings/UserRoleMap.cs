using BlogMvc.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.DAL.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId=Guid.Parse("04334454-BE2C-46D5-A0D4-B47BED3A9CDA"),
                RoleId=Guid.Parse("05740A04-06ED-4698-9D2C-306FDD4814CD")
            },
            new AppUserRole
            {
                UserId=Guid.Parse("74349438-A454-413C-9B3E-2F7563A1FA07"),
                RoleId=Guid.Parse("9BC34F79-D60C-49CA-825B-FA47638C43E6")
            });

        }
    }
}
