using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Appartment { get; set; }
        public string? Phone { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
        public string? UserId { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
