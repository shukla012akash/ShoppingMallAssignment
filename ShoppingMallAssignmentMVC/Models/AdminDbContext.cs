using Microsoft.EntityFrameworkCore;

namespace ShoppingMallAssignmentMVC.Models
{
    public class AdminDbContext : DbContext
    {
        public DbSet<AdminModel> AdminModels { get; set; }
        public AdminDbContext()
        {

        }
        public AdminDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0LKSRK2;Initial Catalog=ShoppingMVC;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AdminModel>(entity => entity.HasIndex(e => e.Email).IsUnique());
            builder.Entity<AdminModel>().Property(e => e.Email).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Entity<AdminModel>().Property(e => e.PanNumber).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<AdminModel>().Property(e => e.RoleName).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<AdminModel>().Property(e => e.Status).HasColumnType("VARCHAR").HasMaxLength(10);
        }
    }
}
