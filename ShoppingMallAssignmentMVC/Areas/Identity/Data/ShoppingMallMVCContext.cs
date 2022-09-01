using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingMallAssignmentMVC.Areas.Identity.Data;
using ShoppingMallAssignmentMVC.Models;

namespace ShoppingMallAssignmentMVC.Data;

public class ShoppingMallMVCContext : IdentityDbContext<ShoppingMallUser>
{
   
    public ShoppingMallMVCContext(DbContextOptions<ShoppingMallMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    

}
