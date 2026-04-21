using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class PesachTasksDbContext : DbContext
{
    public PesachTasksDbContext()
    {
    }

    public PesachTasksDbContext(DbContextOptions<PesachTasksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL-KITOTBB\\TICHNUT;Initial Catalog=Pesach_Tasks_DB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__People__AA2FFBE5733DCE83");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B1C8C971BB");

            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Header).HasMaxLength(50);

            entity.HasOne(d => d.ParentTask).WithMany(p => p.InverseParentTask)
                .HasForeignKey(d => d.ParentTaskId)
                .HasConstraintName("FK__Tasks__ParentTas__398D8EEE");

            entity.HasOne(d => d.Person).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Tasks__PersonId__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
