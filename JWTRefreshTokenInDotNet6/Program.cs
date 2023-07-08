using Alzheimer.Iservices;
using GraduationProject.Iservices;
using GraduationProject.Services;
using Hangfire;
using JWTRefreshTokenInDotNet6.Models;
using JWTRefreshTokenInDotNet6.Services;
using JWTRefreshTokenInDotNet6.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using PET.Iservices;
using PET.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEventsService, EventsService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IMailService, SendGridMailService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IGroomingService, GroomingService>();
builder.Services.AddScoped<IWishProductService, WishProductService>();
builder.Services.AddScoped<ISalesProductService, SalesProductService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//builder.Services.AddHangfire(x => x.UseSqlServerStorage("Data Source=.;Initial Catalog=PETDB;Integrated Security=True"));
//builder.Services.AddHangfireServer();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            //ClockSkew = TimeSpan.Zero
            ClockSkew = TimeSpan.FromMinutes(10)
        };
    });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy =  null;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
var x = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Resources", "Images"));
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine( Directory.GetCurrentDirectory(), Path.Combine("Resources", "Images"))),
    RequestPath = new PathString( "/Images")
});

////RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Minutely);
//RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), TimeSpan.FromMinutes(1));
//BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist!"), TimeSpan.FromSeconds(20));

app.UseHttpsRedirection();
//app.UseHangfireDashboard();
//RecurringJob.AddOrUpdate<EventsService>(x => x.GetEvents(), Cron.Minutely);

//app.MapHangfireDashboard();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
