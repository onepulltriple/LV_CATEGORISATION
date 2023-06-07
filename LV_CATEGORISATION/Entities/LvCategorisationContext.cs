using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LV_CATEGORISATION.Entities;

public partial class LvCategorisationContext : DbContext
{
    public LvCategorisationContext()
    {
    }

    public LvCategorisationContext(DbContextOptions<LvCategorisationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=LV_CATEGORISATION; Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESULTS__3213E83F97979ADC");

            entity.ToTable("RESULTS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Beschreibung)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Einheiten)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Filter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Kurztext)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Langtext)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Lokale)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Menge).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Positionsnummer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Treffer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WeitereBemerkungen)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
