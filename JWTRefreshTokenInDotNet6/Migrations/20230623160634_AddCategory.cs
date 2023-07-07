using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Insert INTO Category
values('Shop')
Go
Insert INTO Category
values('Fish')
GO
Insert INTO Category
values('Bird')

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
