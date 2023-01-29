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
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.PersonalNumber)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(s => s.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(s => s.Gender)
                .HasColumnType("tinyint");


            builder.Property(s => s.ImagePath).HasMaxLength(200);

            builder.HasMany(p => p.Phones)
                .WithOne(pn => pn.Person)
                .HasForeignKey(pn => pn.PersonId);
                
            
            
        }
     }
}
