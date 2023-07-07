using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class userRe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('A709B397-8EEF-4BF5-9B9E-21307B178008'
           ,'Reciption'
           ,'Reciption'
           ,'Reciption')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
