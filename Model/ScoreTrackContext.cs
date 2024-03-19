using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back.Model;

public partial class ScoreTrackContext : DbContext
{
    public ScoreTrackContext()
    {
    }

    public ScoreTrackContext(DbContextOptions<ScoreTrackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Collaborator> Collaborators { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<OccupationArea> OccupationAreas { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-000F4\\SQLEXPRESS;Initial Catalog=ScoreTrack;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__class__3213E83FC4F4F213");

            entity.ToTable("class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Collaborator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__collabor__3213E83F21903CA0");

            entity.ToTable("collaborator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPosition).HasColumnName("id_position");
            entity.Property(e => e.Identification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("identification");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Collaborators)
                .HasForeignKey(d => d.IdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__collabora__id_po__2C3393D0");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__feedback__3213E83F2E77B1C5");

            entity.ToTable("feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.IdClass).HasColumnName("id_class");
            entity.Property(e => e.IdCollaborator).HasColumnName("id_collaborator");
            entity.Property(e => e.IdSubjects).HasColumnName("id_subjects");

            entity.HasOne(d => d.IdClassNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__feedback__id_cla__33D4B598");

            entity.HasOne(d => d.IdCollaboratorNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdCollaborator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__feedback__id_col__34C8D9D1");

            entity.HasOne(d => d.IdSubjectsNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__feedback__id_sub__32E0915F");
        });

        modelBuilder.Entity<OccupationArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__occupati__3213E83FF1C8F0C4");

            entity.ToTable("occupation_area");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83F7CCDF70F");

            entity.ToTable("position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Positions)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__position__id_are__29572725");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.Positions)
                .HasForeignKey(d => d.IdSector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__position__id_sec__286302EC");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sector__3213E83F08E3DEC9");

            entity.ToTable("sector");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subjects__3213E83F46783B62");

            entity.ToTable("subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task__3213E83FFF96BDF1");

            entity.ToTable("task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ExpectedEndDate).HasColumnName("expected_end_date");
            entity.Property(e => e.IdCollaborator).HasColumnName("id_collaborator");
            entity.Property(e => e.RealEndDate).HasColumnName("real_end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdCollaboratorNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdCollaborator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__task__id_collabo__37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
