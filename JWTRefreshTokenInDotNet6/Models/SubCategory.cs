namespace PET.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
