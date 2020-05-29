using ConstructoIT.Hotel.Accor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.EntityConfiguration
{
    public class ConfigurationMorador : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Nome).HasMaxLength(256).IsRequired().IsUnicode(false);

            builder.HasOne(x => x.Familia)
                .WithMany(x => x.Moradores)
                .HasForeignKey(x => x.Id_Familia).IsRequired(false)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
