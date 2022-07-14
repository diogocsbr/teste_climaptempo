using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace teste.clima.models.Models
{
    public partial class ClimaTempoSimplesContext : DbContext
    {
        String ConnectionString { get; }
        public ClimaTempoSimplesContext(string conn)
        {
            ConnectionString = conn;
        }

        public ClimaTempoSimplesContext(DbContextOptions<ClimaTempoSimplesContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<PrevisaoClima> PrevisaoClimas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("Cidade");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cidade_estado");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<PrevisaoClima>(entity =>
            {
                entity.ToTable("PrevisaoClima");

                entity.Property(e => e.Clima)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DataPrevisao).HasColumnType("date");

                entity.Property(e => e.TemperaturaMaxima).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.TemperaturaMinima).HasColumnType("numeric(3, 1)");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.PrevisaoClimas)
                    .HasForeignKey(d => d.CidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_previsao_cidade");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
