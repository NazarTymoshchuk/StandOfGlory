using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Configurations
{
    internal class BattalionConfigurations : IEntityTypeConfiguration<Battalion>
    {
        public void Configure(EntityTypeBuilder<Battalion> builder)
        {
            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set Property configurations
            builder.Property(x => x.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder
                .HasMany(x => x.Heroes)
                .WithOne(x => x.Battalion)
                .HasForeignKey(x => x.BattalionId);
        }
    }
}
