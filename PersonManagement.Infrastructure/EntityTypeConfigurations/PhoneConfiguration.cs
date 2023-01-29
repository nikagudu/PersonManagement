using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Domain.Entities;
using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.EntityTypeConfigurations
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Phones");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.PhoneNumber)
                .HasColumnType("varchar(50)");

            builder.Property(s => s.PhoneNumberType)
             .HasColumnType("tinyint");
        }
    }
}
