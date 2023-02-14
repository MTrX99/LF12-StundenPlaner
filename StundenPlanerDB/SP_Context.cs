﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StundenPlanerDB.Models
{
    public partial class SP_Context : DbContext
    {
        public SP_Context()
        {
        }

        public SP_Context(DbContextOptions<SP_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Klasse> Klasse { get; set; }
        public virtual DbSet<Lehrer> Lehrer { get; set; }
        public virtual DbSet<Schulfach> Schulfach { get; set; }
        public virtual DbSet<Schüler> Schüler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klasse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lehrer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SchulfachId).HasColumnName("SchulfachID");

                entity.HasOne(d => d.Schulfach)
                    .WithMany(p => p.Lehrer)
                    .HasForeignKey(d => d.SchulfachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lehrer__Schulfac__4BAC3F29");
            });

            modelBuilder.Entity<Schulfach>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LehrerId).HasColumnName("LehrerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Raum)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.LehrerNavigation)
                    .WithMany(p => p.SchulfachNavigation)
                    .HasForeignKey(d => d.LehrerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schulfach__Lehre__4CA06362");
            });

            modelBuilder.Entity<Schüler>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.KlasseId).HasColumnName("KlasseID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Klasse)
                    .WithMany()
                    .HasForeignKey(d => d.KlasseId)
                    .HasConstraintName("FK__Schüler__KlasseI__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}