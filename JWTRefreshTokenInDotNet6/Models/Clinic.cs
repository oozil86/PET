﻿namespace PET.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Phone { get; set; }    
        public string Address { get; set; }    
        public string Description { get; set; }    
        public string Location { get; set; }    
        public string Photo { get; set; }
        public string? UserId { get; set; }
    }
}
