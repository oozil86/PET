using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alzheimer.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int Nmber { get; set; }
        public string Details { get; set; }
        public DateTime AppointmentTime { get; set; }
        //public bool IsReserved { get; set; }=false;
        [DefaultValue(false)]
        public bool IsReserved { get; set; } = false;
        [NotMapped]
        public int? Status { get; set; }
        public string? price { get; set; }
        public string? time { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
        public string? UserId { get; set; }
        public int? IsWorkFlow { get; set; } = 1;
        public string? ClientName { get; set; }




    }
}
