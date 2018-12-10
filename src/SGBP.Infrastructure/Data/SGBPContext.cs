using Microsoft.EntityFrameworkCore;
using SGBP.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGBP.Infrastructure.Data
{
    public class SGBPContext : DbContext

    {

        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<BemPatrimonial> BemPatrimonials { get; set; }
        public DbSet<BemPatrimonialAuditoria> BemPatrimonialAuditorias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Responsavel> Responsavels { get; set; }


       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BdSGBP;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region ENDEREÇO
            modelBuilder.Entity<Endereco>()
                .Property(x => x.Logradouro)
                .HasColumnType("varchar(400)");


            modelBuilder.Entity<Endereco>()
                 .Property(x => x.Bairro)
                 .HasColumnType("varchar(200)");

            modelBuilder.Entity<Endereco>()
                .Property(x => x.CEP)
                .HasColumnType("varchar(12)");

            modelBuilder.Entity<Endereco>()
               .Property(x => x.Numero)
               .HasColumnType("varchar(9)");

            #endregion

                        
            #region RESPONSAVEL 
            modelBuilder.Entity<Responsavel>()
                .Property(x => x.Nome)
                .HasColumnType("varchar(300)");


            modelBuilder.Entity<Responsavel>()
                 .Property(x => x.Email)
                 .HasColumnType("varchar(200)");


            #endregion


            #region BEM PATRIMONIAL
            modelBuilder.Entity<BemPatrimonial>()
                .Property(x => x.NumeroTombo)
                .HasColumnType("varchar(30)");


            modelBuilder.Entity<BemPatrimonial>()
                 .Property(x => x.Descricao)
                 .HasColumnType("varchar(200)");

            #endregion


            #region CATEGORIA
            modelBuilder.Entity<Categoria>()
                .Property(x => x.Descricao)
                .HasColumnType("varchar(400)");

            #endregion



           
        }
    }
}
