using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTo.Repository.Migrations
{
    public partial class conn_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DatabaseConnections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DatabaseConnections");
        }
    }
}
