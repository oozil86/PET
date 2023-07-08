using Alzheimer.Models;
using GraduationProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PET.Models;

namespace JWTRefreshTokenInDotNet6.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Events> Events { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Grooming> Grooming { get; set; }
        public DbSet<SalesProduct> SalesProduct { get; set; }
        public DbSet<WishProduct> WishProduct { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

    }
}