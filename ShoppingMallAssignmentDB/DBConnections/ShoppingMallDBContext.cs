using Microsoft.EntityFrameworkCore;
using ShoppingMallAssignmentDB.Models;

namespace ShoppingMallAssignmentDB.DBConnections
{
    public class ShoppingMallDBContext : DbContext
    {
        public DbSet<ShoppingMallModel> ShoppingMallModels { get; set; }
        public ShoppingMallDBContext()
        {

        }
        public ShoppingMallDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0LKSRK2;Initial Catalog=ShoppingMVC;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShoppingMallModel>(entity => entity.HasIndex(e => e.ShoppingMallName).IsUnique());
            builder.Entity<ShoppingMallModel>().Property(e => e.ShoppingMallCity).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Entity<ShoppingMallModel>().Property(e => e.ShoppingMallName).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Entity<ShoppingMallModel>().Property(e => e.ShoppingMallState).HasColumnType("VARCHAR").HasMaxLength(50);
        }
    }
}
