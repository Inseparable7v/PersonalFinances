using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class PersonalFinancesDBContext : DbContext
    {
        public PersonalFinancesDBContext()
        {
        }

        public PersonalFinancesDBContext(DbContextOptions<PersonalFinancesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HA3KM96\\SQLEXPRESS;Database=PersonalFinancesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.HasKey(e => e.ExpretId);

                entity.ToTable("EXPERTS");

                entity.Property(e => e.ExpretId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("EXPRET_ID");

                entity.Property(e => e.ExpertLastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPERT_LASTNAME");

                entity.Property(e => e.ExpertName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPERT_NAME");

                entity.Property(e => e.ExpertSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPERT_SURNAME");

                entity.Property(e => e.ExpertType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXPERT_TYPE")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECTS");

                entity.HasIndex(e => e.ProjectName, "IDX_PROJECT_UQ")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.ProjectBegin)
                    .HasColumnType("date")
                    .HasColumnName("PROJECT_BEGIN");

                entity.Property(e => e.ProjectClient)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_CLIENT");

                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_DESCRIPTION");

                entity.Property(e => e.ProjectEnd)
                    .HasColumnType("date")
                    .HasColumnName("PROJECT_END");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_NAME");

                entity.Property(e => e.ProjectPayPerHour)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("PROJECT_PAY_PER_HOUR");

                entity.Property(e => e.ProjectStatus)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PROJECT_STATUS");

                entity.HasOne(d => d.ProjectStatusNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECTS_REFERENCE_PROJECT_");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.HasKey(e => e.PstatusId);

                entity.ToTable("PROJECT_STATUS");

                entity.HasIndex(e => e.PstatusName, "IDX_PROJECT_STATUS_UQ")
                    .IsUnique();

                entity.Property(e => e.PstatusId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PSTATUS_ID");

                entity.Property(e => e.PstatusName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PSTATUS_NAME");
            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.ToTable("PROJECT_TASKS");

                entity.HasIndex(e => new { e.ProjectId, e.TaskName }, "IDX_PROJECT_TASK")
                    .IsUnique();

                entity.Property(e => e.TaskId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("TASK_ID");

                entity.Property(e => e.ExpretId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("EXPRET_ID");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.TasDeliverables)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("TAS_DELIVERABLES");

                entity.Property(e => e.TaskBegin)
                    .HasColumnType("date")
                    .HasColumnName("TASK_BEGIN");

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("TASK_DESCRIPTION");

                entity.Property(e => e.TaskEnd)
                    .HasColumnType("date")
                    .HasColumnName("TASK_END");

                entity.Property(e => e.TaskHours)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("TASK_HOURS");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TASK_NAME");

                entity.Property(e => e.TaskPriority)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TASK_PRIORITY")
                    .IsFixedLength(true);

                entity.Property(e => e.TaskReady)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("TASK_READY");

                entity.Property(e => e.TaskStatus)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("TASK_STATUS");

                entity.HasOne(d => d.Expret)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.ExpretId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT__REFERENCE_EXPERTS");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT__REFERENCE_PROJECTS");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.TaskStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT__REFERENCE_TASK_STA");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("TASK_STATUS");

                entity.HasIndex(e => e.StatusName, "IDX_TASK_STATUS_UQ")
                    .IsUnique();

                entity.Property(e => e.StatusId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATUS_ID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
