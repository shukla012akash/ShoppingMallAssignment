using System.ComponentModel.DataAnnotations;

namespace ShoppingMallAssignmentMVC.Models
{
    public class ShoppingMallModelMVC
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? ShoppingMallName { get; set; }
        [Required]
        public string? ShoppingMallCity { get; set; }
        [Required]
        public string? ShoppingMallState { get; set; }
        [Required]
        public int YearBuilt { get; set; }
    }
}
