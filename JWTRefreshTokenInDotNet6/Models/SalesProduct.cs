namespace PET.Models
{
    public class SalesProduct
    {


        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Qty { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; } = string.Empty;
        public Product? Product { get; set; }
        public int? ProductId { get; set; }
    }
}
