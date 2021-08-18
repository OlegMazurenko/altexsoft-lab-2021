using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceEF.Data.Migrations
{
    public partial class trigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER RenameCategory ON Categories AFTER INSERT AS UPDATE Categories SET Name = Name + 'category'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER RenameCategory");
        }
    }
}
