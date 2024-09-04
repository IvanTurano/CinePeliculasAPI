using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationcsas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc60dd80-5d65-422b-b09d-6624c4c0af97", null, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d2692c8-ff0b-4284-8656-0c8b77ab6afd", 0, "357d1f24-6900-4aba-9f03-7cee6608a40a", "ivan@gmail.com", false, false, null, "ivan@gmail.com", "ivan@gmail.com", "AQAAAAIAAYagAAAAECTqiBqgw0kn3P6bMjTGwY+D+jP4XIQmxQYKgJunvbHU9V1K2CPQU2a9euJn0k4t8A==", null, false, "4f3736db-85c2-49cb-9b96-f1c2d202db3b", false, "ivan@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "6d2692c8-ff0b-4284-8656-0c8b77ab6afd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
