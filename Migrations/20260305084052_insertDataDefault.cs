using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParcelDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class insertDataDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "role_id", "role_name" },
                values: new object[,]
                {
                    { 1, "SuperAdmin" },
                    { 2, "BranchAdmin" },
                    { 3, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "shipment_status",
                columns: new[] { "status_id", "Description", "status_name" },
                values: new object[,]
                {
                    { 1, "El envío ha sido creado.", "CREATED" },
                    { 2, "El envío está en camino.", "IN_TRANSIT" },
                    { 3, "El envío ha sido entregado.", "DELIVERED" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "name", "password", "phone", "role_id" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "admin@system.com", "Super Admin", "$2a$12$d3dwKQXdFPkVmOzY7mQ/k.PR/h7tqhZYqdpSLrBl0ydpJXRH2FJp.", "00000000", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "role_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "role_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "shipment_status",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "shipment_status",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "shipment_status",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "role_id",
                keyValue: 1);
        }
    }
}
