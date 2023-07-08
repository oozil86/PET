using System.ComponentModel.DataAnnotations.Schema;

namespace PET.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Qty { get; set; }
        public string Description { get; set; }
        public string? UserId { get; set; }

        public string? Photo { get; set; } = string.Empty;
        public SubCategory? SubCategory { get; set; }
        public int? SubCategoryId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
