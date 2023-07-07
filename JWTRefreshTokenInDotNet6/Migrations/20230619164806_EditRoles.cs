using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class EditRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('7876B8D1-1722-44DD-8019-46F3187976D5'
           ,'EventPlanner'
           ,'EventPlanner'
           ,'EventPlanner')


GO
 delete AspNetRoles  where id='A709B397-8EEF-4BF5-9B9E-21307B178008'


"
);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
