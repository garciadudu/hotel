using ConstructoIT.Hotel.Accor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.EntityConfiguration
{
    public class ConfigurationCondominio : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Nome).HasMaxLength(256).IsRequired().IsUnicode(false);
            builder.Property(x => x.Bairro).HasMaxLength(256).IsRequired().IsUnicode(false);
        }
    }
}
