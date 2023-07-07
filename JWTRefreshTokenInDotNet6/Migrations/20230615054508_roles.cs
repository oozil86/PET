using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"


INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('C35218F8-03A6-4BF9-B67F-E34E58CFCDEA'
           ,'Seller'
           ,'Seller'
           ,'Seller')
GO

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('EE0AA4F9-822B-49E7-97BE-DC77C3479439'
           ,'Vet'
           ,'Vet'
           ,'Vet')
GO

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('D0FF26B8-D93C-406A-BC44-9F640A9FA3C1'
           ,'Client'
           ,'Client'
           ,'Client')
GO


");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
