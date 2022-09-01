using System.ComponentModel.DataAnnotations;

namespace ShoppingMallAssignmentMVC.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PanNumber { get; set; }
        [Required]
        public string? RoleName { get; set; }
        [Required]
        public string? Status { get; set; }

        public Boolean IsApproved { get; set; }
    }
}
