using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class EditSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
insert into SubCategory
values('Dog',3)
go

insert into SubCategory
values('Bird',3)
go


insert into SubCategory
values('Fish',3)
go

insert into SubCategory
values('Cat',3)
go


insert into SubCategory
values('Accessories',4)
go
insert into SubCategory
values('Dry Food',4)
go

insert into SubCategory
values('Accessories',5)
go
insert into SubCategory
values('Dry Food',5)
go



");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
