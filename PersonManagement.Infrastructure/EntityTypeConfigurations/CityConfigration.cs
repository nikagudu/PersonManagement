using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.EntityTypeConfigurations
{
    internal class CityConfigration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");           
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).HasMaxLength(100);

            builder.HasMany(s => s.Persons)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityID)
                .IsRequired(false);
        }
    }
}
