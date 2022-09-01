using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMallAssignmentMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ShoppingMallUser class
public class ShoppingMallUser : IdentityUser
{
    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
    public string? PanNumber { get; set; }
}

