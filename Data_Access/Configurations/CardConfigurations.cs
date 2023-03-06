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
    internal class CardConfigurations : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set Property configurations
            builder.Property(x => x.Number)
                   .HasMaxLength(100)
                   .IsRequired();

            builder
                .HasMany(x => x.Heroes)
                .WithOne(x => x.Card)
                .HasForeignKey(x => x.CardId);
        }
    }
}
