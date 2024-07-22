using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Entities
{
    public partial class MyPortaLiveContext : DbContext
    {
        public MyPortaLiveContext()
        {
        }

        public MyPortaLiveContext(DbContextOptions<MyPortaLiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<App> Apps { get; set; } = null!;
        public virtual DbSet<TechStackApp> TechStackApps { get; set; } = null!;
        public virtual DbSet<Technology> Technologies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MyPortaLive;TrustServerCertificate=True;Trusted_Connection=True;user=sa;password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>(entity =>
            {
                entity.ToTable("App", "MyPortafolio");

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.LiveLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.RepositoryLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TechStackApp>(entity =>
            {
                entity.ToTable("TechStackApp", "MyPortafolio");

                entity.Property(e => e.TechStackAppId).HasColumnName("TechStackAppID");

                entity.Property(e => e.AppId).HasColumnName("AppID");

                entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.TechStackApps)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_TechStackApp");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.TechStackApps)
                    .HasForeignKey(d => d.TechnologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnologyID_TechStackApp");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.ToTable("Technology", "MyPortafolio");

                entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
