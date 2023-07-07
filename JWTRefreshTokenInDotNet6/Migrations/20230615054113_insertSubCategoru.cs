using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class insertSubCategoru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
insert into SubCategory
values('accessories',1)
Go
insert into SubCategory
values('vitamens',1)
Go
insert into SubCategory
values('dry food ',1)
Go

insert into SubCategory
values('grooming',1)
Go
insert into SubCategory
values('toys',1)

go
insert into SubCategory
values('accessories',2)
Go
insert into SubCategory
values('vitamens',2)
Go
insert into SubCategory
values('dry food',2)
Go

insert into SubCategory
values('grooming',2)
Go
insert into SubCategory
values('toys',2)
");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
