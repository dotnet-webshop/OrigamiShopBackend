using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webshop.Api.Migrations
{
    public partial class NewCustomerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b9208fb0-176e-4111-a45e-cab82d5dbac5", "a3ee37bf-343c-45e0-9890-6ef85ed2d0b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f244a16c-4af9-4f28-a616-e2baaece654c", "b66557b6-2acf-4772-b323-f5de601c90af" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9208fb0-176e-4111-a45e-cab82d5dbac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f244a16c-4af9-4f28-a616-e2baaece654c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3ee37bf-343c-45e0-9890-6ef85ed2d0b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b66557b6-2acf-4772-b323-f5de601c90af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e589e3b-ee5d-46db-8ef4-d1f45aed9da8", "7239dc70-f28e-4602-ab81-d4f3dc384e1e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8858cc18-22c5-481b-9eef-62ba4d5d9ca6", "cde8a1ff-59ff-4b34-98f7-da319499251a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BillingAddress", "City", "ConcurrencyStamp", "Country", "DefaultShippingAddress", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "6f07aed7-7884-4c4b-b3b4-3087dee01280", 0, null, "Göteborg", "b79cb77b-1762-4694-a798-1fbbebd824a8", "Sweden", "Götgatan 9", "Customer", "admin@admin.com", false, "Admin Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAELzVZxrt/cs0y4k8xV4vENEktIyWISj4YbVQEVY9zRFjfGK2G6ghm8DfIXDZFeTP0Q==", "031-84468", false, "8a63b36a-2c9d-4a9d-99d4-a3ecf3f2d607", false, "Admin", "41105" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BillingAddress", "City", "ConcurrencyStamp", "Country", "DefaultShippingAddress", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "38dc2e33-ee0b-4228-a69d-6ccccbb5cfa2", 0, null, "Göteborg", "e8727e7d-fa1c-491b-b565-4f6bb5f6886b", "Sweden", "Götgatan 9", "Customer", "user@user.com", false, "User Usersson", false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEDDa8LLoutIa785KA1kGSf0rjJQsqNZjQ1alQAL3f5Pg7Zbdt/W8+3lm3SJaL4WX9Q==", "031-84468", false, "4bc2471d-cc1c-4153-a8f9-a5898126a3a5", false, "User", "412105" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e589e3b-ee5d-46db-8ef4-d1f45aed9da8", "6f07aed7-7884-4c4b-b3b4-3087dee01280" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8858cc18-22c5-481b-9eef-62ba4d5d9ca6", "38dc2e33-ee0b-4228-a69d-6ccccbb5cfa2" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "OrderDate" },
                values: new object[] { "38dc2e33-ee0b-4228-a69d-6ccccbb5cfa2", new DateTime(2022, 1, 24, 9, 40, 6, 218, DateTimeKind.Local).AddTicks(5801) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8858cc18-22c5-481b-9eef-62ba4d5d9ca6", "38dc2e33-ee0b-4228-a69d-6ccccbb5cfa2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e589e3b-ee5d-46db-8ef4-d1f45aed9da8", "6f07aed7-7884-4c4b-b3b4-3087dee01280" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8858cc18-22c5-481b-9eef-62ba4d5d9ca6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e589e3b-ee5d-46db-8ef4-d1f45aed9da8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38dc2e33-ee0b-4228-a69d-6ccccbb5cfa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f07aed7-7884-4c4b-b3b4-3087dee01280");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f244a16c-4af9-4f28-a616-e2baaece654c", "bd434ccf-0ee7-42b1-a5ef-93ef7cdeb3ed", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9208fb0-176e-4111-a45e-cab82d5dbac5", "bdce19f5-ece2-417e-9b69-b97199b9287f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BillingAddress", "City", "ConcurrencyStamp", "Country", "DefaultShippingAddress", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "b66557b6-2acf-4772-b323-f5de601c90af", 0, null, "Göteborg", "5f1e7d99-2b4e-4abb-8150-e570d27e0a09", "Sweden", "Götgatan 9", "Customer", "admin@admin.com", false, "Admin Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEIsFQ7NH8cQscAEZzkMTaJEHemvVwxBWo8RkR23fyt+Fa4BBnJJoZfCLPuW6M4IdJw==", "031-84468", false, "30df9a8e-2f10-47b2-9038-7ca1408338d3", false, "Admin", "41105" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BillingAddress", "City", "ConcurrencyStamp", "Country", "DefaultShippingAddress", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "a3ee37bf-343c-45e0-9890-6ef85ed2d0b7", 0, null, "Göteborg", "5e4f9844-f7d4-4491-a9b7-45b9481ec6b0", "Sweden", "Götgatan 9", "Customer", "user@user.com", false, "User Usersson", false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEMkAVHYmTre8/aGxNmhb8kC/ze5WRuLGmhNJ6B63nOKKU7ATarHBI40s31a2J3oNBQ==", "031-84468", false, "f7848594-bf58-4bb8-81ca-6d74f4516799", false, "User", "412105" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f244a16c-4af9-4f28-a616-e2baaece654c", "b66557b6-2acf-4772-b323-f5de601c90af" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b9208fb0-176e-4111-a45e-cab82d5dbac5", "a3ee37bf-343c-45e0-9890-6ef85ed2d0b7" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "OrderDate" },
                values: new object[] { "a3ee37bf-343c-45e0-9890-6ef85ed2d0b7", new DateTime(2022, 1, 21, 16, 13, 41, 360, DateTimeKind.Local).AddTicks(5775) });
        }
    }
}
