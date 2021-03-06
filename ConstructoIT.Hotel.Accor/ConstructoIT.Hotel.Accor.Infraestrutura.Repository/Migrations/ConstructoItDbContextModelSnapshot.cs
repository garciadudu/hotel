﻿// <auto-generated />
using ConstructoIT.Hotel.Accor.Dominio.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Migrations
{
    [DbContext(typeof(ConstructoItDbContext))]
    partial class ConstructoItDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConstructoIT.Hotel.Accor.Domain.Entities.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Condominio");
                });

            modelBuilder.Entity("ConstructoIT.Hotel.Accor.Domain.Entities.Familia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Apto")
                        .HasColumnType("int");

                    b.Property<int>("Id_Condominio")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Id_Condominio");

                    b.ToTable("Familia");
                });

            modelBuilder.Entity("ConstructoIT.Hotel.Accor.Domain.Entities.Morador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Familia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<int>("QuantidadeBichosEstimacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Familia");

                    b.ToTable("Morador");
                });

            modelBuilder.Entity("ConstructoIT.Hotel.Accor.Domain.Entities.Familia", b =>
                {
                    b.HasOne("ConstructoIT.Hotel.Accor.Domain.Entities.Condominio", "Condominio")
                        .WithMany("Familias")
                        .HasForeignKey("Id_Condominio")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ConstructoIT.Hotel.Accor.Domain.Entities.Morador", b =>
                {
                    b.HasOne("ConstructoIT.Hotel.Accor.Domain.Entities.Familia", "Familia")
                        .WithMany("Moradores")
                        .HasForeignKey("Id_Familia")
                        .OnDelete(DeleteBehavior.ClientNoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
