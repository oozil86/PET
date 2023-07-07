namespace GraduationProject.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? time { get; set; }
        public string? UserId { get; set; }
        public int? IsWorkFlow { get; set; }
        public string? IDNumber { get; set; }
        public string? UserName { get; set; }

        public DateTime? EventDate { get; set; }
    }
}
