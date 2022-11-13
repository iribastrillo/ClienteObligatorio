using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class pkroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RolesDeUsuarios_RolId",
                table: "RolesDeUsuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolesDeUsuarios",
                table: "RolesDeUsuarios",
                columns: new[] { "RolId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolesDeUsuarios",
                table: "RolesDeUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_RolesDeUsuarios_RolId",
                table: "RolesDeUsuarios",
                column: "RolId");
        }
    }
}
