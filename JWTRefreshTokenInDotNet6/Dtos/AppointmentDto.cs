namespace PET.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int Nmber { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsReserved { get; set; } = false;
        public string? price { get; set; }
        public string? time { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public string? ClientName { get; set; }
    }
}
