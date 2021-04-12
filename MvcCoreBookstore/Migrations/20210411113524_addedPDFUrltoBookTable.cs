using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCoreBookstore.Migrations
{
    public partial class addedPDFUrltoBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PDFUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PDFUrl",
                table: "Books");
        }
    }
}
