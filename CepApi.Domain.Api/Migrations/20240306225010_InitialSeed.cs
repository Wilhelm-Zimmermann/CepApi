using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CepApi.Domain.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("968e9479-45f8-48d1-bdfc-f66394b42790"), "adm@gmail.com", "Adm", "5AZZDLmHeaa7FdxCekPHiwOsZ0IW8+Fcdh7hpeJV8GeVNiPIs4i0RZ4T+XjXyEb0", "Administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("968e9479-45f8-48d1-bdfc-f66394b42790"));
        }
    }
}
