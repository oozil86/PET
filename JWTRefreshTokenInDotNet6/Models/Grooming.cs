﻿using System.ComponentModel;

namespace PET.Models
{
    public class Grooming
    {

        public int Id { get; set; }
        public int Nmber { get; set; }
        public string Details { get; set; }
        public DateTime AppointmentTime { get; set; }
        [DefaultValue(false)]
        public bool IsReserved { get; set; } = false;
        public string? time { get; set; }
        public string? price { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }

        public string? Address { get; set; }
        public string? Location { get; set; }

    }
}
