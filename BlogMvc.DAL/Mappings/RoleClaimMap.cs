using BlogMvc.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvc.DAL.Mappings
{
    public class RoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppRoleClaim> builder)
        {
            // Primary key
            builder.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            builder.ToTable("AspNetRoleClaims");
        }
    }
}
