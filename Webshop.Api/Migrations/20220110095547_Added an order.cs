using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopApp.Migrations
{
    public partial class Addedanorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7538d3ba-90e5-49e1-947b-f18397b0fb6f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7dc7f26-1f98-4383-80d6-04cbd4df33a2", "3e7f0d35-b195-4537-ba7f-4eebe6627f47" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "3e7f0d35-b195-4537-ba7f-4eebe6627f47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7dc7f26-1f98-4383-80d6-04cbd4df33a2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e7f0d35-b195-4537-ba7f-4eebe6627f47");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2d64dad-efaa-47ce-b618-d1a70e83a6f1", "020c222c-8f1f-4a8b-9ebf-1c1d582b0d58", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a19567c6-2322-422d-84a9-dda824ebe07a", "30a97a05-7638-44fd-bfd8-6799bcafba17", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0", 0, "77574b49-1596-4dda-85ac-0e27762aac0b", "admin@admin.com", false, "Admin Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEFHYpwZPEarB/dxMxW7cpTTk3oLVTLIZAVHWGUFkmmr9eXbtvNrygcM2fTs/ox6+7A==", "031-84468", false, "f4712909-33b4-4dad-a698-3116ad50c3b9", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2d64dad-efaa-47ce-b618-d1a70e83a6f1", "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BillingAddress", "City", "Country", "DefaultShippingAddress", "ZipCode" },
                values: new object[] { "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0", null, "Göteborg", "Sweden", "Götgatan 9", "41105" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderAddress", "OrderDate", "OrderEmail", "OrderStatus", "ShippingAddress", "TotalPrice" },
                values: new object[] { 1, "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0", "Götgatan 9, 41105 Göteborg", new DateTime(2022, 1, 10, 10, 55, 46, 733, DateTimeKind.Local).AddTicks(436), "admin@admin.com", "Order placed", "Götgatan 9, 41105 Göteborg", 250.0 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Id", "Price", "Quantity" },
                values: new object[] { 1, 1, 1, 250.0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a19567c6-2322-422d-84a9-dda824ebe07a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2d64dad-efaa-47ce-b618-d1a70e83a6f1", "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0" });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2d64dad-efaa-47ce-b618-d1a70e83a6f1");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7dc7f26-1f98-4383-80d6-04cbd4df33a2", "3434eba6-80fe-4218-928f-3c301cea403c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7538d3ba-90e5-49e1-947b-f18397b0fb6f", "bfbdb3a0-c18c-4e8e-9e44-aaba123dcf8a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e7f0d35-b195-4537-ba7f-4eebe6627f47", 0, "88d07063-23c4-46f5-a454-ce6fbc2e0f6f", "admin@admin.com", false, "Admin Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEAC8T+0P5yQk7nuhlza71suDJiY/DKDo69rhwqx9Gvipy9NX0qaHgNyJRo9E/jnv+g==", "08-84468", false, "d9d342c1-586a-41a4-a16e-e319eacd2d93", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7dc7f26-1f98-4383-80d6-04cbd4df33a2", "3e7f0d35-b195-4537-ba7f-4eebe6627f47" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BillingAddress", "City", "Country", "DefaultShippingAddress", "ZipCode" },
                values: new object[] { "3e7f0d35-b195-4537-ba7f-4eebe6627f47", null, null, "Sweden", "Götgatan 8", null });
        }
    }
}
