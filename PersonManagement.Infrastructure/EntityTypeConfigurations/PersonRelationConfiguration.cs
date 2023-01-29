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
    internal class PersonRelationConfiguration : IEntityTypeConfiguration<PersonRelation>
    {
        public void Configure(EntityTypeBuilder<PersonRelation> builder)
        {
            builder.ToTable("PersonRelations");

            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Person)
                .WithMany(s => s.PersonRelations)
                .HasForeignKey(s => s.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.RelatedPerson)
                .WithMany(s => s.RelatedPersons)
                .HasForeignKey(s => s.RelatedPersonId)
                .OnDelete(DeleteBehavior.Restrict);
                

            builder.Property(s => s.PersonRelationType)
             .HasColumnType("tinyint");

        }
    }
}
