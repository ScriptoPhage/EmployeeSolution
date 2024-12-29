using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Seedrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc3ae509-f29c-499a-ae8c-653d779b0148", "16b96ec7-1fdc-4334-afe0-f68d7f2297c1", "Admin", "ADMIN" },
                    { "f1cb131d-1c83-4b5e-8765-2784f8c398a6", "7c559cfe-00e4-4b3c-b3e9-40d641d81039", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc3ae509-f29c-499a-ae8c-653d779b0148");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1cb131d-1c83-4b5e-8765-2784f8c398a6");
        }
    }
}
