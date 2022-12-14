using AvanadeInternalTraining.Entity;
using Microsoft.EntityFrameworkCore;

namespace AvanadeInternalTraining.Context
{
    public partial class AvanadeInternalTrainingContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AvanadeInternalTrainingContext()
        {
        }

        public AvanadeInternalTrainingContext(
            DbContextOptions<AvanadeInternalTrainingContext> options,
            IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<StudentEntity> Students { get; set; }

        public virtual DbSet<ClassEntity> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sql"));


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07DAEAC58A");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BirthDate).HasColumnType("datetime");
                entity.Property(e => e.Matriculation)
                    .HasMaxLength(40)
                    .IsUnicode(false);
                entity.Property(e => e.Document).IsUnicode(false);
            });

            modelBuilder.Entity<ClassEntity>(entity =>
            {
                entity.ToTable("Classes");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.InitialPeriod).HasColumnType("datetime");
                entity.Property(e => e.FinalPeriod).HasColumnType("datetime");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
