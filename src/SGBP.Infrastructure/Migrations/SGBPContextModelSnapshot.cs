﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGBP.Infrastructure.Data;

namespace SGBP.Infrastructure.Migrations
{
    [DbContext(typeof(SGBPContext))]
    partial class SGBPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.Auditoria", b =>
                {
                    b.Property<int>("AuditoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprovado");

                    b.Property<DateTime>("Data");

                    b.HasKey("AuditoriaId");

                    b.ToTable("Auditorias");
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.BemPatrimonial", b =>
                {
                    b.Property<int>("BemPatrimonialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroTombo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(30)");

                    b.Property<int>("ResponsavelId");

                    b.HasKey("BemPatrimonialId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("BemPatrimonials");
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.BemPatrimonialAuditoria", b =>
                {
                    b.Property<int>("BemPatrimonialAuditoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuditoriaId");

                    b.Property<int>("BemPatrimonialId");

                    b.HasKey("BemPatrimonialAuditoriaId");

                    b.HasIndex("AuditoriaId");

                    b.HasIndex("BemPatrimonialId");

                    b.ToTable("BemPatrimonialAuditorias");
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(400)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(9)");

                    b.Property<int>("ResponsavelId");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ResponsavelId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.Responsavel", b =>
                {
                    b.Property<int>("ResponsavelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(300)");

                    b.HasKey("ResponsavelId");

                    b.ToTable("Responsavels");
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.BemPatrimonial", b =>
                {
                    b.HasOne("SGBP.ApplicationCore.Entity.Categoria", "Categoria")
                        .WithMany("BemPatrimonials")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGBP.ApplicationCore.Entity.Responsavel", "Responsavel")
                        .WithMany("BemPatrimonials")
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.BemPatrimonialAuditoria", b =>
                {
                    b.HasOne("SGBP.ApplicationCore.Entity.Auditoria", "Auditoria")
                        .WithMany("BemPatrimonialAuditoria")
                        .HasForeignKey("AuditoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGBP.ApplicationCore.Entity.BemPatrimonial", "BemPatrimonial")
                        .WithMany("BemPatrimonialAuditoria")
                        .HasForeignKey("BemPatrimonialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGBP.ApplicationCore.Entity.Endereco", b =>
                {
                    b.HasOne("SGBP.ApplicationCore.Entity.Responsavel", "Responsavel")
                        .WithOne("Endereco")
                        .HasForeignKey("SGBP.ApplicationCore.Entity.Endereco", "ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
