using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class insertCategory : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

Insert INTO Category
values('DOGS')
Go
Insert INTO Category
values('CATS')
              ");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
