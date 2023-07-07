namespace PET.Models
{
    public class WishProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Qty { get; set; }
        public string? UserId { get; set; }
    }
}
