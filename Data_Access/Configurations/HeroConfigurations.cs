using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Configurations
{
    internal class HeroConfigurations : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set Property Configurations
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Story)
                .IsRequired(false);

            builder.Property(x => x.ImagePath)
                .IsRequired(false);
        }
    }
}
