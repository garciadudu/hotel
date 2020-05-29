using ConstructoIT.Hotel.Accor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.EntityConfiguration
{
    public class ConfigurationFamilia : IEntityTypeConfiguration<Familia>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Familia> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(256).IsUnicode(false);
            builder.HasOne(x => x.Condominio)
                .WithMany(x => x.Familias)
                .HasForeignKey(x => x.Id_Condominio)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
}
}
