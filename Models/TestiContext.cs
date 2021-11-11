using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiTieto.Models
{
    public partial class TestiContext : DbContext
    {
        public TestiContext()
        {
        }

        public TestiContext(DbContextOptions<TestiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Testi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.TeId);

                entity.ToTable("Quiz");

                entity.Property(e => e.TeId).HasColumnName("TeID");

                entity.Property(e => e.Aa).HasMaxLength(255);

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Bee).HasMaxLength(255);

                entity.Property(e => e.Cee).HasMaxLength(255);

                entity.Property(e => e.Dee).HasMaxLength(255);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TopicId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TopicID");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.TopId);

                entity.ToTable("Topic");

                entity.Property(e => e.TopId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TopName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TopText).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
